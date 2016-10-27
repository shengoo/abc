using System.Collections.Generic;
using System.Linq;
using Model;
using DataBase;

namespace DAL
{
    /// <summary>
    /// 数据访问类:Orders
    /// </summary>
    public partial class OrdersDao : BaseModel<Orders>
    {
        /// <summary>
        /// 获取我的订单
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<MyOrder> GetOrders(int memberId,string orderNo)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("@memberId", memberId); 
            dic.Add("@orderNo", orderNo); 
            return DbHelperSQL.ExcuteProcedure<MyOrder>("PRO_MyOrder", dic);
        }

        public List<Orders> GetOrder(string orderNo, int memberId)
        {
            return DbHelperSQL.ExcuteScaler<Orders>("select orderid,orderno,totalamount,ordertime from orders where orderno=@0 and memberid=@1", orderNo, memberId);
        }

        public int GetOrderEnabled(int orderId)
        {
            int flag = 0;
            var orders = GetModels("orderId=@0 ", orderId);
            Orders order = null;
            if (orders.Count == 1)
            {
                order = orders[0];
                if (order != null)
                {
                    if (order.Enabled == 1) flag = 1;
                }
            } 
            return flag;
        }
    }
}

