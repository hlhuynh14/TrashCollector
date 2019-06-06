using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int zipcode { get; set; }
        public double? balance { get; set; }
        public string pickUpDay { get; set; }
        public DateTime? oneTimePickUp { get; set; }
        public DateTime? suspendedStart { get; set; }
        public DateTime? supspendEnd { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }



    }
}