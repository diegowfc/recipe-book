using RecipeBook.Communication.Request;

namespace RecipeBook.Application.UseCases.User.Register;

public class UseCaseRegisterUser
{
    private void Validate(UserRegistrationRequestJSON request)
    {
        var validator = new UseCaseRegisterValidation();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var erroMessages = result.Errors.Select(err => err.ErrorMessage);
            throw new Exception();
        }
    }

    public Task Register(UserRegistrationRequestJSON request)
    {
        
    }

    
}
