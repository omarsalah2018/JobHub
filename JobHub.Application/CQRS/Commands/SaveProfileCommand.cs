using JobHub.Application.Dtos;
using JobHub.Application.Interfaces.ICustomRepo;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace JobHub.Application.CQRS.Commands
{
    public class SaveProfileCommand : IRequest<CandidateDto>
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
    public class SaveProfileHandler : IRequestHandler<SaveProfileCommand, CandidateDto>
    {
        private readonly ICandidateRepository _candidateRepository;
        public SaveProfileHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<CandidateDto> Handle(SaveProfileCommand request, CancellationToken cancellationToken)
        {

            var profile = await _candidateRepository.GetCandidateById(request.Id);
            if (profile == null)
                _candidateRepository.Add(request);

            else
                _candidateRepository.Update(request);

            CandidateDto candidateDto = new CandidateDto();

            return candidateDto;

        }
    }
}
