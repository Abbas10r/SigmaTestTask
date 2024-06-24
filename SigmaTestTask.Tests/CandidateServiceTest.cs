using NUnit.Framework;
using SigmaTestTask.Entities;
using SigmaTestTask.Repositories.Interfaces;
using Moq;
using SigmaTestTask.Services;

namespace SigmaTestTask.Tests
{
    public class CandidateServiceTest
    {
        private Mock<ICandidateRepository> _candidateRepositoryMock;
        private CandidateService _candidateService;

        [SetUp]
        public void Setup()
        {
            _candidateRepositoryMock = new Mock<ICandidateRepository>();
            _candidateService = new CandidateService(_candidateRepositoryMock.Object);
        }

        [Test]
        public async Task CreateOrUpdateCandidate_ShouldCreateCandidate()
        {
            // Arrange
            var candidate = new Candidate { Email = "abbastktL@gmail.com" };
            CancellationToken cancellationToken = new CancellationToken();
            _candidateRepositoryMock.Setup(repo => repo.GetCandidateByEmailAsync(candidate.Email, cancellationToken))
                                    .ReturnsAsync((Candidate)null);
            _candidateRepositoryMock.Setup(repo => repo.CreateCandidateAsync(candidate, cancellationToken))
                                    .ReturnsAsync(candidate);

            // Act
            var result = await _candidateService.CreateOrUpdateCandidateAsync(candidate, cancellationToken);

            // Assert
            Assert.AreEqual(candidate, result);
            _candidateRepositoryMock.Verify(repo => repo.CreateCandidateAsync(candidate, cancellationToken), Times.Once);
            _candidateRepositoryMock.Verify(repo => repo.UpdateCandidateAsync(It.IsAny<Candidate>(), cancellationToken), Times.Never);
        }

        [Test]
        public async Task CreateOrUpdateCandidate_ShouldUpdateCandidate()
        {
            // Arrange
            var existingCandidate = new Candidate { Email = "abbastktL@gmail.com" };
            var updatedCandidate = new Candidate { Email = "abbastktL@gmail.com", FirstName = "Abbas" };
            CancellationToken cancellationToken = new CancellationToken();
            _candidateRepositoryMock.Setup(repo => repo.GetCandidateByEmailAsync(existingCandidate.Email, cancellationToken))
                                    .ReturnsAsync(existingCandidate);
            _candidateRepositoryMock.Setup(repo => repo.UpdateCandidateAsync(It.IsAny<Candidate>(), cancellationToken))
                                    .ReturnsAsync(updatedCandidate);

            // Act
            var result = await _candidateService.CreateOrUpdateCandidateAsync(updatedCandidate, cancellationToken);

            // Assert
            Assert.AreEqual(updatedCandidate, result);
            _candidateRepositoryMock.Verify(repo => repo.CreateCandidateAsync(It.IsAny<Candidate>(), cancellationToken), Times.Never);
            _candidateRepositoryMock.Verify(repo => repo.UpdateCandidateAsync(It.IsAny<Candidate>(), cancellationToken), Times.Once);
        }
    }
}