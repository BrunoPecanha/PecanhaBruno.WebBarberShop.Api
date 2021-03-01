namespace PecanhaBruno.WebBarberShop.Infra.Context {
    public static class SqlHelper {
        public static string ConnectionString {
            get {
                return "Server=tcp:pecanha.database.windows.net,1433;Initial Catalog=WebBarberShopp;Persist Security Info=False;User ID=pecanha;Password= 13676616766m&b; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }           
        }
    }
}
