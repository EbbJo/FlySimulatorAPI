namespace FlySimulatorAPI.Models.Repository;

public interface IRepository<T> {
    public void Add(T obj);

    public T? GetById(Guid id);
    
    public List<T> GetAll();
    
    public void SaveChanges();
    
    public void Delete(Guid id);
}