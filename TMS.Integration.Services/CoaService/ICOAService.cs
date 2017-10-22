using System.Threading.Tasks;
using TMS.Integration.Services.CoaService.Dto;

namespace TMS.Integration.Services.COAService
{
    public interface ICoaService
    {
        Task<Services.CoaService.Dto.CoaPostResponse> AsyncSetter(string token);
    }
  
}
