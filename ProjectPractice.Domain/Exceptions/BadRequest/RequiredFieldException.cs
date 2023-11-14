using ProjectPractice.Domain.Enums;

namespace ProjectPractice.Domain.Exceptions.BadRequest
{
    public class RequiredFieldException: BadRequestException
    {
        public RequiredFieldException(ExceptionEnum message) :base(message){ }
    }
}
