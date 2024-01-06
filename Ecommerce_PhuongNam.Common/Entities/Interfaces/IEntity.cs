namespace Ecommerce_PhuongNam.Common.Entities.Interfaces;

public interface IEntity : IAuditableEntity
{
    string Id { get; set; }
    DateTime DateCreate { get; set; }
    DateTime DateUpdate { get; set; }
    int Status { get; set; }
}