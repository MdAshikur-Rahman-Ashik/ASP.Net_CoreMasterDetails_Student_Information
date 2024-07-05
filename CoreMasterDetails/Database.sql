CREATE TABLE [dbo].[Courses] (
    [CourseId]   INT          IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [CourseName] VARCHAR (50) NOT NULL
);

CREATE TABLE [dbo].[Student] (
    [StudentId]   INT           IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [StudentName] VARCHAR (50)  NOT NULL,
    [Dob]         DATETIME      NOT NULL,
    [Mobile]      VARCHAR (50)  NOT NULL,
    [ImageUrl]    VARCHAR (MAX) NOT NULL,
    [Enroll]      BIT           NOT NULL,
    [CourseId]    INT           NOT NULL,
    CONSTRAINT FK_Student_Course FOREIGN KEY (CourseId) REFERENCES Courses (CourseId)
);

CREATE TABLE [dbo].[Module] (
    [ModuleId]   INT          IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [ModuleName] VARCHAR (50) NOT NULL,
    [Duration]   INT          NOT NULL,
    [StudentId]  INT          NOT NULL,
    CONSTRAINT FK_Module_Student FOREIGN KEY (StudentId) REFERENCES Student (StudentId)
);
