using BESMIK.ViewModel.Permission;
using FluentValidation;

namespace BESMIK.SM.Validations
{
    public class PermissionViewModelValidator : AbstractValidator<PermissionViewModel>
    {
        public PermissionViewModelValidator() 
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            RuleFor(x => x.PermissionType).
                NotEmpty().WithMessage("İzin tipi boş olamaz.");
            RuleFor(x => x.PermissionStartDate)
            .NotNull().WithMessage("Başlangıç tarihi boş olamaz.")
            .NotEmpty().WithMessage("Başlangıç tarihi boş olamaz.")
            .Must(date => date >= today).WithMessage("Başlangıç tarihi bugünden önce olamaz.")
            .Must(BeAValidDate).WithMessage("Başlangıç tarihi geçerli bir tarih olmalıdır.");

            RuleFor(x => x.PermissionEndDate)
                .NotNull().WithMessage("Başlangıç tarihi boş olamaz.")
                .NotEmpty().WithMessage("Bitiş tarihi boş olamaz.")
                .Must(BeAValidDate).WithMessage("Bitiş tarihi geçerli bir tarih olmalıdır.");

            RuleFor(x => new { x.PermissionStartDate, x.PermissionEndDate })
                .Must(dates => dates.PermissionStartDate <= dates.PermissionEndDate)
                .WithMessage("Başlangıç tarihi, bitiş tarihinden sonra olamaz.");

        }
        private bool BeAValidDate(DateOnly date)
        {
            return date != default;
        }
    }
}
