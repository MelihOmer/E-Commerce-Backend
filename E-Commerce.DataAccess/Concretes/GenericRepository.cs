using E_Commerce.Core;
using E_Commerce.Core.Abstracts;
using E_Commerce.Core.Enums;
using E_Commerce.Infrastructure.Extensions;
using E_Commerce.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.Infrastructure.Concretes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        private DbSet<T> Table => _context.Set<T>();
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.SingleOrDefaultAsync(t => t.Id == id);
        }
        public async Task<int> CountAsync()=> await Table.CountAsync();
        public async Task<IReadOnlyList<T>> GetAllWithWhereAndIncludesAsync(RequestParameters requestParameters, Expression<Func<T,object>>[] orderByProperties = null,OrderBy orderBy = OrderBy.None, Expression<Func<T, bool>>[] filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query
                .ApplyWhere(filter)
                .ApplyOrderBy(orderBy, orderByProperties)
                .ApplyIncludeProperties(includeProperties)
                .ApplyPagination(requestParameters);
            return await query.ToListAsync();


            
        }

        public async Task<T> GetEntityWithWhereAndIncludesAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = filter is not null ? query.Where(filter) : query
                .ApplyIncludeProperties(includeProperties);

            return await query.FirstOrDefaultAsync();
        }
        //private async Task<IQueryable<T>> ApplyOrderBy(IQueryable<T> query, OrderBy orderBy, Expression<Func<T, object>>[] orderByProperties)
        //{
        //    await Task.Run(() =>
        //     {
        //         switch (orderBy)
        //         {
        //             case OrderBy.None:
        //                 break;
        //             case OrderBy.Ascending:
        //                 IOrderedQueryable<T> orderedAscList = query.OrderBy(orderByProperties.First());
        //                 for (int i = 1; i < orderByProperties.Count(); i++)
        //                 {
        //                     query = orderedAscList.ThenBy(orderByProperties[i]);
        //                 }
        //                 break;
        //             case OrderBy.Descending:
        //                 IOrderedQueryable<T> orderedDescList = query.OrderByDescending(orderByProperties.First());
        //                 for (int i = 1; i < orderByProperties.Count(); i++)
        //                 {
        //                     query = orderedDescList.ThenByDescending(orderByProperties[i]);
        //                 }
        //                 break;
        //             default:
        //                 break;
        //         }
        //     });
        //    return query;
        //}



        //private IQueryable<T> ApplyIncludeProperties(IQueryable<T> query, params Expression<Func<T, object>>[] includeProperties)
        //{

        //    foreach (var includeProperty in includeProperties)
        //    {
        //        query = query.Include(includeProperty);
        //    }
        //    return query;
        //}



        //private async Task<IQueryable<T>> ApplyPagination(IQueryable<T> query, RequestParameters requestParameters)
        //{
        //    await Task.Run(() =>
        //    {
        //        query = query.Skip((requestParameters.PageNumber - 1) * requestParameters.PageSize)
        //         .Take(requestParameters.PageSize);
        //    });
        //    return query;
        //}
    }
}
//query = filter is not null ? query.Where(filter) : query;
//query = query
//    .ApplyOrderBy(orderBy,orderByProperties)
//    .ApplyIncludeProperties(includeProperties)
//    .ApplyPagination(requestParameters);