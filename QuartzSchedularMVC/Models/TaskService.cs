using Quartz;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
namespace QuartzSchedularMVC.Models
{
    public class TaskService : IJob
    {
        public static readonly string SchedulingStatus = ConfigurationManager.AppSettings["TaskService"];
        public Task Execute(IJobExecutionContext context)
        {
            var task = Task.Run(() =>
            {
                if (SchedulingStatus.Equals("ON"))
                {
                    try
                    {
                        string path = "C:\\Sample.txt";
                        using (StreamWriter writer = new StreamWriter(path, true))
                        {
                            writer.WriteLine(string.Format("Quartz Schedular Called on "+ DateTime.Now.ToString("dd /MM/yyyy hh:mm:ss tt")));
                            writer.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            });
            return task;
        }
    }
}