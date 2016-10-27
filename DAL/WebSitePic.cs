using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using DataBase;
    using Model;

    public class WebSitePicDao : BaseModel<WebSitePic>
    {
        public List<WebSitePic> GetWebSitePic(int siteType, int typeId)
        {
            return DbHelperSQL.ExcuteScaler<WebSitePic>("select * from WebSitePic where enabled=1 and siteType=@0 and typeId=@1", siteType, typeId);
        }
    }
}
