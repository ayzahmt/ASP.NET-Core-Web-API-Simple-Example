USE [Article]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 22/10/2019 11:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Author] [varchar](50) NOT NULL,
	[Subject] [varchar](50) NOT NULL,
	[PublishDate] [date] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([Id], [Name], [Author], [Subject], [PublishDate]) VALUES (1, N'Deep Learning', N'Ahmet Ayaz', N'Classification', CAST(N'2019-10-20' AS Date))
INSERT [dbo].[Article] ([Id], [Name], [Author], [Subject], [PublishDate]) VALUES (6, N'Machine Learning', N'Ahmet Ayaz', N'Face Detection', CAST(N'2019-10-20' AS Date))
INSERT [dbo].[Article] ([Id], [Name], [Author], [Subject], [PublishDate]) VALUES (7, N'Advanced Algorithm Analysis', N'Ahmet Ayaz', N'Dynamic Programming', CAST(N'2019-10-20' AS Date))
INSERT [dbo].[Article] ([Id], [Name], [Author], [Subject], [PublishDate]) VALUES (8, N'Data Structure', N'Ahmet Ayaz', N'Stack - Heap', CAST(N'2019-10-20' AS Date))
INSERT [dbo].[Article] ([Id], [Name], [Author], [Subject], [PublishDate]) VALUES (10, N'Köy', N'Ugur Dagasan', N'Hayvancilik - Tarim', CAST(N'2019-10-21' AS Date))
INSERT [dbo].[Article] ([Id], [Name], [Author], [Subject], [PublishDate]) VALUES (11, N'Image Processing', N'Ahmet Ayaz', N'Segmentation Lung Tissue from CT', CAST(N'2019-10-21' AS Date))
INSERT [dbo].[Article] ([Id], [Name], [Author], [Subject], [PublishDate]) VALUES (13, N'Test', N'Ahmet Ayaz', N'Segmentation Lung Tissue from CT', CAST(N'2019-10-21' AS Date))
INSERT [dbo].[Article] ([Id], [Name], [Author], [Subject], [PublishDate]) VALUES (14, N'Test', N'Ahmet Ayaz', N'Segmentation Lung Tissue from CT', CAST(N'2019-10-21' AS Date))
SET IDENTITY_INSERT [dbo].[Article] OFF
