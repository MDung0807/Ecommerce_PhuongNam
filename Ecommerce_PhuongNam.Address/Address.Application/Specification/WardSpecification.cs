using Ecommerce_PhuongNam.Address.Address.Domain.Entities;
using Ecommerce_PhuongNam.Common.Specifications;

namespace Ecommerce_PhuongNam.Address.Address.Application.Specification;

public sealed class WardSpecification : BaseSpecification<Ward>
{
    public WardSpecification(int id) : base(x => x.Id.Equals(id))
    {
        AddInclude(x => x.District);
        AddInclude(x => x.AdministrativeUnit);
        AddInclude(x => x.District.Province);
        AddInclude(x => x.District.Province.AdministrativeRegion);
    }
}