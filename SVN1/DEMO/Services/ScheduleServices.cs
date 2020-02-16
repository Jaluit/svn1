using DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEMO.Services
{
    public class ScheduleServices : BaseSQL
    {
       
        public static List<Schedule> sel()
        {
            
            var schedule = Db.Schedule.Select(a => a);                   
            return schedule.ToList();
        }
        public static void ins(Schedule schedule)
        {
            
            Db.Schedule.Add(schedule);
            Db.SaveChanges();
        }

        public static void upd(Schedule schedule)
        {            
            Schedule edit = Db.Schedule.First(c => c.Inum == schedule.Inum);
            edit.Type = schedule.Type;
            edit.Hours = schedule.Hours;
            Db.SaveChanges();
        }

        public static void del(int id)
        {
            
            Schedule schedule = Db.Schedule.Single(x => x.ID == id);
            Db.Schedule.Remove(schedule);
            Db.SaveChanges();
        }
    }
}