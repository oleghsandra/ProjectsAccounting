﻿using System;
using System.Data.Entity;

namespace ProjectsAccounting.DAL.Repositories
{
    public class RepositoryBase<T> : IDisposable where T : DbContext, new()
    {
        public RepositoryBase()
        {
            this.Context = new T();
        }

        public T Context { get; private set; }

        public void Save()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        /// <summary>
        /// Override dispose method
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
