using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSite.Model.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        [StringLength(250)]
        [Column(TypeName = "varchar")]
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        [StringLength(250)]
        [Column(TypeName = "varchar")]
        public string UpdatedBy { get; set; }
    }
}
