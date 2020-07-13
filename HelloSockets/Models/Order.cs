using System;

namespace HelloSockets
{
    public class Order
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal PaperRolls { get; set; }

        public string Commentary { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && PaperRolls > 0;
        }
    }
}