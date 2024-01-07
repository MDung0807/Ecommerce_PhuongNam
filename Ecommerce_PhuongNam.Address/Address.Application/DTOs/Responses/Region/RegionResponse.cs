
using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Province;

namespace Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Region;

public class RegionResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ProvinceResponse> Provinces { get; set; }
}