using VG.MasterpieceCatalog.Application.Infrastructure;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application.Features.ReserveMasterpiece
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
      Domain.Masterpiece m = _masterpieceRepository.Get(command.MasterpieceId);
      m.Reserve(command.CustomerId, _customerRepository);
      _masterpieceRepository.Save(m, command.ExpectedVersion);
    }
  }
}
