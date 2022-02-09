namespace Ensek.Data.Abstract;

/*
 * Repository Design pattern for Database CRUD operations
 */


/// <summary>
/// Generic repository
/// </summary>
public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Creates a new <typeparamref name="TEntity"/>
    /// </summary>
    /// <param name="entity"><typeparamref name="TEntity"/> data</param>
    /// <returns></returns>
    TEntity Create(TEntity entity);


    /// <summary>
    /// Updates an exist <typeparamref name="TEntity"/>
    /// </summary>
    /// <param name="entity"><typeparamref name="TEntity"/> data</param>
    /// <returns></returns>
    TEntity Update(TEntity entity);

    /// <summary>
    /// Deletes a <typeparamref name="TEntity"/> record
    /// </summary>
    /// <param name="Id">Data key to deleting</param>
    void Delete(int Id);

    /// <summary>
    /// Gets all <typeparamref name="TEntity"/> data
    /// </summary>
    /// <returns></returns>
    IEnumerable<TEntity> GetAll();


}
