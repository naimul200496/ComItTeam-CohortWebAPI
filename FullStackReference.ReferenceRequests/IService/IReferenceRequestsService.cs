// methods related to managing reference requests,
// such as creating a reference request, getting reference requests, and handling mentor-specific requests.
public interface IReferenceRequestService
{
    Task<string> CreateReferenceRequest(ReferenceRequestDto model);
    Task<IEnumerable<ReferenceRequestDto>> GetReferenceRequests();
    Task<IEnumerable<ReferenceRequestDto>> GetMentorReferenceRequests(int mentorId);
    Task<UserDataDto> GetCurrentUserData();

}
