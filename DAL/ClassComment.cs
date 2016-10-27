
using System;
using System.Collections.Generic;
using DataBase;

namespace DAL
{
    using Model;
    /// <summary>
    /// 数据访问类:ClassComment
    /// </summary>
    public partial class ClassCommentDao : BaseModel<ClassComment>
    {
        public ClassCommentDao()
        { }

        /// <summary>
        /// 获取学员评价 学员对老师的评价
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<MyEvaluate> GetStudentEvaluates(int memberId)
        {
            var sql = @"
            SELECT 
                t1.rate1 remark,
                t1.ClassId,
                t1.Content,
                t3.About,
                t3.CnName CourseName,
                t6.EnName Teacher,
                t6.Logo,
 0 coursetype,t1.cplid,
                t1.CreateTime FROM ClassComment t1
                inner join Teacher t5 on t1.teacherid = t5.teacherid AND t1.CplId>0 AND t1.MemberId=@0 and t1.CommentType=0
                inner join Member t6 ON t5.MemberId = t6.id 
                inner join ClassPlan t2 on t1.classid = t2.classid 
                inner join course t3 on t2.courseid=t3.courseid 
                UNION
                SELECT 
                t1.rate1 remark,
                t1.ClassId,
                t1.Content,
                t3.CourseDesc About,
                t3.CnName CourseName,
                t6.EnName Teacher,
                t6.Logo,
 1 coursetype,t1.cplid,
                t1.CreateTime FROM ClassComment t1
                inner JOIN OpenClass t2 on t1.classid = t2.openclassid AND t1.CplId=0 AND t1.memberid=@0
                inner join opencourse t3 on t2.courseid=t3.courseid 
                inner join Teacher t5 on t1.teacherid = t5.teacherid 
                left JOIN Member t6 ON t5.MemberId = t6.id 
                ORDER BY CourseName desc";

            return DbHelperSQL.ExcuteScaler<MyEvaluate>(sql, memberId);
        }

        /// <summary>
        /// 获取学员评价 老师对学员的评价
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<MyEvaluate> GetTeacherEvaluates(int memberId)
        {
            var sql = @"
                SELECT 
                t1.rate1 remark,
                t1.ClassId,
                t3.About,
                t1.Content,
                t3.CnName CourseName,
                t6.CnName Teacher,
                t6.Logo,
0 coursetype, t1.cplid,
                t1.CreateTime FROM ClassComment t1
                inner join ClassPlan t2 on t1.classid = t2.classid inner join course t3 on t2.courseid=t3.courseid 
                inner join Teacher t4 on t4.TeacherId = t1.TeacherId 
                left JOIN Member t6 ON t4.MemberId = t6.id where t1.memberid=@0 and CommentType=1 ORDER BY CourseName desc";

            return DbHelperSQL.ExcuteScaler<MyEvaluate>(sql, memberId);
        }


        /// <summary>
        /// 获取教师评价 学员对老师的评价
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<MyEvaluate> GetTeacherToStudentEvaluates(int memberId)
        {
            var sql = @"
                SELECT t1.rate1 remark,
                t1.ClassId,
                t1.Content,
                t5.About,
                t5.CnName CourseName,
                t3.CnName Teacher,
                t3.Logo,
0 coursetype, t1.cplid,
                t1.CreateTime  FROM ClassComment t1 INNER JOIN Teacher t2 ON t1.TeacherId = t2.TeacherId and t2.MemberId=@0 AND t1.CommentType=0
INNER JOIN Member t3 ON t1.MemberId = t3.Id
INNER JOIN ClassPlan t4 ON t1.ClassId = t4.ClassId INNER JOIN Course t5 ON t4.CourseId = t5.CourseId";

            return DbHelperSQL.ExcuteScaler<MyEvaluate>(sql, memberId);
        }

        /// <summary>
        /// 获取教师评价 老师对学员的评价
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<MyEvaluate> GetStudentToTeacherEvaluates(int memberId)
        {
            var sql = @"
                SELECT 
                t1.rate1 remark,
                t1.ClassId,
                t3.About,
                t1.Content,
                t3.CnName CourseName,
                t6.CnName Teacher,
                t6.Logo,
0 coursetype, t1.cplid,
                t1.CreateTime FROM ClassComment t1
                inner join ClassPlan t2 on t1.classid = t2.classid inner join course t3 on t2.courseid=t3.courseid 
                inner join Teacher t4 on t4.TeacherId = t1.TeacherId 
                left JOIN Member t6 ON t4.MemberId = t6.id where t6.id=@0 and CommentType=1";

            return DbHelperSQL.ExcuteScaler<MyEvaluate>(sql, memberId);
        }

    }
}

