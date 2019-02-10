using VG.MasterpieceCatalog.Application.BaseTypes;
using VG.MasterpieceCatalog.Application.ReserveMasterpiece;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.CreateMasterpiece
{
  public class ReserveMasterpieceHandler : ICommandHandler<ReserveMasterpieceCommand>
  {
    private readonly IMasterpieceRepository _masterpieceRepository;
    private readonly ICustomerRepository _customerRepository;

    public ReserveMasterpieceHandler(IMasterpieceRepository masterpieceRepository, ICustomerRepository customerRepository)
    {
      _masterpieceRepository = masterpieceRepository;
      _customerRepository = customerRepository;
    }

    public void Handle(ReserveMasterpieceCommand command)
    {
      Masterpiece m = _masterpieceRepository.Get(command.MasterpieceId);
      m.Reserve(command.CustormerId, _customerRepository);
      _masterpieceRepository.Save(m);
    }
  }
}
