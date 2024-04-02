namespace E_Commerce.Core.DbEntities;

public class Product : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal? Price { get; set; }
    public string ImageUrl { get; set; }

    //Relational Entity
    public ProductType? ProductType { get; set; }
    public int? ProductTypeId { get; set; }
    public ProductBrand? ProductBrand { get; set; }
    public int? ProductBrandId { get; set; }
}
