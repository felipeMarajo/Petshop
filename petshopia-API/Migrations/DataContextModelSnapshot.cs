﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using petshopia_API.Data;

namespace petshopia_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("petshopia_API.Model.Alojamento", b =>
                {
                    b.Property<int>("AlojamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstadoAlojamentoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlojamentoId");

                    b.HasIndex("EstadoAlojamentoId");

                    b.ToTable("Alojamentos");

                    b.HasData(
                        new
                        {
                            AlojamentoId = 1,
                            EstadoAlojamentoId = 1
                        },
                        new
                        {
                            AlojamentoId = 2,
                            EstadoAlojamentoId = 1
                        },
                        new
                        {
                            AlojamentoId = 3,
                            EstadoAlojamentoId = 1
                        },
                        new
                        {
                            AlojamentoId = 4,
                            EstadoAlojamentoId = 1
                        },
                        new
                        {
                            AlojamentoId = 5,
                            EstadoAlojamentoId = 1
                        },
                        new
                        {
                            AlojamentoId = 6,
                            EstadoAlojamentoId = 1
                        },
                        new
                        {
                            AlojamentoId = 7,
                            EstadoAlojamentoId = 1
                        },
                        new
                        {
                            AlojamentoId = 8,
                            EstadoAlojamentoId = 1
                        },
                        new
                        {
                            AlojamentoId = 9,
                            EstadoAlojamentoId = 1
                        },
                        new
                        {
                            AlojamentoId = 10,
                            EstadoAlojamentoId = 1
                        });
                });

            modelBuilder.Entity("petshopia_API.Model.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DonoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstadoSaudeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Foto")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdAlojamento")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MotivacaoInternacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("AnimalId");

                    b.HasIndex("DonoId");

                    b.HasIndex("EstadoSaudeId");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("petshopia_API.Model.Dono", b =>
                {
                    b.Property<int>("DonoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("DonoId");

                    b.ToTable("Donos");
                });

            modelBuilder.Entity("petshopia_API.Model.EstadoAlojamento", b =>
                {
                    b.Property<int>("EstadoAlojamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.HasKey("EstadoAlojamentoId");

                    b.ToTable("EstadoAlojamento");

                    b.HasData(
                        new
                        {
                            EstadoAlojamentoId = 1,
                            Descricao = "Livre"
                        },
                        new
                        {
                            EstadoAlojamentoId = 2,
                            Descricao = "Ocupado"
                        },
                        new
                        {
                            EstadoAlojamentoId = 3,
                            Descricao = "Esperando dono"
                        });
                });

            modelBuilder.Entity("petshopia_API.Model.EstadoSaude", b =>
                {
                    b.Property<int>("EstadoSaudeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.HasKey("EstadoSaudeId");

                    b.ToTable("EstadoSaudes");

                    b.HasData(
                        new
                        {
                            EstadoSaudeId = 1,
                            Descricao = "Em tratamento"
                        },
                        new
                        {
                            EstadoSaudeId = 2,
                            Descricao = "Em recuperação"
                        },
                        new
                        {
                            EstadoSaudeId = 3,
                            Descricao = "Recuperado"
                        });
                });

            modelBuilder.Entity("petshopia_API.Model.Alojamento", b =>
                {
                    b.HasOne("petshopia_API.Model.EstadoAlojamento", "EstadoAlojamento")
                        .WithMany()
                        .HasForeignKey("EstadoAlojamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoAlojamento");
                });

            modelBuilder.Entity("petshopia_API.Model.Animal", b =>
                {
                    b.HasOne("petshopia_API.Model.Dono", "Dono")
                        .WithMany()
                        .HasForeignKey("DonoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("petshopia_API.Model.EstadoSaude", "EstadoSaude")
                        .WithMany()
                        .HasForeignKey("EstadoSaudeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dono");

                    b.Navigation("EstadoSaude");
                });
#pragma warning restore 612, 618
        }
    }
}
