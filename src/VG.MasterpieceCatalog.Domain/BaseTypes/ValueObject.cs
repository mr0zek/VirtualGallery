﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VG.MasterpieceCatalog.Domain.BaseTypes
{
  public abstract class ValueObject : IEqualityComparer, IEquatable<ValueObject>
  {
    private const int StartValue = 397;

    public bool Equals(ValueObject other)
    {
      throw new NotImplementedException();
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((ValueObject)obj);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    
    public override int GetHashCode()
    {
      return GetEqualityComponents()
        .Aggregate(1, (current, obj) =>
        {
          unchecked
          {
            return current * 23 + (obj?.GetHashCode() ?? 0);
          }
        });
    }

    public static bool operator ==(ValueObject a, ValueObject b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return true;

      if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        return false;

      return a.Equals(b);
    }

    public static bool operator !=(ValueObject a, ValueObject b)
    {
      return !(a == b);
    }

    public new bool Equals(object x, object y)
    {
      if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
      {
        return true;
      }

      if (ReferenceEquals(x, null))
      {
        return false;
      }

      return x.Equals(y);
    }

    public int GetHashCode(object obj)
    {
      return obj.GetHashCode();
    }
  }
}