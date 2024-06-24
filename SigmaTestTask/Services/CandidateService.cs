using SigmaTestTask.Entities;
using SigmaTestTask.Helpers;
using SigmaTestTask.Repositories.Interfaces;
using SigmaTestTask.Services.Interfaces;

namespace SigmaTestTask.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<Candidate> CreateOrUpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            var existingCandidate = await _candidateRepository.GetCandidateByEmailAsync(candidate.Email, cancellationToken);

            if (existingCandidate is null)
            {
                return await _candidateRepository.CreateCandidateAsync(candidate, cancellationToken);
            }

            existingCandidate = Mapper.Map(existingCandidate, candidate);

            return await _candidateRepository.UpdateCandidateAsync(existingCandidate, cancellationToken);
        }
    }
}
