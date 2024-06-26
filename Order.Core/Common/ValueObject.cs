namespace Order.Core.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEq();

        public override bool Equals(object? obj)
        {
            if (obj == null) 
                return false;
            if (GetType() != obj.GetType()) 
                return false;
            var valueObject = (ValueObject)obj;

            return GetEq().SequenceEqual(valueObject.GetEq());
        }

        public override int GetHashCode() =>
            GetEq().Aggregate(
                default(int),
                (hashcode, value) =>
                    HashCode.Combine(hashcode, value));

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }
    }
}
