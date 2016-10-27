using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class BuyClass
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string Category { get; set; }

        public List<Gift> gifts { get; set; }

        public string Price { get; set; }
    }

    public class Gift
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
