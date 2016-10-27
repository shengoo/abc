using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Enum
{
    /// <summary>
    /// 网站图片位置枚举类
    /// </summary>
    public enum WebSitePicPositionEnum
    {
        Enu_FirstPage = 1,//首页
        Enu_FreeCourse = 2,//免费课程
        Enu_CourseFeature = 3,//课程特色
        Enu_ForeignTeacher = 4,//外教团队
        Enu_FreeAnswer = 5,//免费答疑
        Enu_CourseFlow = 6,//上课流程
        Enu_StudentVoice = 7//学员心声
    }
    /// <summary>
    /// 网站图片版本枚举类
    /// </summary>
    public enum WebSitePicType
    {
        Enu_Adult = 0,//成人版
        Enu_Child = 1,//少儿版
    }
}
