using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentsService.Data
{
    public class Order
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string TypeId { get; set; }
        public Types Type { get; set; }
        public string Discription { get; set; }
        public DateTime DateOnOrder { get; set; }
        public string Status { get; set; }
        public ICollection<Execute> Executes { get; set; }
    }
}
