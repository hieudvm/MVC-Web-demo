using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team17Project.Models;
using System.IO;

namespace Team17Project.Controllers
{
    public class ImagesController : Controller
    {
        private Team17ProjectBetaDatabaseEntities db = new Team17ProjectBetaDatabaseEntities();

        // GET: Images
        public ActionResult Index()
        {
            var images = db.Images.Include(i => i.Location).Include(i => i.User);
            return View(images.ToList());
        }

        // GET: Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            var comment = (from c in db.Comments
                           where c.ImgId == id
                           select new
                           {
                               userId = c.UserId,
                               text = c.Text
                           }
                           ).ToList();
            List<CommentView> commentsView = new List<CommentView>();
            for(int i = 0; i < comment.Count; i++)
            {
                var commentView = new CommentView();
                int userId = comment[i].userId;
                commentView.Username = (from u in db.Users where u.Id == userId select u.Username).First();
                commentView.Text = comment[i].text;
                commentsView.Add(commentView);
               
            }

            ViewBag.Comments = commentsView;
            return View(image);
        }

        // GET: Images/Upload
        public ActionResult Upload()
        {
            // Check Session for user login condition
            if(Session["Login"] == null)
            {

                // Upload image here
                TempData["UploadRedirectMessage"] = "Chức năng yêu cầu đăng nhập";
                return RedirectToAction("Login", "Auth");
                // Must create a view for redirect message
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View();
        }

        // POST: Images/Upload
        [HttpPost]
        public ActionResult Upload(/*HttpPostedFileBase fileInput*/[Bind(Include ="FileInput, LocationId")] UploadedFile uploadedFile)
        {
            var id = Convert.ToInt32(Session["Login"].ToString());

            var uploadImage = new Image();
            string path = Path.Combine(Server.MapPath("~/Uploads"), Path.GetFileName(uploadedFile.FileInput.FileName));
            uploadedFile.FileInput.SaveAs(path);

            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(uploadedFile.FileInput.FileName);

                var client = new ImgurClient("b1f964993df2f33", "1e883abc64b9e0d6259ea6f68e4e5eca875747b8");

                var endpoint = new ImageEndpoint(client);

                IImage image;

                using (var fs = new FileStream(path, FileMode.Open))
                {
                    image = endpoint.UploadImageStreamAsync(fs).GetAwaiter().GetResult();
                }


                uploadImage.Url = image.Link;
                uploadImage.UserId = id;
                uploadImage.LocationId = uploadedFile.LocationId; // Hardcode for now
                db.Images.Add(uploadImage);
                db.SaveChanges();
                System.IO.File.Delete(path);

                return RedirectToAction("Details", "Images", new { id = uploadImage.Id });
            }
            System.IO.File.Delete(path);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View(uploadedFile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment([Bind(Include = "ImageId, Text")] SubmitedComment submitedComment)
        {
            if (Session["Login"] == null)
            {
                TempData["UploadRedirectMessage"] = "Chức năng yêu cầu đăng nhập";
                return RedirectToAction("Login", "Auth");
            }
            if (ModelState.IsValid)
            {
                var comment = new Comment();
                comment.ImgId = submitedComment.ImageId;
                comment.UserId = Convert.ToInt32(Session["Login"].ToString());
                comment.Text = submitedComment.Text;

                db.Comments.Add(comment);
                db.SaveChanges();
            }
            

            return RedirectToAction("Details", new { id = submitedComment.ImageId });
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
