﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment13.Migrations
{
    public partial class InsertRatings5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "SQL", @"6-5-InsertRatings.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from usermovies where id >= 50000 and id < 60000");
        }
    }
}
