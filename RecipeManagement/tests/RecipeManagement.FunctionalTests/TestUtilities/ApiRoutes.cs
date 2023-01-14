namespace RecipeManagement.FunctionalTests.TestUtilities;
public class ApiRoutes
{
    public const string Base = "api";
    public const string Health = Base + "/health";

    // new api route marker - do not delete

    public static class Recipes
    {
        public static string GetList => $"{Base}/recipes";
        public static string GetRecord(Guid id) => $"{Base}/recipes/{id}";
        public static string Delete(Guid id) => $"{Base}/recipes/{id}";
        public static string Put(Guid id) => $"{Base}/recipes/{id}";
        public static string Create => $"{Base}/recipes";
        public static string CreateBatch => $"{Base}/recipes/batch";
    }

    public static class Categories
    {
        public static string GetList => $"{Base}/categories";
        public static string GetRecord(Guid id) => $"{Base}/categories/{id}";
        public static string Delete(Guid id) => $"{Base}/categories/{id}";
        public static string Put(Guid id) => $"{Base}/categories/{id}";
        public static string Create => $"{Base}/categories";
        public static string CreateBatch => $"{Base}/categories/batch";
    }

    public static class Books
    {
        public static string GetList => $"{Base}/books";
        public static string GetRecord(Guid id) => $"{Base}/books/{id}";
        public static string Delete(Guid id) => $"{Base}/books/{id}";
        public static string Put(Guid id) => $"{Base}/books/{id}";
        public static string Create => $"{Base}/books";
        public static string CreateBatch => $"{Base}/books/batch";
    }

    public static class Blogs
    {
        public static string GetList => $"{Base}/blogs";
        public static string GetRecord(Guid id) => $"{Base}/blogs/{id}";
        public static string Delete(Guid id) => $"{Base}/blogs/{id}";
        public static string Put(Guid id) => $"{Base}/blogs/{id}";
        public static string Create => $"{Base}/blogs";
        public static string CreateBatch => $"{Base}/blogs/batch";
    }

    public static class Posts
    {
        public static string GetList => $"{Base}/posts";
        public static string GetRecord(Guid id) => $"{Base}/posts/{id}";
        public static string Delete(Guid id) => $"{Base}/posts/{id}";
        public static string Put(Guid id) => $"{Base}/posts/{id}";
        public static string Create => $"{Base}/posts";
        public static string CreateBatch => $"{Base}/posts/batch";
    }

    public static class UserProfiles
    {
        public static string GetList => $"{Base}/userProfiles";
        public static string GetRecord(Guid id) => $"{Base}/userProfiles/{id}";
        public static string Delete(Guid id) => $"{Base}/userProfiles/{id}";
        public static string Put(Guid id) => $"{Base}/userProfiles/{id}";
        public static string Create => $"{Base}/userProfiles";
        public static string CreateBatch => $"{Base}/userProfiles/batch";
    }

    public static class Users
    {
        public static string GetList => $"{Base}/users";
        public static string GetRecord(Guid id) => $"{Base}/users/{id}";
        public static string Delete(Guid id) => $"{Base}/users/{id}";
        public static string Put(Guid id) => $"{Base}/users/{id}";
        public static string Create => $"{Base}/users";
        public static string CreateBatch => $"{Base}/users/batch";
    }
}
