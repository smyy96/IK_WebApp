
using BESMIK.ViewModel.Spending;
using FluentValidation;

namespace BESMIK.SM.Validations
{
    public class SpendingViewModelValidator: AbstractValidator<SpendingViewModel>
    {
        public SpendingViewModelValidator()
        {

            RuleFor(x => x.SpendingType)
                .IsInEnum().WithMessage("Geçersiz Harcama Türü seçimi")
                .NotEmpty().WithMessage("Bir harcama türü seçiniz");

            RuleFor(x => x.Sum)
                .GreaterThan(0).WithMessage("Harcama tutarı pozitif bir değer olmalıdır.")
                .LessThanOrEqualTo(1000000).WithMessage("Harcama tutarı 1.000.000'den büyük olamaz.");

            RuleFor(x => x.SpendingCurrency)
                .IsInEnum().WithMessage("Geçersiz para birimi seçimi")
                .NotEmpty().WithMessage("Bir para birimi seçiniz");

        }

    }
}
