using kolokwium_2.Context;
using kolokwium_2.ResponseModels;

namespace kolokwium_2.Services;

interface IExampleTableClassService
{
    Task<GetExampleTableClassResponseModel> GetExampleTableClassIdAsync(int id);
}

public class ExampleTableClassService(DatabaseContext context) : IExampleTableClassService 
{
    public Task<GetExampleTableClassResponseModel> GetExampleTableClassIdAsync(int id)
    {
        
        /*var res = await context.Accounts
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

        return res;*/
        
        throw new NotImplementedException();
    }
}