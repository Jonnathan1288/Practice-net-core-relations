using EFCommonCRUD.Interfaces;

namespace ProjectPractice.API.Handlers
{
    public static class ResponseHandler
    {
        public static Dictionary<string, object> BadRequest(string message = "bad-request")
        {
            return new() 
            {
                {"statusCode", 400 },
                {"message", message }
            };
        }

        public static Dictionary<string, object> Conflict(string message)
        {
            return new()
            {
                { "statusCode", 409},
                { "message", message }
            };
        }

        public static Dictionary<string, object> Error(int status, string message)
        {
            return new()
            {
                { "statusCode", status },
                { "message", message}
            };
        }
        public static Dictionary<string, object> NotFound(string message = "not-found") 
        {
            return new()
            {
                { "statusCode", 404},
                { "message", message }
            };
        
        }

        public static Dictionary<string, object?> Ok<T>(T data, string message = "successful")
        {
            return new()
            {
                { "statusCode", 200},
                { "message", message},
                { "data", data}
            };
        }

        public static Dictionary<string, object> Ok<T>(IPage<T> page) where T : class
        { 
            return new()
            {
                {"statusCode", 200 },
                {"message", "successful" },
                {"totalElements", page.GetTotalElements() },
                {"totalPages", page.GetTotalPages() },
                {"numberOfElements", page.GetNumberOfElements() },
                {"pageNumber", page.GetNumber() + 1 },
                {"last", page.IsLast()},
                {"first",page.IsFirst()},
                {"offset", page.GetPageable().GetOffset()},
                {"data", page.GetContent()},
            };
        }
    }
}
