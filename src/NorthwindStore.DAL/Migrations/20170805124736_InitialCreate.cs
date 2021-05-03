using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NorthwindStore.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // nothing to do here - we are not starting with an empty database
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
