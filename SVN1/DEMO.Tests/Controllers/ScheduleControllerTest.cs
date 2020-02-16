using System;
using System.Collections.Generic;
using DEMO.Controllers;
using DEMO.Models;
using DEMO.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DEMO.Tests.Controllers
{
    [TestClass]
    public class ScheduleControllerTest
    {
        [TestMethod]
        public void S1_Schedule_ins()
        {
            SalaryController controller = new SalaryController();
            Schedule schedule = new Schedule();
            schedule.ID = 999;
            schedule.Hours = 1;
            schedule.Type = "2";

            controller.Post(schedule);
        }

        [TestMethod]
        public void S2_Schedule_sel()
        {
            SalaryController controller = new SalaryController();

            List<Schedule> result = controller.Get();
            Schedule result2 = result.Find(x => x.ID == 999);
            Assert.IsNotNull(result2);
        }

        [TestMethod]
        public void S3_Schedule_upd()
        {
            SalaryController controller = new SalaryController();
            Schedule schedule = new Schedule();
            schedule.ID = 999;

            List<Schedule> result = ScheduleServices.sel(schedule);

            foreach (Schedule vr in result)
            {
                vr.Hours = 777;
                controller.Put(vr);
            }

            result = controller.Get();
            schedule = result.Find(x => x.ID == 999);
        
            Assert.AreEqual(777, schedule.Hours);
         
        }

        [TestMethod]
        public void S4_Schedule_del()
        {
            SalaryController controller = new SalaryController();
            Schedule schedule = new Schedule();
            schedule.ID = 999;

            List<Schedule> result = ScheduleServices.sel(schedule);
            foreach (Schedule vr in result)
            {
                controller.Delete(vr.Inum);
            }

            result = controller.Get();
            schedule = result.Find(x => x.ID == 999);
            Assert.IsNull(schedule);
        }

        //[TestMethod]
        //public void Schedule_sel()
        //{
        //    SalaryController controller = new SalaryController();

        //    List<Schedule> result = controller.Get();
        //    Schedule result2 = result.Find(x => x.ID == 999);
        //    Assert.IsNotNull(result2);
        //}
    }
}
