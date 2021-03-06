using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data;
using teaCRM.DBContext;
using teaCRM.Entity;

namespace teaCRM.Dao
{
    public interface ITCusBaseDao : ITableDao<TCusBase>
    {
        #region 手写的扩展函数 2014-09-05 14:58:50 By 唐有炜



        


        /// <summary>
        /// 添加客户信息 2014-08-30 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="cusBase">客户信息</param>
        /// <param name="cusCon">主联系人信息</param>
        /// <returns></returns>
        bool AddCustomer(TCusBase cusBase, TCusCon cusCon);

        /// <summary>
        /// 删除客户信息 2014-08-30 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="customerId">客户id</param>
        /// <returns>删除状态</returns>
        bool DeleteCustomer(int customerId);

        /// <summary>
        /// 修改客户信息 2014-08-30 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="customerId">客户id</param>
        /// <param name="cusBase">客户信息</param>
        /// <param name="cusCon">主联系人信息</param>
        /// <returns></returns>
        bool EditCustomer(int customerId, TCusBase cusBase, TCusCon cusCon);

        /// <summary>
        /// 获取客户信息列表
        /// </summary>
        /// <param name="compNum">企业编号</param>
        /// <param name="selectFields">选择的字段</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="strWhere">筛选条件</param>
        /// <param name="filedOrder">排序字段</param>
        /// <param name="recordCount">记录结果</param>
        /// <returns>DataTable</returns>
        DataTable GetCustomerLsit(string compNum, string[] selectFields, int pageIndex, int pageSize,
            string strWhere, string filedOrder,
            out int recordCount);

        /// <summary>
        /// 获取客户信息列表 2014-08-29 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="selector">要查询的字段</param>
        /// <param name="expFields">存储扩展字段值的字段</param>
        /// <param name="expSelector">要查询的扩展字段</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="ordering">排序</param>
        /// <param name="recordCount">记录结果数</param>
        /// <param name="values">参数</param>
        /// <returns>客户信息列表</returns>
        List<Dictionary<string, object>> GetCustomerLsit(int pageIndex, int pageSize, string selector, string expFields, string expSelector,
            string predicate, string ordering,
            out int recordCount, params object[] values);



        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="selector">The selector.</param>
        /// <param name="expFields">The exp fields.</param>
        /// <param name="expSelector">The exp selector.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="values">The values.</param>
        /// <returns>Dictionary&lt;System.String, System.Object&gt;.</returns>
        Dictionary<string, object> GetCustomer(string selector, string expFields, string expSelector, string predicate,
            params object[] values);


        /// <summary>
        /// 使用where sql语句更改客户状态(只更改主表) 2014-09-05 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="strSet">要更新的字段</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        bool UpdateCustomerStatusByWhere(string strSet, string strWhere);


        /// <summary>
        /// 使用LINQ批量更改TCusBase状态 2014-09-05 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="fields">要更新的字段（支持批量更新）</param>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        bool UpdateTCusBaseStatusByLINQ(Dictionary<string, object> fields,
            Expression<Func<TCusBase, bool>> predicate);


        /// <summary>
        /// 批量改状态
        /// </summary>
        /// <param name="cus_ids">id集合</param>
        /// <param name="op">操作（0 1）</param>
        /// <param name="field">字段</param>
        /// <returns></returns>
        bool UpdateStatusMoreCustomer(string cus_ids, int op, string field);


        #endregion
    }
}