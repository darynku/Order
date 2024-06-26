using CSharpFunctionalExtensions;
using Entity = Order.Core.Common.Entity;
using Order.Core.ValueObjects;

namespace Order.Core.Entities
{
    public class OrderItem : Entity
    {
        public int Quantity { get; private set; }
        public Money Price { get; private set; } = null!;
        //public int ProductId { get; private set; }

        private OrderItem() { }
        private OrderItem(Guid id, int quantity, Money price/*, int productId*/) : base(id)
        {
            Quantity = quantity;
            Price = price;
            //ProductId = productId;
        } 
        public static Result<OrderItem> Create(Guid id, int quantity, Money price/*, int productId*/)
        {
            return new OrderItem(id, quantity, price/*, productId*/);
        }


    }
}
