using BESMIK.ViewModel.Advance;
using FluentValidation;

namespace BESMIK.SM.Validations
{
    public class AdvanceViewModelValidator : AbstractValidator<AdvanceViewModel>
    {
        public AdvanceViewModelValidator() 
        {
            RuleFor(x => x.AdvanceRequestDate)
                .NotEmpty().WithMessage("Avans talep tarihi boş olamaz");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Miktar boş olamaz"); // Sadece rakam mı girilebilecek test etmek lazım önce, harf de girilebiliyorsa validation'ını yazılacak.

            RuleFor(x => x.Currency)
                .IsInEnum().WithMessage("Geçersiz para birimi seçimi")
                .NotEmpty().WithMessage("Bir para birimi seçiniz");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz");

            RuleFor(x => x.AdvanceType)
                .IsInEnum().WithMessage("Geçersiz avans türü seçimi")
                .NotEmpty().WithMessage("Bir avans türü seçiniz");

            //Avans onay durumunu her zaman onay bekliyor olarak göndermek lazım yani avans talebini oluşturan kişi değiştirememeli, hidden olarak gizlenebilir belki.

            //Aynı şekilde avans cevap tarihi, sadece avans talebi yetkili kişi tarafından cevaplandığı zaman olarak değişmeli. Bu iki prop talep oluşturan kişi tarafından görülememeli ve değiştirilememeli.
        }
    }
}
