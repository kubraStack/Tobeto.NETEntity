using Business.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private List<Category> _categories;
        public CategoryManager()
        {
            _categories = new List<Category>();
            _categories.Add(new Category() { Id=1, Name="Giysi"});
            _categories.Add(new Category() { Id =2, Name = "Ev Eşyaları" });
        }
        public Category Add(Category category)
        {
            _categories.Add(category);
            return category;
        }

        public void Delete(int id)
        {
            Category category = _categories.Find(c=> c.Id == id);
            if (category == null)
            {
                throw new Exception("Kategori bulunamadı");
            }
            _categories.Remove(category);
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public Category GetById(int id)
        {
            Category category = _categories.Find(c => c.Id == id);
            if (category == null)
            {
                throw new Exception("Kategori bulunamadı");
            }
            return category;
        }

        public Category Update(Category category)
        {
            Category checkCategory = _categories.Find(c => c.Id == category.Id);
            if (checkCategory == null)
            {
                throw new Exception("Kategori bulunamadi");

            }
            checkCategory.Name = category.Name;
            checkCategory.Id = category.Id;


            return checkCategory;
        }
    }
}
