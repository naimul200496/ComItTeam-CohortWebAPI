using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FullStackReference.ReferenceRequests.Data;
using FullStackReference.ReferenceRequests.Models;


namespace FullStackReference.ReferenceRequests.Data
{
    public class ReferenceRequestsRepository : IReferenceRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public ReferenceRequestsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateReferenceRequest(ReferenceRequest referenceRequest)
        {
            _context.ReferenceRequest.Add(referenceRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReferenceRequest>> GetReferenceRequests()
        {
            return await _context.ReferenceRequest.ToListAsync();
        }

        public async Task<IEnumerable<ReferenceRequest>> GetMentorReferenceRequests(int mentorId)
        {
            return await _context.ReferenceRequest
                .Where(request => request.MentorId == mentorId)
                .ToListAsync();
        }
    }
}
