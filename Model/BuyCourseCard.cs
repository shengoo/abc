using System;

namespace Model
{
    public class BuyCourseCard
    {
        public int CardId{get;set;}
        public string CardName{get;set;}
        public int CardCategoryId{get;set;}
        public int CardTypeId{get;set;}
        public int Total{get;set;}
        public int Months{get;set;}
        public decimal Price{get;set;}
        public string ClassContent{get;set;}
        public string Discount{get;set;}
        public string Thumb { get; set; }
    }
}
