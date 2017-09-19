namespace SR.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SRContext : DbContext
    {
        // Your context has been configured to use a 'SRContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SR.Data.SRContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SRContext' 
        // connection string in the application configuration file.
        public SRContext()
            : base("name=SRContext")
        {
        }

      
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}