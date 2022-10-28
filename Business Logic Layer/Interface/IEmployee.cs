
using System.ComponentModel;
using ModelLayer;
namespace Business_Logic_Layer
    
{
    public interface IEmployee
    {
        public List<EmployeeRegistration> Get();
        EmployeeRegistration Get(string username);
        void Post(EmployeeRegistration empl);
       
        void  Delete(string UserName);
        void Edit(EmployeeRegistration emp1);

    }
}