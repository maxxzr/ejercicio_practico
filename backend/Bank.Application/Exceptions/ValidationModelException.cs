using FluentValidation.Results;

namespace Bank.Application.Exceptions
{
    public class ValidationModelException : Exception
    {
        public ValidationModelException(List<ValidationFailure> errors)
            : base(string.Join("\n", errors.Select(x => x.ErrorMessage)))
        {
        }
    }
}
