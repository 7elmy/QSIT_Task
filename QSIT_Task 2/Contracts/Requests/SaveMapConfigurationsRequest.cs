using System;
using System.ComponentModel.DataAnnotations;

namespace QSIT_Task_2.Contracts.Requests
{
    public class SaveMapConfigurationsRequest
    {

        [Range(0.01, 99)]
        [RegularExpression(@"^[0-9]{1,11}(?:\.[0-9]{1,3})?$")]
        public double ClusterRadius { get; set; }
        public bool GeoFencing { get; set; }
        [RegularExpression(@"^[0-9]{1,11}(?:\.[0-9]{1,3})?$")]
        public double DuplicationEventTimeBuffer { get; set; }
        [RegularExpression(@"^[0-9]{1,11}(?:\.[0-9]{1,3})?$")]
        public double DuplicationEventLocationBuffer { get; set; }
        [RegularExpression(@"^[0-9]{1,11}(?:\.[0-9]{1,3})?$")]
        public double EndEventDuration { get; set; }
        public int MapSubTypeId { get; set; }
    }
}
