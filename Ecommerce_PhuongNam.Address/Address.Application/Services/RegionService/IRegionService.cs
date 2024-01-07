using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.Region;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Region;
using Ecommerce_PhuongNam.Common.Services;

namespace BusBookTicket.AddressManagement.Services.RegionService;

public interface IRegionService : IService<RegionCreate, RegionUpdate, int, RegionResponse, object, object>
{
    
}