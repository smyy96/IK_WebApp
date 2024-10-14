using BESMIK.ViewModel.Advance;
using BESMIK.ViewModel.AppUser;
using FluentValidation;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Claims;

namespace BESMIK.SM.Validations
{
    public class AdvanceViewModelValidator : AbstractValidator<AdvanceViewModel>
    {
        private readonly HttpClient _httpClient;
        public AdvanceViewModelValidator(HttpClient httpClient)
        {
            _httpClient = httpClient;

            RuleFor(x => x.AdvanceRequestDate)
                .NotEmpty().WithMessage("Avans talep tarihi boş olamaz");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Miktar boş olamaz veya sıfır olamaz");
                //.MustAsync(async (model, amount, cancellationToken) =>
                //    await BeWithinSalaryLimit(model, amount, cancellationToken))
                //.WithMessage("Avans miktarı maaşınızın 3 katından fazla olamaz.");

            RuleFor(x => x.Currency)
                .IsInEnum().WithMessage("Geçersiz para birimi seçimi")
                .NotEmpty().WithMessage("Bir para birimi seçiniz");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz");

            RuleFor(x => x.AdvanceType)
                .IsInEnum().WithMessage("Geçersiz avans türü seçimi")
                .NotEmpty().WithMessage("Bir avans türü seçiniz");

            

            
        }


        private async Task<bool> BeWithinSalaryLimit(AdvanceViewModel model, float amount, CancellationToken cancellationToken)
        {
            var salaryResponse = await _httpClient.GetFromJsonAsync<AppUserViewModel>($"https://localhost:7136/api/Advance/GetUser/{model.AppUserId}", cancellationToken);

            if (salaryResponse == null || salaryResponse.Wage == null || salaryResponse.Wage == 0)
            {
                return false;
            }

            return amount <= (salaryResponse.Wage * 3);
        }
    }
}
