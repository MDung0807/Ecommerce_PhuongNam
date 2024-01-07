using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Province;

namespace Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Unit;

public class UnitResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<ProvinceResponse> Provinces { get; set; }
}