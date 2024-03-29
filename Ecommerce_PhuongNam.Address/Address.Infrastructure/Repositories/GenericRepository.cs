﻿

using System.Collections;
using System.Linq.Expressions;
using Ecommerce_PhuongNam.Address.Address.Application.Common;
using Ecommerce_PhuongNam.Address.Address.Infrastructure.EntityEF;
using Ecommerce_PhuongNam.Common.Entities;
using Ecommerce_PhuongNam.Common.Exceptions;
using Ecommerce_PhuongNam.Common.Repositories.Interfaces;
using Ecommerce_PhuongNam.Common.Specifications;
using Ecommerce_PhuongNam.Common.Specifications.Interfaces;
using Ecommerce_PhuongNam.Common.Utils.Enums;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_PhuongNam.Address.Address.Infrastructure.Repositories;

public class GenericRepository<T, TId> : IGenericRepository<T, TId> where T : BaseEntity<TId>
{
    #region -- Properties --

    private readonly AddressDbContext _context;
    private readonly DbSet<T> _dbSet;
    #endregion -- Properties --

    public GenericRepository(AddressDbContext context)
    {
        this._context = context;
        this._dbSet = context.Set<T>();
    }

    public async Task<List<T>> ToList(ISpecification<T> specification)
    {
        try
        {
            List<T> listData = await ApplySpecification(specification).ToListAsync();
            // listData.ForEach(CheckStatus);
            return listData;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ExceptionDetail(AddressConstants.ERROR);
        }
    }

    public async Task<bool> Contains(ISpecification<T> specification = null)
    {
        return await Count(specification) > 0 ? true : false;
    }

    public async Task<bool> Contains(Expression<Func<T, bool>> predicate)
    {
        return await Count(predicate) > 0 ? true : false;
    }

    public async Task<int> Count(ISpecification<T> specification = null)
    {
        return await ApplySpecification(specification).CountAsync();
    }

