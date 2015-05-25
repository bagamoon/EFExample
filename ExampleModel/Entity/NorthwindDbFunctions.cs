using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ExampleModel.Entity
{
    public class NorthwindDbFunctions
    {
        [DbFunction("NorthwindModel.Store", "fn_retEmployeeName")]
        public static string fn_retEmployeeName(int employeeId)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
    }
}
