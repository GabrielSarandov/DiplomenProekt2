using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentsService.Models
{
    public class OrderVM
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string TypeId { get; set; }
        public List<SelectListItem> Type { get; set; } 
        public string Discription { get; set; }
        public DateTime DateOnOrder { get; set; }
        public string Status { get; set; }
    }
}
