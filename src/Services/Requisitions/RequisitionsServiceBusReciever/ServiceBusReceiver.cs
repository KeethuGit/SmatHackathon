using System;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Requisitions.BusinessLogic.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Requisitions.BusinessLogic.Repositories;
using Requisitions.BusinessLogic.Data;

namespace RequisitionsServiceBusReciever
{
    internal class ServiceBusReceiver
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var client = new ServiceBusClient("Endpoint=sb://smartmaterialsdigital.servicebus.windows.net/;SharedAccessKeyName=test-b-sender;SharedAccessKey=sj7yVQHKYGHGB1Q3ju9DnVilPsZcoaqNvcGwIeM0QrI=;EntityPath=bom");
            var receiver = client.CreateReceiver("bom", "req-listner");
            var msg =   receiver.ReceiveMessageAsync().Result;
            if (msg != null)
            {
                Console.WriteLine("Message received : " + msg.Body);
                var json = JObject.Parse(msg.Body.ToString());
                var positions = json["data"].SelectToken("positions");
                List<LineItem> lineItems = new List<LineItem>();
                int count = 1;
                foreach (var pos in positions)
                {                    
                    LineItem line = new LineItem();
                    line.Position = count;
                    line.SubPosition = 1;
                    line.ItemType = (string) pos["ItemType"];
                    line.ReleasedQty = (decimal)pos["Quantity"];
                    line.CommodityCode = (string)pos["CommodityCode"];
                    line.ReleaseQtyUnit = (string)pos["QuantityUnit"];
                    line.IdentCode = (string)pos["IdentCode"];
                    line.Currency = "INR";
                    lineItems.Add(line);
                    count++;
                }

                Requisition requisition = new Requisition()
                {
                    RequisitionName = "AUTOMATED_BOMREQ",
                    RequisitionType = "ORDER",
                    PurchaseIndicator = "YES",
                    ReqNodePath = "REQ/NODE/BOM",
                    Origin = "HOME",
                    ReqStatusCode = "OPEN",
                    Supplement = 0,
                    Originator = "NIKHILK",
                    Currency = "INR",
                    CreatedDate = DateTime.Now,
                    LineItems = lineItems

                };

                RequisitionRepository requisitionrRepo = new RequisitionRepository(new RequisitionContext());
                requisitionrRepo.CreateReq(requisition);
                receiver.CompleteMessageAsync(msg);
            }
            else
            {
                Console.WriteLine("No Message received");
            }
        
        }
    }
}
