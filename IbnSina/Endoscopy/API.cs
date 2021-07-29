namespace Endoscopy
{
    internal static class API
    {
        public static bool Login(string userName, string password)
        {
            return userName == "Handosa" && password == "123";
        }
    }
}
