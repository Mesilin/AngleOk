using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public interface IClientsRepository
    {
        IQueryable<Client> GetAll();
        Client? GetClientById(Guid clientId);
        void SaveClient(Client client);
        void DeleteClient(Guid clientId);
    }
}
