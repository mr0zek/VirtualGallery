using FluentValidation;

namespace VG.MasterpieceCatalog.Application.Features.CreateMasterpiece
{
  public class CreateMasterpieceRequestValidator : AbstractValidator<CreateMasterpieceRequest>
  {
    public CreateMasterpieceRequestValidator()
    {
      RuleFor(f => f.Id).NotNull().NotEmpty();
      RuleFor(f => f.Name).NotNull().NotEmpty();
      RuleFor(f => f.Price).GreaterThan(0);
      RuleFor(f => f.Produced).NotNull();
    }
  }
}