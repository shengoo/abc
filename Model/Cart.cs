using System;

namespace Model
{
    public class Cart
    {
        public int Id { get; set; }

        public int CardId { get; set; }

        public string CardName { get; set; }

        public string GiftIds { get; set; }

        public string GiftNames { get; set; }

        public int Number { get; set; }

        public decimal Price { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
