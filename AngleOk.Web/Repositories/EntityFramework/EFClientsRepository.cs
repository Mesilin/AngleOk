using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;

namespace AngleOk.Web.Repositories.EntityFramework
{
    public class EFClientsRepository: IClientsRepository
    {
        private readonly AngleOkContext context;
        public EFClientsRepository(AngleOkContext context) { this.context = context; }
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
            if(client.Id == null)
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
            context.Clients.Remove(GetClientById(clientId));
        }
    }
}
