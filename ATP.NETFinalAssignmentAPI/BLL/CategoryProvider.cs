using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BEL;

namespace BLL
{
    public class CategoryProvider
    {
        public static List<CategoryModel> getAll()
        {
            var data = CategoryRepo.getAll();
            return AutoMapper.Mapper.Map<List<category>, List<CategoryModel>>(data);
        }
        public static CategoryDetailsModel get(int id)
        {
            var data = CategoryRepo.get(id);
            return AutoMapper.Mapper.Map<category, CategoryDetailsModel>(data);
        }
        public static void create(CategoryModel cat)
        {
            var c = AutoMapper.Mapper.Map<CategoryModel, category>(cat);
            CategoryRepo.create(c);
        }
        public static void edit(CategoryModel cat)
        {
            var c = AutoMapper.Mapper.Map<CategoryModel, category>(cat);
            CategoryRepo.edit(c);
        }
        public static void delete(int id)
        {
            CategoryRepo.delete(id);
        }
    }
}
