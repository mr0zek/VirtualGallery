using VG.MasterpieceCatalog.Application.BaseTypes;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Features.Masterpiece.BuyMasterpiece
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
      m.Buy(command.CustormerId);
      _masterpieceRepository.Save(m);
    }
  }
}
