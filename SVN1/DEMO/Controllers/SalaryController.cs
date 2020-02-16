using DEMO.Models;
using DEMO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DEMO.Controllers
{
    public class SalaryController : ApiController
    {
 
        public List<Schedule> Get()
        {
            //Schedule schedule = new Schedule();
            //schedule.Inum = 2;
            //schedule.Hours = 23;
            //schedule.Type = "2";
            //ScheduleServices.del(schedule.Inum);
   
            return ScheduleServices.sel();
        }

        public void Post(Schedule schedule)
        {
            ScheduleServices.ins(schedule);
        }

        public void Put(Schedule schedule)
        {
            ScheduleServices.upd(schedule);
        }

        public void Delete(int id)
        {
            ScheduleServices.del(id);
        }
    }
}
