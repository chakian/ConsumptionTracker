using SQLite;

namespace ConTrk.Persistence
{
    public abstract class RepositoryBase
    {
        private const string DB_NAME = "ConsumptionData.db";
        protected readonly SQLiteConnection _db;

        public RepositoryBase()
        {
            //string appPath = AppContext.BaseDirectory;
            //var databasePath = Path.Combine(appPath, "ConsumptionData.db");

            _db = new SQLiteConnection(DB_NAME);
            _db.CreateTable<CategoryDbo>();
            _db.CreateTable<ConsumptionDbo>();
        }
        public RepositoryBase(SQLiteConnection db)
        {
            _db = db;
        }
    }
}
