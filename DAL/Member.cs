using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataBase;
using Model;

namespace DAL
{
    /// <summary>
    /// 数据访问类:Member
    /// </summary>
    public partial class MemberDao : BaseModel<Member>
    {

        public bool ExistValidCode(string mobile, string uuId, string code) 
        {
            return DbHelperSQL.Exists("select id from MemberVerify where uuid=@0 and mobile=@1 and verifycode=@2", uuId, mobile, code);
        }
    }
}

