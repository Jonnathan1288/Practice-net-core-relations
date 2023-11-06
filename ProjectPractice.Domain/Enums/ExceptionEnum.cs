
namespace ProjectPractice.Domain.Enums
{
    public enum ExceptionEnum: short
    {
        /// <summary>
        ///  Thrown if there already exists an shift by employee and schedule
        /// </summary>
        AlreadyExistShiftByemployeeAndSchedule,
        /// <summary>
        /// Thrown if date is required.
        /// </summary>
        DateRequired,
        /// <summary>
        /// Thrown if user try access to forbidden resource.
        /// </summary>
        Forbidden,
        /// <summary>
        /// Thrown if description is invalid.
        /// </summary>
        InvalidDescription,
        /// <summary>
        ///  Thrown if date is invalid.
        /// </summary>
        InvalidDate,
        /// <summary>
        /// Thrown if name is invalid.
        /// </summary>
        InvalidName,
        /// <summary>
        /// Thrown if observation is invalid.
        /// </summary>
        InvalidObservation,
        /// <summary>
        /// Thrown if periodicity is invalid.
        /// </summary>
        InvalidPeriodicity,
        /// <summary>
        /// Thrown if end and start time is inavlid.
        /// </summary>
        InvalidEndTimeAndStartTime,
        /// <summary>
        /// Thrown if max capacity time is inavlid.
        /// </summary>
        InvalidMaxCapacity,
        /// <summary>
        /// Thrown if not found results.
        /// </summary>
        NotFound,
        /// <summary>
        ///  Thrown if unauthorized operation.
        /// </summary>
        OperationNotAllowed,
        /// <summary>
        ///  Thrown if the shift not found.
        /// </summary>
        ShiftNotFound,
        /// <summary>
        /// Thrown if unauthorized user.
        /// </summary>
        Unauthorized,
    }
}
