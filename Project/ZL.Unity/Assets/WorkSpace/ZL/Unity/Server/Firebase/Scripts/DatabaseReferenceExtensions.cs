using Firebase.Database;

namespace ZL.Unity.Server.Firebase
{
    public static partial class DatabaseReferenceExtensions
    {
        public static DatabaseReference Child(this DatabaseReference instance, string[] paths)
        {
            foreach (var path in paths)
            {
                instance = instance.Child(path);
            }

            return instance;
        }
    }
}