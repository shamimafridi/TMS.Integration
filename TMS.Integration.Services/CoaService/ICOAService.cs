using System.Threading.Tasks;

namespace TMS.Integration.Services.COAService
{
   public interface ICoaService
    {
         Task<Services.CoaService.Dto.CoaPostResponse> AsyncSetter();
    }
}
