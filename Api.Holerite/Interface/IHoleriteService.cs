using Api.Holerite.Models;

namespace Api.Holerite.Interface
{
    public interface IHoleriteService
    {
        Task<IEnumerable<Models.Holerite>> GetHolerite();
        Task<Models.Holerite> GetHoleriteById(int id);
        Task<Models.Holerite> CreateHolerite(Models.Holerite product);
        Task<Models.Holerite> UpdateHolerite(int id, Models.Holerite product);
        Task DeleteHolerite(int id);
    }
}
