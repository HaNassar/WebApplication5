using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public interface IStore
    {
        SubmissionResponse SaveEmployee(Employee employee);
       
    }
}
