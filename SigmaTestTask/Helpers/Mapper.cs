using SigmaTestTask.Entities;
using SigmaTestTask.Models;

namespace SigmaTestTask.Helpers
{
    public static class Mapper
    {
        public static Candidate Map(this CandidateDTO candidateDTO)
        {
            return new Candidate
            {
                FirstName = candidateDTO.FirstName,
                LastName = candidateDTO.LastName,
                Email = candidateDTO.Email,
                Comment = candidateDTO.Comment,
                TimeInterval = candidateDTO.TimeInterval,
                GithubUrl = candidateDTO.GithubUrl,
                LinkedinUrl = candidateDTO.LinkedinUrl,
                PhoneNumber = candidateDTO.PhoneNumber
            };
        }

        public static Candidate Map(this Candidate candidateToUpdate, Candidate candidate)
        {
            candidateToUpdate.PhoneNumber = candidate.PhoneNumber;
            candidateToUpdate.TimeInterval = candidate.TimeInterval;
            candidateToUpdate.Comment = candidate.Comment;
            candidateToUpdate.FirstName = candidate.FirstName;
            candidateToUpdate.LastName = candidate.LastName;
            candidateToUpdate.GithubUrl = candidate.GithubUrl;
            candidateToUpdate.LinkedinUrl = candidate.LinkedinUrl;

            return candidateToUpdate;
        }
    }
}
