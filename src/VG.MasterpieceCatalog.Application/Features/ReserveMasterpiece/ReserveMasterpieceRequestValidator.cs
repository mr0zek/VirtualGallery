using FluentValidation;

namespace VG.MasterpieceCatalog.Application.Features.ReserveMasterpiece
{
  public class ReserveMasterpieceRequestValidator : AbstractValidator<ReserveMasterpieceRequest>
  {
    public ReserveMasterpieceRequestValidator()
    {
      RuleFor(f => f.CustomerId).NotNull().NotEmpty();
    }
  }
}