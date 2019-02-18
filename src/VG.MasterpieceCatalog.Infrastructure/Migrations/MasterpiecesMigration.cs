using FluentMigrator;

namespace VG.MasterpieceCatalog.Infrastructure.Migrations
{
  [Migration(201902181512)]
  public class MasterpiecesMigration : Migration
  {
    public override void Up()
    {
      Create.Table("Masterpieces")
        .WithColumn("Id").AsString().PrimaryKey()
        .WithColumn("Name").AsString(512).NotNullable()
        .WithColumn("Version").AsInt32().NotNullable()
        .WithColumn("Produced").AsDateTime().NotNullable()
        .WithColumn("Price").AsDouble().NotNullable()
        .WithColumn("IsRemoved").AsBoolean().NotNullable();
    }

    public override void Down()
    {
      Delete.Table("Events");
    }
  }
}
