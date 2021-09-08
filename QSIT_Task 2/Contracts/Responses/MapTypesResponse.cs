using System.Collections.Generic;

namespace QSIT_Task_2.Contracts.Responses
{
    public class MapTypesResponse
    {
        public MapTypesResponse()
        {
            MapTypes = new List<MapTypeResponse>();
        }
        public List<MapTypeResponse> MapTypes { get; set; }
    }

    public class MapTypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
