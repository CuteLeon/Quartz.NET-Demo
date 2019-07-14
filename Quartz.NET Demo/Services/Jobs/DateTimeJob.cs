using System;
using System.Threading.Tasks;

namespace Quartz.NET_Demo.Services.Jobs
{
    public class DateTimeJob : IJob
    {
        public DateTimeJob()
            => Console.WriteLine($"构造作业：{this.GetType().Name} ({this.GetHashCode().ToString("X")})");

        /// <summary>
        /// 执行作业
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync($"当前时间：{DateTime.Now.ToLongTimeString()}");
        }
    }
}
