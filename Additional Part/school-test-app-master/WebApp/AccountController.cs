using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp
{
    // TODO 4: unauthorized users should receive 401 status code
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IAccountCache _accountCache;

        public AccountController(IAccountService accountService, IAccountCache accountCache)
        {
            _accountService = accountService;
            _accountCache = accountCache;
        }

        [Authorize]
        [HttpGet]
        public ValueTask<Account> Get()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            return _accountService.LoadOrCreateAsync(username /* TODO 3: Get user id from cookie */);
        }

        //TODO 5: Endpoint should works only for users with "Admin" Role
        [Authorize]
        [HttpGet("{id}")]
        public Account GetByInternalId([FromRoute] int id)
        {
            var user = Get().Result;

            if (user.Role != "Admin")
            {
                return null;
            }
            var account = _accountService.GetFromCache(id);

            return account;
        }

        [Authorize]
        [HttpPost("counter")]
        public async Task UpdateAccount()
        {
            //Update account in cache, don't bother saving to DB, this is not an objective of this task.
            var account = await Get();
            account.Counter++;
            _accountCache.AddOrUpdate(account);
        }
    }
}