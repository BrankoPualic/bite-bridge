using BiteBridge.Domain.Entities._Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiteBridge.Domain.Entities.Application;

public class Category
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    [ForeignKey(nameof(ParentId))]
    public virtual Category Parent { get; set; }

    [InverseProperty(nameof(Parent))]
    public virtual ICollection<Category> Children { get; set; } = [];
}