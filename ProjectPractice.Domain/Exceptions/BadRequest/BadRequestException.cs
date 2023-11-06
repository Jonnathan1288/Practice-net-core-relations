using ProjectPractice.Domain.Enums;

namespace ProjectPractice.Domain.Exceptions.BadRequest
{
    public class BadRequestException :CustomException
    {
        public BadRequestException(ExceptionEnum message) : base(message) { 
        }
    }
}
