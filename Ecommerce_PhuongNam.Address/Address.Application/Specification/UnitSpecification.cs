﻿
using Ecommerce_PhuongNam.Address.Address.Domain.Entities;
using Ecommerce_PhuongNam.Common.Specifications;

namespace Ecommerce_PhuongNam.Address.Address.Application.Specification;

public sealed class UnitSpecification : BaseSpecification<AdministrativeUnit>
{
    public UnitSpecification(int id) : base(x => x.Id.Equals(id))
    {
        AddInclude(x => x.Provinces);
    }

    public UnitSpecification()
    {
        
    }
}