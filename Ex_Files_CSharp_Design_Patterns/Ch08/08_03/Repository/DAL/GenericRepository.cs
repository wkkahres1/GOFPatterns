﻿using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

//Generic to minimize reduntant code

namespace Repository.DAL 
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        // Part 1 - Declared class variables for the context and for the entity set that the 
        // repository is instantiated for
        internal RepositoryContext context;        
        internal DbSet<TEntity> dbSet; //this is only on generic

        // Constructor - accept database context instance and initializes entity set variables
        public GenericRepository(RepositoryContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        // Part 2  Very different from real repository
        // uses lambda expressions to allow calling code to specify a filter conditon
        // and a column to order results by,
        // YOURS MAY BE DIFFERENT DEPENDING ON PROJECT
        //GET
        public virtual IEnumerable<TEntity> Get(
    Expression<Func<TEntity, bool>> filter = null,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
    string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

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

        // Part 3
        // GETBYID, INSERT, and UPDATE VERy similar to NON GENERIC but references depository
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        //Part 4 - provided two overloads for delete method
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
                
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }        
    }
}