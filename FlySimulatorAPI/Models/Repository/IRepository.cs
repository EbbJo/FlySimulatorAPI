namespace FlySimulatorAPI.Models.Repository;

public interface IRepository<T> {
    public void Add(T obj);

    public List<T> GetAll();
    
    public void SaveChanges();
    
    public void Delete(T obj);
}