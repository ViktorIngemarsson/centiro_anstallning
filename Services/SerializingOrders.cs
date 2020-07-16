using System;
using centiro_anstallning.Models;
using System.Xml.Serialization;
using System.IO;

namespace centiro_anstallning.Services
{
    public class SerializingOrders
    {

        public static Order Ingoing(int OrderNumberToFind)
        {
            AllOrders AllOrders = SerializeOutputOrder();
            Order OutputOrder = FindOrder(AllOrders, OrderNumberToFind);
            return OutputOrder;
        }

        private static AllOrders SerializeOutputOrder()
        {
            string filepath = Environment.CurrentDirectory + "/Db/saved_orders.xml";
            XmlSerializer ser = new XmlSerializer(typeof(AllOrders));
            using (StreamReader sr = new StreamReader(@filepath))
            {
                return (AllOrders)ser.Deserialize(sr);
            }
        }

        private static Order FindOrder(AllOrders InputOrders, int OrderNumberToFind)
        {
            for(int i = 0; i < InputOrders.NumberOrders(); i++)
            {
                if(InputOrders.Orders[i].OrderNumber == OrderNumberToFind)
                {
                    return InputOrders.Orders[i];
                }
            }
            return null;
        }
    }
}
