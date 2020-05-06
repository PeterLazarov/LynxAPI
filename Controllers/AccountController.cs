using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace Controllers
{
    [ApiController]
    [EnableCors]
    [Produces("application/json")]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager) {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }
         
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] User registerUser)
        {
            var user = new IdentityUser {
                UserName = registerUser.username
            };
            var result = await userManager.CreateAsync(user, registerUser.password);

            int statusCode = 200;
            string message = string.Empty;
            if (result.Succeeded) {
                await signInManager.SignInAsync(user, isPersistent: false);
            }
            else {
                statusCode = 403;
            }

            return StatusCode(statusCode, JsonConvert.SerializeObject(result));
        }
         
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(User loginUser)
        {
            var result = await signInManager.PasswordSignInAsync(loginUser.username, loginUser.password, false, false);

            int statusCode = 200;
            if (!result.Succeeded) {
                statusCode = 403;
            }
            
            return StatusCode(statusCode, JsonConvert.SerializeObject(result));
        }
         
        [HttpGet]
        [Route("IsSignedIn")]
        public async Task<ActionResult> IsUserSignedIn()
        {
            var user = await userManager.GetUserAsync(User);
            // var a = signInManager.IsSignedIn(User);

            return StatusCode(200, user);
        }
         
        [HttpGet]
        [Route("SignOut")]
        public async Task<ActionResult> SignOut()
        {
            await signInManager.SignOutAsync();

            return StatusCode(200);
        }
    }
}
