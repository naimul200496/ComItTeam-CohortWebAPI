//creating, reading, updating, or deleting reference requests in the database.

public interface IReferenceRequestRepository
{
    Task CreateReferenceRequest(ReferenceRequest referenceRequest);
    Task<IEnumerable<ReferenceRequest>> GetReferenceRequest();
    Task<IEnumerable<ReferenceRequest>> GetMentorReferenceRequest(int mentorId);

}
