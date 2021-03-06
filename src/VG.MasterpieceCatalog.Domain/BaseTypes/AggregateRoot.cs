﻿using System;

namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  public class AggregateRoot
  {
    private IEventPublisher _eventPublisher;
    public Guid Id { get; }
    public int Version { get; internal set; }
    protected void PublishEvent(IEvent @event)
    {
      _eventPublisher.Publish(@event);
    }
  }
}