﻿namespace VG.MasterpieceCatalog.BaseTypes
{
  public interface ICommandHandler<in T>
  {
    void Handle(T command);
  }
}