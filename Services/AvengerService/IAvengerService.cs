
namespace AvengersManagement.Services.AvengerService
{
    public interface IAvengerService
    {
        Task<List<Avenger>> QueryAsync();
        Task<Avenger?> ReadAsync(int id);
        Task<Avenger> CreateAsync(Avenger request);
        Task<Avenger?> UpdateAsync(Avenger request);
        Task DeleteAsync(int id);
    }
}