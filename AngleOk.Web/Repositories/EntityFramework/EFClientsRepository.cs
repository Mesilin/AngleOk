using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.EntityFramework
{
    public class EfClientsRepository(AngleOkContext context) : IClientsRepository
    {
        public IQueryable<Client> GetAll() {return context.Clients; }
        
        public Client? GetClientByName(string name)
        {
            return context.Clients.FirstOrDefault(x => x.Email == name);
        }

        public Client? GetClientById(Guid id)
        {
            return context.Clients.FirstOrDefault(x => x.Id == id);
        }
        public void SaveClient(Client client)
        {
            if(client.Id == default)
            {
                client.Id = Guid.NewGuid();
                context.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
                context.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteClient(Guid clientId)
        {
            var client = GetClientById(clientId);
            if (client != null)
            {
                context.Clients.Remove(client);
            }
        }
    }
}
