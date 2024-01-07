using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.District;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.District;
using Ecommerce_PhuongNam.Common.Paging;
using Ecommerce_PhuongNam.Common.Services;

namespace Ecommerce_PhuongNam.Address.Address.Application.Services.DistrictService;

public interface IDistrictService : IService<DistrictCreate, DistrictUpdate, int, DistrictResponse, PagingRequest, PagingResult<DistrictResponse>>
{
}