namespace RecipeBook.Exceptions.ExceptionBase
{
    public class ValidationErrorsExceptions : RecipeBookException
    {
        public List<string> Errors { get; set; }

        public ValidationErrorsExceptions(List<string> errors)
        {
            Errors = errors;
        }
    }
}
