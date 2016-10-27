using System;
using System.Collections.Generic;

using System.Text;
using DataBase;
using Model;

namespace DAL
{
    public class OpenClassDao : BaseModel<OpenClassMember>
    {
        public List<OpenClass> GetOpenClass(int memberId)
        {
            //  t4.num,
           //   t4.exist,
            string sql = @"
                select oc.openclassid id,classtime,tm.ENName teacher,
                                        t3.CnName title,coursedesc about,MaxStudentNum maxNum,
                                         (CASE WHEN t4.num IS NULL THEN 0 ELSE t4.num end) AS Num,
                                        (CASE WHEN t4.exist IS NULL THEN 0 ELSE t4.exist end) AS Exist,
                                        u.Hash ImgUrl,CONVERT(varchar(100), FreeStartTime, 20) as FreeStartTime,CONVERT(varchar(100), FreeEndTime, 20) as FreeEndTime from openclass oc inner join teacher tc on oc.teacherid = tc.teacherid
                                        INNER JOIN Member tm ON tm.id = tc.MemberId 
                                        INNER JOIN OpenCourse t3 ON oc.CourseId = t3.CourseId
                                        INNER JOIN UploadFile u ON u.FileId=t3.ThumbId
                                        Left JOIN (
                SELECT count(*) num,OpenClassId,
                (CASE WHEN (SELECT  memberid FROM OpenClassMember 
                WHERE MemberId=@0 AND OpenClassId = t1.OpenClassId) is NULL THEN 0 ELSE 1 end)exist 
                FROM OpenClassMember t1 GROUP BY OpenClassId) t4 ON oc.openclassid = t4.openclassid
                                        WHERE oc.IsClosed>=1 order by FreeStartTime desc";
            var list = DbHelperSQL.ExcuteScaler<OpenClass>(sql, memberId);
            return list;
        }
    }
}
