using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramewrork
{
    public interface EfCategoryRepository :ICategoryRepository
    {
        public void Add(Category category)
        {
            //using ifadesi genellikle belirli türdeki kaynakların düzgün bir şekilde yönetilmesini sağlar.
            using (BaseDbContext context = new())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void Delete(Category category)
        {
            using (BaseDbContext context = new())
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            using (BaseDbContext context = new())
            {
                return context.Categories.ToList();
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            using (BaseDbContext context = new())
            {
                return context.Categories.FirstOrDefault(p => p.Id == id);
            }
        }

        public void Update(Category category)
        {
            using (BaseDbContext context = new())
            {
                context.Categories.Update(category);
                context.SaveChanges();
            }
        }
    }
}
