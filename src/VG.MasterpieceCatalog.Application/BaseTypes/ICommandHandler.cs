namespace VG.MasterpieceCatalog.Application.BaseTypes
{
  public interface ICommandHandler<in T>
  {
    void Handle(T command);
  }
}