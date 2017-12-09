using System;
using System.Data;

namespace WebAPI.DataAccess.Infrastructure
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
