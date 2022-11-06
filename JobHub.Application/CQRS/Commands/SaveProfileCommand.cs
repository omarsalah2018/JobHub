using JobHub.Application.Interfaces.ICustomRepo;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace JobHub.Application.CQRS.Commands
{
    public class SaveProfileCommand : IRequest<bool>
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string CallTimeFrom { get; set; }
        public string CallTimeTo { get; set; }
        public string LinkedInProfileURL { get; set; }
        public string GitHubProfileURL { get; set; }
        [Required]
        public string Comment { get; set; }

    }
    public class SaveProfileHandler : IRequestHandler<SaveProfileCommand, bool>
    {
        private readonly ICandidateRepository _candidateRepository;
        public SaveProfileHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public async Task<bool> Handle(SaveProfileCommand request, CancellationToken cancellationToken)
        {
            bool isSaved;
            var profile = await _candidateRepository.GetCandidateById(request.Id);
            if (profile == null)
                isSaved = _candidateRepository.Add(request);

            else
                isSaved = _candidateRepository.Update(request);

            return isSaved;
        }
    }
}
