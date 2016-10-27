using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;

namespace mvcweb.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult DownFileId(string fileId)
        {
            var files =CommonService.GetFilePathById(fileId).Split(',');
            string filePath = Common.RootPath + files[0];
            if (System.IO.File.Exists(filePath))
            {
                FileStream stream = new FileStream(filePath, FileMode.Open);
                string contentType = "application/octet-stream";
                switch (files[1].Split('.')[1].ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                        contentType = "image/png";
                        break;
                    case ".doc":
                    case ".docx":
                        contentType = "application/msword";
                        break;
                    case ".xls":
                    case ".xlsx":
                        contentType = "application/vnd.ms-excel";
                        break;
                    case ".pdf":
                        contentType = "application/pdf";
                        break;
                    case ".zip":
                        contentType = "application/x-zip-compressed";
                        break;
                }
                return File(stream, contentType, files[1]);
            }
            return this.Content("文件不存在");
        }

        public ActionResult DownFileName(string fileName,string downName=null) 
        { 
            string filePath = Common.RootPath + fileName;
            if (System.IO.File.Exists(filePath))
            {
                FileStream stream = new FileStream(filePath, FileMode.Open);
                string contentType = "application/octet-stream";
                switch (fileName.Split('.').Last().ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                        contentType = "image/png";
                        break;
                    case ".doc":
                    case ".docx":
                        contentType = "application/msword";
                        break;
                    case ".xls":
                    case ".xlsx":
                        contentType = "application/vnd.ms-excel";
                        break;
                    case ".pdf":
                        contentType = "application/pdf";
                        break;
                    case ".zip":
                        contentType = "application/x-zip-compressed";
                        break;
                }
                return File(stream, contentType, downName ?? fileName.Split('/').Last());
            }
            return this.Content("文件不存在");
        }
    }
}
