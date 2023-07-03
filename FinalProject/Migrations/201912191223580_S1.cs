namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class S1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false, maxLength: 50, unicode: false),
                        CourseName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Credit = c.Double(nullable: false),
                        Description = c.String(maxLength: 8000, unicode: false),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Semesters", t => t.SemesterId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemesterId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false, maxLength: 7, unicode: false),
                        DepartmentName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.SemesterId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Address = c.String(maxLength: 8000, unicode: false),
                        TeacherEmail = c.String(nullable: false),
                        ContactNo = c.String(nullable: false, maxLength: 11, unicode: false),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        TeacherCredit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.RoomAllocates",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Room = c.Int(nullable: false),
                        FromTime = c.DateTime(nullable: false),
                        ToTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 50, unicode: false),
                        StudentEmail = c.String(nullable: false),
                        ContactNo = c.String(nullable: false, maxLength: 11, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 8000, unicode: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.RoomAllocates", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.RoomAllocates", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.RoomAllocates", new[] { "CourseId" });
            DropIndex("dbo.RoomAllocates", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropTable("dbo.Students");
            DropTable("dbo.RoomAllocates");
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
            DropTable("dbo.Semesters");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
