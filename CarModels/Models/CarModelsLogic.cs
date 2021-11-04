using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarModels.Models
{
    [Table("CarModels")]
    public class CarModelsLogic
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public string Released { get; set; }
        public string Country { get; set; }
        public string Color { get; set; }
    }
}
