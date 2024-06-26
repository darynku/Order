using CSharpFunctionalExtensions;
using Order.Core.ValueObjects;
using Entity = Order.Core.Common.Entity;

namespace Order.Core.Entities
{
    public class OrderEntity : Entity
    {
        private OrderEntity(
            Guid id, 
            string name, 
            string description, 
            DateTime orderDate, 
            DateTime shippedDate, 
            Money money,
            List<OrderItem> orderItems) : base(id)
        {
      
            Name = name;
            Description = description;
            OrderDate = orderDate;
            ShippedDate = shippedDate;
            Money = money;
            _orderItems = orderItems;
        }
        private OrderEntity() { }

        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public DateTime OrderDate { get; private set; }
        public DateTime ShippedDate { get; private set; }
        public Money Money { get; private set; } = null!;

        public IReadOnlyList<OrderItem> OrderItems => _orderItems;
        private readonly List<OrderItem> _orderItems = [];

        //public OrderStatus OrderStatus { get; private set; } = null!;

        public static Result<OrderEntity> Create(
            Guid orderId, 
            string name, 
            string description, 
            DateTime orderDate, 
            DateTime shippedDate, 
            Money money,
            List<OrderItem> orderItems)
        {
            return new OrderEntity(orderId, name, description, orderDate, shippedDate, money, orderItems);
        }
        
        //public Result Prinyat()
        //{
        //    if (OrderStatus == OrderStatus.Prinyat)
        //        return Result.Failure<OrderStatus>("Already approved");

        //    OrderStatus = OrderStatus.Prinyat;
        //    return Result.Success();
        //}

    }
}
