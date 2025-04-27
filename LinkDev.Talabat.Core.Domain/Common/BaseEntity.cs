namespace LinkDev.Talabat.Core.Domain.Common
{
    // Abstract Class As Base Entity is not a business object 
    public abstract class BaseEntity<TKey> where TKey : IEquatable<TKey>// TKey lazem ykon available for comparsion 3l4an lama agy implement Generic Repository fy GetById() , FindMethod()
                                                                       // mehtag Entity tkon ptimplement IEquatable 3l4an tkaren .  
    {
        public required TKey Id { get; set; } // P.K // Required Keyword : prevent new from Initialiazation so when we make object from
                                              // baseEntity we must to intialize id with vaue in objectInitalizer 
    }

        // Notethat  :
        // at first time when user create Entity , the approach of CRM is  : 
        // LastModifiedBy  = CreatedBy && LastModofiedOn = CreatedOn
}
