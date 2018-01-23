using System;
using System.Threading.Tasks;

namespace Request.Net
{
    public interface IRequestService
    {
        Task<Request> GetCompleteRequestById(string requestId);
        Task<Request> GetCompleteRequestByTransactionHash(string transactionHash);
    }
}
