using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Team17Project.Models;
using Team17Project.Class;
using BotDetect.Web.Mvc;

namespace Team17Project.Controllers
{
    public class AuthController : Controller
    {
        private Team17ProjectBetaDatabaseEntities db = new Team17ProjectBetaDatabaseEntities();

        // GET: SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult SignUp([Bind(Include = "Username, Password, ConfirmPassword, Email")] RegistrationUser user)
        {
            if (ModelState.IsValid)
            {
                // Check if Username exist
                if (db.Users.Count(item => item.Username == user.Username) > 0) // Username Existed
                {
                    ModelState.AddModelError("UsernameExist", "Tên đăng nhập đã được sử dụng");
                    return View(user);
                }
                
                // Check email
                if(db.Users.Count(item => item.Email == user.Email) > 0)
                {
                    ModelState.AddModelError("EmailExist", "Địa chỉ email đã được sử dụng");
                    return View(user);
                }
                
                User newUser = new User();
                //newUser.Id = db.Users.Max(item => item.Id) + 1;
                newUser.Username = user.Username;
                newUser.Email = user.Email;
                newUser.Type = 0;
                //Hashing password
                newUser.Password = Crypto.Hash(user.Password);


                db.Users.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Index", "Users");


            }
            return View(user);
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            // find username in server
            var user = (from u in db.Users
                       where u.Username == username
                       select u).FirstOrDefault();
            

            if(user != null)
            {
                // Username exists, check password
                var hashPassword = Crypto.Hash(password);
                if(user.Password == hashPassword)
                {
                    Session["Login"] = user.Id;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("PasswordInvalid", "Mật khẩu không chính xác");
                    return View("Login");
                }

            }

            ModelState.AddModelError("UsernameInvalid", "Tên đăng nhập không tồn tại");
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Remove("Login");
            return RedirectToAction("Index", "Home");
        }

    }
}