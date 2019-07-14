using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quartz.Impl;
using Quartz.NET_Demo.Services.Jobs;

namespace Quartz.NET_Demo
{
    public partial class DemoForm : Form
    {
        /// <summary>
        /// 调度器
        /// </summary>
        IScheduler scheduler;

        /// <summary>
        /// 调度器工厂
        /// </summary>
        ISchedulerFactory factory;

        public DemoForm()
        {
            this.InitializeComponent();

            this.factory = new StdSchedulerFactory();
            this.scheduler = this.factory.GetScheduler().Result;
            this.scheduler.Start();

            IJobDetail job = JobBuilder.Create()
                .OfType<DateTimeJob>()
                .WithIdentity("作业1", "分组1")
                .WithDescription("我是分组1里的作业1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("触发器1", "分组1")
                .WithDescription("我是分组1里的触发器1")
                .WithCronSchedule("0/5 * * * * ?")
                .Build();

            this.scheduler.ScheduleJob(job, trigger);
            this.scheduler.Start();
        }
    }
}
