using Ecommerce_PhuongNam.Address.Address.Domain.Entities;
using Ecommerce_PhuongNam.Common.Specifications;

namespace Ecommerce_PhuongNam.Address.Address.Application.Specification;

public sealed class ProvinceSpecification : BaseSpecification<Province>
{
    public ProvinceSpecification(int id) : base(x => x.Id.Equals(id))
    {
        AddInclude(x => x.Districts);
        AddInclude(x => x.AdministrativeUnit);
        AddInclude(x => x.AdministrativeRegion);
    }
    
    public ProvinceSpecification() : base()
    {
        AddInclude(x => x.AdministrativeUnit);
        AddInclude(x => x.AdministrativeRegion);
    }
}