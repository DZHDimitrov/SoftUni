namespace BookShop.Data
{
    internal class Configuration
    {
        internal static string ConnectionString 
            => "Server=.\\SQLEXPRESS;Database=BookShop;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}
