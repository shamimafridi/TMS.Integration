using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TMS.Integration.Services.CustomerService.CustomerService;

namespace TMS.Integration.Services.CustomerService
{
   public interface ICustomerService
    {
         Task<AuthResponse> AsyncSetter();
    }
}
