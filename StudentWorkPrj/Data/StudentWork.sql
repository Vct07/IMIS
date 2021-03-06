USE [StudentWork]
GO
/****** Object:  Table [dbo].[WorkObj]    Script Date: 04/05/2016 22:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkObj](
	[ID] [uniqueidentifier] NOT NULL,
	[MS_Person_FK] [uniqueidentifier] NULL,
	[WorkInfo_FK] [uniqueidentifier] NULL,
	[CreateDate] [datetime] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_WorkObj] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生外键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkObj', @level2type=N'COLUMN',@level2name=N'MS_Person_FK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位外键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkObj', @level2type=N'COLUMN',@level2name=N'WorkInfo_FK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkObj', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型(1:意向;2:已分配)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkObj', @level2type=N'COLUMN',@level2name=N'Type'
GO
/****** Object:  Table [dbo].[WorkInfo]    Script Date: 04/05/2016 22:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkInfo](
	[ID] [uniqueidentifier] NOT NULL,
	[PostName] [nvarchar](50) NULL,
	[Remark] [text] NULL,
	[Responsibility] [text] NULL,
	[Requirement] [text] NULL,
	[CreateDate] [datetime] NULL,
	[Num] [int] NULL,
	[Company_FK] [uniqueidentifier] NULL,
	[WorkType] [nvarchar](50) NULL,
	[Wages] [int] NULL,
	[Flg] [bit] NULL,
	[ObjNum] [int] NULL,
 CONSTRAINT [PK_WorkInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkInfo', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkInfo', @level2type=N'COLUMN',@level2name=N'PostName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkInfo', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职责' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkInfo', @level2type=N'COLUMN',@level2name=N'Responsibility'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'要求' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkInfo', @level2type=N'COLUMN',@level2name=N'Requirement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkInfo', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'招聘数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkInfo', @level2type=N'COLUMN',@level2name=N'Num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkInfo', @level2type=N'COLUMN',@level2name=N'WorkType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkInfo', @level2type=N'COLUMN',@level2name=N'Wages'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否有效' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkInfo', @level2type=N'COLUMN',@level2name=N'Flg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'已入职数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkInfo', @level2type=N'COLUMN',@level2name=N'ObjNum'
GO
/****** Object:  Table [dbo].[WorkExperience]    Script Date: 04/05/2016 22:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkExperience](
	[ID] [uniqueidentifier] NOT NULL,
	[MS_Person_FK] [uniqueidentifier] NOT NULL,
	[CompanyName] [nvarchar](200) NOT NULL,
	[CompanyCountry] [nvarchar](100) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[PostName] [nvarchar](100) NULL,
 CONSTRAINT [PK_WorkExperience] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkExperience', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生外键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkExperience', @level2type=N'COLUMN',@level2name=N'MS_Person_FK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkExperience', @level2type=N'COLUMN',@level2name=N'CompanyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司所在地（国家）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkExperience', @level2type=N'COLUMN',@level2name=N'CompanyCountry'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkExperience', @level2type=N'COLUMN',@level2name=N'StartDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkExperience', @level2type=N'COLUMN',@level2name=N'PostName'
GO
/****** Object:  Table [dbo].[WorkCompany]    Script Date: 04/05/2016 22:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkCompany](
	[ID] [uniqueidentifier] NOT NULL,
	[CompanyName] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[City] [nvarchar](100) NULL,
	[PostCode] [nvarchar](10) NULL,
	[Contry] [nvarchar](100) NULL,
	[ContactMiddleName] [nvarchar](50) NULL,
	[ContactFirstName] [nvarchar](50) NULL,
	[ContactPost] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[WebSite] [nvarchar](50) NULL,
	[Remark] [nvarchar](500) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_WorkCompany] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'CompanyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'City'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'PostCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'Contry'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'ContactMiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人姓' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'ContactFirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人职位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'ContactPost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司网址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'WebSite'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkCompany', @level2type=N'COLUMN',@level2name=N'Email'
GO
/****** Object:  Table [dbo].[StudentEduMap]    Script Date: 04/05/2016 22:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentEduMap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Student_FK] [uniqueidentifier] NULL,
	[Education_FK] [uniqueidentifier] NULL,
 CONSTRAINT [PK_StudentEduMap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 04/05/2016 22:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'技能名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Skill', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别(1:技术;2:CMS;3:操作系统)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Skill', @level2type=N'COLUMN',@level2name=N'Type'
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 04/05/2016 22:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[ID] [uniqueidentifier] NOT NULL,
	[SYear] [nvarchar](50) NULL,
	[Stype] [int] NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Semester', @level2type=N'COLUMN',@level2name=N'SYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学期（1:秋季/2:冬季，默认秋季）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Semester', @level2type=N'COLUMN',@level2name=N'Stype'
GO
/****** Object:  Table [dbo].[MS_Person]    Script Date: 04/05/2016 22:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MS_Person](
	[MS_PersonOID] [uniqueidentifier] NOT NULL,
	[PersonNumber] [nvarchar](50) NOT NULL,
	[PassWord] [nvarchar](50) NOT NULL,
	[IfAdmin] [bit] NULL,
	[NickName] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[MiddleName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Sex] [bit] NULL,
	[Status] [int] NULL,
	[WorkStatus] [bit] NULL,
	[Semester_FK] [uniqueidentifier] NULL,
 CONSTRAINT [PK_MS_Person] PRIMARY KEY CLUSTERED 
(
	[MS_PersonOID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'MS_PersonOID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'PersonNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登陆密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'PassWord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否管理员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'IfAdmin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'NickName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生中间名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'MiddleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生姓' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'FirstName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别(男:True;女:False)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态（1:国际学生;2:本地人）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实习状态(1:已受雇;0:未受雇)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'WorkStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学期学年外键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_Person', @level2type=N'COLUMN',@level2name=N'Semester_FK'
GO
/****** Object:  Table [dbo].[InterestWork]    Script Date: 04/05/2016 22:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterestWork](
	[ID] [uniqueidentifier] NOT NULL,
	[MS_Person_FK] [uniqueidentifier] NULL,
	[WorkInfo_FK] [uniqueidentifier] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_InterestWork] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InterestWork', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学生外键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InterestWork', @level2type=N'COLUMN',@level2name=N'MS_Person_FK'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工作职位外键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InterestWork', @level2type=N'COLUMN',@level2name=N'WorkInfo_FK'
GO
/****** Object:  Table [dbo].[Education]    Script Date: 04/05/2016 22:11:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[ID] [uniqueidentifier] NOT NULL,
	[DegreeType] [int] NULL,
	[MajorName] [nvarchar](100) NULL,
	[GPA] [nvarchar](100) NULL,
	[UniversityName] [nvarchar](100) NULL,
	[ContryName] [nvarchar](100) NULL,
	[CertificateTitle] [nvarchar](50) NULL,
	[CertificateOntology] [nvarchar](50) NULL,
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学位种类（0:毕业前/1:毕业后）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Education', @level2type=N'COLUMN',@level2name=N'DegreeType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专业' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Education', @level2type=N'COLUMN',@level2name=N'MajorName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Education', @level2type=N'COLUMN',@level2name=N'ContryName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'证书称谓（例如CCNA）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Education', @level2type=N'COLUMN',@level2name=N'CertificateTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'证书本体（例如CISCO）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Education', @level2type=N'COLUMN',@level2name=N'CertificateOntology'
GO
/****** Object:  Default [DF_MS_Person_Sex]    Script Date: 04/05/2016 22:11:33 ******/
ALTER TABLE [dbo].[MS_Person] ADD  CONSTRAINT [DF_MS_Person_Sex]  DEFAULT ((1)) FOR [Sex]
GO
/****** Object:  Default [DF_MS_Person_WorkStatus]    Script Date: 04/05/2016 22:11:33 ******/
ALTER TABLE [dbo].[MS_Person] ADD  CONSTRAINT [DF_MS_Person_WorkStatus]  DEFAULT ((0)) FOR [WorkStatus]
GO
/****** Object:  Default [DF_Semester_Stype]    Script Date: 04/05/2016 22:11:33 ******/
ALTER TABLE [dbo].[Semester] ADD  CONSTRAINT [DF_Semester_Stype]  DEFAULT ((1)) FOR [Stype]
GO
/****** Object:  Default [DF_WorkInfo_Flg]    Script Date: 04/05/2016 22:11:33 ******/
ALTER TABLE [dbo].[WorkInfo] ADD  CONSTRAINT [DF_WorkInfo_Flg]  DEFAULT ((1)) FOR [Flg]
GO
/****** Object:  Default [DF_WorkInfo_ObjNum]    Script Date: 04/05/2016 22:11:33 ******/
ALTER TABLE [dbo].[WorkInfo] ADD  CONSTRAINT [DF_WorkInfo_ObjNum]  DEFAULT ((0)) FOR [ObjNum]
GO
/****** Object:  Default [DF_WorkObj_Type]    Script Date: 04/05/2016 22:11:33 ******/
ALTER TABLE [dbo].[WorkObj] ADD  CONSTRAINT [DF_WorkObj_Type]  DEFAULT ((1)) FOR [Type]
GO
