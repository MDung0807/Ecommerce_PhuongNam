using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.Unit;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Unit;
using Ecommerce_PhuongNam.Common.Services;

namespace BusBookTicket.AddressManagement.Services.UnitService;

public interface IUnitService : IService<UnitCreate, UnitUpdate, int, UnitResponse, object, object>
{
    
}