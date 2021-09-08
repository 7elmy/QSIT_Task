using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QSIT_Task_2.Models
{
    public class MapType
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual MapType ParentMapType { get; set; }
        public virtual ICollection<MapType> MapSubTyps { get; set; }

        [InverseProperty("MapSubType")]
        public virtual MapConfigurations MapConfigurations { get; set; }


    }
}
