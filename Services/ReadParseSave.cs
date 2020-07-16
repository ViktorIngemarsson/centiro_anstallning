using System;
using centiro_anstallning.Models;
using System.IO;
using System.Xml.Serialization;

namespace centiro_anstallning.Services
{
    public class ReadParseSave
    {
        public static void DeserializeSerialize()
        {
            AllOrders AllOrders = ReadTxtFiles("Ingoing");
            DeserializeObject(AllOrders, Environment.CurrentDirectory + "/Db/saved_orders.xml");

        }

        private static AllOrders ReadTxtFiles(string FolderName)
        {
            string FullPath = Environment.CurrentDirectory + "/" + FolderName + "/";
            string[] AllFileNames = Directory.GetFiles(@FullPath);
            
            AllOrders AllOrders = new AllOrders();
            for (int i = 0; i < AllFileNames.Length; i++)
            {
                AllOrders.AddOrder(ReadTxtFile(AllFileNames[i]));
            }
            return AllOrders;
        }

        private static Order ReadTxtFile(string fileName)
        {
            string[] lines = File.ReadAllLines(@fileName);
            Order OutputOrder = new Order();
            for (int i = 1; i < lines.Length; i++)
            {
                OutputOrder.AddOrderLine(ParseOrderLine(lines[i]));
            }
            OutputOrder.OrderNumber = OutputOrder.OrderLines[0].OrderNumber;
            return OutputOrder;

        }

        private static OrderLine ParseOrderLine(string orderline)
        {
            var VectorOfInfo = orderline.Split('|');
            OrderLine output = new OrderLine
            {
                OrderNumber = Int32.Parse(VectorOfInfo[1]),
                OrderLineN = Int32.Parse(VectorOfInfo[2]),
                ProductNumber = VectorOfInfo[3],
                Quantity = Int32.Parse(VectorOfInfo[4]),
                Name = VectorOfInfo[5],
                Description = VectorOfInfo[6],
                Price = Double.Parse(VectorOfInfo[7]),
                ProductGroup = VectorOfInfo[8],
                OrderDate = DateTime.Parse(VectorOfInfo[9]),
                CustomerName = VectorOfInfo[10],
                CustomerNumber = Int32.Parse(VectorOfInfo[11])
            };
            return output;
        }

        private static void DeserializeObject(AllOrders incoming, string SavePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(incoming.GetType());
            using StreamWriter writer = new StreamWriter(@SavePath);
            xmlSerializer.Serialize(writer, incoming);
        }
    }
}
