namespace FlySimulatorAPI.Models.Repository;

/// <summary>
/// Represents a dataset of objects with full Create-Read-Update-Delete operations.
/// </summary>
/// <typeparam name="T">Type of the objects to store.</typeparam>
public interface IRepository<T> {
    /// <summary>
    /// Add an object to the repository.
    /// </summary>
    /// <param name="obj">Object to add.</param>
    public void Add(T obj);

    /// <summary>
    /// Get an object by its ID.
    /// </summary>
    /// <param name="id">ID of the object to get.</param>
    /// <returns>The object, or null if no object was found.</returns>
    public T? GetById(Guid id);
    
    /// <summary>
    /// Get all objects in the repository.
    /// </summary>
    /// <returns>A list of all objects.</returns>
    public List<T> GetAll();
    
    /// <summary>
    /// Delete an object from the repository.
    /// </summary>
    /// <param name="id">ID of the object to delete.</param>
    public void Delete(Guid id);

    /// <summary>
    /// Overwrite an existing object with a new object.
    /// </summary>
    /// <param name="id">ID of the object to overwrite.</param>
    /// <param name="obj">New object - ID will be overwritten.</param>
    public void Update(Guid id, T obj);
    
    /// <summary>
    /// Write the changes to the underlying database.
    /// </summary>
    public void SaveChanges();
}