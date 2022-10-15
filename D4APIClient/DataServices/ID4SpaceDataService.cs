using D4APIClient.Dtos;

namespace D4APIClient.DataServices
{
    public interface ID4SpaceDataService
    {
        Task<D4SpaceDto[]> GetAllSpaces();
    }
}
