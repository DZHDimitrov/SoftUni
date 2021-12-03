namespace SoftJail.Data
{
   public static class Configuration
    {
        //public static string ConnectionString = @"Server=.;Database=SoftJail;Trusted_Connection=True";
        public static string ConnectionString =
            @"Server=.\SQLEXPRESS;Database=SoftJail;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}
