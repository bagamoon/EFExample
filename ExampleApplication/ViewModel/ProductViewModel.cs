using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleApplication.ViewModel
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public string SupplierName { get; set; }

        public int ReorderLevel { get; set; }

    }
}
