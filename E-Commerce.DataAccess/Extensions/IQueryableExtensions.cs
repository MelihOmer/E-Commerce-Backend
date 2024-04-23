using E_Commerce.Core.Enums;
using E_Commerce.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.Infrastructure.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, RequestParameters requestParameters)
        {
          query = query.Skip((requestParameters.PageNumber - 1) * requestParameters.PageSize)
                .Take(requestParameters.PageSize);
            
            return query;
        }
        public static IQueryable<T> ApplyOrderBy<T>(this IQueryable<T> query, OrderBy orderBy, Expression<Func<T, object>>[] orderByProperties)
        {
            switch (orderBy)
            {
                case OrderBy.None:
                    break;
                case OrderBy.Ascending:
                    IOrderedQueryable<T> orderedAscList = query.OrderBy(orderByProperties.First());
                    query = orderedAscList;
                    for (int i = 1; i < orderByProperties.Count(); i++)
                    {
                        query = orderedAscList.ThenBy(orderByProperties[i]);
                    }
                    break;
                case OrderBy.Descending:
                    IOrderedQueryable<T> orderedDescList = query.OrderByDescending(orderByProperties.First());
                    query = orderedDescList;
                    for (int i = 1; i < orderByProperties.Count(); i++)
                    {
                        query = orderedDescList.ThenByDescending(orderByProperties[i]);
                    }
                    break;
                default:
                    break;
            }
            return query;
        }
        public static IQueryable<T> ApplyIncludeProperties<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            if (includeProperties is not null)
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public static IQueryable<T> ApplyWhere<T>(this IQueryable<T> query, Expression<Func<T, bool>>[] predicates)
        {
            if (predicates is not null)
            foreach (var item in predicates)
            {
                query = query.Where(item);
            }
            return query;
        }
    }


}

