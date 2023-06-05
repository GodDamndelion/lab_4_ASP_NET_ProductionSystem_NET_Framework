using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Models
{
    public class Production_machine
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Recipe_Id { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}