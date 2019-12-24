using Microsoft.EntityFrameworkCore.Migrations;

namespace Aventude.Demo.eShop.Data.Migrations
{
    public partial class sp_SearchCatalogItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var storedProcedure = @"SET ANSI_NULLS ON
                GO

                SET QUOTED_IDENTIFIER ON
                GO

                CREATE PROCEDURE [dbo].[sp_SearchProductCatalogItems]
                                @name VARCHAR(50),
	                            @minimumPrice DECIMAL(18,2),
	                            @highestPrice DECIMAL(18,2)
                            AS
                            BEGIN
	                            -- SET NOCOUNT ON added to prevent extra result sets from
	                            -- interfering with SELECT statements.
	                            SET NOCOUNT ON;

                                -- Insert statements for procedure here
	                            SELECT Id, [Name], [Description], Price, ImageUrl FROM [dbo].[CatalogItem] WHERE 
	                            [Name] LIKE '%' + @name + '%' AND
                                Price BETWEEN @minimumPrice and @highestPrice
                            END
                GO
                ";

            migrationBuilder.Sql(storedProcedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
