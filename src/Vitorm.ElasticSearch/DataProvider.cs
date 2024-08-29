﻿using System.Collections.Generic;
using System.Linq;

using Vitorm.DataProvider;

namespace Vitorm.ElasticSearch
{
    public partial class DataProvider : IDataProvider
    {
        Vitorm.DbContext IDataProvider.CreateDbContext() => this.CreateDbContext();

        protected Dictionary<string, object> config;
        protected DbConfig dbConfig;
        public DbContext CreateDbContext() => new Vitorm.ElasticSearch.DbContext(dbConfig);

        public void Init(Dictionary<string, object> config)
        {
            this.config = config;
            this.dbConfig = new(config);
        }


        // #0 Schema :  Create
        public virtual void TryCreateTable<Entity>() => CreateDbContext().TryCreateTable<Entity>();
        public virtual void TryDropTable<Entity>() => CreateDbContext().TryDropTable<Entity>();
        public virtual void Truncate<Entity>() => CreateDbContext().Truncate<Entity>();


        // #1 Create :  Add AddRange
        public virtual Entity Add<Entity>(Entity entity) => CreateDbContext().Add<Entity>(entity);
        public virtual void AddRange<Entity>(IEnumerable<Entity> entities) => CreateDbContext().AddRange<Entity>(entities);

        // #2 Retrieve : Get Query
        public virtual Entity Get<Entity>(object keyValue) => CreateDbContext().Get<Entity>(keyValue);
        public virtual IQueryable<Entity> Query<Entity>() => CreateDbContext().Query<Entity>();


        // #3 Update: Update UpdateRange
        public virtual int Update<Entity>(Entity entity) => CreateDbContext().Update<Entity>(entity);
        public virtual int UpdateRange<Entity>(IEnumerable<Entity> entities) => CreateDbContext().UpdateRange<Entity>(entities);


        // #4 Delete : Delete DeleteRange DeleteByKey DeleteByKeys
        public virtual int Delete<Entity>(Entity entity) => CreateDbContext().Delete<Entity>(entity);
        public virtual int DeleteRange<Entity>(IEnumerable<Entity> entities) => CreateDbContext().DeleteRange<Entity>(entities);

        public virtual int DeleteByKey<Entity>(object keyValue) => CreateDbContext().DeleteByKey<Entity>(keyValue);
        public virtual int DeleteByKeys<Entity, Key>(IEnumerable<Key> keys) => CreateDbContext().DeleteByKeys<Entity, Key>(keys);

    }
}
