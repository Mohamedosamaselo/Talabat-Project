using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Common
{
    public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>
                                                           where TKey : IEquatable<TKey>
    {
        public required string CreatedBy { get; set; }  // Interceptor Will intercept  any Entity in Database before creation of Entity => the CreatedBy Field 
        public DateTime CreatedOn { get; set; } 
        public required string LastModifiedBy { get; set; }// Interceptr will Intercept any entity in Database Before Modification of Entity => the LastModifiedBy Field 
        public DateTime LastModifiedOn { get; set; }
    }
}
