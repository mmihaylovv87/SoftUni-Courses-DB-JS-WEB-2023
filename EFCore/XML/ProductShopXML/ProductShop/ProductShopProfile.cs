namespace ProductShop
{
    using AutoMapper;
    using ProductShop.DTOs.Export;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // User
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<User, ExportUserWithSoldProductDto>();
            this.CreateMap<User, ExportUserCountDto>();
            this.CreateMap<User, ExportUserDto>();

            // Product
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<Product, ExportProductDto>();
            this.CreateMap<Product, ExportSoldProductDto>();
            this.CreateMap<Product, ExportSoldProductsDto>();

            // Category
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<Category, ExportCategoryDto>();

            // CategoryProduct
            this.CreateMap<ImportCategoryProductDto, Category>();
        }
    }
}