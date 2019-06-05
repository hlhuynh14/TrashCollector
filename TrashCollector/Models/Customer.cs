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
        int id { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string email { get; set; }
        string address { get; set; }
        int zipcode { get; set; }
        int balance;
        string pickUpDay;
        DateTime oneTimePickUp;
        DateTime suspendedStart;
        DateTime supspendEnd;
        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }



    }
}