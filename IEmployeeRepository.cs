using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.model
{
   public  interface IEmployeeRepository
    {

        MyEmployee GetEmployee(int id);
        List<MyEmployee> DisplayDetails();


    }
}
