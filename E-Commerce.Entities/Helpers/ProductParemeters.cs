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
        private string _searchTerm;
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
        public string SearchTerm
        {
            get { return _searchTerm; }
            set { _searchTerm = value; GenerateFilter(); }
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
            var filters = new List<Expression<Func<Product, bool>>>();
            if (BrandId > 0)
                filters.Add(x => x.ProductBrandId == BrandId);
            if (TypeId > 0)
                filters.Add(x => x.ProductTypeId == TypeId);
            if (!String.IsNullOrEmpty(SearchTerm))
               filters.Add(x => x.Title.Contains(SearchTerm) || x.Description.Contains(SearchTerm));
            _filter = filters.ToArray();
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
