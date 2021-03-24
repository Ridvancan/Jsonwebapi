using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ShipAddress
    {
        public string street { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public object postalCode { get; set; }
        public string country { get; set; }
    }

    public class Detail
    {
        public int productId { get; set; }
        public double unitPrice { get; set; }
        public int quantity { get; set; }
        public double discount { get; set; }
    }

    public class Orders
    {
        public int id { get; set; }
        public string customerId { get; set; }
      
        public string orderDate { get; set; }
        public string requiredDate { get; set; }
        public string shippedDate { get; set; }
      
        public double freight { get; set; }
        public string shipName { get; set; }
        public ShipAddress address { get; set; }
        public List<Detail> details { get; set; }

       
    }
   


    }

