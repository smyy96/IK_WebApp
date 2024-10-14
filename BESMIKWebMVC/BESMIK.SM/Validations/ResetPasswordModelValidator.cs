using BESMIK.ViewModel;
using FluentValidation;

namespace BESMIK.SM.Validations
{

    public class ResetPasswordModelValidator : AbstractValidator<ResetPasswordModel>
    {
        public ResetPasswordModelValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Lütfen şifrenizi giriniz.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches(@"[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                .Matches(@"\d").WithMessage("Şifre en az bir rakam içermelidir.")
                .Matches(@"[\W_]").WithMessage("Şifre en az bir özel karakter içermelidir.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Lütfen şifrenizi doğrulayın.")
                .Equal(x => x.Password).WithMessage("Şifre tekrarı eşleşmiyor.");
        }
    }
}
