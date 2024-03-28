using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    //Generic Repository Design Pattern => Sadece nesne adları değiştiği için bunların ortak işlemlerini alıp generic tipde interface kullanmış oluruz.
    //Methodları bir filtreleme ile çalıştırmak için Expression kullanılır.
    public interface IEntityRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
