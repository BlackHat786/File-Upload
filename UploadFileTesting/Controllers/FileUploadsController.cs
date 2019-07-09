using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UploadFileTesting.Models;
//Coded By BlackHat786
namespace UploadFileTesting.Controllers
{
    public class FileUploadsController : Controller
    {
        private UploadFileTestingContext db = new UploadFileTestingContext();

        // GET: FileUploads
        public ActionResult Index()
        {
            return View(db.FileUploads.ToList());
        }

        public ActionResult UploadFile(UploadViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            FileUpload fileUploadModel = new FileUpload();

            byte[] uploadFile = new byte[model.File.InputStream.Length];
            model.File.InputStream.Read(uploadFile, 0, uploadFile.Length);

            fileUploadModel.FileName = model.FileName;
            fileUploadModel.File = uploadFile;
            db.FileUploads.Add(fileUploadModel);
            db.SaveChanges();
            return RedirectToAction("UploadSuccessful");
        }


        public ActionResult UploadSuccessful()
        {
            return View();
        }
        // GET: FileUploads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUpload fileUpload = db.FileUploads.Find(id);
            if (fileUpload == null)
            {
                return HttpNotFound();
            }
            return View(fileUpload);
        }


        public FileContentResult FileDownload(int? id)
        {
            byte[] fileData;
            string fileName;

            FileUpload fileRecord = db.FileUploads.Find(id);

            fileData = (byte[])fileRecord.File.ToArray();
            fileName = fileRecord.FileName;

            return File(fileData, "text", fileName);
        }

        // POST: FileUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileUpload fileUpload = db.FileUploads.Find(id);
            db.FileUploads.Remove(fileUpload);
            db.SaveChanges();
            return RedirectToAction("Index");
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
