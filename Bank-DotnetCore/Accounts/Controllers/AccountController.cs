using Accounts.Models;
using Bank_DotnetCore.Dtos;
using Bank_DotnetCore.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accounts.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountServices _accountService;
        public AccountController( IAccountServices accountService)
        {
            _accountService = accountService;
        }
        // GET: api/<AccountController>
        [HttpGet("accountdetails")]
        public IEnumerable<string> GetAccountDetails()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<ActionResult<AccountModel>> AddAccount(AddAccountDto user)
        {
            var userFromDB = await _accountService.AddAccount(user);
            if (userFromDB == null)
            {
                return BadRequest();
            } else
            {

            return Ok(userFromDB);
            }
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
