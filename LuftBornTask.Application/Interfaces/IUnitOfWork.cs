using LuftBornTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
