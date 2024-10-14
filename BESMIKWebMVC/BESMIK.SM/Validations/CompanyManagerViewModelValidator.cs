using BESMIK.ViewModel.AppUser;
using FluentValidation;

namespace BESMIK.SM.Validations
{
    public class CompanyManagerViewModelValidator : AbstractValidator<AppUserViewModel>
    {
        public CompanyManagerViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş olamaz")
                .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olabilir")
                .Matches(@"^[^\d]+$").WithMessage("İsim sadece harf içermelidir");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyad alanı boş olamaz")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir")
                 .Matches(@"^[^\d]+$").WithMessage("Soyad sadece harf içermelidir");

            RuleFor(x => x.PersonalEmail)
                .NotEmpty().WithMessage("E-posta alanı boş olamaz")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon alanı boş olamaz")
                .Matches(@"^\d{10}$").WithMessage("Telefon numarası 10 haneli olmalıdır");

            RuleFor(x => x.Tc)
                .NotEmpty().WithMessage("TC Kimlik Numarası boş olamaz")
                .Matches(@"^\d{11}$").WithMessage("TC Kimlik Numarası 11 haneli olmalıdır")
                 .Must(tc => !string.IsNullOrEmpty(tc) && tc.All(char.IsDigit)).WithMessage("TC Kimlik Numarası sadece rakam içermelidir");


            RuleFor(x => x.BirthDate)
               .NotEmpty().WithMessage("Doğum Tarihi boş olamaz")
               .Must(date => date.ToDateTime(new TimeOnly(0, 0)) < DateTime.Today)
               .WithMessage("Doğum Tarihi bugünden küçük olmalıdır");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres alanı boş olamaz")
                .MaximumLength(250).WithMessage("Adres en fazla 250 karakter olabilir");


            RuleFor(x => x.WorkStartDate)
                .NotEmpty().WithMessage("İşe Başlama Tarihi boş olamaz");

            RuleFor(x => x.Department)
                .IsInEnum().WithMessage("Geçersiz departman seçimi")
                .NotEmpty().WithMessage("Bir departman seçiniz");

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Bir şirket seçiniz");
        }
    }
}
