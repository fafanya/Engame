﻿// <auto-generated />
using System;
using ClientCommon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClientCommon.Migrations
{
    [DbContext(typeof(ClientDBContext))]
    partial class ClientDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("ClientCommon.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TaskTypeId");

                    b.Property<string>("Text");

                    b.HasKey("TaskId");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ClientCommon.TaskInstance", b =>
                {
                    b.Property<int>("TaskInstanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TaskId");

                    b.Property<int>("TestId");

                    b.HasKey("TaskInstanceId");

                    b.HasIndex("TaskId");

                    b.HasIndex("TestId");

                    b.ToTable("TaskInstances");
                });

            modelBuilder.Entity("ClientCommon.TaskItem", b =>
                {
                    b.Property<int>("TaskItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SeqNo");

                    b.Property<int?>("TaskId");

                    b.Property<int>("TaskItemGroupId");

                    b.Property<int>("ValueInt");

                    b.Property<string>("ValueString");

                    b.HasKey("TaskItemId");

                    b.HasIndex("TaskId");

                    b.HasIndex("TaskItemGroupId");

                    b.ToTable("TaskItems");
                });

            modelBuilder.Entity("ClientCommon.TaskItemGroup", b =>
                {
                    b.Property<int>("TaskItemGroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Name");

                    b.Property<int>("TaskId");

                    b.HasKey("TaskItemGroupId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskItemGroups");
                });

            modelBuilder.Entity("ClientCommon.TaskItemInstance", b =>
                {
                    b.Property<int>("TaskItemInstanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SeqNo");

                    b.Property<int?>("TaskInstanceId");

                    b.Property<int>("TaskItemGroupId");

                    b.Property<int>("ValueInt");

                    b.Property<string>("ValueString");

                    b.HasKey("TaskItemInstanceId");

                    b.HasIndex("TaskInstanceId");

                    b.HasIndex("TaskItemGroupId");

                    b.ToTable("TaskItemInstances");
                });

            modelBuilder.Entity("ClientCommon.TaskType", b =>
                {
                    b.Property<int>("TaskTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("TaskTypeId");

                    b.ToTable("TaskTypes");
                });

            modelBuilder.Entity("ClientCommon.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Header");

                    b.Property<int>("UserId");

                    b.HasKey("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("ClientCommon.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClientCommon.Task", b =>
                {
                    b.HasOne("ClientCommon.TaskType", "TaskType")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClientCommon.TaskInstance", b =>
                {
                    b.HasOne("ClientCommon.Task", "Task")
                        .WithMany("TaskInstances")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClientCommon.Test", "Test")
                        .WithMany("TaskInstances")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClientCommon.TaskItem", b =>
                {
                    b.HasOne("ClientCommon.Task")
                        .WithMany("TaskItems")
                        .HasForeignKey("TaskId");

                    b.HasOne("ClientCommon.TaskItemGroup", "TaskItemGroup")
                        .WithMany("TaskItems")
                        .HasForeignKey("TaskItemGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClientCommon.TaskItemGroup", b =>
                {
                    b.HasOne("ClientCommon.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClientCommon.TaskItemInstance", b =>
                {
                    b.HasOne("ClientCommon.TaskInstance")
                        .WithMany("TaskItemInstances")
                        .HasForeignKey("TaskInstanceId");

                    b.HasOne("ClientCommon.TaskItemGroup", "TaskItemGroup")
                        .WithMany("TaskItemInstances")
                        .HasForeignKey("TaskItemGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClientCommon.Test", b =>
                {
                    b.HasOne("ClientCommon.User", "User")
                        .WithMany("Tests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
