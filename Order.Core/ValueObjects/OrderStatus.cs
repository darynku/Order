using Order.Core.Common;
namespace Order.Core.ValueObjects
{
    public class OrderStatus : ValueObject
    {
        public static readonly OrderStatus Prinyat = new(nameof(Prinyat).ToUpper());
        public static readonly OrderStatus Otmenen = new(nameof(Otmenen).ToUpper());
        public static readonly OrderStatus Ojidanie = new(nameof(Ojidanie).ToUpper());

        private static readonly OrderStatus[] _all = [Prinyat, Otmenen, Ojidanie];
        public string Status { get; }

        private OrderStatus(string status)
        {
            Status = status;
        }
        protected override IEnumerable<object> GetEq()
        {
            yield return Status;
        }
    }
}
