using System.ComponentModel.DataAnnotations.Schema;

namespace QSIT_Task_2.Models
{
    public class MapConfigurations
    {
        public int Id { get; set; }
        public double ClusterRadius { get; set; }
        public bool GeoFencing { get; set; }
        public double DuplicationEventTimeBuffer { get; set; }
        public double DuplicationEventLocationBuffer { get; set; }
        public double EndEventDuration { get; set; }
        public int MapSubTypeId { get; set; }

        [ForeignKey(nameof(MapSubTypeId))]
        public virtual MapType MapSubType { get; set; }
    }
}
