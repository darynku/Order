using Order.Core.Common;

namespace Order.Core.ValueObjects
{
    public class FullName : ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string? UserName { get; }

        private FullName(string firstName, string lastName, string userName)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
        }

        public static FullName Create(string firstName, string lastName, string userName)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));
            if (userName == null) throw new ArgumentNullException(nameof(userName));

            return new FullName(firstName, lastName, userName);
        }

        protected override IEnumerable<object> GetEq()
        {
            yield return FirstName;
            yield return LastName;
            
        }
    }
}
