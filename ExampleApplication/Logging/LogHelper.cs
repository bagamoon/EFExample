using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using log4net;
using System.Configuration;

namespace ExampleApplicationCSharp.Logging
{
    /// <summary>
    /// 使用Log4Net記錄Log, 並提供method執行時間監控API及訊息視窗API
    /// </summary>
    public static class LogHelper
    {
        private static readonly TimeSpan bound;

        private static ILog logger = LogManager.GetLogger(typeof(LogHelper).Name);

        /// <summary>
        /// 效能監測Logger, LoggerName為PerformanceMonitor
        /// </summary>
        public static ILog PerformanceLogger { get; private set; }

        /// <summary>
        /// 訊息視窗Logger, LoggerName為MessageBoxDisplayer
        /// </summary>
        public static ILog MsgBoxLogger { get; private set; }

        /// <summary>
        /// 建構子, 初始化PerformanceLogger及MsgBoxLogger
        /// 初始化執行效能容忍時間上限(預設三秒), 讀取config: PerformanceBound
        /// </summary>
        static LogHelper()
        {
            PerformanceLogger = LogManager.GetLogger("PerformanceMonitor");
            MsgBoxLogger = LogManager.GetLogger("MessageBoxDisplayer");

            string boundStr = ConfigurationManager.AppSettings["PerformanceBound"];
            int boundInt = 0;
            if (int.TryParse(boundStr, out boundInt) == false)
            {
                boundInt = 3000;
            }
            bound = new TimeSpan(0, 0, 0, 0, boundInt);
        }

        /// <summary>
        /// 嘗試執行有回傳值的method, 若執行失敗會記錄log
        /// </summary>
        /// <typeparam name="TResult">回傳值的型別</typeparam>
        /// <param name="fun">欲執行的委派</param>
        /// <returns>執行結果</returns>
        public static ExecutedResult<TResult> TryExcute<TResult>(Expression<Func<TResult>> fun)
        {
            ExecutedResult<TResult> result;

            try
            {
                result = Excute(fun);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                result = new ExecutedResult<TResult> { IsSuccess = false, Exception = ex };
            }

            return result;
        }

        /// <summary>
        /// 嘗試執行無回傳值的method, 若執行失敗會記錄log
        /// </summary>
        /// <param name="act">欲執行的委派</param>
        /// <returns>是否執行成功</returns>
        public static bool TryExcute(Expression<Action> act)
        {
            bool isSuccess = false;

            try
            {
                Excute(act);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                isSuccess = false;
            }

            return isSuccess;
        }

        /// <summary>
        /// 執行有回傳值的method
        /// </summary>
        /// <typeparam name="TResult">回傳值的型別</typeparam>
        /// <param name="fun">欲執行的委派</param>
        /// <returns>執行結果</returns>
        public static ExecutedResult<TResult> Excute<TResult>(Expression<Func<TResult>> fun)
        {
            MethodCallExpression method = fun.Body as MethodCallExpression;
            string log = GetExpressionLog(method);

            DateTime start = DateTime.Now;
            TResult result = fun.Compile()();
            LogPerformance(DateTime.Now - start, log);

            ExecutedResult<TResult> executedResult = new ExecutedResult<TResult> { IsSuccess = true, Result = result };
            return executedResult;
        }

        /// <summary>
        /// 執行無回傳值的method
        /// </summary>
        /// <param name="act">欲執行的委派</param>
        public static void Excute(Expression<Action> act)
        {
            MethodCallExpression method = act.Body as MethodCallExpression;
            string log = GetExpressionLog(method);
            
            DateTime start = DateTime.Now;
            act.Compile()();
            LogPerformance(DateTime.Now - start, log);
        }

        /// <summary>
        /// 依據執行時間是否超過容忍上限記錄log
        /// </summary>
        /// <param name="timeCost">執行時間</param>
        /// <param name="logInfo">log訊息</param>
        private static void LogPerformance(TimeSpan timeCost, string logInfo)
        {
            if (timeCost < bound)
            {
                PerformanceLogger.Info(string.Format("{0} [{1} ms]", logInfo, timeCost.TotalMilliseconds));
            }
            else
            {
                PerformanceLogger.Warn(string.Format("{0} [{1} ms]", logInfo, timeCost.TotalMilliseconds));
            }
        }

        /// <summary>
        /// 取得委派的執行method資訊, 回傳"method: class.Method()"格式的字串
        /// </summary>
        /// <param name="methodCallExpression">委派內容資訊</param>
        /// <returns>"method: class.Method()"格式的字串</returns>
        private static string GetExpressionLog(MethodCallExpression methodCallExpression)
        {
            string log = "";
            if (methodCallExpression != null)
            {
                log = string.Format("method: {0}.{1}()", methodCallExpression.Method.ReflectedType.FullName, methodCallExpression.Method.Name);
            }

            return log;
        }        
    }

    /// <summary>
    /// 執行結果
    /// </summary>
    /// <typeparam name="TResult">委派回傳值的型別</typeparam>
    public class ExecutedResult<TResult>
    {
        /// <summary>
        /// 是否執行成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 委派回傳值
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// 執行exception
        /// </summary>
        public Exception Exception { get; set; }
    }
}
