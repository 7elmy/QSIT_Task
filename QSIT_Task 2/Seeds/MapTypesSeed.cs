using QSIT_Task_2.Models;
using System.Collections.Generic;
using System.Linq;

namespace QSIT_Task_2.Seeds
{
    public static class MapTypesSeed
    {
        public static void Seed(AppDbContext dataContext)
        {
            var types = dataContext.MapTypes.ToList();
            if (!types.Any())
            {
                var mapTypes = InitializeObjects();

                dataContext.AddRange(mapTypes);

                dataContext.SaveChanges();
            }
        }

        private static List<MapType> InitializeObjects()
        {
            var mapTypes = new List<MapType>();

            var FeaturesType = new MapType()
            {
                Name = "Features",
                MapSubTyps = new List<MapType>()
                {
                    new MapType()
                    {
                        Name="Dynamic"
                    },
                     new MapType()
                    {
                        Name="Cached"
                    }
                }
            };

            var BasemapType = new MapType()
            {
                Name = "Basemap",
                MapSubTyps = new List<MapType>()
                {
                    new MapType()
                    {
                        Name="Imagery"
                    },
                     new MapType()
                    {
                        Name="Topographic"
                    }
                }
            };

            mapTypes.Add(FeaturesType);
            mapTypes.Add(BasemapType);

            return mapTypes;

        }
    }
}
