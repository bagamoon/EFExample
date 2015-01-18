using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Validation;

namespace LibDataAccess.Extension
{
    public static class DbEntityValidationExceptionExtension
    {
        public static string ToTraceString(this DbEntityValidationException ex)
        {
            var exceptions = ex.EntityValidationErrors.Select(e => new
            {
                Entry = e.Entry,
                Errors = e.ValidationErrors.Select(err => string.Format("Property: '{0}', Value: '{1}', Message: {2}",
                                                                             err.PropertyName,
                                                                             e.Entry.CurrentValues[err.PropertyName],
                                                                             err.ErrorMessage))
            });

            string traceString = string.Join(", ", exceptions.Select(e => string.Format("[{0}] {1}",
                                                                     e.Entry.Entity.GetType().Name,
                                                                     string.Join("\r\n", e.Errors))));

            return traceString;
        }

    }
}
