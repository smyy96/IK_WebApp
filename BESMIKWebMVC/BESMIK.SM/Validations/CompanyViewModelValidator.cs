using BESMIK.ViewModel.Company;
using FluentValidation;

namespace BESMIK.SM.Validations
{
    public class CompanyViewModelValidator : AbstractValidator<CompanyViewModel>
    {
        public CompanyViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş olamaz")
                .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olabilir");

            RuleFor(x => x.TitleName)
                .NotEmpty().WithMessage("Şirket ismi alanı boş olamaz")
                .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olabilir");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta alanı boş olamaz")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon alanı boş olamaz")
                .Matches(@"^\d{10}$").WithMessage("Telefon numarası 10 haneli olmalıdır");

            RuleFor(x => x.TaxNumber)
                .NotEmpty().WithMessage("Vergi Numarası boş olamaz")
                .MaximumLength(50).WithMessage("Vergi Numarası en fazla 50 karakter olabilir")
                .Must(tn => !string.IsNullOrEmpty(tn) && tn.All(char.IsDigit)).WithMessage("Vergi Numarası sadece rakam içermelidir");

            RuleFor(x => x.TaxAdministration)
                .NotEmpty().WithMessage("Vergi Dairesi alanı boş olamaz")
                .MaximumLength(50).WithMessage("Vergi Dairesi en fazla 50 karakter olabilir");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres alanı boş olamaz")
                .MaximumLength(250).WithMessage("Adres en fazla 250 karakter olabilir");

            RuleFor(x => x.EmployeesNumber)
                .NotEmpty().WithMessage("Çalışan Sayısı boş olamaz")
                .Must(en => !string.IsNullOrEmpty(en) && en.All(char.IsDigit)).WithMessage("Çalışan Sayısı sadece rakam içermelidir");

            RuleFor(x => x.EstablishmentYear)
                .NotEmpty().WithMessage("Kuruluş Yılı boş olamaz");

            //RuleFor(x => x.Logo)
            //    .MaximumLength(100).WithMessage("Logo dosya adı en fazla 100 karakter olabilir")
            //    .Matches(@"^[a-zA-Z0-9_\-\.]*$").WithMessage("Logo dosya adı sadece harf, rakam, alt çizgi, tire ve nokta içerebilir");
        }
    }
}
