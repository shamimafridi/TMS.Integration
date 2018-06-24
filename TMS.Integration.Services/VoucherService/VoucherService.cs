using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TMS.Common.Enum;
using TMS.Common.ServicePattren;
using TMS.Integration.Services.Common.Dto;
using TMS.Integration.Services.VoucherService.Dto;
using TMS.Integration.Storage;

namespace TMS.Integration.Services.VoucherService
{
    public class VoucherPostService : PostServiceHandler<PostResponse>
    {

        public override async Task<PostResponse> AsyncSetter(string token)
        {

            using (var context = new Storage.TMSEntities())
            {
                var coa = context.GL_GetCOACombineTransactionVW.ToList();
                foreach (var voucher in context.Vouchers.ToList())
                {
                    var detailVoucher = VoucherDetailBodyRequests(voucher, coa);

                    var body = new VoucherPostRequestBody
                    {

                        branch = new GeneralDto { id = voucher.Branch.RefNo, name = voucher.Branch.BranchDescription },
                        desc = voucher.Description,
                        date = voucher.VoucherDate,
                        voucher_detail = detailVoucher
                    };

                    await (string.IsNullOrEmpty(voucher.RefNo) ?
                        Create(body, voucher) :
                        Update(voucher.RefNo, body,  voucher));

                    context.SaveChanges();
                }
                return new PostResponse
                {
                    NoOfRecordEffected = 10,
                    Status = ResponseStatus.Ok.ToString()
                };

            }
            //Storage.Voucher
        }

        private static List<VoucherDetailBodyRequest> VoucherDetailBodyRequests(Voucher local, IEnumerable<GL_GetCOACombineTransactionVW> coa)
        {
            var detailVoucher = (from d in local.VoucherDetails
                                 join c in coa on d.GLCode.Trim() equals c.GLCode.Trim()
                                 where  d.BranchCode.Trim() == local.BranchCode.Trim()
                                       && d.VoucherNature.Trim() == local.VoucherNature.Trim()
                                       && d.VoucherNo.Trim() == local.VoucherNo.Trim()
                                 select new VoucherDetailBodyRequest
                                 {
                                     coa = new GeneralDto { id = c.RefNo, name = c.GLDescription },
                                     credit = d.Credit,
                                     debit = d.Debit,
                                     reference = d.Reference,
                                     narration = d.Narration
                                 }).ToList();
            return detailVoucher;
        }


        private async Task Update(string id,  VoucherPostRequestBody body, Voucher voucher)
        {

            var response = _client.PutAsJsonAsync("api/Voucher/" + id, body).Result;
            response.EnsureSuccessStatusCode();
            var contentResult = await response.Content.ReadAsAsync<VoucherPostResponse>();
            voucher.RefNo = contentResult._id;
            voucher.UpdatedOn = DateTime.Now;
            
        }



        private async Task Create(VoucherPostRequestBody body, Voucher voucher)
        {

            var response = _client.PostAsJsonAsync("api/Voucher", body).Result;
            response.EnsureSuccessStatusCode();
            var contentResult = await response.Content.ReadAsAsync<VoucherPostResponse>();
            voucher.RefNo = contentResult._id;
            voucher.UpdatedOn = DateTime.Now;
            
        }
    }

}

