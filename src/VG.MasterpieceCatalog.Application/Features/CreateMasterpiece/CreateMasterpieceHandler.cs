using VG.MasterpieceCatalog.Application.Infrastructure;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.CreateMasterpiece
{
  public class CreateMasterpieceHandler : ICommandHandler<CreateMasterpieceCommand>
  {
    private readonly IMasterpieceRepository _masterpieceRepository;
    private IMasterpieceFactory _masterpieceFactory;

    public CreateMasterpieceHandler(IMasterpieceRepository masterpieceRepository, IMasterpieceFactory masterpieceFactory)
    {
      _masterpieceRepository = masterpieceRepository;
      _masterpieceFactory = masterpieceFactory;
    }

    public void Handle(CreateMasterpieceCommand command)
    {
      Masterpiece m = _masterpieceFactory.Create(command.Id, command.Name, command.Price, command.Produced);
      _masterpieceRepository.Save(m, null);
    }
  }
}
