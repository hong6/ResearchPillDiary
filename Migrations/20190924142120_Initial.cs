using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResearchPillDiary.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    MedicationId = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Purpose = table.Column<string>(maxLength: 50, nullable: true),
                    Instructions = table.Column<string>(maxLength: 50, nullable: true),
                    Frequency = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.MedicationId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientId = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    EmergencyContact = table.Column<string>(maxLength: 50, nullable: true),
                    EmergencyContactPhone = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Trial",
                columns: table => new
                {
                    TrialId = table.Column<string>(maxLength: 50, nullable: false),
                    TrialName = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trial", x => x.TrialId);
                });

            migrationBuilder.CreateTable(
                name: "DiaryMedication",
                columns: table => new
                {
                    DiaryMedicationId = table.Column<string>(maxLength: 50, nullable: false),
                    PatientId = table.Column<string>(maxLength: 50, nullable: true),
                    DiaryEntryDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    DidTake = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryMedication", x => x.DiaryMedicationId);
                    table.ForeignKey(
                        name: "FK_DiaryMedication_Patient",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiarySymptom",
                columns: table => new
                {
                    DiarySymptomId = table.Column<string>(maxLength: 50, nullable: false),
                    PatientId = table.Column<string>(maxLength: 50, nullable: true),
                    Note = table.Column<string>(maxLength: 100, nullable: true),
                    Attachment = table.Column<string>(maxLength: 100, nullable: true),
                    Pain = table.Column<string>(maxLength: 50, nullable: true),
                    DiaryEntryDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiarySymptom", x => x.DiarySymptomId);
                    table.ForeignKey(
                        name: "FK_DiarySymptom_Patient",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiaryVital",
                columns: table => new
                {
                    DiaryVitalId = table.Column<string>(maxLength: 50, nullable: false),
                    PatientId = table.Column<string>(maxLength: 50, nullable: true),
                    BodyTemp = table.Column<string>(maxLength: 50, nullable: true),
                    BloodPressure = table.Column<string>(maxLength: 50, nullable: true),
                    BodyWeight = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryVital", x => x.DiaryVitalId);
                    table.ForeignKey(
                        name: "FK_DiaryVital_Patient",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicationSchedule",
                columns: table => new
                {
                    PatientMedicationScheduleId = table.Column<string>(maxLength: 50, nullable: false),
                    PatientId = table.Column<string>(maxLength: 50, nullable: true),
                    MedicationId = table.Column<string>(maxLength: 50, nullable: true),
                    TrialId = table.Column<string>(maxLength: 50, nullable: true),
                    Time = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Day = table.Column<DateTime>(type: "date", nullable: true),
                    Dosage = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Active = table.Column<string>(maxLength: 200, nullable: true),
                    PrescribingDoctor = table.Column<string>(maxLength: 50, nullable: true),
                    Pharmacy = table.Column<string>(maxLength: 100, nullable: true),
                    Reminder = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicationSchedule", x => x.PatientMedicationScheduleId);
                    table.ForeignKey(
                        name: "FK_PatientMedicationSchedule_Medication",
                        column: x => x.MedicationId,
                        principalTable: "Medication",
                        principalColumn: "MedicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientMedicationSchedule_PatientMedicationSchedule",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientAppointment",
                columns: table => new
                {
                    PatientAppointmentId = table.Column<string>(maxLength: 50, nullable: false),
                    PatientId = table.Column<string>(maxLength: 50, nullable: true),
                    TrialId = table.Column<string>(maxLength: 50, nullable: true),
                    DoctorId = table.Column<string>(maxLength: 50, nullable: true),
                    LocationId = table.Column<string>(maxLength: 50, nullable: true),
                    AppointmentDateTime = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAppointment", x => x.PatientAppointmentId);
                    table.ForeignKey(
                        name: "FK_PatientAppointment_Patient1",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientAppointment_Patient",
                        column: x => x.TrialId,
                        principalTable: "Trial",
                        principalColumn: "TrialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrialMedication",
                columns: table => new
                {
                    TrialMedicationId = table.Column<string>(maxLength: 50, nullable: false),
                    TrialId = table.Column<string>(maxLength: 50, nullable: true),
                    MedicationId = table.Column<string>(maxLength: 50, nullable: true),
                    Optional = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialMedication", x => x.TrialMedicationId);
                    table.ForeignKey(
                        name: "FK_TrialMedication_Trial",
                        column: x => x.TrialId,
                        principalTable: "Trial",
                        principalColumn: "TrialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaryMedication_PatientId",
                table: "DiaryMedication",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DiarySymptom_PatientId",
                table: "DiarySymptom",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaryVital_PatientId",
                table: "DiaryVital",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAppointment_PatientId",
                table: "PatientAppointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAppointment_TrialId",
                table: "PatientAppointment",
                column: "TrialId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationSchedule_MedicationId",
                table: "PatientMedicationSchedule",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationSchedule_PatientId",
                table: "PatientMedicationSchedule",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TrialMedication_TrialId",
                table: "TrialMedication",
                column: "TrialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryMedication");

            migrationBuilder.DropTable(
                name: "DiarySymptom");

            migrationBuilder.DropTable(
                name: "DiaryVital");

            migrationBuilder.DropTable(
                name: "PatientAppointment");

            migrationBuilder.DropTable(
                name: "PatientMedicationSchedule");

            migrationBuilder.DropTable(
                name: "TrialMedication");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Trial");
        }
    }
}
