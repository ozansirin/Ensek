using Ensek.Core.Model;
namespace Ensek.Business.Abstract;

/*
 * Genereted new interface for Loose coupling
 */


/// <summary>
/// Account process service
/// </summary>
public interface IAccountService
{

    /// <summary>
    /// Creates a new account
    /// </summary>
    /// <param name="account">Account model</param>
    /// <returns></returns>
    Account CreateAccount(Account account);

    /// <summary>
    /// Updates an account
    /// </summary>
    /// <param name="account">Account model</param>
    /// <returns></returns>
    Account UpdateAccount(Account account);

    /// <summary>
    /// Deletes an account
    /// </summary>
    /// <param name="id">Account ID</param>
    /// <returns></returns>
    void DeleteAccount(int id);

    /// <summary>
    /// Gets all accounts
    /// </summary>
    /// <returns></returns>
    IEnumerable<Account> GetAllAccounts();
}
