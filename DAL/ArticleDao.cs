using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DataBase;
using Model.ViewModel;
using System.Data.SqlClient;

namespace DAL
{
    public class ArticleDao
    {
        public List<Article> GetArticles()
        {
            var code = System.Configuration.ConfigurationManager.AppSettings["OneWord"].ToString();
            return DbHelperSQL.ExcuteScaler<Article>(" select articleid id,title,WeiXinUrl,description,content from article t1,ArticleCate t2 where t1.cateid=t2.cateid and t2.code=@0 and enabled=1 order by orderby desc ", code);
        }

        public Article GetArticle(int id)
        {
            return DbHelperSQL.ExcuteScaler<Article>(" select articleid id,title,description,content from article where enabled=1 and articleid=@0 ", id).FirstOrDefault();
        }

        /// <summary>
        /// 获取页脚文章列表
        /// </summary>
        /// <returns></returns>
        public List<ArtcleViewModel> GetArtcleListForFooter()
        {
            var pId = System.Configuration.ConfigurationManager.AppSettings["footerParentId"].ToString();

            var templist = new List<ArtcleViewModel>();
            //   var sqlstring = "SELECT * FROM  ArticleCate WHERE ParentId=4";
            var catelist = DbHelperSQL.ExcuteScaler<ArticleCate>("SELECT * FROM  ArticleCate WHERE ParentId=@0 ", pId).ToList();
            if (catelist != null && catelist.Count > 0)
            {
                foreach (var item in catelist)
                {
                    ArtcleViewModel model = new ArtcleViewModel();
                    model.ArtcleCateName = item.CateName;
                    model.ArtcleList = new List<Article>();
                    var sqlartstring = string.Format("SELECT articleid id,title,description,content FROM Article WHERE CateId={0}", item.CateId);
                    model.ArtcleList = DbHelperSQL.ExcuteScaler<Article>(sqlartstring).ToList();
                    templist.Add(model);
                }
            }
            return templist;
        }
    }
}
