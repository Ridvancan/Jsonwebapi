using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{

    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public string quantityPerUnit { get; set; }
        public double unitPrice { get; set; }
        public int unitsInStock { get; set; }
        public int unitsOnOrder { get; set; }
        public int reorderLevel { get; set; }
        public bool discontinued { get; set; }
        public int supplierId { get; set; }
        public int categoryId { get; set; }
    }
}
