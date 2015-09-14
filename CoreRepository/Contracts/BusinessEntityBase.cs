namespace CoreRepository
{
    public abstract class BusinessEntityBase: IBusinessEntity 
    {
        public BusinessEntityBase ()
		{
		}
		
		/// <summary>
		/// Gets or sets the Database ID.
		/// </summary>
		
		[PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
