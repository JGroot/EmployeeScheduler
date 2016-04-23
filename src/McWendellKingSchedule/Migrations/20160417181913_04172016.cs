using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace McWendellKingSchedule.Migrations
{
    public partial class _04172016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Schedule_Employee_UserName", table: "Schedule");
            migrationBuilder.DropForeignKey(name: "FK_ScheduleDetail_Position_PositionName", table: "ScheduleDetail");
            migrationBuilder.DropForeignKey(name: "FK_ScheduleDetail_Schedule_ScheduleID", table: "ScheduleDetail");
            migrationBuilder.DropForeignKey(name: "FK_ScheduleDetail_Shift_ShiftName", table: "ScheduleDetail");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropUniqueConstraint(name: "AK_Employee_UserName1", table: "Employee");
            migrationBuilder.DropColumn(name: "UserName1", table: "Employee");
            migrationBuilder.AlterColumn<string>(
                name: "ShiftName",
                table: "ScheduleDetail",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "PositionName",
                table: "ScheduleDetail",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ScheduleDetail",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ScheduleDetail",
                nullable: false);
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Schedule",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employee",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employee",
                nullable: false);
            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Employee_EmployeeID",
                table: "Schedule",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDetail_Position_PositionName",
                table: "ScheduleDetail",
                column: "PositionName",
                principalTable: "Position",
                principalColumn: "PositionName",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDetail_Schedule_ScheduleID",
                table: "ScheduleDetail",
                column: "ScheduleID",
                principalTable: "Schedule",
                principalColumn: "ScheduleID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDetail_Shift_ShiftName",
                table: "ScheduleDetail",
                column: "ShiftName",
                principalTable: "Shift",
                principalColumn: "ShiftName",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Schedule_Employee_EmployeeID", table: "Schedule");
            migrationBuilder.DropForeignKey(name: "FK_ScheduleDetail_Position_PositionName", table: "ScheduleDetail");
            migrationBuilder.DropForeignKey(name: "FK_ScheduleDetail_Schedule_ScheduleID", table: "ScheduleDetail");
            migrationBuilder.DropForeignKey(name: "FK_ScheduleDetail_Shift_ShiftName", table: "ScheduleDetail");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "EmployeeID", table: "Schedule");
            migrationBuilder.AlterColumn<string>(
                name: "ShiftName",
                table: "ScheduleDetail",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "PositionName",
                table: "ScheduleDetail",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ScheduleDetail",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ScheduleDetail",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employee",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employee",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "UserName1",
                table: "Employee",
                nullable: false,
                defaultValue: "");
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employee_UserName1",
                table: "Employee",
                column: "UserName1");
            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Employee_UserName",
                table: "Schedule",
                column: "UserName",
                principalTable: "Employee",
                principalColumn: "UserName1",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDetail_Position_PositionName",
                table: "ScheduleDetail",
                column: "PositionName",
                principalTable: "Position",
                principalColumn: "PositionName",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDetail_Schedule_ScheduleID",
                table: "ScheduleDetail",
                column: "ScheduleID",
                principalTable: "Schedule",
                principalColumn: "ScheduleID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDetail_Shift_ShiftName",
                table: "ScheduleDetail",
                column: "ShiftName",
                principalTable: "Shift",
                principalColumn: "ShiftName",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
