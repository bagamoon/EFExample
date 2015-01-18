using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ExampleApplication.ViewModel;
using ExampleModel.Entity;

namespace ExampleApplicationCSharp.AutoMapper
{
    public class ProductProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return this.GetType().Name;
            }
        }

        protected override void Configure()
        {            
            Mapper.CreateMap<Products, ProductViewModel>()
                  .ForMember(x => x.ReorderLevel, y => y.Ignore())
                  .ForMember(x => x.SupplierName, y => y.MapFrom(s => string.Format("{0}-{1}", s.Suppliers.Country, s.Suppliers.CompanyName)));

        }
    }
}