    public async Task<int> Count(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).CountAsync();
    }

    public async Task<T> Get(ISpecification<T> specification, bool checkStatus = true)
    {
        try
        {
            var ob = await ApplySpecification(specification).FirstOrDefaultAsync();
            // ?? throw new NotFoundException(AppConstants.NOT_FOUND);
            
            if (ob != null)
                CheckStatus(ob, checkStatus: false);
            return ob;
        }
        // catch (LockedResource ex)
        // {
        //     throw new LockedResource(AddressConstants.LOCKED_RESOURCE);
        // }
        // catch (NotFoundException ex)
        // {
        //     Console.WriteLine(ex.ToString());
        //     throw new NotFoundException(AddressConstants.NOT_FOUND);
        // }
        // catch (StatusException e)
        // {
        //     Console.WriteLine(e.ToString());
        //     throw new StatusException(e.message);
        // }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new ExceptionDetail(AddressConstants.ERROR);
        }
    }

    public async Task<T> Update(T entity)
    {
        try
        {
            entity.DateUpdate = DateTime.Now;
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new ExceptionDetail(AddressConstants.ERROR);
        }
    }

    public async Task<T> Delete(T entity)
    {
        try
        {
            // entity.DateUpdate = DateTime.Now;
            // entity.UpdateBy = userId;
            _dbSet.Entry(entity).State = EntityState.Modified;
            // _dbSet.Entry(entity).Property(x => x.DateCreate).IsModified = false;
            // _dbSet.Entry(entity).Property(x => x.CreateBy).IsModified = false;
            
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new ExceptionDetail(AddressConstants.ERROR);
        }
    }

    public async Task<T> Create(T entity)
    {
        try
        {
            _dbSet.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new ExceptionDetail(AddressConstants.ERROR);
        }
    }

    public async Task<bool> ChangeStatus(object entity, int status, List<Dictionary<string, int>> listObjectNotChange = null)
    {
        try
        {
            listObjectNotChange ??= new List<Dictionary<string, int>>();
            await ChangeStatusImpl(entity, status, listObjectNotChange);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            throw;
        }
    }

    public async Task<bool> CheckIsExist(ISpecification<T> specification)
    {
        var ob = await ApplySpecification(specification).FirstOrDefaultAsync();
        if (ob == null)
            return false;
        return true;
    }

    public async Task<T> CreateOrUpdate(T entity)
    {
        try
        {
            _dbSet.Entry(entity).State = entity.Id != null ? EntityState.Modified : EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw new ExceptionDetail(AddressConstants.ERROR);
        }
    }

    public async Task<bool> DeleteHard(T entity)
    {
        try
        {
            _dbSet.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            throw new ExceptionDetail(AddressConstants.ERROR);
        }
    }

    #region -- Private Method --
    private IQueryable<T> ApplySpecification(ISpecification<T> specifications)
    {
        return SpecificationEvaluator<T, TId>.GetQuery(_dbSet.AsQueryable(), specifications, _dbSet);
    }

    private void CheckStatus(T data, bool checkStatus = true)
    {
        // if (data.Status == (int) EnumsApp.Delete)
        // {
        //     throw new StatusException(AppConstants.NOT_EXIST);
        // }
        //
        // if (checkStatus)
        // {
        //     if (data.Status == (int)EnumsApp.Waiting)
        //     {
        //         throw new StatusException(AppConstants.WAITING);
        //     }
        //
        //     else if (data.Status == (int)EnumsApp.Disable)
        //     {
        //         throw new StatusException(AppConstants.NOT_USED);
        //     }
        // }        
        
    }

    private async Task<bool> ChangeStatusImpl(object entity, int status, List<Dictionary<string, int>> checkedObject)
    {
        Dictionary<string, int> objectState = new Dictionary<string, int>
        {
            { entity.GetType().Name, (int)entity.GetType().GetProperty("Id").GetValue(entity) }
        };

        if (!checkedObject.Any(x => x.Keys.SequenceEqual(objectState.Keys) && (x.Values.SequenceEqual(new[] { 0 }) || x.Values.SequenceEqual(objectState.Values))))
        {
            checkedObject.Add(objectState);
        }

        foreach (var property in entity.GetType().GetProperties())
        {
            if (property.PropertyType.IsClass && property.GetValue(entity) != null && property.PropertyType != typeof(string))
            {
                if (property.PropertyType.IsGenericType)
                {
                    var genericType = property.PropertyType.GetGenericTypeDefinition();
                    if (genericType == typeof(List<>) || genericType == typeof(HashSet<>))
                    {
                        var collection = (IEnumerable)property.GetValue(entity);
                        foreach (var item in collection)
                        {
                            if (item != null && item.GetType().IsClass)
                            {
                                await ChangeStatusImpl(item, status, checkedObject);
                            }
                        }
                    }
                }
                else
                {
                    bool isContants = false;
                    foreach (var item in checkedObject)
                    {
                        if ((item.Values.Contains(0) ||
                             item.Values.Contains((int)property.GetValue(entity).GetType().GetProperty("Id").GetValue(entity))) && item.Keys.Contains(property.Name))
                        {
                            isContants = true;
                            break;
                        }
                    }

                    if (!isContants)
                    {
                        checkedObject.Add(
                        new Dictionary<string, int>
                        {
                            { property.Name, (int)property.GetValue(entity).GetType().GetProperty("Id").GetValue(entity) }
                        }); 
                        await ChangeStatusImpl(property.GetValue(entity), status, checkedObject);
                    }
                }
            }
            else
            {
                if (property.Name == "Status")
                {
                    property.SetValue(entity, status);
                }
                // else if (property.Name == "UpdateBy")
                // {
                //     property.SetValue(entity, userId);
                // }
                else if (property.Name == "DateUpdate")
                {
                    property.SetValue(entity, DateTime.Now);
                }
            }
        }

        // Only update modified entities
        _context.Entry(entity).State = EntityState.Modified;

        return true;
    }

    #endregion -- Private Method --
}