using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExampleApplicationCSharp
{
    public class Counting
    {
        //定義delegate型別
        public delegate void CountingNotify(int currentNum);
        //宣告CountingNotify型別的Field
        public CountingNotify notifyHandler;

        private int currentNum = 0;

        //初始化後每兩秒會+1
        public Counting()
        {
            TaskFactory taskFactory = new TaskFactory();

            taskFactory.StartNew(() =>
            {                
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(2000);
                    Add();                    
                }
            });
        }

        private void Add()
        {
            currentNum++;
            //每次加完都以現在的值呼叫delegate
            if (notifyHandler != null)
            {
                notifyHandler(currentNum);
            }
        }
    }

    public class CountingAction
    {
        //宣告Action<int>型別的Field
        public Action<int> notifyHandler;

        private int currentNum = 0;

        //初始化後每兩秒會+1
        public CountingAction()
        {
            TaskFactory taskFactory = new TaskFactory();            

            taskFactory.StartNew(() =>
            {                
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(2000);
                    Add();                    
                }
            });
        }

        private void Add()
        {
            currentNum++;
            //每次加完都以現在的值呼叫Action
            if (notifyHandler != null)
            {
                notifyHandler(currentNum);
            }
        }
    }
}
