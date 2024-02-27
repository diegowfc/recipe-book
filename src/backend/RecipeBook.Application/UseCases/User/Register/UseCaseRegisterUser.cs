using RecipeBook.Communication.Request;
using RecipeBook.Exceptions.ExceptionBase;

namespace RecipeBook.Application.UseCases.User.Register;

public class UseCaseRegisterUser
{
    private void Validate(UserRegistrationRequestJSON request)
    {
        var validator = new UseCaseRegisterValidation();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(err => err.ErrorMessage).ToList();
            throw new ValidationErrorsExceptions(errorMessages);
        }
    }

    public async Task Register(UserRegistrationRequestJSON request)
    {
        Validate(request);
    }

    
}
