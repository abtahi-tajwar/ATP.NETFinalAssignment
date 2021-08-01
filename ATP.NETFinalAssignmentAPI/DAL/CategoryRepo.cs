using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryRepo
    {
        static Entities context;
        static CategoryRepo()
        {
            context = new Entities();
        }
        public static List<category> getAll()
        {
            return context.categories.ToList();
        }
        public static category get(int id)
        {
            return context.categories.FirstOrDefault(pr => pr.id == id);
        }
        public static void create(category p)
        {
            context.categories.Add(p);
            context.SaveChanges();
        }
        public static void edit(category p)
        {
            var oldp = context.categories.FirstOrDefault(pr => pr.id == p.id);
            context.Entry(oldp).CurrentValues.SetValues(p);
            context.SaveChanges();
        }
        public static void delete(int id)
        {
            var category = context.categories.FirstOrDefault(ct => ct.id == id);
            context.categories.Remove(category);
            context.SaveChanges();
        }
    }
}
