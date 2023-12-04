using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.Abstract
{
    public interface IClientsRepository
    {
        IQueryable<Client> GetAll();
        Client GetClientById(Guid ClientId);
        void SaveClient(Client client);
        void DeleteClient(Guid ClientId);
    }
}
