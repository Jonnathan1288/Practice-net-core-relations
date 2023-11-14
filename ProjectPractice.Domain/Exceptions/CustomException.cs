
using ProjectPractice.Domain.Enums;

namespace ProjectPractice.Domain.Exceptions
{
    public class CustomException: Exception
    {
        private readonly ExceptionEnum _exceptionEnum;
        public CustomException(ExceptionEnum exceptionEnum) {
            _exceptionEnum = exceptionEnum;
        }

        public string Code
        {
            get
            {
                return _exceptionEnum switch
                {
                    ExceptionEnum.AlreadyExistShiftByemployeeAndSchedule => "already-exist-shift-employee-schedule",
                    ExceptionEnum.DateRequired => "date-is-requiered",
                    ExceptionEnum.Forbidden => "forbidden",
                    ExceptionEnum.InvalidDescription => "invalid-description",
                    ExceptionEnum.InvalidDate => "invalid-date",
                    ExceptionEnum.InvalidName => "invalid-name",
                    ExceptionEnum.InvalidObservation => "invalid-observation",
                    ExceptionEnum.InvalidPeriodicity => "invalid-periodicity",
                    ExceptionEnum.InvalidEndTimeAndStartTime => "the-end-time-must-be-greater-than-start-time",
                    ExceptionEnum.InvalidMaxCapacity => "invalid-max-capacity-at-least-one-is-required",
                    ExceptionEnum.ShiftNotFound => "shift-not-found",
                    ExceptionEnum.NotFound => "not-results-found",
                    ExceptionEnum.OperationNotAllowed => "operation-not-allowed",
                    ExceptionEnum.Unauthorized => "unauthorized",
                    ExceptionEnum.ReuieredBrandName => "brand-name-is-requiered",
                    ExceptionEnum.FieldIsRequiered => "field-is-requiered",
                    _ => _exceptionEnum.ToString(),
                } ;
            }
        }
    }
}
