namespace StudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentWithCourses_relation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentWithCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(),
                        CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentWithCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentWithCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentWithCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentWithCourses", new[] { "StudentId" });
            DropTable("dbo.StudentWithCourses");
        }
    }
}
