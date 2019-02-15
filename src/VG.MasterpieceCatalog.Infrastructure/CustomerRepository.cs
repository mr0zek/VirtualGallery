using VG.MasterpieceCatalog.Domain;

namespace VG.MasterpieceCatalog.Infrastructure
{
  class CustomerRepository : ICustomerRepository
  {
    public Customer Get(CustomerId custormerId)
    {
      return new Customer(true);
    }
  }
}