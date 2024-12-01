namespace LinkDev.Talabat.Core.Domain.Common
{
    // Abstract Class As Base Entity is not a business object 
    public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public required TKey Id { get; set; }

        public required string CreatedBy { get; set; }  // Interceptor Will intercept  any Entity in Database before creation of Entity => the CreatedBy Field 

        public DateTime CreatedOn { get; set; } /*= DateTime.UtcNow;*/

        public required string LastModifiedBy { get; set; }// Interceptr will Intercept any entity in Database Before Modification of Entity => the LastModifiedBy Field 

        public DateTime LastModifiedOn { get; set; } /*= DateTime.UtcNow;*/


    }

}
