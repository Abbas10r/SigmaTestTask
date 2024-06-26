﻿using SigmaTestTask.Entities;

namespace SigmaTestTask.Repositories.Interfaces
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateByEmailAsync(string email, CancellationToken cancellationToken);
        Task<Candidate> CreateCandidateAsync(Candidate candidate, CancellationToken cancellationToken);
        Task<Candidate> UpdateCandidateAsync(Candidate candidate, CancellationToken cancellationToken);
    }
}
