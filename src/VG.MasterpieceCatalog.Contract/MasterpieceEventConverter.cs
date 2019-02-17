using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VG.MasterpieceCatalog.Contract
{
  public class MasterpieceEventConverter : JsonConverter
  {
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      throw new NotImplementedException();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      if (reader.TokenType == JsonToken.Null)
      {
        return string.Empty;
      }

      if (reader.TokenType == JsonToken.String)
      {
        return serializer.Deserialize(reader, objectType);
      }

      Event masterpieceEvent = null;
      JObject obj = JObject.Load(reader);
      switch (obj[nameof(Event.Type).ToLower()].Value<string>())
      {
        case nameof(MasterpieceCreatedEvent):
          masterpieceEvent = JsonConvert.DeserializeObject<MasterpieceCreatedEvent>(obj.ToString());
          break;
        case nameof(MasterpieceBoughtEvent):
          masterpieceEvent= JsonConvert.DeserializeObject<MasterpieceBoughtEvent>(obj.ToString());
          break;
        case nameof(MasterpieceRemovedEvent):
          masterpieceEvent = JsonConvert.DeserializeObject<MasterpieceRemovedEvent>(obj.ToString());
          break;
        case nameof(RevokedMasterpieceReservationEvent):
          masterpieceEvent = JsonConvert.DeserializeObject<RevokedMasterpieceReservationEvent>(obj.ToString());
          break;
        case nameof(MasterpieceReservedEvent):
          masterpieceEvent = JsonConvert.DeserializeObject<MasterpieceReservedEvent>(obj.ToString());
          break;
        default:
          throw new SerializationException("Unknown type: "+ obj[nameof(Event.Type).ToLower()].Value<string>());
      }
      masterpieceEvent.Id = obj[nameof(Event.Id).ToLower()].Value<int>();
      masterpieceEvent.Type = obj[nameof(Event.Type).ToLower()].Value<string>();
      masterpieceEvent.Version = obj[nameof(Event.Version).ToLower()].Value<int>();

      return masterpieceEvent;
    }

    public override bool CanConvert(Type objectType)
    {
      return false;
    }
  }
}