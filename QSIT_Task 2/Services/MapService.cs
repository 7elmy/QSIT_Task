using Microsoft.EntityFrameworkCore;
using QSIT_Task_2.Contracts.Requests;
using QSIT_Task_2.Contracts.Responses;
using QSIT_Task_2.Interfaces;
using QSIT_Task_2.Models;
using System;
using System.Linq;

namespace QSIT_Task_2.Services
{
    public class MapService : IMapService
    {
        private readonly AppDbContext _dataContext;

        public MapService(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public MainResponse SaveMapConfigurations(SaveMapConfigurationsRequest requestModel)
        {
            var response = new MainResponse();
            try
            {
                var isMapSubTypeExists = _dataContext.MapTypes.Find(requestModel.MapSubTypeId) is not null;
                if (!isMapSubTypeExists)
                {
                    response.Error = "Map sub type is not found";
                    return response;
                }

                var model = MapToMapConfigurationModel(requestModel);

                //clear old data
                _dataContext.MapConfigurations.RemoveRange(_dataContext.MapConfigurations);

                _dataContext.MapConfigurations.Add(model);

                _dataContext.SaveChanges();

                response.IsSuccess = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                return response;
            }


        }

        private MapConfigurations MapToMapConfigurationModel(SaveMapConfigurationsRequest requestModel)
        {
            return new MapConfigurations()
            {
                ClusterRadius = requestModel.ClusterRadius,
                DuplicationEventLocationBuffer = requestModel.DuplicationEventLocationBuffer,
                DuplicationEventTimeBuffer = requestModel.DuplicationEventTimeBuffer,
                EndEventDuration = requestModel.EndEventDuration,
                GeoFencing = requestModel.GeoFencing,
                MapSubTypeId = requestModel.MapSubTypeId
            };
        }

        public MapTypesResponse GetParentMapTypes()
        {
            var parentMapTypes = _dataContext.MapTypes.Where(x => x.ParentId == null);

            var res = GenerateMapTypesResponse(parentMapTypes);

            return res;
        }

        public MapTypesResponse GetMapSubTypes(int parentId)
        {
            var mapSubTypes = _dataContext.MapTypes.Where(x => x.ParentId == parentId);

            var res = GenerateMapTypesResponse(mapSubTypes);

            return res;
        }

        private MapTypesResponse GenerateMapTypesResponse(IQueryable<MapType> mapTypes)
        {
            var mapTypesList = mapTypes.Select(x => new MapTypeResponse()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            var res = new MapTypesResponse()
            {
                MapTypes = mapTypesList
            };
            return res;
        }

        public MapConfigurationsResponse GetMapConfigurations()
        {
            var mapConfigurationsResponse = new MapConfigurationsResponse();
            var mapConfigurations = _dataContext.MapConfigurations.Include(x=>x.MapSubType).FirstOrDefault();
            if (mapConfigurations is not null)
                MapToMapConfigurationsResponse(mapConfigurationsResponse, mapConfigurations);
            return mapConfigurationsResponse;
        }

        private static void MapToMapConfigurationsResponse(MapConfigurationsResponse mapConfigurationsResponse, MapConfigurations mapConfigurations)
        {
            mapConfigurationsResponse.ClusterRadius = mapConfigurations.ClusterRadius;
            mapConfigurationsResponse.DuplicationEventLocationBuffer = mapConfigurations.DuplicationEventLocationBuffer;
            mapConfigurationsResponse.DuplicationEventTimeBuffer = mapConfigurations.DuplicationEventTimeBuffer;
            mapConfigurationsResponse.EndEventDuration = mapConfigurations.EndEventDuration;
            mapConfigurationsResponse.GeoFencing = mapConfigurations.GeoFencing;
            mapConfigurationsResponse.MapTypeId = mapConfigurations.MapSubType.ParentId ?? 0;
            mapConfigurationsResponse.MapSubTypeId = mapConfigurations.MapSubTypeId;
        }
    }
}
