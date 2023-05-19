using Xiyi_Platform.Entities.Context;
using Xiyi_Platform.Services;

namespace Xiyi_Platform.UoW
{
    /// <summary>
    /// 使用UOW设计模式 事务管理过程
    /// </summary>
    public class UnitOfWork
    {
        private readonly DataBaseContext _dataBaseContext;

        public DataBaseContext DBContext => _dataBaseContext;

        public UnitOfWork(DataBaseContext db)
        {
            this._dataBaseContext = db;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public  void Commit()
        {
            _dataBaseContext.SaveChanges();
        }

        public  void Rollback()
        {
            _dataBaseContext.Database.RollbackTransaction();
        }
    }
}
