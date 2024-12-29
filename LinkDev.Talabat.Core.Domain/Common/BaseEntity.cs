namespace LinkDev.Talabat.Core.Domain.Common
{
    // Abstract Class As Base Entity is not a business object 
    public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public required TKey Id { get; set; } // P.K
    }

        // Notethat  :
        // at first time when user create Entity , the approach of CRM is  : 
        // LastModifiedBy  = CreatedBy && LastModofiedOn = CreatedOn
}
