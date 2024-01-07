using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Requests.Ward;
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Ward;
using Ecommerce_PhuongNam.Address.Address.Domain.Entities;
using Ecommerce_PhuongNam.Common.Services;

namespace Ecommerce_PhuongNam.Address.Address.Application.Services.WardService;

public interface IWardService : IService<WardCreate, WardUpdate, int, WardResponse, object, object>
{
    Task<Ward> WardGet(int id);
}