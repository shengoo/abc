using System.Collections.Generic;
using Model;
using DAL;

namespace Service
{
    public class TeamService
    {
        TeacherDao teacherDao = new TeacherDao();

        public List<TeamTeature> GetForeignTeature()
        {
            return teacherDao.GetForeignTeature();
        }
    }
}
