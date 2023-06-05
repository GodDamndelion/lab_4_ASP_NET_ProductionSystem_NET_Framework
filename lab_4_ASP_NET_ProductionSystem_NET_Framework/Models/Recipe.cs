using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Use_in> Used_in { get; set; }
        public virtual ICollection<Production_machine> Production_machines { get; set; }
    }
}