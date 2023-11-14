using ProjectPractice.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Exceptions.Unauthorized
{
    public class UnauthorizedException: CustomException
    {
        public UnauthorizedException(ExceptionEnum message) : base(message) { }
    }
}
