using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BEL;
using DAL;

namespace BLL
{
    public class AutoMapperProfiles : Profile
    {
        public string basePath = "https://localhost:44301/";
        public string category_imagePath = "Uploads/Categories/";
        public string product_imagePath = "Uploads/Products/";
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(config => config.AddProfile<AutoMapperProfiles>());
        }
        public AutoMapperProfiles()
        {
            CreateMap<product, ProductModel>()
                .ForMember(dest => dest.category_name, opt => opt.MapFrom(src => src.category.name))
                .ForMember(dest => dest.category_name, opt => opt.MapFrom(src => src.category.name))
                .ForMember(dest => dest.image, opt => opt.MapFrom(src => this.basePath + product_imagePath + src.image));
            CreateMap<ProductAddModel, product>()
                .ForMember(dest => dest.created_at, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.updated_at, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<CategoryModel, category>();                
            CreateMap<category, CategoryModel>()
                .ForMember(dest => dest.image, opt => opt.MapFrom(src => this.basePath + category_imagePath + src.image));
            CreateMap<category, CategoryDetailsModel>()
                .ForMember(dest => dest.products, opt => opt.MapFrom(src => AutoMapper.Mapper.Map<ICollection<product>, ICollection<ProductModel>>(src.products)));

            CreateMap<order, OrderModel>()
                .ForMember(dest => dest.amount, opt => opt.MapFrom(src => src.order_products.Sum(op => op.product.price * op.qty)));
            CreateMap<CreateOrderModel, order>();
        }
    }
}
