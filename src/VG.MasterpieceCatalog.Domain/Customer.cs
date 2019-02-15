namespace VG.MasterpieceCatalog.Domain
{
  public class Customer
  {
    private bool _isVip;

    public Customer(bool isVip)
    {
      _isVip = isVip;
    }

    public bool CanReserve()
    {
      return _isVip;
    }
  }
}