using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
public class AccountController : Controller
{
   private readonly ILogger<AccountController> _logger;
   public AccountController(ILogger<AccountController> logger)
   {
       _logger = logger;
   }
   [HttpGet]
   public IActionResult Login()
   {
       return View();
   }
   [HttpPost]
   public IActionResult Login(LoginViewModel model)
   {
       if (ModelState.IsValid)
       {
           if (model.Username == "admin" && model.Password == "password")
           {
               _logger.LogInformation("User '{Username}' logged in successfully.", model.Username);
               return RedirectToAction("Index", "Home");
           }
           _logger.LogWarning("Login failed for user '{Username}'.", model.Username);
           ModelState.AddModelError("", "Invalid credentials");
       }
       return View(model);
   }
}