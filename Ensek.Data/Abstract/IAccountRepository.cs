using Ensek.Core.Model;
namespace Ensek.Data.Abstract;

/*
 * Genereted new interface for Loose coupling
 */

public interface IAccountRepository: IRepository<Account>
{
    /// <summary>
    /// Finds an account
    /// </summary>
    /// <param name="FirstName">Firstname filter</param>
    /// <param name="LastName">Lastname filter</param>
    /// <returns></returns>
    Account Find(string FirstName, string LastName);
}
