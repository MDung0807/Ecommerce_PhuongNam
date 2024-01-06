﻿using System.Collections;
using Ecommerce_PhuongNam.Address.Address.Infrastructure.EntityEF;
using Ecommerce_PhuongNam.Address.Address.Infrastructure.Repositories;
using Ecommerce_PhuongNam.Common.Entities;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace BusBookTicket.Core.Infrastructure;

public class UnitOfWork : IUnitOfWork, IAsyncDisposable
{
    private readonly AppDbContext _context;
    private IDbContextTransaction _transaction;
    private Hashtable _repositories;
    

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public async Task SaveChangesAsync()
    {
        await _transaction.CommitAsync();
    }

    public async Task BeginTransaction()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _transaction.RollbackAsync();
        await DisposeAsync();
    }

    public IGenericRepository<T> GenericRepository<T>() where T : BaseEntity
    {
        if (_repositories == null)
            _repositories = new Hashtable();
 
        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);

            var repositoryInstance =
                Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

            _repositories.Add(type, repositoryInstance);
        }

        return (IGenericRepository<T>)_repositories[type];
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        _transaction.Dispose();
    }
}


