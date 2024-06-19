using BiteBridge.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;

namespace BiteBridge.Persistence.Contexts;

public partial class ApplicationContext
{
    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
}