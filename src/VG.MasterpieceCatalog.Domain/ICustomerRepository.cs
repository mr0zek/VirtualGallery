using VG.MasterpieceCatalog.Application.Commands.ReserveMasterpiece;
using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Application
{
  public interface ICustomerRepository
  {
    Customer Get(CustomerId commandCustormerId);
  }
}