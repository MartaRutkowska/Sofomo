namespace Sofomo.CQRS.Repositories
{
    public interface IRepository
    {
        public Task SaveChangesAsync();
    }
}
