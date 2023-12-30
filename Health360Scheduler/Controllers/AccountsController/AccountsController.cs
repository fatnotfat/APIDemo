using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Services.Interfaces;
using AutoMapper;
using Health360Scheduler.DataTransferObjects;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Principal;
using Health360Scheduler.Mappers;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Health360Scheduler.Controllers.AccountsController
{
    [Authorize(Roles = "Admin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper, IConfiguration config)
        {
            _accountService = accountService;
            _mapper = mapper;
            _configuration = config;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAccountsAsync()
        {
            //create map
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AccountFrofile());
            });
            var mapper = config.CreateMapper();
            //End create map

            //transfer from account to account dto

            var data = await _accountService.GetAllAccountAsync();
            var accounts = data.Select(
                             acc => mapper.Map<Account, AccountDTO>(acc)
                           );
            if (await _accountService.GetAllAccountAsync() == null)
            {
                return NotFound();
            }
            return Ok(accounts);
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountDTO>> PostAccountAsync(AccountDTO account)
        {
            var data = _mapper.Map<Account>(account);
            if (await _accountService.GetAllAccountAsync() == null)
            {
                return Problem("Entity set 'Health360SchedulerDBContext.Accounts'  is null.");
            }
            await _accountService.RegistAccountAsync(data);

            return Ok("user " + data.AccountId + " was created");
        }

        [HttpPost]
        [Route("/api/v1/auth/login")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckLogin(string email, string password)
        {
            if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
            {
                var data = await _accountService.CheckLoginAsync(email, password);
                if (data != null)
                {
                    var account = _mapper.Map<AccountDTO>(data);
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role, account.Role.ToString()),
                        new Claim("Email", account.Email),
                        new Claim("Role", account.Role.ToString())};
                    //create claims details based on the user information

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                return BadRequest("Invalid credentials");
            }
            return BadRequest();
        }


        //// GET: api/Accounts/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Account>> GetAccount(Guid id)
        //{
        //  if (_context.Accounts == null)
        //  {
        //      return NotFound();
        //  }
        //    var account = await _context.Accounts.FindAsync(id);

        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    return account;
        //}

        //// PUT: api/Accounts/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAccount(Guid id, Account account)
        //{
        //    if (id != account.AccountId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(account).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AccountExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Accounts
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Account>> PostAccount(Account account)
        //{
        //  if (_context.Accounts == null)
        //  {
        //      return Problem("Entity set 'Health360SchedulerDBContext.Accounts'  is null.");
        //  }
        //    _context.Accounts.Add(account);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
        //}

        //// DELETE: api/Accounts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAccount(Guid id)
        //{
        //    if (_context.Accounts == null)
        //    {
        //        return NotFound();
        //    }
        //    var account = await _context.Accounts.FindAsync(id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Accounts.Remove(account);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AccountExists(Guid id)
        //{
        //    return (_context.Accounts?.Any(e => e.AccountId == id)).GetValueOrDefault();
        //}
    }
}
