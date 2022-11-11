using Account.Service.DTOs;
using System.Threading.Tasks;

namespace Account.Service.Interfaces
{
    public interface IAccountCommands
    {
        Task UpdateAccount(AccountUpdateDTO accountUpdate);
    }
}
