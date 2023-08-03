﻿
using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static NHibernate.Engine.Query.CallableParser;

namespace Dyno.Platform.ReferentialData.Nhibernate
{
    public class MapperSession<T> : IMapperSession<T> where T : class
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public MapperSession(ISession session)
        {
            _session = session;
        }
        public IQueryable<T> Entity => _session.Query<T>();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

       public void Add(T entity)
        {
            _session.Save(entity);
            _session.Flush();
        }

        public void Delete(T entity)
        {
           _session.Delete(entity);
            _session.Flush();
        }

        public T GetById(int id)
        {
            T entity=_session.Load<T>(id);
            return entity;
        }

        public T GetByExpression(Expression<Func<T, bool>> expression)
        {
            T entity = _session.Query<T>().FirstOrDefault<T>();
            return entity;
        }

        public List<T> GetAllByExpression(Expression<Func<T, bool>> expression)
        {
            List<T> entities = _session.Query<T>().Where<T>(expression).ToList<T>();
            return entities;
        }

        public void Update(T entity)
        {
              _session.Update(entity);
            _session.Flush();
        }

        public IList<T> GetAll()
        {
            ICriteria criteria = _session.CreateCriteria(typeof(T));
            return criteria.List<T>();
        }
    }
       
}
