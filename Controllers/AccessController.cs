using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnetMVCIdentity.Controllers
{
    [Authorize]
    public class AccessController : Controller
    {
        //Authorize from cookie/jwt
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Consumer,Blogger")]
        public IActionResult ConsumerAndBlogger()
        {
            return View();
        }
        [Authorize(Policy = "OnlyBloggerChecker")]
        public IActionResult OnlyBloggerChecker()
        {
            return View();
        }
        [Authorize(Policy = "CheckNickNameTeddy")]
        public IActionResult CheckNicknamTeddy()
        {
            return View();
        }
    }
}
