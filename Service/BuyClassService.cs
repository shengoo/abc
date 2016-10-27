using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace Service
{
    public class BuyClassService
    {
        CourseCategoryDao categoryDao = new CourseCategoryDao();
        CourseCardDao cardDao = new CourseCardDao();
        MemberCartDao cartDao = new MemberCartDao();
        OrdersDao ordersDao = new OrdersDao();
        OrderDetailDao detailDao = new OrderDetailDao();
        ClassPlanDao classPlanDao = new ClassPlanDao();

        public Response<List<CourseCategory>> GetCategory()
        {
            var res = new Response<List<CourseCategory>>();
            try
            {
                res.Result = categoryDao.GetModels(" Enabled=1 ");
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取课程卡种类失败！" + ex.Message;
            }
            return res;
        }

        /// <summary>
        /// 获取课程卡
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Response<List<BuyCourseCard>> GetCourseCard(int type,int cardTypeId)
        {
            var res = new Response<List<BuyCourseCard>>();
            try
            {
                res.Result = cardDao.GetCourseCard(type,cardTypeId);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取课程卡信息失败！" + ex.Message;
            }
            return res;
        }

        public Response<List<CourseCard>> GetCardGift(string cardId)
        {
            var res = new Response<List<CourseCard>>();
            try
            {
                res.Result = cardDao.GetCardGift(cardId);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取课程卡赠品信息失败！" + ex.Message;
            }
            return res;
        }

        public Response<bool> BuyCart(int cardId, int number, int memberId)
        {
            var res = new Response<bool>();
            try
            {
                var gift = "";
                cardDao.GetCardGift(cardId.ToString()).ForEach(t =>
                    {
                        gift += "," + t.CardId;
                    });
                cartDao.Insert(new MemberCart
                {
                    CardId = cardId,
                    GiftIds = gift == "" ? "" : gift.Substring(1),
                    Qty = number,
                    MemberId = memberId,
                    CreateTime = DateTime.Now
                }, new string[] { "CardId",
                    "GiftIds",
                    "Qty",
                    "MemberId",
                    "CreateTime" });
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取课程卡赠品信息失败！" + ex.Message;
            }
            return res;
        }

        public List<MyOrder> GetOrders(string orderNo, int memberId)
        {
            return ordersDao.GetOrders(memberId, orderNo);
        }

        public Orders GetOrder(string orderNo, int memberId)
        {
            return ordersDao.GetOrder(orderNo, memberId).FirstOrDefault();
        }

        public Response<List<Cart>> GetCart(int memberId)
        {
            var res = new Response<List<Cart>>();
            try
            {
                res.Result = cartDao.GetCart(memberId);
                foreach (var t in res.Result)
                {
                    if (!string.IsNullOrEmpty(t.GiftIds))
                    {

                        var where = "";
                        List<string> val = new List<string>();
                        var i = 0;
                        foreach (var id in t.GiftIds.Split(','))
                        {
                            where += ",@" + i++;
                            val.Add(id);
                        }
                        var gifts = cardDao.GetModels(" cardId in (" + where.Substring(1) + ")", val.ToArray());
                        var n = 0;
                        foreach (var gift in gifts)
                        {
                            t.GiftNames += gift.CardName;
                            n++;
                            if (n % 3 == 0)
                                t.GiftNames += "<br/> ";
                            else
                                t.GiftNames += ",";
                        }
                        t.GiftNames = t.GiftNames.Substring(0, t.GiftNames.Length - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取购物车信息失败！" + ex.Message;
            }
            return res;
        }

        public Response<bool> DelCart(int memberId, int[] carts)
        {
            var res = new Response<bool>();
            try
            {
                cartDao.BatchDelete(carts.Select(t => new MemberCart { CartId = t, MemberId = memberId }).ToList(), "CartId", "MemberId");
            }
            catch (Exception ex)
            {
                res.ErrMsg = "购物车信息删除失败！" + ex.Message;
            }
            return res;
        }

        public Response<string> AccountCart(int memberId, List<Cart> carts)
        {
            var res = new Response<string>();
            try
            {
                var orderNo = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                ordersDao.Insert(new Orders
                {
                    MemberId = memberId,
                    OrderNo = orderNo,
                    Enabled = 0,
                    OrderTime = DateTime.Now,
                    TotalQty = carts.Count + carts.Sum(t => string.IsNullOrEmpty(t.GiftIds) ? 0 : t.GiftIds.Split(',').Length),
                    TotalAmount = carts.Sum(t => t.Price * t.Number)
                }, "MemberId", "OrderNo", "Enabled", "OrderTime", "TotalQty", "TotalAmount");
                int id = ordersDao.GetModels(" OrderNo=@0 ", orderNo).First().OrderId;

                var details = new List<OrderDetail>();
                carts.ForEach(b =>
                {
                    for (var j = 0; j < b.Number; j++)
                    {
                        details.Add(new OrderDetail
                        {
                            CardId = b.CardId,
                            OrderId = id,
                            Qty = 1,
                            Amount = b.Price,
                            AssignNum = 0,
                            IsAssign = 0
                        });
                        if (!string.IsNullOrEmpty(b.GiftIds))
                        {
                            foreach (var t in b.GiftIds.Split(','))
                                details.Add(new OrderDetail
                                {
                                    CardId = int.Parse(t),
                                    OrderId = id,
                                    Qty = 1,
                                    Amount = 0,
                                    AssignNum = 0,
                                    IsAssign = 0
                                });
                        }
                    }
                });

                detailDao.BatchInsert(details, "Qty", "CardId", "OrderId", "Amount", "AssignNum", "IsAssign");
                cartDao.BatchDelete(carts.Select(t => new MemberCart()
                {
                    CartId = t.Id
                }).ToList(), "CartId");

                res.Result = orderNo;
            }
            catch (Exception ex)
            {
                res.ErrMsg = "结算失败！" + ex.Message;
            }
            return res;
        }

        public Response<List<ClassPlanRlt>> GetClasPlans(int memberId)
        {
            var res = new Response<List<ClassPlanRlt>>();
            try
            {
                res.Result = classPlanDao.GetClassPlans(memberId);
            }
            catch (Exception ex)
            {
                res.ErrMsg = "获取课程信息失败！" + ex.Message;
            }
            return res;

        }

        public int GetOrderEnabled(int orderId) {
            return ordersDao.GetOrderEnabled(orderId); 
        }

        public Orders GetOrderById(int orderId)
        {
            Orders order = null;
            var orders = ordersDao.GetModels("OrderId=@0 ", orderId);
            if (orders != null) {
                order = orders[0];
            }
            return order; 
        }


    }
}
