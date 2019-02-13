using VG.MasterpieceCatalog.Application.BaseTypes;
using VG.MasterpieceCatalog.Application.ReserveMasterpiece;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.CreateMasterpiece
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
      Masterpiece m = new Masterpiece(command.Id, command.Name, command.Price);
      _masterpieceRepository.Save(m);
    }
  }
}
