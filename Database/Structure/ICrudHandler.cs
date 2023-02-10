namespace TmTaskManagerApi.Database.Structure
{
    public interface ICrudHandler<T>
    {
        public Task<List<T>> GetAllEntryAsync();

        public Task<T?> GetSpecificEntryAsync(int id);

        public Task<bool> AddEntryAsync(T taskdata);

        public Task<bool> UpdateEntryAsync(T taskdata);

        public Task<bool> DeleteEntryAsync(int id);
    }
}
