using System;

namespace School.Common.Utils.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception GetInnerException(this Exception ex)
        {
            return ex.InnerException != null
                ? ex.InnerException.GetInnerException()
                : ex;
        }
    }
}
