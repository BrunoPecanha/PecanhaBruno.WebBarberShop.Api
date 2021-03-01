using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PecanhaBruno.WebBarberShop.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteringDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Activated = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    LastVisitDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    MobileInfo = table.Column<string>(nullable: true),
                    Owner = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteringDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Activated = table.Column<bool>(nullable: false, defaultValue: true),
                    FantasyName = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    UseQueue = table.Column<bool>(type: "bit", nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    ConfirmationNotice = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LastQueueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteringDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    IsWorking = table.Column<bool>(nullable: false),
                    FinalizationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queue_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteringDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Activated = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    MediumTime = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    Img = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceType_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayBalance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteringDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    QueueId = table.Column<int>(nullable: true),
                    ScheduleDayId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayBalance_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayBalance_Queue_QueueId",
                        column: x => x.QueueId,
                        principalTable: "Queue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustumerServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteringDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    CustumerId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustumerServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustumerServices_ServiceType_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteringDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NextId = table.Column<int>(nullable: true),
                    CurrentId = table.Column<int>(nullable: true),
                    LastId = table.Column<int>(nullable: true),
                    EstimatedTimeToNext = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DayBalanceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Custumer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteringDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    IsServiceDone = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    FinalizationDateAndTime = table.Column<DateTime>(nullable: false),
                    QueuePosition = table.Column<int>(nullable: false),
                    CurrentCustomerInService = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    QueueId = table.Column<int>(nullable: true),
                    ScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custumer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Custumer_Queue_QueueId",
                        column: x => x.QueueId,
                        principalTable: "Queue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Custumer_ScheduleDay_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "ScheduleDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Custumer_SysUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SysUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDayCustumers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteringDate = table.Column<DateTime>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    CustumerId = table.Column<int>(nullable: false),
                    ScheduleDayId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDayCustumers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleDayCustumers_ScheduleDay_ScheduleDayId",
                        column: x => x.ScheduleDayId,
                        principalTable: "ScheduleDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_UserId",
                table: "Company",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Custumer_QueueId",
                table: "Custumer",
                column: "QueueId");

            migrationBuilder.CreateIndex(
                name: "IX_Custumer_ScheduleId",
                table: "Custumer",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Custumer_UserId",
                table: "Custumer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustumerServices_CustumerId",
                table: "CustumerServices",
                column: "CustumerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustumerServices_ServiceId",
                table: "CustumerServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DayBalance_CompanyId",
                table: "DayBalance",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DayBalance_QueueId",
                table: "DayBalance",
                column: "QueueId",
                unique: true,
                filter: "[QueueId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DayBalance_ScheduleDayId",
                table: "DayBalance",
                column: "ScheduleDayId",
                unique: true,
                filter: "[ScheduleDayId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Queue_CompanyId",
                table: "Queue",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDay_CurrentId",
                table: "ScheduleDay",
                column: "CurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDay_LastId",
                table: "ScheduleDay",
                column: "LastId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDay_NextId",
                table: "ScheduleDay",
                column: "NextId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDayCustumers_ScheduleDayId",
                table: "ScheduleDayCustumers",
                column: "ScheduleDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceType_CompanyId",
                table: "ServiceType",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayBalance_ScheduleDay_ScheduleDayId",
                table: "DayBalance",
                column: "ScheduleDayId",
                principalTable: "ScheduleDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustumerServices_Custumer_CustumerId",
                table: "CustumerServices",
                column: "CustumerId",
                principalTable: "Custumer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDay_Custumer_CurrentId",
                table: "ScheduleDay",
                column: "CurrentId",
                principalTable: "Custumer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDay_Custumer_LastId",
                table: "ScheduleDay",
                column: "LastId",
                principalTable: "Custumer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDay_Custumer_NextId",
                table: "ScheduleDay",
                column: "NextId",
                principalTable: "Custumer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_SysUser_UserId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Custumer_SysUser_UserId",
                table: "Custumer");

            migrationBuilder.DropForeignKey(
                name: "FK_Custumer_Queue_QueueId",
                table: "Custumer");

            migrationBuilder.DropForeignKey(
                name: "FK_Custumer_ScheduleDay_ScheduleId",
                table: "Custumer");

            migrationBuilder.DropTable(
                name: "CustumerServices");

            migrationBuilder.DropTable(
                name: "DayBalance");

            migrationBuilder.DropTable(
                name: "ScheduleDayCustumers");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "SysUser");

            migrationBuilder.DropTable(
                name: "Queue");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "ScheduleDay");

            migrationBuilder.DropTable(
                name: "Custumer");
        }
    }
}
