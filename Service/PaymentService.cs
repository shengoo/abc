using DAL;
using Model;

namespace Service
{
    public class PaymentService
    {
        PaymentLogDal paymentLogDal = new PaymentLogDal();
        PaymentDal paymentDal = new PaymentDal();
        public void WeiXinPay(PaymentLog payment)
        {
            paymentLogDal.Insert(payment, "MemberId", "SourceOrderId", "Payment", "TradeNo", "Amount", "IsPayed", "PayedIp", "PayedTime", "PayInfo");
        }
    }
}
