using VG.MasterpieceCatalog.Application.Infrastructure;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.BuyMasterpiece
{
  public class BuyMasterpieceHandler : ICommandHandler<BuyMasterpieceCommand>
  {
    private readonly IMasterpieceRepository _masterpieceRepository;
    
    public BuyMasterpieceHandler(IMasterpieceRepository masterpieceRepository)
    {
      _masterpieceRepository = masterpieceRepository;
    }

    public void Handle(BuyMasterpieceCommand command)
    {
      Domain.Masterpiece m = _masterpieceRepository.Get(command.MasterpieceId);
      m.Buy(command.CustomerId);
      _masterpieceRepository.Save(m);
    }
  }
}
