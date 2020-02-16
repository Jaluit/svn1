using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEMO.Library
{ 

    class SalaryService
    {
        private ISalaryFormula _SalaryFormula;
        public SalaryService(ISalaryFormula SalaryFormula)
        {
            _SalaryFormula = SalaryFormula;
        }

        public double Calculate(double BasicSalary, int PrivateOffHours, int OverOffHours)
        {
            return _SalaryFormula.Execute(BasicSalary, PrivateOffHours, OverOffHours);
        }
    }

    class SalaryFormula : ISalaryFormula
    {
        public double Execute(double BasicSalary, int PrivateOffHours, int OverOffHours)
        {
            //薪資=基本薪-扣薪假+加班時數
            return BasicSalary - (BasicSalary/30/8* PrivateOffHours)+(BasicSalary / 30/8 * OverOffHours * 1.33);
        } 
    }

    class BossSalaryFormula : ISalaryFormula
    {
        public double Execute(double BasicSalary, int PrivateOffHours, int OverOffHours)
        {
            //主管責任制+主管加給
            return BasicSalary - (BasicSalary / 30/8 * PrivateOffHours) + 5000;
        }
    }
     
    public interface ISalaryFormula
    {        
        double Execute(double BasicSalary, int PrivateOffHours, int OverOffHours);
    }
}