using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanovKirillKt_41_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academic_degree",
                columns: table => new
                {
                    ad_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор ученой степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_ad_name = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Название ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Academic_degree_ad_id", x => x.ad_id);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_discipline_name = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Название дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_position_title = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "Kafedra",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_department_name = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Название кафедры"),
                    f_head_teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор заведующего кафедрой")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Kafedra_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_teacher_firstname = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Имя преподавателя"),
                    c_teacher_lastname = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Фамилия преподавателя"),
                    c_teacher_middlename = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Отчество преподавателя"),
                    f_academic_degree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор ученой степени"),
                    f_position_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности"),
                    f_department_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_teacher_academic_degree",
                        column: x => x.f_academic_degree_id,
                        principalTable: "Academic_degree",
                        principalColumn: "ad_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_teacher_department",
                        column: x => x.f_department_id,
                        principalTable: "Kafedra",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_teacher_position",
                        column: x => x.f_position_id,
                        principalTable: "Position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Napravlenie",
                columns: table => new
                {
                    direction_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор направления")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    c_direction_name = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Название направления"),
                    n_hours = table.Column<int>(type: "int", nullable: false, comment: "Количество часов")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Napravlenie_direction_id", x => x.direction_id);
                    table.ForeignKey(
                        name: "fk_direction_discipline",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_direction_teacher",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kafedra_f_head_teacher_id",
                table: "Kafedra",
                column: "f_head_teacher_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Napravlenie_DisciplineId",
                table: "Napravlenie",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Napravlenie_TeacherId",
                table: "Napravlenie",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_f_academic_degree_id",
                table: "Teacher",
                column: "f_academic_degree_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_f_department_id",
                table: "Teacher",
                column: "f_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_f_position_id",
                table: "Teacher",
                column: "f_position_id");

            migrationBuilder.AddForeignKey(
                name: "fk_department_head_teacher",
                table: "Kafedra",
                column: "f_head_teacher_id",
                principalTable: "Teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_department_head_teacher",
                table: "Kafedra");

            migrationBuilder.DropTable(
                name: "Napravlenie");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Academic_degree");

            migrationBuilder.DropTable(
                name: "Kafedra");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
