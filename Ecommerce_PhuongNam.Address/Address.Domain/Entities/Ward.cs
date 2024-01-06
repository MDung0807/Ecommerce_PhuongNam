﻿using Ecommerce_PhuongNam.Common.Entities;

namespace Ecommerce_PhuongNam.Address.Address.Domain.Entities;

public class Ward : BaseEntity
{
    #region -- Properties --

    public string FullName { get; set; }
    public string FullNameEnglish { get; set; }
    public string CodeName { get; set; }
    public string Name { get; set; }
    public string NameEnglish { get; set; }

    #endregion -- Properties --

    #region -- Relationship --
    public District District { get; set; }
    public AdministrativeUnit AdministrativeUnit { get; set; }
    #endregion -- Relationship --
}