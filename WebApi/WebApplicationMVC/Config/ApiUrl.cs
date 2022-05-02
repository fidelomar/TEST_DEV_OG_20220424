namespace WebApplicationMVC.Config
{
    public static class ApiUrl
    {
        public static string ApiRoute = "http://localhost:24457/";
        public static string LoginRoute = ApiRoute + "api/login";
        public static string PersonRoute = ApiRoute + "api/person/getperson";
        public static string PersonsRoute = ApiRoute + "api/persons/getpersons";
    }
}