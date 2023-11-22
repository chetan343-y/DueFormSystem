
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2023 19:45:20
-- Generated from EDMX file: C:\Users\Chetan\Desktop\Project\DueFormSystem\DueFormSystem\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DueCheckDatabase (1)];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tblAccountSection_tblStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAccountSection] DROP CONSTRAINT [FK_tblAccountSection_tblStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDepartement_tblStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDepartement] DROP CONSTRAINT [FK_tblDepartement_tblStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDepartement_tblYesNo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDepartement] DROP CONSTRAINT [FK_tblDepartement_tblYesNo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDepartement_tblYesNo1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDepartement] DROP CONSTRAINT [FK_tblDepartement_tblYesNo1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDepartement_tblYesNo2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDepartement] DROP CONSTRAINT [FK_tblDepartement_tblYesNo2];
GO
IF OBJECT_ID(N'[dbo].[FK_tblGym_tblStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblGym] DROP CONSTRAINT [FK_tblGym_tblStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_tblHostel_tblStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHostel] DROP CONSTRAINT [FK_tblHostel_tblStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_tblHostel_tblYesNo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblHostel] DROP CONSTRAINT [FK_tblHostel_tblYesNo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblLibrary_tblStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblLibrary] DROP CONSTRAINT [FK_tblLibrary_tblStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_tblScholarship_tblStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblScholarship] DROP CONSTRAINT [FK_tblScholarship_tblStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_tblScholarship_tblYesNo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblScholarship] DROP CONSTRAINT [FK_tblScholarship_tblYesNo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStudent_tblBranch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStudent] DROP CONSTRAINT [FK_tblStudent_tblBranch];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStudent_tblCaste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStudent] DROP CONSTRAINT [FK_tblStudent_tblCaste];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStudent_tblGender]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStudent] DROP CONSTRAINT [FK_tblStudent_tblGender];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStudentSection_tblStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStudentSection] DROP CONSTRAINT [FK_tblStudentSection_tblStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStudentSection_tblYesNo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStudentSection] DROP CONSTRAINT [FK_tblStudentSection_tblYesNo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStudentSection_tblYesNo1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStudentSection] DROP CONSTRAINT [FK_tblStudentSection_tblYesNo1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblStudentSection_tblYesNo2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblStudentSection] DROP CONSTRAINT [FK_tblStudentSection_tblYesNo2];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTPO_tblStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTPO] DROP CONSTRAINT [FK_tblTPO_tblStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTPO_tblYesNo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTPO] DROP CONSTRAINT [FK_tblTPO_tblYesNo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[tblAccountSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccountSection];
GO
IF OBJECT_ID(N'[dbo].[tblAdmin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAdmin];
GO
IF OBJECT_ID(N'[dbo].[tblBranch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblBranch];
GO
IF OBJECT_ID(N'[dbo].[tblCaste]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCaste];
GO
IF OBJECT_ID(N'[dbo].[tblDepartement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDepartement];
GO
IF OBJECT_ID(N'[dbo].[tblGender]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGender];
GO
IF OBJECT_ID(N'[dbo].[tblGym]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblGym];
GO
IF OBJECT_ID(N'[dbo].[tblHostel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblHostel];
GO
IF OBJECT_ID(N'[dbo].[tblLibrary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLibrary];
GO
IF OBJECT_ID(N'[dbo].[tblScholarship]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblScholarship];
GO
IF OBJECT_ID(N'[dbo].[tblStudent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblStudent];
GO
IF OBJECT_ID(N'[dbo].[tblStudentLogin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblStudentLogin];
GO
IF OBJECT_ID(N'[dbo].[tblStudentSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblStudentSection];
GO
IF OBJECT_ID(N'[dbo].[tblTPO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTPO];
GO
IF OBJECT_ID(N'[dbo].[tblYesNo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblYesNo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'tblAccountSections'
CREATE TABLE [dbo].[tblAccountSections] (
    [PRNNo] nvarchar(50)  NOT NULL,
    [PendingFee] decimal(18,2)  NULL
);
GO

-- Creating table 'tblBranches'
CREATE TABLE [dbo].[tblBranches] (
    [Id] int  NOT NULL,
    [Branch] nvarchar(50)  NULL
);
GO

-- Creating table 'tblCastes'
CREATE TABLE [dbo].[tblCastes] (
    [Id] int  NOT NULL,
    [Caste] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tblDepartements'
CREATE TABLE [dbo].[tblDepartements] (
    [PRNNo] nvarchar(50)  NOT NULL,
    [ProjectStatus] int  NULL,
    [Backlog] int  NULL,
    [CGPA] decimal(18,0)  NULL,
    [Pass] int  NULL
);
GO

-- Creating table 'tblGenders'
CREATE TABLE [dbo].[tblGenders] (
    [Id] int  NOT NULL,
    [Gender] nvarchar(50)  NULL
);
GO

-- Creating table 'tblGyms'
CREATE TABLE [dbo].[tblGyms] (
    [PRNNo] nvarchar(50)  NOT NULL,
    [Role] nvarchar(50)  NULL,
    [Fine] decimal(18,2)  NULL
);
GO

-- Creating table 'tblHostels'
CREATE TABLE [dbo].[tblHostels] (
    [PRNNo] nvarchar(50)  NOT NULL,
    [Member] int  NULL,
    [PendingFee] decimal(18,2)  NULL,
    [Fine] decimal(18,2)  NULL
);
GO

-- Creating table 'tblLibraries'
CREATE TABLE [dbo].[tblLibraries] (
    [PRNNo] nvarchar(50)  NOT NULL,
    [PendingBookingId] nvarchar(50)  NULL,
    [Fine] decimal(18,2)  NULL
);
GO

-- Creating table 'tblScholarships'
CREATE TABLE [dbo].[tblScholarships] (
    [PRNNo] nvarchar(50)  NOT NULL,
    [ScholarshipRemFromCollege] decimal(18,2)  NULL,
    [NumberofScholarship] int  NULL,
    [Authenticate] int  NULL
);
GO

-- Creating table 'tblStudents'
CREATE TABLE [dbo].[tblStudents] (
    [PRNNo] nvarchar(50)  NOT NULL,
    [Name] nvarchar(80)  NULL,
    [Branch] int  NULL,
    [Gender] int  NULL,
    [Caste] int  NULL,
    [DOB] datetime  NULL,
    [PhoneNo] decimal(11,0)  NULL,
    [Email] nvarchar(50)  NULL
);
GO

-- Creating table 'tblStudentSections'
CREATE TABLE [dbo].[tblStudentSections] (
    [PRNNo] nvarchar(50)  NOT NULL,
    [Backlog] int  NULL,
    [PendingFee] int  NULL,
    [PendingProject] int  NULL,
    [CheckDue] int  NULL
);
GO

-- Creating table 'tblTPOes'
CREATE TABLE [dbo].[tblTPOes] (
    [PRNNo] nvarchar(50)  NOT NULL,
    [PlacementStatus] int  NULL,
    [ActivtyCompleted] int  NULL
);
GO

-- Creating table 'tblYesNoes'
CREATE TABLE [dbo].[tblYesNoes] (
    [ID] int  NOT NULL,
    [Value] nvarchar(50)  NULL
);
GO

-- Creating table 'tblAdmins'
CREATE TABLE [dbo].[tblAdmins] (
    [Id] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NULL
);
GO

-- Creating table 'tblStudentLogins'
CREATE TABLE [dbo].[tblStudentLogins] (
    [PRNNo] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [PRNNo] in table 'tblAccountSections'
ALTER TABLE [dbo].[tblAccountSections]
ADD CONSTRAINT [PK_tblAccountSections]
    PRIMARY KEY CLUSTERED ([PRNNo] ASC);
GO

-- Creating primary key on [Id] in table 'tblBranches'
ALTER TABLE [dbo].[tblBranches]
ADD CONSTRAINT [PK_tblBranches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblCastes'
ALTER TABLE [dbo].[tblCastes]
ADD CONSTRAINT [PK_tblCastes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PRNNo] in table 'tblDepartements'
ALTER TABLE [dbo].[tblDepartements]
ADD CONSTRAINT [PK_tblDepartements]
    PRIMARY KEY CLUSTERED ([PRNNo] ASC);
GO

-- Creating primary key on [Id] in table 'tblGenders'
ALTER TABLE [dbo].[tblGenders]
ADD CONSTRAINT [PK_tblGenders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PRNNo] in table 'tblGyms'
ALTER TABLE [dbo].[tblGyms]
ADD CONSTRAINT [PK_tblGyms]
    PRIMARY KEY CLUSTERED ([PRNNo] ASC);
GO

-- Creating primary key on [PRNNo] in table 'tblHostels'
ALTER TABLE [dbo].[tblHostels]
ADD CONSTRAINT [PK_tblHostels]
    PRIMARY KEY CLUSTERED ([PRNNo] ASC);
GO

-- Creating primary key on [PRNNo] in table 'tblLibraries'
ALTER TABLE [dbo].[tblLibraries]
ADD CONSTRAINT [PK_tblLibraries]
    PRIMARY KEY CLUSTERED ([PRNNo] ASC);
GO

-- Creating primary key on [PRNNo] in table 'tblScholarships'
ALTER TABLE [dbo].[tblScholarships]
ADD CONSTRAINT [PK_tblScholarships]
    PRIMARY KEY CLUSTERED ([PRNNo] ASC);
GO

-- Creating primary key on [PRNNo] in table 'tblStudents'
ALTER TABLE [dbo].[tblStudents]
ADD CONSTRAINT [PK_tblStudents]
    PRIMARY KEY CLUSTERED ([PRNNo] ASC);
GO

-- Creating primary key on [PRNNo] in table 'tblStudentSections'
ALTER TABLE [dbo].[tblStudentSections]
ADD CONSTRAINT [PK_tblStudentSections]
    PRIMARY KEY CLUSTERED ([PRNNo] ASC);
GO

-- Creating primary key on [PRNNo] in table 'tblTPOes'
ALTER TABLE [dbo].[tblTPOes]
ADD CONSTRAINT [PK_tblTPOes]
    PRIMARY KEY CLUSTERED ([PRNNo] ASC);
GO

-- Creating primary key on [ID] in table 'tblYesNoes'
ALTER TABLE [dbo].[tblYesNoes]
ADD CONSTRAINT [PK_tblYesNoes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'tblAdmins'
ALTER TABLE [dbo].[tblAdmins]
ADD CONSTRAINT [PK_tblAdmins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [PRNNo] in table 'tblStudentLogins'
ALTER TABLE [dbo].[tblStudentLogins]
ADD CONSTRAINT [PK_tblStudentLogins]
    PRIMARY KEY CLUSTERED ([PRNNo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PRNNo] in table 'tblAccountSections'
ALTER TABLE [dbo].[tblAccountSections]
ADD CONSTRAINT [FK_tblAccountSection_tblStudent]
    FOREIGN KEY ([PRNNo])
    REFERENCES [dbo].[tblStudents]
        ([PRNNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Branch] in table 'tblStudents'
ALTER TABLE [dbo].[tblStudents]
ADD CONSTRAINT [FK_tblStudent_tblBranch]
    FOREIGN KEY ([Branch])
    REFERENCES [dbo].[tblBranches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStudent_tblBranch'
CREATE INDEX [IX_FK_tblStudent_tblBranch]
ON [dbo].[tblStudents]
    ([Branch]);
GO

-- Creating foreign key on [Gender] in table 'tblStudents'
ALTER TABLE [dbo].[tblStudents]
ADD CONSTRAINT [FK_tblStudent_tblCaste]
    FOREIGN KEY ([Gender])
    REFERENCES [dbo].[tblCastes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStudent_tblCaste'
CREATE INDEX [IX_FK_tblStudent_tblCaste]
ON [dbo].[tblStudents]
    ([Gender]);
GO

-- Creating foreign key on [PRNNo] in table 'tblDepartements'
ALTER TABLE [dbo].[tblDepartements]
ADD CONSTRAINT [FK_tblDepartement_tblStudent]
    FOREIGN KEY ([PRNNo])
    REFERENCES [dbo].[tblStudents]
        ([PRNNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProjectStatus] in table 'tblDepartements'
ALTER TABLE [dbo].[tblDepartements]
ADD CONSTRAINT [FK_tblDepartement_tblYesNo]
    FOREIGN KEY ([ProjectStatus])
    REFERENCES [dbo].[tblYesNoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDepartement_tblYesNo'
CREATE INDEX [IX_FK_tblDepartement_tblYesNo]
ON [dbo].[tblDepartements]
    ([ProjectStatus]);
GO

-- Creating foreign key on [Pass] in table 'tblDepartements'
ALTER TABLE [dbo].[tblDepartements]
ADD CONSTRAINT [FK_tblDepartement_tblYesNo1]
    FOREIGN KEY ([Pass])
    REFERENCES [dbo].[tblYesNoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDepartement_tblYesNo1'
CREATE INDEX [IX_FK_tblDepartement_tblYesNo1]
ON [dbo].[tblDepartements]
    ([Pass]);
GO

-- Creating foreign key on [Pass] in table 'tblDepartements'
ALTER TABLE [dbo].[tblDepartements]
ADD CONSTRAINT [FK_tblDepartement_tblYesNo2]
    FOREIGN KEY ([Pass])
    REFERENCES [dbo].[tblYesNoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDepartement_tblYesNo2'
CREATE INDEX [IX_FK_tblDepartement_tblYesNo2]
ON [dbo].[tblDepartements]
    ([Pass]);
GO

-- Creating foreign key on [ProjectStatus] in table 'tblDepartements'
ALTER TABLE [dbo].[tblDepartements]
ADD CONSTRAINT [FK_tblDepartement_tblYesNo3]
    FOREIGN KEY ([ProjectStatus])
    REFERENCES [dbo].[tblYesNoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDepartement_tblYesNo3'
CREATE INDEX [IX_FK_tblDepartement_tblYesNo3]
ON [dbo].[tblDepartements]
    ([ProjectStatus]);
GO

-- Creating foreign key on [Gender] in table 'tblStudents'
ALTER TABLE [dbo].[tblStudents]
ADD CONSTRAINT [FK_tblStudent_tblGender]
    FOREIGN KEY ([Gender])
    REFERENCES [dbo].[tblGenders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStudent_tblGender'
CREATE INDEX [IX_FK_tblStudent_tblGender]
ON [dbo].[tblStudents]
    ([Gender]);
GO

-- Creating foreign key on [PRNNo] in table 'tblGyms'
ALTER TABLE [dbo].[tblGyms]
ADD CONSTRAINT [FK_tblGym_tblStudent]
    FOREIGN KEY ([PRNNo])
    REFERENCES [dbo].[tblStudents]
        ([PRNNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PRNNo] in table 'tblHostels'
ALTER TABLE [dbo].[tblHostels]
ADD CONSTRAINT [FK_tblHostel_tblStudent]
    FOREIGN KEY ([PRNNo])
    REFERENCES [dbo].[tblStudents]
        ([PRNNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Member] in table 'tblHostels'
ALTER TABLE [dbo].[tblHostels]
ADD CONSTRAINT [FK_tblHostel_tblYesNo]
    FOREIGN KEY ([Member])
    REFERENCES [dbo].[tblYesNoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblHostel_tblYesNo'
CREATE INDEX [IX_FK_tblHostel_tblYesNo]
ON [dbo].[tblHostels]
    ([Member]);
GO

-- Creating foreign key on [PRNNo] in table 'tblLibraries'
ALTER TABLE [dbo].[tblLibraries]
ADD CONSTRAINT [FK_tblLibrary_tblStudent]
    FOREIGN KEY ([PRNNo])
    REFERENCES [dbo].[tblStudents]
        ([PRNNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PRNNo] in table 'tblScholarships'
ALTER TABLE [dbo].[tblScholarships]
ADD CONSTRAINT [FK_tblScholarship_tblStudent]
    FOREIGN KEY ([PRNNo])
    REFERENCES [dbo].[tblStudents]
        ([PRNNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Authenticate] in table 'tblScholarships'
ALTER TABLE [dbo].[tblScholarships]
ADD CONSTRAINT [FK_tblScholarship_tblYesNo]
    FOREIGN KEY ([Authenticate])
    REFERENCES [dbo].[tblYesNoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblScholarship_tblYesNo'
CREATE INDEX [IX_FK_tblScholarship_tblYesNo]
ON [dbo].[tblScholarships]
    ([Authenticate]);
GO

-- Creating foreign key on [PRNNo] in table 'tblStudentSections'
ALTER TABLE [dbo].[tblStudentSections]
ADD CONSTRAINT [FK_tblStudentSection_tblStudent]
    FOREIGN KEY ([PRNNo])
    REFERENCES [dbo].[tblStudents]
        ([PRNNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PRNNo] in table 'tblTPOes'
ALTER TABLE [dbo].[tblTPOes]
ADD CONSTRAINT [FK_tblTPO_tblStudent]
    FOREIGN KEY ([PRNNo])
    REFERENCES [dbo].[tblStudents]
        ([PRNNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CheckDue] in table 'tblStudentSections'
ALTER TABLE [dbo].[tblStudentSections]
ADD CONSTRAINT [FK_tblStudentSection_tblYesNo]
    FOREIGN KEY ([CheckDue])
    REFERENCES [dbo].[tblYesNoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStudentSection_tblYesNo'
CREATE INDEX [IX_FK_tblStudentSection_tblYesNo]
ON [dbo].[tblStudentSections]
    ([CheckDue]);
GO

-- Creating foreign key on [Backlog] in table 'tblStudentSections'
ALTER TABLE [dbo].[tblStudentSections]
ADD CONSTRAINT [FK_tblStudentSection_tblYesNo1]
    FOREIGN KEY ([Backlog])
    REFERENCES [dbo].[tblYesNoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStudentSection_tblYesNo1'
CREATE INDEX [IX_FK_tblStudentSection_tblYesNo1]
ON [dbo].[tblStudentSections]
    ([Backlog]);
GO

-- Creating foreign key on [PendingProject] in table 'tblStudentSections'
ALTER TABLE [dbo].[tblStudentSections]
ADD CONSTRAINT [FK_tblStudentSection_tblYesNo2]
    FOREIGN KEY ([PendingProject])
    REFERENCES [dbo].[tblYesNoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblStudentSection_tblYesNo2'
CREATE INDEX [IX_FK_tblStudentSection_tblYesNo2]
ON [dbo].[tblStudentSections]
    ([PendingProject]);
GO

-- Creating foreign key on [PlacementStatus] in table 'tblTPOes'
ALTER TABLE [dbo].[tblTPOes]
ADD CONSTRAINT [FK_tblTPO_tblYesNo]
    FOREIGN KEY ([PlacementStatus])
    REFERENCES [dbo].[tblYesNoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblTPO_tblYesNo'
CREATE INDEX [IX_FK_tblTPO_tblYesNo]
ON [dbo].[tblTPOes]
    ([PlacementStatus]);
GO

-- Creating foreign key on [Backlog] in table 'tblDepartements'
ALTER TABLE [dbo].[tblDepartements]
ADD CONSTRAINT [FK_tblDepartement_tblYesNo21]
    FOREIGN KEY ([Backlog])
    REFERENCES [dbo].[tblYesNoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDepartement_tblYesNo21'
CREATE INDEX [IX_FK_tblDepartement_tblYesNo21]
ON [dbo].[tblDepartements]
    ([Backlog]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------