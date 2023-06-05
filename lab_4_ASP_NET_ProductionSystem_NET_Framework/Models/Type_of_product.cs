using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Models
{
    public class Type_of_product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым!")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Use_in> Used_in { get; set; }
    }
}