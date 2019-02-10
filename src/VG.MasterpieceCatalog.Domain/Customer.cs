namespace VG.MasterpieceCatalog.Application.Commands.ReserveMasterpiece
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