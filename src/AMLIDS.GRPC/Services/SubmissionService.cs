using System.Threading.Tasks;

using Grpc.Core;

using Microsoft.Extensions.Logging;

namespace AMLIDS.gRPC
{
    public class SubmissionService : Submission.SubmissionBase
    {
        private readonly ILogger<SubmissionService> _logger;

        public SubmissionService(ILogger<SubmissionService> logger)
        {
            _logger = logger;
        }

        public override Task<SubmissionResponse> SubmitNetworkTraffic(SubmissionRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SubmissionResponse
            {
                Message = string.Empty,
                Success = true
            });
        }
    }
}