using AngleOk.Web.Repositories.Abstract;
using Data.AngleOk.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace AngleOk.Web.Repositories.EntityFramework
{
    public class EfTextFieldsRepository(AngleOkContext context) : ITextFieldsRepository
    {
        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }

        public TextField? GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public TextField? GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public void SaveTextField(TextField entity)
        {
            entity.DateAdded = DateTime.UtcNow;
            context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTextField(Guid id)
        {
            var field = GetTextFieldById(id);
            if (field != null)
            {
                context.TextFields.Remove(field);
                context.SaveChanges();
            }
        }
    }
}
