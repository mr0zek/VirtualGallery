using FluentMigrator;

namespace VG.MasterpieceCatalog.Perspective.Migrations
{
  [Migration(201902170815)]
  public class PerspectiveMigration : Migration
  {
    public override void Up()
    {
      Create.Table("MasterpiecesPerspective")
        .WithColumn("AggregateId").AsString(512).NotNullable()
        .WithColumn("Name").AsString(128).NotNullable()
        .WithColumn("Price").AsDecimal().NotNullable()
        .WithColumn("Version").AsInt32().NotNullable()
        .WithColumn("IsAvailable").AsInt32().NotNullable();
      Create.Table("HandledEvents")
        .WithColumn("lastEventId").AsInt32().NotNullable();
      Insert.IntoTable("HandledEvents").Row(new {lastEventId = 0});
    }

    public override void Down()
    {
      Delete.Table("MasterpiecesPerspective");
    }
  }
}
