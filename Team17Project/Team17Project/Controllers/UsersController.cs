using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team17Project.Class;
using Team17Project.Models;

namespace Team17Project.Controllers
{
    public class UsersController : Controller
    {
        private Team17ProjectBetaDatabaseEntities db = new Team17ProjectBetaDatabaseEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Profile
        public new ActionResult Profile()
        {
            int id = Convert.ToInt32(Session["Login"].ToString());
            var user = (from u in db.Users
                       where u.Id == id
                       select u).FirstOrDefault();
            if(user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // GET: Users/Edit
        public ActionResult Edit()
        {

            if (Session["Login"] == null)
            {
                return HttpNotFound();
            }

            int? id = Convert.ToInt32(Session["Login"].ToString());
            var user = (from u in db.Users
                        where u.Id == id
                        select u).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }

            var editProfile = new EditProfile();
            editProfile.Username = user.Username;
            editProfile.NewEmail = user.Email;

            return View(editProfile);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username, NewEmail, ConfirmPassword")] EditProfile profile)
        {
            var id = Convert.ToInt32(Session["Login"].ToString());
            
            var user = (from u in db.Users
                            where u.Id == id
                            select u).FirstOrDefault();
            if(ModelState.IsValid)
            {
                // Kiểm tra Email của user muốn đổi đã có trong database chưa
                var count = (from u in db.Users
                             where u.Email == profile.NewEmail
                             select u).Count();
                if (count > 0)
                {
                    ModelState.AddModelError("EmailExist", "Địa chỉ email đã được sử dụng");
                    return View("Profile", user);
                }
                // Xác minh mật khẩu
                var hashedPassword = Crypto.Hash(profile.ConfirmPassword);
                if(hashedPassword != user.Password)
                {
                    ModelState.AddModelError("ConfirmPasswordError", "Mật khẩu xác nhận không đúng");
                    profile.Username = user.Username;
                    return View("Edit", profile);
                }
                user.Email = profile.NewEmail;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return View("Profile", user);
            }
            
            return View("Profile", user);
        }

        // GET: Users/EditPass
        public ActionResult EditPass()
        {
            if (Session["Login"] == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Users/EditPass
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPass([Bind(Include ="OldPassword, NewPassword, ConfirmPassword")] EditPassword editPassword)
        {
            var id = Convert.ToInt32(Session["Login"].ToString());

            var user = (from u in db.Users
                        where u.Id == id
                        select u).FirstOrDefault();
            if(ModelState.IsValid)
            {
                // Kiem tra mat khau hien tai
                if(Crypto.Hash(editPassword.OldPassword) != user.Password)
                {
                    ModelState.AddModelError("PasswordInvalid", "Mật khẩu không chính xác");
                    editPassword.OldPassword = "";
                    return View("EditPass", editPassword);
                }

                user.Password = Crypto.Hash(editPassword.NewPassword);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return View("Profile", user);
            }
           
            return View("EditPass", editPassword);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
