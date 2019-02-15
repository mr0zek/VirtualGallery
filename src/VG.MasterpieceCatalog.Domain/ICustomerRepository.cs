namespace VG.MasterpieceCatalog.Domain
{
  public interface ICustomerRepository
  {
    Customer Get(CustomerId commandCustormerId);
  }
}