using System;

namespace StaffCoursework
{
    class WorkerException : Exception
    {
        public WorkerException(string message) : base(message) { }
        public WorkerException() : base("Помилка. Спроба записати неправильні дані працівника.") { }
    }
}
