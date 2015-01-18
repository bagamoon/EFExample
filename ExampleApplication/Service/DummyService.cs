using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleApplication.ViewModel;

namespace ExampleApplicationCSharp.Service
{
    public class DummyService
    {
        public void DoSomething()
        { 
        
        }

        public void DoSomethingWithArgs(int num)
        { 
        
        }

        public void DoSomethingWithComplexArgs(ProductViewModel vm)
        {

        }

        public ProductViewModel BadPerformanceMethod(string fundId, string currency, string fundName)
        {
            //睡四秒模擬效能不佳的method
            System.Threading.Thread.Sleep(4000);
            return new ProductViewModel() { ProductName = "product", CategoryName = "category", SupplierName = "supplier", ReorderLevel = 10 };
        }

        public ProductViewModel FailedMethod(string fundId, string currency, string fundName)
        {
            //拋出錯誤模擬執行失敗
            throw new Exception();            
        }
    }
}
