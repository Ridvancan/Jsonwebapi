using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Address
    {

        public string street { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public object postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
       
    }

    public class Employess
    {
        public int id { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }

        public string title { get; set; }
        public string titleOfCourtesy { get; set; }
        public string birthDate { get; set; }
        public string hireDate { get; set; }
        public Address address { get; set; }
        public string notes { get; set; }
        public object reportsTo { get; set; }
        public List<int> territoryIds { get; set; }

        
        
        
            

        //    public string street
        //    {
        //        get
        //        { return address.street; }
        //        set
        //        { address.street = value; }
        //    }
        //    public string city
        //    {
        //        get
        //        { return address.city; }
        //        set
        //        { address.city = value; }
        //    }
        //    public string region
        //    {
        //        get
        //        {
        //            if (address.region.Equals("NULL"))
        //            {
        //                return "Empty";
        //            }
        //            return address.region;
        //        }
        //        set
        //        {
        //            address.region = value;
        //        }
        //    }
        //    public string country
        //    {
        //        get
        //        { return address.country; }
        //        set
        //        { address.country = value; }
        //    }

        //    public string phone
        //    {
        //        get
        //        { return address.phone; }
        //        set
        //        { address.phone = value; }
        //    }
        //}

    }

}
