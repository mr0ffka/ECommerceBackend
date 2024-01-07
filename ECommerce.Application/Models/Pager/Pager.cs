using ECommerce.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce.Application.Models.Pager
{

    [Bind]
    public class Pager : IPager
    {
        private int pageIndex;
        private int pageSize;
        private string? sort;
        private string? order;
        private int totalRows;

        [FromQuery(Name = "index")]
        [JsonProperty(PropertyName = "index")]
        public virtual int PageIndex
        {
            get
            {
                if (pageIndex < TotalPages)
                {
                    return pageIndex;
                }
                else if (TotalPages > 0)
                {
                    return TotalPages;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                pageIndex = value > 0 ? value : 1;
            }
        }

        [FromQuery(Name = "size")]
        [JsonProperty(PropertyName = "size")]
        public virtual int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value > 0 ? value : 1;
            }
        }

        [FromQuery(Name = "sort")]
        [JsonProperty(PropertyName = "sort")]
        public virtual string? Sort
        {
            get
            {
                return sort;
            }
            set
            {
                sort = value;
            }
        }

        [FromQuery(Name = "order")]
        [JsonProperty(PropertyName = "order")]
        public virtual string? Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value?.ToUpper() == "ASC" ? "ASC" : "DESC";
            }
        }

        [BindNever]
        public virtual int TotalRows
        {
            get
            {
                return totalRows;
            }
            set
            {
                totalRows = value > 0 ? value : 0;
            }
        }

        [BindNever]
        public virtual int TotalPages
        {
            get
            {
                if (PageSize > 0)
                    return Convert.ToInt32(Math.Ceiling((double)TotalRows / PageSize));
                else
                    return 0;
            }
        }

        [BindNever]
        public virtual int Offset
        {
            get
            {
                return (PageIndex - 1) * PageSize;
            }
        }


        public Pager() : this(1, 20, "Id", "ASC")
        {
        }

        public Pager(Pager pager)
        {
            totalRows = pager.totalRows;
            pageIndex = pager.pageIndex;
            pageSize = pager.pageSize;
            sort = pager.sort;
            order = pager.order;
        }

        public Pager(int pageIndex, int pageSize = 20, string sort = "Id", string order = "ASC")
        {
            TotalRows = Int32.MaxValue;
            PageIndex = pageIndex;
            PageSize = pageSize;
            Sort = sort;
            Order = order;
        }

        internal IQueryable<TModel> PaginateData<TModel>(IQueryable<TModel> query) where TModel : class
        {
            TotalRows = query.Count();

            if (Sort.HasValue())
            {
                query = OrderingMethodFinder.OrderMethodExists(query.Expression)
                    ? (query as IOrderedQueryable<TModel>).ThenBy($"{Sort} {Order}")
                    : query.OrderBy<TModel>($"{Sort} {Order}");
            }

            query = query
                .Skip<TModel>(Offset)
                .Take<TModel>(PageSize);

            return query;
        }

        public IQueryable<TModel> Orderer<TModel>(IQueryable<TModel> query) where TModel : class
        {
            if (Sort.HasValue())
            {
                query = OrderingMethodFinder.OrderMethodExists(query.Expression)
                    ? (query as IOrderedQueryable<TModel>).ThenBy($"{Sort} {Order}")
                    : query.OrderBy<TModel>($"{Sort} {Order}");
            }

            return query;
        }

        public IQueryable<TModel> Take<TModel>(IQueryable<TModel> query) where TModel : class
        {
            TotalRows = query.Count();

            query = query
                .Skip<TModel>(Offset)
                .Take<TModel>(PageSize);

            return query;
        }

        public static implicit operator Pager(int count) => new Pager() { PageSize = count };
    }

    public class SimplePager : IPager
    {
        private readonly int limit;

        public SimplePager(int limit = 20)
        {
            this.limit = limit;
        }

        internal IQueryable<TModel> PaginateData<TModel>(IQueryable<TModel> query) => query.Take(limit);
    }

    public interface IPager
    {

    }

    public static partial class PagerExtensions
    {
        public static IQueryable<TModel> PaginateData<TModel>(this IQueryable<TModel> query, IPager pager) where TModel : class
        {
            return (pager as Pager)?.PaginateData(query) ?? (pager as SimplePager)?.PaginateData(query) ?? query;
        }
    }

    internal class OrderingMethodFinder : ExpressionVisitor
    {
        bool orderingMethodFound = false;

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var name = node.Method.Name;

            if (node.Method.DeclaringType == typeof(Queryable) && (
                name.StartsWith("OrderBy", StringComparison.Ordinal) ||
                name.StartsWith("ThenBy", StringComparison.Ordinal)))
            {
                orderingMethodFound = true;
            }

            return base.VisitMethodCall(node);
        }

        public static bool OrderMethodExists(Expression expression)
        {
            var visitor = new OrderingMethodFinder();

            visitor.Visit(expression);

            return visitor.orderingMethodFound;
        }
    }
}
