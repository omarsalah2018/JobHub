using JobHub.Application.CQRS.Commands;
using JobHub.Domain.Entities;
using System.Threading.Tasks;

namespace JobHub.Application.Interfaces.ICustomRepo
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateById(string id);
        bool Add(SaveProfileCommand candidate);
        bool Update(SaveProfileCommand candidate);
    }
}
