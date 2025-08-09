using api.models;

namespace api.services
{

   public interface BaseServiceInterface<T>
   {
      public Task<T> Get(int idEntity);
      public Task<List<T>> GetAll();
      public void Delete(int idEntity);
      public void Update(T entity);
      public void Create(T entity);


   }

}