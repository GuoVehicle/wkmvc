﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Common;
using Common;

namespace Service
{
   public  interface IRepository <T> where T:class
    {
        #region 数据对象操作
        /// <summary>
        /// 数据上下文
        /// </summary>
        DbContext Context { get; }
        /// <summary>
        /// 数据上下文
        /// </summary>
        Domain.MyConfig Config { get; }

        /// <summary>
        /// 数据模型操作
        /// </summary>
        DbSet<T> dbSet { get; }
        /// <summary>
        /// ef事务
        /// </summary>
        DbContextTransaction Transaction { get; set; }
        /// <summary>
        /// 事务提交结果
        /// </summary>
        bool Committed { get; set; }
        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();
        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();

        #endregion

        #region 单模型操作
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Save(T entity);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isEdit"></param>
        /// <returns></returns>
        bool SaveOrUpdate(T entity, bool isEdit);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Delete(Expression<Func<T, bool>> predicate = null);
        /// <summary>
        /// 执行SQL删除
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        int DeleteBySql(string sql, params DbParameter[] para);
        /// <summary>
        /// 根据属性验证实体对象是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool IsExist(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 根据SQL验证实体对象是否存在
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        bool IsExist(string sql, params DbParameter[] para);


        #endregion

        #region 多模型操作
        /// <summary>
        /// 增加多模型数据，指定独立模型集合
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        int SaveList<T1>(List<T1> t) where T1 : class;
        /// <summary>
        /// 增加多模型数据  与当前模型一致
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int SaveList(List<T> t);
        /// <summary>
        /// 更新多模型 指定独立模型
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        int UpdateList<T1>(List<T1> t) where T1 : class;
        /// <summary>
        /// 更新多模型  与当前模型一致
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int UpdateList(List<T> t);
        /// <summary>
        /// 批量删除模型  当前模型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int DeleteList(List<T> t);
        /// <summary>
        /// 批量删除模型  独立模型
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        int DeleteList<T1>(List<T1> t) where T1 : class;
        #endregion

        #region 存储过程操作
        /// <summary>
        /// 执行增删改存储过程
        /// </summary>
        /// <param name="proname"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        object ExecuteProc(string proname, params DbParameter[] parameter);
        /// <summary>
        /// 执行查询存储过程
        /// </summary>
        /// <param name="proname"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        object ExecuteQueryProc(string proname, params DbParameter[] parameter);
        #endregion
        #region 查询多条数据
        /// <summary>
        /// 获取集合IQueryable
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> LoadAll(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 获取集合List
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<T> LoadListAll(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 获取DbQuery的列表
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        DbQuery<T> LoadQueryAll(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 获取IEnumerable列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        IEnumerable<T> LoadEnumerableAll(string sql, params DbParameter[] para);
        /// <summary>
        /// 获取数据动态集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        System.Collections.IEnumerable LoadEnumerable(string sql, params DbParameter[] para);
        /// <summary>
        ///  采用SQL进行数据的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        List<T> SelectBySql(string sql, params DbParameter[] para);
        List<T1> SelectBySql<T1>(string sql, params DbParameter[] para);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TOrderBy"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <param name="selector"></param>
        /// <param name="IsAsc"></param>
        /// <returns></returns>
        List<TResult> QueryEntity<TEntity, TOrderBy, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool IsAsc)
           where TEntity : class
           where TResult : class;
        /// <summary>
        /// 可指定返回结果、排序、查询条件的通用查询方法，返回Object对象
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">返回结果（必须是模型中存在的字段）</param>
        /// <param name="IsAsc">排序方向，true为正序false为倒序</param>
        /// <returns>自定义实体集合</returns>
        List<object> QueryObject<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool IsAsc)
            where TEntity : class;
        /// <summary>
        /// 可指定返回结果、排序、查询条件的通用查询方法，返回动态类对象
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">返回结果（必须是模型中存在的字段）</param>
        /// <param name="IsAsc">排序方向，true为正序false为倒序</param>
        /// <returns>动态类对象</returns>
        dynamic QueryDynamic<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool IsAsc)
            where TEntity : class;
        #endregion

        #region 分页查询

        /// <summary>
        /// 通过SQL分页
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        IList<T1> PageByListSql<T1>(string sql, IList<DbParameter> parameters, PageCollection page);
        IList<T> PageByListSql(string sql, IList<DbParameter> parameters, PageCollection page);
        /// <summary>
        /// 通用EF分页，默认显示20条记录
        /// </summary>
        /// <typeparam name="TEntity">实体模型</typeparam>
        /// <typeparam name="TOrderBy">排序类型</typeparam>
        /// <param name="index">当前页</param>
        /// <param name="pageSize">显示条数</param>
        /// <param name="where">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">结果集合</param>
        /// <param name="isAsc">排序方向true正序 false倒序</param>
        /// <returns>自定义实体集合</returns>
        PageInfo<object> Query<TEntity, TOrderBy>
            (int index, int pageSize,
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TOrderBy>> orderby,
            Func<IQueryable<TEntity>, List<object>> selector,
            bool IsAsc)
            where TEntity : class;
        /// <summary>
        /// 对IQueryable对象进行分页逻辑处理，过滤、查询项、排序对IQueryable操作
        /// </summary>
        /// <param name="t">Iqueryable</param>
        /// <param name="index">当前页</param>
        /// <param name="PageSize">每页显示多少条</param>
        /// <returns>当前IQueryable to List的对象</returns>
        Common.PageInfo<T> Query(IQueryable<T> query, int index, int PageSize);
        /// <summary>
        /// 普通SQL查询分页方法
        /// </summary>
        /// <param name="index">当前页</param>
        /// <param name="pageSize">显示行数</param>
        /// <param name="tableName">表名/视图</param>
        /// <param name="field">获取项</param>
        /// <param name="filter">过滤条件</param>
        /// <param name="orderby">排序字段+排序方向</param>
        /// <param name="group">分组字段</param>
        /// <returns>结果集</returns>
        Common.PageInfo Query(int index, int pageSize, string tableName, string field, string filter, string orderby, string group, params DbParameter[] para);
        /// <summary>
        /// 简单的Sql查询分页
        /// </summary>
        /// <param name="index"></param>
        /// <param name="pageSize"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        Common.PageInfo Query(int index, int pageSize, string sql, string orderby, params DbParameter[] para);
        /// <summary>
        /// 多表联合分页算法
        /// </summary>
        PageInfo Query(IQueryable query, int index, int pagesize);
        #endregion

        #region ADO.NET增删改查方法
        /// <summary>
        /// 执行增删改方法,含事务处理
        /// </summary>
        object ExecuteSqlCommand(string sql, params DbParameter[] para);
        /// <summary>
        /// 执行多条SQL，增删改方法,含事务处理
        /// </summary>
        object ExecuteSqlCommand(Dictionary<string, object> sqllist);
        /// <summary>
        /// 执行查询方法,返回动态类，接收使用var，遍历时使用dynamic类型
        /// </summary>
        object ExecuteSqlQuery(string sql, params DbParameter[] para);
        #endregion
    }


}
