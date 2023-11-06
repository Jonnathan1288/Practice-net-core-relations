using ProjectPractice.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Exceptions.Forbidden
{
    public class ForbiddenException: CustomException
    {
        public ForbiddenException (ExceptionEnum message) : base(message) { }
    }
}
