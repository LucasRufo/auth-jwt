using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Auth.Data
{
    public class Return
    {
        public bool IsValid { get { return Erros.Count() == 0; } }

        public Dictionary<string, string> Erros { get; private set; } = new Dictionary<string, string>();

        public object Objeto { get; set; }

        public Return() { }

        public Return(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
            {
                if (Erros.Any(m => m.Key == error.PropertyName) == false)
                    AddError(error.PropertyName, error.ErrorMessage);
            }
        }

        public Return(object objeto)
        {
            Objeto = objeto;
        }

        public void AddError(string key, string message) => Erros.Add(key, message);
    }
}
