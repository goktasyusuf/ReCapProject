using Core.Entities.Abstract;
using Core.Utilities.Results;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager<TEntity> 
        where TEntity : class,IEntity, new()
    {
        void Add(object value, int duration);
        TEntity Get();
        bool IsAdd();
        void Remove();
        void RemoveByPattern(string pattern);
    }
}
