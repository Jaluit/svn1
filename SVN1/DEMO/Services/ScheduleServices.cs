using DEMO.Library;
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


        public static List<SalaryViewModels> getSalary(short id)
        {
            var schedule = Db.ve_Salary.Select(a => a);
            
                    schedule = schedule.Where(x => x.ID == id);
 
  
                 

            List<SalaryViewModels> Salary = new List<SalaryViewModels>();

            foreach (ve_Salary tmp in schedule.ToList())
            {
                SalaryService SC = new SalaryService(new SalaryFormula());

                if(tmp.Category == "主管")
                    SC = new SalaryService(new BossSalaryFormula());

                Salary.Add(new SalaryViewModels
                {
                    ID = tmp.ID,
                    Name = tmp.Name,
                    BasicSalary = tmp.BasicSalary,
                    Category = tmp.Category,
                    OverOffHours = tmp.OverOffHours,
                    PrivateOffHours = tmp.PrivateOffHours,
                    WelfareOffHours = tmp.WelfareOffHours,
                    getSalary = (int)SC.Calculate((int)tmp.BasicSalary, (int)tmp.PrivateOffHours, (int)tmp.OverOffHours)

                 });
            }
            


            return Salary.ToList();
        }


    }
}