USE [BookStore]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/19/2019 5:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 12/19/2019 5:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](25) NOT NULL,
	[Password] [nvarchar](25) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookCategory]    Script Date: 12/19/2019 5:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_BookCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 12/19/2019 5:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Author] [nvarchar](max) NOT NULL,
	[DatePublish] [datetime2](7) NOT NULL,
	[Publisher] [nvarchar](max) NOT NULL,
	[Translater] [nvarchar](max) NULL,
	[Size] [nvarchar](max) NOT NULL,
	[Pages] [int] NOT NULL,
	[Cover] [nvarchar](max) NOT NULL,
	[Price] [int] NOT NULL,
	[Saleoff] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[NSeen] [int] NOT NULL,
	[NLove] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartDetails]    Script Date: 12/19/2019 5:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cart_Id] [int] NOT NULL,
	[Book_Id] [int] NOT NULL,
	[Book_Title] [nvarchar](max) NULL,
	[Book_Price] [int] NOT NULL,
	[Book_Saleoff] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Total] [int] NOT NULL,
 CONSTRAINT [PK_CartDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 12/19/2019 5:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NOT NULL,
	[TotalPrice] [int] NOT NULL,
	[TotalQuantity] [int] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 12/19/2019 5:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 12/19/2019 5:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dictricts]    Script Date: 12/19/2019 5:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dictricts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Dictricts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/19/2019 5:24:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](25) NOT NULL,
	[Password] [nvarchar](25) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[NameFirst] [nvarchar](100) NOT NULL,
	[NameMiddle] [nvarchar](100) NULL,
	[NameLast] [nvarchar](100) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DateBirth] [datetime2](7) NULL,
	[CountryId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[DistrictId] [int] NOT NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191219063436_Newasdasd', N'2.2.6-servicing-10079')
SET IDENTITY_INSERT [dbo].[Admins] ON 

INSERT [dbo].[Admins] ([Id], [Username], [Password], [Email]) VALUES (1, N'pthyst', N'phuongdung', N'pthyst@gmail.com')
INSERT [dbo].[Admins] ([Id], [Username], [Password], [Email]) VALUES (2, N'sangnt43', N'sangnt43', N'sangnt43@gmail.com')
SET IDENTITY_INSERT [dbo].[Admins] OFF
SET IDENTITY_INSERT [dbo].[BookCategory] ON 

INSERT [dbo].[BookCategory] ([Id], [Name], [Description]) VALUES (1, N'Truyện thiếu nhi', N'Truyện dành cho thiếu nhi từ 6 đến 12 tuổi')
INSERT [dbo].[BookCategory] ([Id], [Name], [Description]) VALUES (2, N'Truyện tranh', N'Truyện tranh dành mọi lứa tuổi')
INSERT [dbo].[BookCategory] ([Id], [Name], [Description]) VALUES (3, N'Tiểu thuyết', N'Tác phẩm văn học dành cho lứa tuổi từ 16 trở lên')
INSERT [dbo].[BookCategory] ([Id], [Name], [Description]) VALUES (4, N'Truyện kinh dị', N'Sản phẩm giải trí dành cho lứa tuổi từ 12 trở lên')
INSERT [dbo].[BookCategory] ([Id], [Name], [Description]) VALUES (5, N'Văn học Việt Nam', N'Tác phẩm văn học Việt Nam')
INSERT [dbo].[BookCategory] ([Id], [Name], [Description]) VALUES (6, N'Văn học nước ngoài', N'Tác phẩm văn học nước ngoài tổng hợp')
SET IDENTITY_INSERT [dbo].[BookCategory] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Title], [Description], [Author], [DatePublish], [Publisher], [Translater], [Size], [Pages], [Cover], [Price], [Saleoff], [CategoryId], [NSeen], [NLove]) VALUES (1, N'Dế mèn phiêu lưu ký', NULL, N'Tô Hoài', CAST(N'2019-12-24T00:00:00.0000000' AS DateTime2), N'NXB Kim Đồng', NULL, N'35x15', 150, N'2019121916147.jpg', 100000, 0, 1, 0, 0)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Author], [DatePublish], [Publisher], [Translater], [Size], [Pages], [Cover], [Price], [Saleoff], [CategoryId], [NSeen], [NLove]) VALUES (2, N'Dế Choắt và Jombie', NULL, N'Lục Lăng', CAST(N'2019-12-24T00:00:00.0000000' AS DateTime2), N'NXB G5R', NULL, N'35x15', 150, N'2019121916158.jpg', 100000, 0, 1, 0, 0)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Author], [DatePublish], [Publisher], [Translater], [Size], [Pages], [Cover], [Price], [Saleoff], [CategoryId], [NSeen], [NLove]) VALUES (3, N'Tầng thượng 102', NULL, N'Cá Hồi Hoang', CAST(N'2019-12-24T00:00:00.0000000' AS DateTime2), N'NXB Kén Người Nghe', NULL, N'35x15', 150, N'2019121916212.jpg', 100000, 0, 3, 0, 0)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Author], [DatePublish], [Publisher], [Translater], [Size], [Pages], [Cover], [Price], [Saleoff], [CategoryId], [NSeen], [NLove]) VALUES (4, N'5AM', NULL, N'Cá Hồi Hoang', CAST(N'2019-12-24T00:00:00.0000000' AS DateTime2), N'NXB Kén Người Nghe', NULL, N'35x15', 150, N'2019121916225.jpg', 100000, 0, 3, 0, 0)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Author], [DatePublish], [Publisher], [Translater], [Size], [Pages], [Cover], [Price], [Saleoff], [CategoryId], [NSeen], [NLove]) VALUES (5, N'Khói thuốc đợi chờ', NULL, N'Jimmy Nguyễn', CAST(N'2019-12-24T00:00:00.0000000' AS DateTime2), N'NXB Âm nhạc cổ điển', NULL, N'35x15', 150, N'2019121916337.jpg', 100000, 0, 3, 0, 0)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Author], [DatePublish], [Publisher], [Translater], [Size], [Pages], [Cover], [Price], [Saleoff], [CategoryId], [NSeen], [NLove]) VALUES (6, N'Tiết diên 2013', NULL, N'Trần Dần', CAST(N'2019-12-24T00:00:00.0000000' AS DateTime2), N'NXB Người Điên Khu Bolsa', NULL, N'35x15', 150, N'2019121916349.jpg', 100000, 0, 3, 0, 0)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Author], [DatePublish], [Publisher], [Translater], [Size], [Pages], [Cover], [Price], [Saleoff], [CategoryId], [NSeen], [NLove]) VALUES (8, N'Doraemon và 100 bảo bối', NULL, N'Fujima', CAST(N'2019-12-19T00:00:00.0000000' AS DateTime2), N'NXB Kim Đồng', N'Huỳnh Trương Chí Quân', N'25x20', 100, N'2019121916622.jpg', 25000, 10, 2, 0, 0)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Author], [DatePublish], [Publisher], [Translater], [Size], [Pages], [Cover], [Price], [Saleoff], [CategoryId], [NSeen], [NLove]) VALUES (9, N'Thám tử lừng danh Conan tập 54', NULL, N'Fujima', CAST(N'2019-12-19T00:00:00.0000000' AS DateTime2), N'NXB Kim Đồng', N'Huỳnh Trương Chí Quân', N'25x20', 100, N'2019121916728.jpg', 30000, 10, 2, 0, 0)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Author], [DatePublish], [Publisher], [Translater], [Size], [Pages], [Cover], [Price], [Saleoff], [CategoryId], [NSeen], [NLove]) VALUES (10, N'Kim Bình Mai tập 1', NULL, N'Tiếu Tiếu Sinh', CAST(N'2019-12-19T00:00:00.0000000' AS DateTime2), N'NXB Kim Đồng', N'Huỳnh Trương Chí Quân', N'40x25', 250, N'20191219161313.jpg', 3000000, 15, 3, 0, 0)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Author], [DatePublish], [Publisher], [Translater], [Size], [Pages], [Cover], [Price], [Saleoff], [CategoryId], [NSeen], [NLove]) VALUES (11, N'Túp lều bác Tom', NULL, N'Tô Hoài', CAST(N'2019-12-19T00:00:00.0000000' AS DateTime2), N'NXB Kim Đồng', N'Huỳnh Trương Chí Quân', N'35x20', 200, N'20191219161525.jpg', 15000, 10, 1, 0, 0)
INSERT [dbo].[Books] ([Id], [Title], [Description], [Author], [DatePublish], [Publisher], [Translater], [Size], [Pages], [Cover], [Price], [Saleoff], [CategoryId], [NSeen], [NLove]) VALUES (12, N'Thép đã tôi thế đấy', NULL, N'Nikolai A.Ostrovsky', CAST(N'2019-12-19T00:00:00.0000000' AS DateTime2), N'NXB Văn Học', N'Huỳnh Trương Chí Quân', N'40x25', 300, N'2019121916175.jpg', 150000, 5, 6, 0, 0)
SET IDENTITY_INSERT [dbo].[Books] OFF
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_BookCategory_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[BookCategory] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_BookCategory_CategoryId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Cities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Cities_CityId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Countries_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Countries_CountryId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Dictricts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Dictricts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Dictricts_DistrictId]
GO
