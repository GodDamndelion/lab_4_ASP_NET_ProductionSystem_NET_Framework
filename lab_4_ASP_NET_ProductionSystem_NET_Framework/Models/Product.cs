using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int Volume { get; set; }
        public int Type_Id { get; set; }
        public virtual Type_of_product Type_of_product { get; set; }
    }
}