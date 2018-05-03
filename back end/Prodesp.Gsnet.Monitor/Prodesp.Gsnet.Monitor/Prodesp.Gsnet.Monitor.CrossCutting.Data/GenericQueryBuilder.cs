using Prodesp.Gsnet.Core.TO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prodesp.Gsnet.Framework.Expression;
using System.Linq.Expressions;
using Prodesp.Gsnet.Core.TO.Enums;
using Prodesp.Gsnet.Monitor.Domain.Interfaces.Infra.Repositorios;
using Prodesp.Gsnet.Core.TO.Response;
using Prodesp.Gsnet.Framework;

namespace Prodesp.Gsnet.Monitor.CrossCutting.Data
{
    public class GenericQueryBuilder<TEntity, TRepository>
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        TRepository _repository;
        public GenericQueryBuilder(TRepository repository)
        {
            _repository = repository;
        }
        protected virtual IQueryable<TEntity> BuildQuery(SingleSearchRequest predicates)
        {
            IQueryable<TEntity> returnEnumerable = null;
            if (predicates.Data.Fields != null && predicates.Data.Fields.Any())
            {
                var defaultField = predicates.Data.Fields.FirstOrDefault().Field;
                var searchExpressions = this.ToExpression(predicates, defaultField);
                foreach (Expression<Func<TEntity, bool>> searchExpression in searchExpressions)
                {
                    returnEnumerable = Queryable.Where<TEntity>(returnEnumerable, searchExpression);
                }
            }
            return returnEnumerable;
        }


