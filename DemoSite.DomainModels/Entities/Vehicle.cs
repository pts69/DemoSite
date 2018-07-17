using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoSite.DomainModels.Entities
{
    [Table("Vehicles")]
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [StringLength(10)]
        public string RegistrationNo { get; set; }

    }
}
