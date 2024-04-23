using E_Commerce.Core.DbEntities;
using E_Commerce.Core.Enums;
using System.Linq.Expressions;

namespace E_Commerce.Core.Helpers
{
    public class ProductParemeters
    {
        private OrderBy _orderBy;
        private string _sortBy;
        private int _brandId;
        private int _typeId;
        private Expression<Func<Product, bool>>[] _filter;
        private Expression<Func<Product, object>>[] _sortByExpression;

        public OrderBy OrderBy
        {
            get { return _orderBy; }
            set { _orderBy = value;GenerateOrderBy(); }
        }
        public string SortBy
        {
            get { return _sortBy; }
            set { _sortBy = value;GenerateOrderBy(); }
        }

        public Expression<Func<Product, object>>[] SortByExpression
        {
            get {return _sortByExpression; }
            set { _sortByExpression = value; }
        }


        public int BrandId
        {
            get { return _brandId; }
            set { _brandId = value; GenerateFilter(); }
        }
        public int TypeId
        {
            get { return _typeId; }
            set { _typeId = value; GenerateFilter(); }
        }
        public Expression<Func<Product, bool>>[] Filter
        {
            get { return _filter; }
            set { _filter = value; }
        }

        private void GenerateFilter()
        {
            switch(true)
            {
                case var _ when BrandId!=0 && TypeId!=0:
                    _filter = [x => x.ProductTypeId == TypeId & x.ProductBrandId == BrandId];
                    break;
                case var _ when BrandId != 0:
                    _filter = [x => x.ProductBrandId == BrandId];
                    break;
                case var _ when TypeId != 0:
                    _filter = [x => x.ProductTypeId == TypeId];
                    break;
                default:
                    _filter = Array.Empty<Expression<Func<Product, bool>>>();
                    break;
            }
        }
        private void GenerateOrderBy()
        {
            switch (true)
            {
                case var _ when SortBy == "TitleAsc":
                    _sortByExpression = [x => x.Title];
                    _orderBy = OrderBy.Ascending;
                    break;
                case var _ when SortBy == "PriceAsc":
                    _sortByExpression = [x => x.Price];
                    _orderBy = OrderBy.Ascending;
                    break;
                case var _ when SortBy == "PriceDesc":
                    _sortByExpression= [x => x.Price];
                    _orderBy = OrderBy.Descending;
                    break;
            }
        }
    }
}
