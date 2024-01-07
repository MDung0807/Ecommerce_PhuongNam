using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam.Address.Address.Domain.Entities;

public class AdministrativeRegion : BaseEntity<int>
{
    #region -- Properties --

    public string Name { get; set; }
    public string NameEnglish { get; set; }
    public string CodeName { get; set; }
    public string CodeNameEnglish { get; set; }

    #endregion -- Properties --

    #region -- Relationship --

    public HashSet<Province> Provinces { get; set; }

    #endregion -- Relationship --
}