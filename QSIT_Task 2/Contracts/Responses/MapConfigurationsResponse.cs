using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QSIT_Task_2.Contracts.Responses
{
    public class MapConfigurationsResponse
    {
        public double ClusterRadius { get; set; }
        public bool GeoFencing { get; set; }
        public double DuplicationEventTimeBuffer { get; set; }
        public double DuplicationEventLocationBuffer { get; set; }
        public double EndEventDuration { get; set; }
        public int MapTypeId { get; set; }
        public int MapSubTypeId { get; set; }
    }
}
