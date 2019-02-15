using FluentMigrator;

namespace VG.MasterpieceCatalog.Infrastructure.Migrations
{
  [Migration(201902141512)]
  public class EventStore : Migration
  {
    public override void Up()
    {
      Create.Table("Events")
        .WithColumn("Id").AsInt64().PrimaryKey().Identity()
        .WithColumn("AggregateId").AsString(512)
        .WithColumn("Data").AsString(int.MaxValue).NotNullable();
    }

    public override void Down()
    {
      Delete.Table("Events");
    }
  }
}
