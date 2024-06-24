using SigmaTestTask.Entities;

namespace SigmaTestTask.Services.Interfaces
{
    public interface ICandidateService
    {
        Task<Candidate> CreateOrUpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken);
    }
}
