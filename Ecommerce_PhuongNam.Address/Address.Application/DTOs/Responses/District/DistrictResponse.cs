

using Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.Ward;

namespace Ecommerce_PhuongNam.Address.Address.Application.DTOs.Responses.District;

public class DistrictResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<WardResponse> Wards { get; set; }
}