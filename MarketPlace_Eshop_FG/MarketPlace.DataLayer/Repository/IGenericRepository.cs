﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.DataLayer.Entities.Common;

namespace MarketPlace.DataLayer.Repository
{
    public interface IGenericRepository<TEntity> : IAsyncDisposable where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetQuery();
        Task AddEntity(TEntity entity);
        Task AddRangeEntities(List<TEntity> entities);
        Task<TEntity> GetEntityById(long entityId);
        void EditEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
        Task DeleteEntityBy(long entityId);
        void DeletePermanent(TEntity entity);
        void DeletePermanentEntities(List<TEntity> entities);
        Task SaveChanges();
    }
}
