using ProjectPractice.Domain.Enums;


namespace ProjectPractice.Domain.Exceptions.Unauthorized
{
    public class BadCredentialException : UnauthorizedException
    {
        public BadCredentialException(ExceptionEnum message) : base(message) { }
    }
}
