using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using DataBase;

namespace Service
{
    public class CommonService
    {
        public static string GetFilePathById(string fileId)
        {
            var file = DbHelperSQL.GetSingle("select Hash+','+FileName from UploadFile where FileId=@0 ", fileId);
            return file == null ? "" : file.ToString();
        }
    }
}
