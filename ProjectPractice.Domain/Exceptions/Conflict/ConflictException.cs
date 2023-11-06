using ProjectPractice.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Exceptions.Conflict
{
    public class ConflictException : CustomException
    {
        public ConflictException(ExceptionEnum message) : base(message) { }
    }
}
