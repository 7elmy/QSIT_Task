using QSIT_Task_2.Contracts.Requests;
using QSIT_Task_2.Contracts.Responses;

namespace QSIT_Task_2.Interfaces
{
    public interface IMapService
    {
        MainResponse SaveMapConfigurations(SaveMapConfigurationsRequest requestModel);
        MapTypesResponse GetParentMapTypes();
        MapTypesResponse GetMapSubTypes(int parentId);
        MapConfigurationsResponse GetMapConfigurations();
    }
}
