using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentsService.Models
{
    public class ExecuteVM
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public List<SelectListItem> Order { get; set; }
        public string EmployeeId { get; set; }
        public List<SelectListItem>  Employee { get; set; }
        public string Discription { get; set; }
        public string Warrantly { get; set; }
        public string StatusOfOrder { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
    }
}
