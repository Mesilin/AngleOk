using Data.AngleOk.Model.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AngleOkContext db = new AngleOkContext())
            {
                Person user1 = new Person { 
                    PersonId=Guid.NewGuid(),
                    FirstName = "Евгений", 
                    Patronymic = "Владимирович", 
                    LastName="Месилин"};
                
                db.Persons.AddRange(user1);
                db.SaveChanges();
            }

            using (AngleOkContext db = new AngleOkContext())
            {
                var users = db.Persons.ToList();
                Console.WriteLine("Users list:");
                foreach (Person p in users)
                {
                    Console.WriteLine($"{p.FirstName.Substring(0,1)}.{p.Patronymic.Substring(0, 1)}. {p.LastName}");
                }
            }
        }
    }
}