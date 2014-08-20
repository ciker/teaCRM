
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data;
using teaCRM.DBContext;
using teaCRM.Model;

namespace teaCRM.Dao
{
 public class TSysCompanyLinqHelper
    {
	    /// <summary>
        /// 获取所有的数据
	    /// </summary>
	    /// <returns>返回所有数据列表</returns>
        public List<TSysCompany> GetList() 
        {
          using (teaCRMDBContext db=new teaCRMDBContext())
            {
             var models= db.TSysCompanies.ToList();
			 return models;
            }
        }

		/// <summary>
        /// 获取指定的单个实体
        /// 如果不存在则返回null
        /// 如果存在多个则抛异常
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>Entity</returns>
        public TSysCompany GetEntity(Expression<Func<TSysCompany, bool>> predicate) 
        {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
                var model =db.TSysCompanies.Where<TSysCompany>(predicate).SingleOrDefault();
                return model;
		    }
        }

		 /// <summary>
        /// 用SQL语句查询
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="namedParameters">sql参数</param>
        /// <returns>集合</returns>
        public IEnumerable<TSysCompany> GetListBySql(string sql, dynamic namedParameters)
        {
          using (teaCRMDBContext db=new teaCRMDBContext())
            {
               return db.DbHelper.ExecuteDataTable(sql,namedParameters).ToList<TSysCompany>();
            }
          
        }

		  /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        public bool InsertEntity(TSysCompany entity)
        {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
              int rows=  db.TSysCompanies.Insert(entity);
				 if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
       /// <summary>
        /// 删除实体
        /// </summary>
         /// <param name="predicate">Lamda表达式</param>
        public bool DeleteEntity(Expression<Func<TSysCompany , bool>> predicate) 
        {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
                TSysCompany  entity = db.TSysCompanies.Where(predicate).First();
                int rows=db.TSysCompanies.Delete(entity);
				 if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
		
		/// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list">实体集合</param>
        public bool DeletesEntity(List<TSysCompany> list) 
        {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
                var tran = db.Connection.BeginTransaction();
                try
                {
                    foreach (var item in list)
                    {
                        db.TSysCompanies.Delete(item);
                    }
                    tran.Commit();
					return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
					return false;
                    throw new Exception(ex.Message);
                }
            }
        }

         /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        public bool UpadateEntity(TSysCompany entity)
        {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
               int rows= db.TSysCompanies.Update(entity);
			   if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <returns></returns>
       public   bool ExistsEntity(Expression<Func<TSysCompany , bool>> predicate)
	   {
            using (teaCRMDBContext db=new teaCRMDBContext())
            {
               bool status= db.TSysCompanies.Any(predicate);
               return status;
            }
        }

		 //查询分页
      List<TSysCompany> GetListByPage(int pageIndex, int pageSize, Expression<Func<TSysCompany , bool>> predicate)
	  {
	   using (teaCRMDBContext db=new teaCRMDBContext())
            {
             var models= db.TSysCompanies.Where(predicate).ToPagination(pageIndex,pageSize).ToList();
			 return models;
            }
	  }
	   }

}

 
