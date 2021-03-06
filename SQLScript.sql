USE [LibraryDB]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 26-08-2021 17:10:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Book](
	[id] [bigint] IDENTITY(100,1) NOT NULL,
	[BookId] [varchar](20) NOT NULL,
	[BookName] [varchar](100) NULL,
	[Author] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookAssignments]    Script Date: 26-08-2021 17:10:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookAssignments](
	[id] [bigint] IDENTITY(10,1) NOT NULL,
	[AssignmentId] [varchar](50) NOT NULL,
	[StudentId] [varchar](50) NULL,
	[BookId] [varchar](20) NULL,
	[AllotStartDate] [datetime] NULL,
	[AllotEndDate] [datetime] NULL,
	[IsBookGiven] [bit] NULL,
	[IsReturned] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LibraryAssets]    Script Date: 26-08-2021 17:10:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LibraryAssets](
	[id] [bigint] IDENTITY(100,1) NOT NULL,
	[BookId] [varchar](20) NULL,
	[Quantity] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 26-08-2021 17:10:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[id] [bigint] IDENTITY(100,1) NOT NULL,
	[StudentId] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Name] [varchar](100) NULL,
	[Phone] [varchar](15) NULL,
	[ClassName] [varchar](4) NULL,
	[HomeAddress] [varchar](400) NULL,
	[Age] [int] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

GO
INSERT [dbo].[Book] ([id], [BookId], [BookName], [Author]) VALUES (100, N'BK6922208', N'The C++ Programming Language', N'Bjarne Stroustrup')
GO
INSERT [dbo].[Book] ([id], [BookId], [BookName], [Author]) VALUES (101, N'BK9096208', N'The Practice of Programming', N'Brian W. Kernighan, Rob Pike')
GO
INSERT [dbo].[Book] ([id], [BookId], [BookName], [Author]) VALUES (102, N'BK8133208', N'Fundamentals of Computer Algorithms', N'Ellis Horowitz')
GO
INSERT [dbo].[Book] ([id], [BookId], [BookName], [Author]) VALUES (103, N'BK4635208', N'The Art of Unix Programming', N'Eric Raymond')
GO
INSERT [dbo].[Book] ([id], [BookId], [BookName], [Author]) VALUES (104, N'BK7291208', N'The Java Programming Language', N'James Gosling')
GO
INSERT [dbo].[Book] ([id], [BookId], [BookName], [Author]) VALUES (105, N'BK9762208', N'Patterns of Software', N'Richard P. Gabriel')
GO
INSERT [dbo].[Book] ([id], [BookId], [BookName], [Author]) VALUES (106, N'BK01812608', N'Complete Reference of Java32', N'Herbert Shield32')
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[LibraryAssets] ON 

GO
INSERT [dbo].[LibraryAssets] ([id], [BookId], [Quantity], [IsActive]) VALUES (100, N'BK6922208', 5, 1)
GO
INSERT [dbo].[LibraryAssets] ([id], [BookId], [Quantity], [IsActive]) VALUES (101, N'BK6922208', 8, 1)
GO
INSERT [dbo].[LibraryAssets] ([id], [BookId], [Quantity], [IsActive]) VALUES (102, N'BK9096208', 3, 1)
GO
INSERT [dbo].[LibraryAssets] ([id], [BookId], [Quantity], [IsActive]) VALUES (103, N'BK8133208', 12, 1)
GO
INSERT [dbo].[LibraryAssets] ([id], [BookId], [Quantity], [IsActive]) VALUES (104, N'BK4635208', 7, 1)
GO
INSERT [dbo].[LibraryAssets] ([id], [BookId], [Quantity], [IsActive]) VALUES (105, N'BK7291208', 4, 1)
GO
INSERT [dbo].[LibraryAssets] ([id], [BookId], [Quantity], [IsActive]) VALUES (106, N'BK9762208', 2, 1)
GO
INSERT [dbo].[LibraryAssets] ([id], [BookId], [Quantity], [IsActive]) VALUES (107, N'BK01812608', 4, 1)
GO
SET IDENTITY_INSERT [dbo].[LibraryAssets] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Book__3DE0C206D52CBBFA]    Script Date: 26-08-2021 17:10:21 ******/
ALTER TABLE [dbo].[Book] ADD UNIQUE NONCLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__BookAssi__32499E7616852ADD]    Script Date: 26-08-2021 17:10:21 ******/
ALTER TABLE [dbo].[BookAssignments] ADD UNIQUE NONCLUSTERED 
(
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Student__32C52B988A512413]    Script Date: 26-08-2021 17:10:21 ******/
ALTER TABLE [dbo].[Student] ADD UNIQUE NONCLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Student__A9D1053435ADE1F0]    Script Date: 26-08-2021 17:10:21 ******/
ALTER TABLE [dbo].[Student] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BookAssignments]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[BookAssignments]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[LibraryAssets]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
