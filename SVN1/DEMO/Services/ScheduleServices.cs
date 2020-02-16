using DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEMO.Services
{
    public class ScheduleServices : BaseSQL
    {
       
        public static List<Schedule> sel(Schedule query = null)
        {
            
            var schedule = Db.Schedule.Select(a => a);    
            if(query != null)
            {
                if (query.ID > 0)
                    schedule = schedule.Where(x => x.ID == query.ID);

                if (query.Inum > 0)
                    schedule = schedule.Where(x => x.Inum == query.Inum);

            }
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
            Schedule schedule = Db.Schedule.Single(x => x.Inum == id);
            Db.Schedule.Remove(schedule);
            var s = Db.SaveChanges();
      
        }
    }
}