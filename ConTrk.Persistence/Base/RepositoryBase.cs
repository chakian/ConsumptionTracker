using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConTrk.Persistence
{
    public abstract class RepositoryBase
    {
        private const string DB_NAME = "ConsumptionData.db";
        private static SQLiteConnection _db;

        public RepositoryBase()
        {
            if (_db == null)
            {
                _db = new SQLiteConnection(DB_NAME);
                _db.CreateTable<CategoryDbo>();
                _db.CreateTable<ConsumptionDbo>();
            }
        }

        public abstract string GetTableName();

        protected void Insert<T>(T record)
            where T : DboBase
        {
            _db.Insert(record);
        }

        protected void Update<T>(T record)
            where T : DboBase
        {
            if (record.Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Bu nasıl oldu anlamadım. Kayıtta bir sıkıntı var, güncelleme yapamadık.");
            }
            _db.Update(record);
        }

        protected void Delete<T>(int id)
            where T : DboBase, new()
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Bu nasıl oldu anlamadım. Kayıtta bir sıkıntı var, silemedik bunu.");
            }
            _db.Delete<T>(id);
        }

        protected T GetById<T>(int id)
            where T : DboBase, new()
        {
            var record = _db.Query<T>("SELECT * FROM " + GetTableName() + " WHERE id='?';", id.ToString());
            if (record != null && record.Count > 0)
            {
                return record.First();
            }
            return null;
        }

        protected List<T> GetAllAsList<T>()
            where T : DboBase, new()
        {
            var records = _db.Table<T>().ToList();
            return records;
        }
    }
}
