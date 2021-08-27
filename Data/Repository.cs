﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace MvcTest.Data
{
  public class GenericRepository<T> where T : class
  {
    internal ApplicationDbContext _context;
    internal DbSet<T> dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
      this._context = context;
      this.dbSet = context.Set<T>();
    }

    public virtual IEnumerable<T> Get(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "")
    {
      IQueryable<T> query = dbSet;

      if (filter != null)
      {
        query = query.Where(filter);
      }

      foreach (var includeProperty in includeProperties.Split
          (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
      {
        query = query.Include(includeProperty);
      }

      if (orderBy != null)
      {
        return orderBy(query).ToList();
      }
      else
      {
        return query.ToList();
      }
    }

    public virtual T GetByID(object id)
    {
      return dbSet.Find(id);
    }

    public virtual void Insert(T entity)
    {
      dbSet.Add(entity);
    }

    public virtual void Delete(object id)
    {
      T entityToDelete = dbSet.Find(id);
      Delete(entityToDelete);
    }

    public virtual void Delete(T entityToDelete)
    {
      if (_context.Entry(entityToDelete).State == EntityState.Detached)
      {
        dbSet.Attach(entityToDelete);
      }
      dbSet.Remove(entityToDelete);
    }

    public virtual void Update(T entityToUpdate)
    {
      dbSet.Attach(entityToUpdate);
      _context.Entry(entityToUpdate).State = EntityState.Modified;
    }
  }
}