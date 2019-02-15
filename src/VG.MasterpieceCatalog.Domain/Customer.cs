namespace VG.MasterpieceCatalog.Domain
{
  public class Customer
  {
    private bool _isVip; 

    public bool CanReserve()
    {
      return _isVip;
    }
  }
}