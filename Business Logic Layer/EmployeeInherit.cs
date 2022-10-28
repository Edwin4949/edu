using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using Repository_Layer;

namespace Business_Logic_Layer
{
    public class EmployeeInherit:IEmployee
    {
        private readonly AppDBcontext _Idbcontext;
        public EmployeeInherit(AppDBcontext idbcontext)
        {
            _Idbcontext = idbcontext;
        }

        public List<EmployeeRegistration> Get()
        {
            return (_Idbcontext.Employee.ToList());
        }       

        public List<EmployeeRegistration> Edit()
        {
            return (_Idbcontext.Employee.ToList());
        }

            public void Post(EmployeeRegistration empl)
        {
            _Idbcontext.Employee.Add(empl);
            _Idbcontext.SaveChanges();
            }
        public void Delete(string UserName)
        {
            EmployeeRegistration employeeRegistration=_Idbcontext.Employee.FirstOrDefault(i => i.UserName == UserName);
            if (employeeRegistration != null)
            {
                _Idbcontext.Remove(employeeRegistration);
                _Idbcontext.SaveChanges();
            }
        }
        public EmployeeRegistration Get(string UserName)
        {
            return _Idbcontext.Employee.FirstOrDefault(i => i.UserName == UserName);
        }
        public void Edit(EmployeeRegistration empe)
        {
            EmployeeRegistration emplo = _Idbcontext.Employee.FirstOrDefault(i => i.UserName == empe.UserName);
            if (emplo != null)
            {
                _Idbcontext.Employee.Remove(emplo);
                _Idbcontext.Employee.Add(empe);
                _Idbcontext.SaveChanges();
            }
        }
    }
}
