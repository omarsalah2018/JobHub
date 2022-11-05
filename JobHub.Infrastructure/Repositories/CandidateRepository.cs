using JobHub.Application.CQRS.Commands;
using JobHub.Application.Interfaces.ICustomRepo;
using JobHub.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace JobHub.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        public bool Add(SaveProfileCommand candidate)
        {
            var added = CSVHelper.WriteData(candidate);
            return added;

        }
        public async Task<Candidate> GetCandidateById(string id)
        {
            var candidates = CSVHelper.LoadCSVData();

            var candidate = candidates.Where(i => i.Id == id).SingleOrDefault();
            return candidate;
        }

        public bool Update(SaveProfileCommand command)
        {
            return CSVHelper.UpdateRow(command);
        }
    }
}
