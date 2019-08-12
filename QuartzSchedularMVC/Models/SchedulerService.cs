using Quartz;
using Quartz.Impl;
using System;
using System.Configuration;
namespace QuartzSchedularMVC.Models
{
    public class SchedulerService
    {
        private static readonly string ScheduleCronExpression = ConfigurationManager.AppSettings["SchedularService"];
        public static async System.Threading.Tasks.Task StartAsync()
        {
            try
            {
                var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                if (!scheduler.IsStarted)
                {
                    await scheduler.Start();
                }
                var job = JobBuilder.Create<TaskService>()
                    .WithIdentity("ExecuteTaskServiceCallJob1", "group1")
                    .Build();
                var trigger = TriggerBuilder.Create()
                    .WithIdentity("ExecuteTaskServiceCallTrigger1", "group1")
                    .WithCronSchedule(ScheduleCronExpression)
                    .Build();
                await scheduler.ScheduleJob(job, trigger);
            }
            catch (Exception ex)
            {

            }
        }
    }
}