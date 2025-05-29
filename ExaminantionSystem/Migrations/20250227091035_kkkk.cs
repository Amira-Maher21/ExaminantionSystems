using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystem.Migrations
{
    public partial class kkkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_CourseID",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Instructor_InstructorID",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Users_UserID",
                schema: "HR",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "HR",
                table: "Instructor",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_UserID",
                schema: "HR",
                table: "Instructor",
                newName: "IX_Instructor_UserId");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "Exams",
                newName: "InstructorId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Exams",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_InstructorID",
                table: "Exams",
                newName: "IX_Exams_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_CourseID",
                table: "Exams",
                newName: "IX_Exams_CourseId");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                schema: "HR",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
     name: "FK_Exams_Instructor_InstructorId",
     table: "Exams",
     column: "InstructorId",
     principalSchema: "HR",
     principalTable: "Instructor",
     principalColumn: "ID",
     onDelete: ReferentialAction.Restrict); // أو NoAction

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Users_UserId",
                schema: "HR",
                table: "Instructor",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // نفس كود Down السابق بدون تغيير
            
        }
    }
}
