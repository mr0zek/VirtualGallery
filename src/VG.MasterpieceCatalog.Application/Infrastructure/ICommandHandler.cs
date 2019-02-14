namespace VG.MasterpieceCatalog.Application.Infrastructure
{
  public interface ICommandHandler<in T>
  {
    void Handle(T command);
  }
}