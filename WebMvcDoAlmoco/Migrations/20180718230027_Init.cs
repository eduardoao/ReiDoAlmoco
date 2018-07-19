using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebMvcDoAlmoco.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Votacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    TotalVoto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidatoVotacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CandidatoEmail = table.Column<string>(nullable: true),
                    VotacaoId = table.Column<int>(nullable: true),
                    Voto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoVotacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatoVotacao_Candidato_CandidatoEmail",
                        column: x => x.CandidatoEmail,
                        principalTable: "Candidato",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidatoVotacao_Votacao_VotacaoId",
                        column: x => x.VotacaoId,
                        principalTable: "Votacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoVotacao_CandidatoEmail",
                table: "CandidatoVotacao",
                column: "CandidatoEmail");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoVotacao_VotacaoId",
                table: "CandidatoVotacao",
                column: "VotacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoVotacao");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Votacao");
        }
    }
}
