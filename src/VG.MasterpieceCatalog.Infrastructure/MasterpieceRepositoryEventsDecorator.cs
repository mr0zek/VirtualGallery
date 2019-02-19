﻿using System;
using VG.MasterpieceCatalog.Domain;
using VG.MasterpieceCatalog.Domain.BaseTypes;

namespace VG.MasterpieceCatalog.Infrastructure
{
  class MasterpieceRepositoryEventsDecorator : IMasterpieceRepository
  {
    private readonly IMasterpieceRepository _masterpieceRepository;
    private IEventsPublisher _eventsPublisher;

    public MasterpieceRepositoryEventsDecorator(IMasterpieceRepository masterpieceRepository, IEventsPublisher eventsPublisher)
    {
      _masterpieceRepository = masterpieceRepository;
      _eventsPublisher = eventsPublisher;
    }
    public Masterpiece Get(MasterpieceId id)
    {
      return _masterpieceRepository.Get(id);
    }

    public void Save(Masterpiece masterpiece)
    {
      _masterpieceRepository.Save(masterpiece);
      _eventsPublisher.Publish((masterpiece as IEventsAccesor).GetEvents());
    }
  }
}