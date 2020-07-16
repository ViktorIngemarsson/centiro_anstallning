using System;
using Microsoft.AspNetCore.Mvc;
using centiro_anstallning.Models;
using centiro_anstallning.Services;

namespace centiro_anstallning.Controllers
{
    [ApiController]
    [Route("orderapi")]
    public class OrderController : ControllerBase
    {
        [HttpGet("{id}")]
        public string GetTodoItem(string id)
        {
            try
            {
                Order OutputOrder = SerializingOrders.Ingoing(Int32.Parse(id));
                if (OutputOrder != null)
                {
                    return OutputOrder.PrettyPrint();
                }
                else
                {
                    return string.Format("The ordernumber {0} does not exist in the DB.", id);
                }
            }
            catch (FormatException e)
            {
                return string.Format("{0} Exception caught. \n The ordernumber should be a integer, possibly \"{1}\" is not.", e, id);
            }
            
        }

    }
}
