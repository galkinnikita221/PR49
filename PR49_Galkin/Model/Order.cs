using System;

namespace PR49_Galkin.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int DishId { get; set; }
        public int Count { get; set; }
    }
}