        public IQueryable<TEntity> OrderBy(SingleSearchRequest predicates, IQueryable<TEntity> query)
        {
            if (!string.IsNullOrEmpty(predicates.Data.OrderBy))
            {
                var type = typeof(TEntity);
                var prop = type.GetProperties().FirstOrDefault(p => p.Name == predicates.Data.OrderBy);
                if (prop != null)
                {
                    var parameter = Expression.Parameter(type, "p");
                    var propertyAccess = Expression.MakeMemberAccess(parameter, prop);
                    var orderByExp = Expression.Lambda(propertyAccess, parameter);
                    var resultExp = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { type, prop.PropertyType }, query.Expression, Expression.Quote(orderByExp));
                    query = query.Provider.CreateQuery<TEntity>(resultExp);
                }
            }
            return query;
        }
        public void Paginate(IQueryable<TEntity> query, int recordsPerPage, out int totalPages, out int totalRecords)
        {
            totalRecords = query.Count();
            totalPages = (int)Math.Ceiling((double)totalRecords / recordsPerPage);
        }
        public ListResponse<TEntity> Query(SingleSearchRequest predicates)
        {
            var recordsPerPage = predicates.Data.RecordsPerPage > 0 ? predicates.Data.RecordsPerPage : 20;
            var pageNumber = predicates.Data.PageNumber > 0 ? predicates.Data.PageNumber : 1;
            int totalRecords = 0, totalPages = 0;
            var query = this.BuildQuery(predicates);
            query = this.OrderBy(predicates, query);
            this.Paginate(query, recordsPerPage, out totalPages, out totalRecords);
            query = query.Take(recordsPerPage).Skip(pageNumber);
            var result = query.ToList();
            return new ListResponse<TEntity>
            {
                Data = result,
                TotalRecords = totalRecords,
                TotalPages = totalPages
            };
        }
        //protected virtual DataSet InternalGet(SingleSearchRequest predicates)
        //{
        //    //AlterSession();

        //    var recordsPerPage = predicates.Data.RecordsPerPage > 0 ? predicates.Data.RecordsPerPage : 20;
        //    var pageNumber = predicates.Data.PageNumber > 0 ? predicates.Data.PageNumber : 1;
        //    var returnEnumerable = PersistenceContext.Query<TModel>();
        //    var repository = new Repository<TEntity>();
        //    // exemplo: na página 2 para 10 registros por página temos skip = 11 e take = 20
        //    var skip = this.Skip(pageNumber, recordsPerPage);
        //    var take = this.Take(recordsPerPage);

        //    if (predicates.Data.Fields != null && predicates.Data.Fields.Any())
        //    {
        //        var defaultField = predicates.Data.Fields.FirstOrDefault().Field;
        //        var searchExpressions = this.ToExpression(predicates, defaultField);
        //        foreach (Expression<Func<TEntity, bool>> searchExpression in searchExpressions)
        //        {
        //            returnEnumerable = Queryable.Where<TEntity>(returnEnumerable, searchExpression);
        //        }
        //    }

        //    #region TotalPages / TotalRecords

        //    var totalRecords = returnEnumerable.Count();
        //    var totalPages = (int)Math.Ceiling((double)totalRecords / recordsPerPage);

        //    #endregion

        //    #region .: ordenação dos dados :.
        //    if (!string.IsNullOrEmpty(predicates.Data.OrderBy))
        //    {
        //        var type = typeof(TEntity);
        //        var prop = type.GetProperties().FirstOrDefault(p => p.Name == predicates.Data.OrderBy);
        //        if (prop != null)
        //        {
        //            var parameter = Expression.Parameter(type, "p");
        //            var propertyAccess = Expression.MakeMemberAccess(parameter, prop);
        //            var orderByExp = Expression.Lambda(propertyAccess, parameter);
        //            var resultExp = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { type, prop.PropertyType }, returnEnumerable.Expression, Expression.Quote(orderByExp));
        //            returnEnumerable = returnEnumerable.Provider.CreateQuery<TEntity>(resultExp);
        //        }
        //    }
        //    #endregion

        //    return new
        //    {
        //        Data = returnEnumerable.Skip(skip).Take(take).ToList(),
        //        Pages = totalPages,
        //        Records = totalRecords,
        //        RecordsPerPage = predicates.Data.RecordsPerPage
        //    };
        //}
        public virtual Expression<Func<TEntity, bool>>[] ToExpression<TFieldType>(string field, OperationFilterType op,
           TFieldType value1, TFieldType value2)
        {
            var result = new List<Expression<Func<TEntity, bool>>>();

            if (op.Equals(OperationFilterType.Contem))
            {
                result.Add(HelperFilter<TEntity>.Contains<TFieldType>(field, value1));
            }
            else if (op.Equals(OperationFilterType.Diferente))
            {
                result.Add(HelperFilter<TEntity>.NotEqual<TFieldType>(field, value1));
            }
            else if (op.Equals(OperationFilterType.ForaDoIntervalo))
            {
                result.AddRange(HelperFilter<TEntity>.NotBetween<TFieldType>(field, value1, value2));
            }
            else if (op.Equals(OperationFilterType.Igual))
            {
                result.Add(HelperFilter<TEntity>.Equal<TFieldType>(field, value1));
            }
            else if (op.Equals(OperationFilterType.Maior))
            {
                result.Add(HelperFilter<TEntity>.GreaterThan<TFieldType>(field, value1));
            }
            else if (op.Equals(OperationFilterType.MaiorOuIgual))
            {
                result.Add(HelperFilter<TEntity>.GreaterThanOrEqual<TFieldType>(field, value1));
            }
            else if (op.Equals(OperationFilterType.Menor))
            {
                result.Add(HelperFilter<TEntity>.LessThan<TFieldType>(field, value1));
            }
            else if (op.Equals(OperationFilterType.MenorOuIgual))
            {
                result.Add(HelperFilter<TEntity>.LessThanOrEqual<TFieldType>(field, value1));
            }
            else if (op.Equals(OperationFilterType.NaoContem))
            {
                result.Add(HelperFilter<TEntity>.NotContains<TFieldType>(field, value1));
            }
            else
            {
                result.AddRange(HelperFilter<TEntity>.Between<TFieldType>(field, value1, value2));
            }
            return result.ToArray();
        }

        public virtual Expression<Func<TEntity, bool>>[] ToExpression(SingleSearchRequest request, string defaultField)
        {
            var result = new List<Expression<Func<TEntity, bool>>>();
            var properties = typeof(TEntity).GetProperties();
            if (request.Data.SearchType.Equals(SearchType.Default))
            {
                if (string.IsNullOrWhiteSpace(defaultField))
                    throw new ApplicationException("Field not set");

                result.AddRange(ToExpression<String>(defaultField, OperationFilterType.Contem, request.Data.Text,
                    string.Empty));
            }
            else
            {
                foreach (FieldData field in request.Data.Fields)
                {
                    var prop = properties.FirstOrDefault(p => p.Name.Equals(field.Field));
                    if (prop == null)
                    {
                        throw new ApplicationException("Field not found " + field.Field);
                    }
                    if (prop.PropertyType == (typeof(Guid)))
                    {
                        result.AddRange(ToExpression<Guid>(field.Field, field.OperationFilter,
                            HelperConvert.ToGuid(field.Value1), HelperConvert.ToGuid(field.Value2)));
                    }
                    else if (HelperConvert.IsInteger(prop))
                    {
                        if (prop.PropertyType == typeof(Int64))
                        {
                            result.AddRange(ToExpression<Int64>(field.Field, field.OperationFilter,
                                HelperConvert.ToInt64(field.Value1), HelperConvert.ToInt64(field.Value2)));
                        }
                        if (prop.PropertyType == typeof(Int32))
                        {
                            result.AddRange(ToExpression<Int32>(field.Field, field.OperationFilter,
                                HelperConvert.ToInt32(field.Value1), HelperConvert.ToInt32(field.Value2)));
                        }
                        else
                        {
                            result.AddRange(ToExpression<int>(field.Field, field.OperationFilter,
                                HelperConvert.ToInt(field.Value1), HelperConvert.ToInt(field.Value2)));
                        }
                    }
                    else if (HelperConvert.IsNullableInteger(prop))
                    {
                        result.AddRange(ToExpression<int?>(field.Field, field.OperationFilter,
                            HelperConvert.ToInt(field.Value1), HelperConvert.ToInt(field.Value2)));
                    }
                    else if (prop.PropertyType == (typeof(DateTime)))
                    {
                        var dt1 = HelperConvert.ToDateTimeBr(field.Value1);
                        var dt2 = HelperConvert.ToDateTimeBr(field.Value2);
                        result.AddRange(ToExpression<DateTime>(field.Field, field.OperationFilter, dt1, dt2));
                    }
                    else if (prop.PropertyType == (typeof(DateTime?)))
                    {
                        var dt1 = HelperConvert.ToDateTimeBr(field.Value1);
                        var dt2 = HelperConvert.ToDateTimeBr(field.Value2);
                        result.AddRange(ToExpression<DateTime?>(field.Field, field.OperationFilter, dt1, dt2));
                    }
                    else if (prop.PropertyType == (typeof(decimal)))
                    {
                        result.AddRange(ToExpression<decimal>(field.Field, field.OperationFilter,
                            HelperConvert.ToDecimal(field.Value1), HelperConvert.ToDecimal(field.Value2)));
                    }
                    else if (prop.PropertyType == (typeof(decimal?)))
                    {
                        result.AddRange(ToExpression<decimal?>(field.Field, field.OperationFilter,
                            HelperConvert.ToNullableDecimal(field.Value1), HelperConvert.ToNullableDecimal(field.Value2)));
                    }
                    else if (prop.PropertyType == (typeof(Boolean)))
                    {
                        result.AddRange(ToExpression<Boolean>(field.Field, field.OperationFilter,
                            HelperConvert.ToBoolean(field.Value1), HelperConvert.ToBoolean(field.Value2)));
                    }
                    else if (prop.PropertyType == (typeof(Boolean?)))
                    {
                        result.AddRange(ToExpression<Boolean?>(field.Field, field.OperationFilter,
                            HelperConvert.ToBoolean(field.Value1), HelperConvert.ToBoolean(field.Value2)));
                    }

                    else if (prop.PropertyType == (typeof(byte)))
                    {
                        result.AddRange(ToExpression<byte>(field.Field, field.OperationFilter,
                            ToByte(field.Value1), ToByte(field.Value2)));
                    }
                    else if (prop.PropertyType == (typeof(byte?)))
                    {
                        result.AddRange(ToExpression<byte?>(field.Field, field.OperationFilter,
                            ToByte(field.Value1), ToByte(field.Value2)));
                    }

                    else
                    {
                        result.AddRange(ToExpression<string>(field.Field, field.OperationFilter, field.Value1,
                            field.Value2));
                    }
                }
            }
            return result.ToArray();
        }

        private IEnumerable<Expression<Func<TEntity, bool>>> ToExpression<T>(string field, OperationFilterType operationFilter, object p1, object p2)
        {
            throw new NotImplementedException();
        }

        #region .: Helper Methods :.

        public static Tconvert ConvertValue<Tconvert, U>(U value) where U : IConvertible
        {
            return (Tconvert)Convert.ChangeType(value, typeof(Tconvert));
        }

        public static byte ToByte(string value)
        {
            return Convert.ToByte(value);
        }
        #endregion
    }
}
