using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.Province;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Province;
using Ecommerce_PhuongNam.Common.Services;

namespace Ecommerce_PhuongNam.Address.Address.Application.Services.ProvinceService;

public interface IProvinceService : IService<ProvinceCreate, ProvinceUpdate, int, ProvinceResponse, object, object>
{
    
}