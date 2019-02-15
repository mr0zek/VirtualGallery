using System;
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

      MasterpieceEvent masterpieceEvent = new MasterpieceEvent();
      JObject obj = JObject.Load(reader);
      masterpieceEvent.Id = obj[nameof(MasterpieceEvent.Id).ToLower()].Value<int>();
      masterpieceEvent.Type = obj[nameof(MasterpieceEvent.Type).ToLower()].Value<string>();
      masterpieceEvent.Version = obj[nameof(MasterpieceEvent.Version).ToLower()].Value<int>();
      switch (obj[nameof(MasterpieceEvent.Type).ToLower()].Value<string>())
      {
        case nameof(MasterpieceCreatedEvent):
          masterpieceEvent.Event = JsonConvert.DeserializeObject<MasterpieceCreatedEvent>(obj[nameof(MasterpieceEvent.Event).ToLower()].ToString());
          break;
        case nameof(MasterpieceBoughtEvent):
          masterpieceEvent.Event = JsonConvert.DeserializeObject<MasterpieceBoughtEvent>(obj[nameof(MasterpieceEvent.Event).ToLower()].ToString());
          break;
        case nameof(MasterpieceRemovedEvent):
          masterpieceEvent.Event = JsonConvert.DeserializeObject<MasterpieceRemovedEvent>(obj[nameof(MasterpieceEvent.Event).ToLower()].ToString());
          break;
        case nameof(RevokedMasterpieceReservationEvent):
          masterpieceEvent.Event = JsonConvert.DeserializeObject<RevokedMasterpieceReservationEvent>(obj[nameof(MasterpieceEvent.Event).ToLower()].ToString());
          break;
        case nameof(MasterpieceReservedEvent):
          masterpieceEvent.Event = JsonConvert.DeserializeObject<MasterpieceReservedEvent>(obj[nameof(MasterpieceEvent.Event).ToLower()].ToString());
          break;
      }

      return masterpieceEvent;
    }

    public override bool CanConvert(Type objectType)
    {
      return false;
    }
  }
}