using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.District;

namespace Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Province;

public class ProvinceResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<DistrictResponse> Districts { get; set; }
}