using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{


    public class CustAddress
    {

        public string street { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public object postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }

    }

    public class Customers
    {
        public string id { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string contactTitle { get; set; }
        public CustAddress address { get; set; }

        //public string street
        //{
        //    get
        //    { return address.street;}
        //    set
        //    {address.street = value;}
        //}
        //    public string city
        //{
        //    get
        //    { return address.city; }
        //    set
        //    {address.city = value; }
        //}
        //public string region
        //{
        //    get
        //    {
        //        if (address.region.Equals("NULL"))
        //        {
        //            return "Empty";
        //        }
        //        return address.region;
        //    }
        //    set
        //    {
        //        address.region = value;
        //    }
        //}
        //public string country
        //{
        //    get
        //    {return address.country; }
        //    set
        //    {address.country = value;}
        //}

        //    public string phone
        //{
        //    get
        //    {return address.phone;}
        //    set
        //    {address.phone = value;}
        //}
    }
    }

