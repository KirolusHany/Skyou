using System;
using KikoStore.Core.Entities;
using KikoStore.Core.Interfaces;

namespace Company.ClassLibrary1;

public interface IUnitOfWork:IDisposable
{
  IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task<bool> Complete();
}
