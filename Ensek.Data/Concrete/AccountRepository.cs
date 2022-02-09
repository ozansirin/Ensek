using Ensek.Data.Abstract;
using Ensek.Core.Model;
using Ensek.Core;

namespace Ensek.Data.Concrete;

public class AccountRepository : IAccountRepository
{
    private readonly EnsekDbContext _dbContext;

    public AccountRepository(EnsekDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Account Create(Account entity)
    {
        _dbContext.Accounts.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public void Delete(int Id)
    {
        var existEntity = _dbContext.Accounts.FirstOrDefault(x => x.Id == Id);
        _dbContext.Accounts.Remove(existEntity);
        _dbContext.SaveChanges();
    }

    public Account Find(string FirstName, string LastName)
    {
        var account =_dbContext.Accounts.Where(x => x.FirstName == FirstName && x.LastName == LastName).FirstOrDefault();
        return account;
    }

    public IEnumerable<Account> GetAll()
    {
        return _dbContext.Accounts.ToList();
    }

    public Account Update(Account entity)
    {
        var existEntity = new Account();
        existEntity = _dbContext.Accounts.FirstOrDefault(x => x.Id == entity.Id);
        if (existEntity != null)
        {
            existEntity.FirstName = entity.FirstName;
            existEntity.LastName= entity.LastName;
            _dbContext.SaveChanges();
            return existEntity;
        }
        return entity;
    }
}
