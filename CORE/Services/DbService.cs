using CORE.Domain;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace CORE.Services

{
    public abstarct class DbService<TEntity> : Service, IDisposable where TEntity : Record, new():
    {
        
    }
}