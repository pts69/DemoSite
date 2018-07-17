using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoSite.Model.Entities
{
    [Table("Vehicles")]
    public class Vehicle : BaseEntity
    {
        [Key]
        public int VehicleId { get; set; }

        [StringLength(10)]
        public string RegistrationNo { get; set; }

    }
}
