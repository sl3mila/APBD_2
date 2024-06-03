using Microsoft.EntityFrameworkCore;
using zadanie10.Context;
using zadanie10.Exceptions;
using zadanie10.ResponseModels;

namespace zadanie10.Services;

public interface IAccountService
{
    Task<GetAccountResponceModel> GetAccountIdAsync(int id);
}

public class AccountServoce(DatabaseContext context) : IAccountService
{
    public async Task<GetAccountResponceModel> GetAccountIdAsync(int id)
    {
        var res = await context.Accounts
            .Where(a => a.AccountId == id)
            .Select(a => new GetAccountResponceModel
            {
                AccountId = a.AccountId,
                AccountFirstName = a.AccountFirstName,
                AccountLastName = a.AccountLastName,
                AccountEMail = a.AccountEMail,
                AccountPhone = a.AccountPhone
            }).FirstOrDefaultAsync();

        if (res is null)
        {
            throw new NotFoundException("Account with id:{id} doesn't exist");
        }

        return res;
    }
}