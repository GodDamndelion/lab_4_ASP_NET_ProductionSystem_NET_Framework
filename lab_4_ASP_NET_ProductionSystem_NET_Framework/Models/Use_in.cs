using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Models
{
    public class Use_in
    {
        //[Key]
        //[Column(Order=1)]
        [Key]
        public int Id { get; set; }
        public int Type_of_product_Id { get; set; }
        public virtual Type_of_product Type_of_product { get; set; }
        public int Quantity { get; set; }
        public bool Is_output { get; set; }
        //[Key]
        //[Column(Order = 2)]
        public int Recipe_Id { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}