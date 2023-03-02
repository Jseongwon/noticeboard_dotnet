using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noticeboard.Data.Migrations
{
    /// <inheritdoc />
    public partial class NoticeBoardCreatedUtcDatabaseGenerated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>("CreatedUtc", "NoticeBoard", defaultValueSql: "getutcdate()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>("CreatedUtc", "NoticeBoard", defaultValueSql: "");
        }
    }
}
