using Microsoft.EntityFrameworkCore.Migrations;

namespace petshopia_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donos",
                columns: table => new
                {
                    DonoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Endereco = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donos", x => x.DonoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoAlojamento",
                columns: table => new
                {
                    EstadoAlojamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAlojamento", x => x.EstadoAlojamentoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoSaudes",
                columns: table => new
                {
                    EstadoSaudeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoSaudes", x => x.EstadoSaudeId);
                });

            migrationBuilder.CreateTable(
                name: "Alojamentos",
                columns: table => new
                {
                    AlojamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: true),
                    EstadoAlojamentoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamentos", x => x.AlojamentoId);
                    table.ForeignKey(
                        name: "FK_Alojamentos_EstadoAlojamento_EstadoAlojamentoId",
                        column: x => x.EstadoAlojamentoId,
                        principalTable: "EstadoAlojamento",
                        principalColumn: "EstadoAlojamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    DonoId = table.Column<int>(type: "INTEGER", nullable: false),
                    MotivacaoInternacao = table.Column<string>(type: "TEXT", nullable: true),
                    EstadoSaudeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: true),
                    IdAlojamento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animais_Donos_DonoId",
                        column: x => x.DonoId,
                        principalTable: "Donos",
                        principalColumn: "DonoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animais_EstadoSaudes_EstadoSaudeId",
                        column: x => x.EstadoSaudeId,
                        principalTable: "EstadoSaudes",
                        principalColumn: "EstadoSaudeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadoAlojamento",
                columns: new[] { "EstadoAlojamentoId", "Descricao" },
                values: new object[] { 1, "Livre" });

            migrationBuilder.InsertData(
                table: "EstadoAlojamento",
                columns: new[] { "EstadoAlojamentoId", "Descricao" },
                values: new object[] { 2, "Ocupado" });

            migrationBuilder.InsertData(
                table: "EstadoAlojamento",
                columns: new[] { "EstadoAlojamentoId", "Descricao" },
                values: new object[] { 3, "Esperando dono" });

            migrationBuilder.InsertData(
                table: "EstadoSaudes",
                columns: new[] { "EstadoSaudeId", "Descricao" },
                values: new object[] { 1, "Em tratamento" });

            migrationBuilder.InsertData(
                table: "EstadoSaudes",
                columns: new[] { "EstadoSaudeId", "Descricao" },
                values: new object[] { 2, "Em recuperação" });

            migrationBuilder.InsertData(
                table: "EstadoSaudes",
                columns: new[] { "EstadoSaudeId", "Descricao" },
                values: new object[] { 3, "Recuperado" });

            migrationBuilder.InsertData(
                table: "Alojamentos",
                columns: new[] { "AlojamentoId", "AnimalId", "EstadoAlojamentoId" },
                values: new object[] { 1, null, 1 });

            migrationBuilder.InsertData(
                table: "Alojamentos",
                columns: new[] { "AlojamentoId", "AnimalId", "EstadoAlojamentoId" },
                values: new object[] { 2, null, 1 });

            migrationBuilder.InsertData(
                table: "Alojamentos",
                columns: new[] { "AlojamentoId", "AnimalId", "EstadoAlojamentoId" },
                values: new object[] { 3, null, 1 });

            migrationBuilder.InsertData(
                table: "Alojamentos",
                columns: new[] { "AlojamentoId", "AnimalId", "EstadoAlojamentoId" },
                values: new object[] { 4, null, 1 });

            migrationBuilder.InsertData(
                table: "Alojamentos",
                columns: new[] { "AlojamentoId", "AnimalId", "EstadoAlojamentoId" },
                values: new object[] { 5, null, 1 });

            migrationBuilder.InsertData(
                table: "Alojamentos",
                columns: new[] { "AlojamentoId", "AnimalId", "EstadoAlojamentoId" },
                values: new object[] { 6, null, 1 });

            migrationBuilder.InsertData(
                table: "Alojamentos",
                columns: new[] { "AlojamentoId", "AnimalId", "EstadoAlojamentoId" },
                values: new object[] { 7, null, 1 });

            migrationBuilder.InsertData(
                table: "Alojamentos",
                columns: new[] { "AlojamentoId", "AnimalId", "EstadoAlojamentoId" },
                values: new object[] { 8, null, 1 });

            migrationBuilder.InsertData(
                table: "Alojamentos",
                columns: new[] { "AlojamentoId", "AnimalId", "EstadoAlojamentoId" },
                values: new object[] { 9, null, 1 });

            migrationBuilder.InsertData(
                table: "Alojamentos",
                columns: new[] { "AlojamentoId", "AnimalId", "EstadoAlojamentoId" },
                values: new object[] { 10, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Alojamentos_EstadoAlojamentoId",
                table: "Alojamentos",
                column: "EstadoAlojamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Animais_DonoId",
                table: "Animais",
                column: "DonoId");

            migrationBuilder.CreateIndex(
                name: "IX_Animais_EstadoSaudeId",
                table: "Animais",
                column: "EstadoSaudeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alojamentos");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "EstadoAlojamento");

            migrationBuilder.DropTable(
                name: "Donos");

            migrationBuilder.DropTable(
                name: "EstadoSaudes");
        }
    }
}
