using Microsoft.EntityFrameworkCore;
using SigmaTestTask.Context;
using SigmaTestTask.Entities;
using SigmaTestTask.Repositories.Interfaces;

namespace SigmaTestTask.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly CandidatesContext _context;

        public CandidateRepository(CandidatesContext context)
        {
            _context = context;
        }
        public async Task<Candidate> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
            return candidate;
        }

        public async Task<Candidate> CreateCandidateAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            await _context.Candidates.AddAsync(candidate, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return candidate;
        }

        public async Task<Candidate> UpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken)
        {
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync(cancellationToken);
            return candidate;
        }
    }
}
