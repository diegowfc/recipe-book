using FluentValidation;
using RecipeBook.Communication.Request;
using RecipeBook.Exceptions;
using System.Text.RegularExpressions;

namespace RecipeBook.Application.UseCases.User.Register;

public class UseCaseRegisterValidation: AbstractValidator<UserRegistrationRequestJSON>
{
    public UseCaseRegisterValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ExceptionInvalidMessages.EmptyInputName);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ExceptionInvalidMessages.EmptyInputPassword);
        RuleFor(x => x.Email).NotEmpty().WithMessage(ExceptionInvalidMessages.EmptyInputEmail);
        RuleFor(x => x.Phone).NotEmpty().WithMessage(ExceptionInvalidMessages.EmptyInputPhone);
        When(x => !string.IsNullOrWhiteSpace(x.Email), IsEmailValid);
        When(x => !string.IsNullOrWhiteSpace(x.Password), IsPasswordValid);
        When(x => !string.IsNullOrWhiteSpace(x.Phone), IsPhoneValid);

    }

    private void IsEmailValid()
    {
        RuleFor(x => x.Email).EmailAddress().WithMessage(ExceptionInvalidMessages.InvalidInputEmail);
    }

    private void IsPasswordValid()
    {
        RuleFor(x => x.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ExceptionInvalidMessages.InvalidInputPassword);
    }

    private void IsPhoneValid()
    {
        RuleFor(x => x.Phone).Custom((phone, context) =>
        {
            string phoneFormat = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
            var isPhoneValid = Regex.IsMatch(phone, phoneFormat);

            if (!isPhoneValid)
                context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(phone), ExceptionInvalidMessages.InvalidInputPhone));
        });
    }
}
