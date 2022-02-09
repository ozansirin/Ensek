using Ensek.Business.Abstract;
using Ensek.Core.Model;
using Ensek.Data.Abstract;

namespace Ensek.Business.Concrete;

public class AccountService : IAccountService
{
    private readonly IAccountRepository repository;

    public AccountService(IAccountRepository _repository)
    {
        repository = _repository;
    }

    public Account CreateAccount(Account account)
    {
        if (ValidateAccount(account))
        {
            return repository.Create(account);
        }
        throw new Exception("Account is not validated");
    }

    public void DeleteAccount(int id)
    {
       repository.Delete(id);
    }

    public IEnumerable<Account> GetAllAccounts()
    {
        return repository.GetAll();
    }

    public Account UpdateAccount(Account account)
    {
        if (ValidateAccount(account))
        {
            return repository.Update(account);
        }
        throw new Exception("Account is not validated");
    }

    private bool ValidateAccount(Account account) {
        if (account.Id ==0 && repository.Find(account.FirstName, account.LastName) != null)
        {
            return false;
        } else if (account.Id > 0)
        {
            //If is there any record exist that account info then return false
            var result = repository.Find(account.FirstName, account.LastName);
            if (result.Id != account.Id)
            return false;
        }
        return true;
    }
}
