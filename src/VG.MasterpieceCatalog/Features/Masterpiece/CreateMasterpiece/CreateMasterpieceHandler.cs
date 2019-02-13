using VG.MasterpieceCatalog.Application.BaseTypes;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Features.Masterpiece.CreateMasterpiece
{
  public class CreateMasterpieceHandler : ICommandHandler<CreateMasterpieceCommand>
  {
    private readonly IMasterpieceRepository _masterpieceRepository;

    public CreateMasterpieceHandler(IMasterpieceRepository masterpieceRepository)
    {
      _masterpieceRepository = masterpieceRepository;
    }

    public void Handle(CreateMasterpieceCommand command)
    {
      Domain.Masterpiece m = new Domain.Masterpiece(command.Id, command.Name, command.Price);
      _masterpieceRepository.Save(m);
    }
  }
}
