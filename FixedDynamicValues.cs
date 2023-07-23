namespace AutoMapperDemo
{
    /// <summary>
    /// The AutoMapper UseValue() method is used to assign a Fixed Value to a Destination Property 
    /// whereas the ResolveUsing() is used to assign a dynamic value to a destination property at runtime. 
    /// But, from AutoMapper 8.0, UseValue() and ResolveUsing() methods are deprecated and if you are trying to use the above two methods, 
    /// then you will get compile time error. 
    /// So, whatever we achieve using  UseValue() and ResolveUsing() methods, 
    /// now we can achieve the same using the AutoMapper MapFrom() method.
    /// </summary>
    internal class FixedDynamicValues
    {
        /// <summary>
        /// Our business Requirement is to Map to Source PermanentAddress Object to the Destination TemporaryAddress object. 
        /// But, we don’t want to map the CreatedBy and CreatedOn property values of the Source Object to the Destination Object. 
        /// Instead, we want to store the hard-coded or Fixed value “System” as the Value for the CreatedBy column 
        /// and the current DateTime value as the Value from the CreatedOn destination Property.
        /// </summary>
        public class PermanentAddress
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string CreatedBy { get; set; }
            public DateTime? CreatedOn { get; set; }
        }
        public class TemporaryAddress
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string CreatedBy { get; set; }
            public DateTime? CreatedOn { get; set; }
        }
        }
    
}
//https://dotnettutorials.net/lesson/usevalue-resolveusing-and-null-substitution-using-automapper/