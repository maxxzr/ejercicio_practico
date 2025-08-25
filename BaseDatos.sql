USE [bank]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 25/08/2025 03:56:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[Number] [varchar](50) NULL,
	[AccountTypeId] [int] NULL,
	[InitialBalance] [money] NULL,
	[StatusAccountId] [int] NULL,
	[CurrentBalance] [money] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 25/08/2025 03:56:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[AccountTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED 
(
	[AccountTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 25/08/2025 03:56:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[Password] [varchar](50) NULL,
	[StatusClientId] [int] NULL,
	[PersonId] [int] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 25/08/2025 03:56:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[GenderId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 25/08/2025 03:56:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNumber] [varchar](10) NULL,
	[Name] [varchar](50) NULL,
	[GenderId] [int] NULL,
	[BirthDate] [date] NULL,
	[Phone] [varchar](15) NULL,
	[Address] [varchar](300) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusAccount]    Script Date: 25/08/2025 03:56:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusAccount](
	[StatusAccountId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
 CONSTRAINT [NewTable_PK] PRIMARY KEY CLUSTERED 
(
	[StatusAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 25/08/2025 03:56:10 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[DateTransaction] [date] NULL,
	[TransactionTypeId] [int] NULL,
	[Amount] [money] NULL,
	[Balance] [money] NULL,
	[AccountId] [int] NULL,
	[InitialBalance] [money] NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 
GO
INSERT [dbo].[Accounts] ([AccountId], [ClientId], [Number], [AccountTypeId], [InitialBalance], [StatusAccountId], [CurrentBalance]) VALUES (1, 2, N'225487', 2, 100.0000, 1, 700.0000)
GO
INSERT [dbo].[Accounts] ([AccountId], [ClientId], [Number], [AccountTypeId], [InitialBalance], [StatusAccountId], [CurrentBalance]) VALUES (4, 1, N'478758', 2, 2000.0000, 1, 1425.0000)
GO
INSERT [dbo].[Accounts] ([AccountId], [ClientId], [Number], [AccountTypeId], [InitialBalance], [StatusAccountId], [CurrentBalance]) VALUES (12, 2, N'496825', 1, 540.0000, 1, 0.0000)
GO
INSERT [dbo].[Accounts] ([AccountId], [ClientId], [Number], [AccountTypeId], [InitialBalance], [StatusAccountId], [CurrentBalance]) VALUES (13, 3, N'495878', 1, 0.0000, 1, 150.0000)
GO
INSERT [dbo].[Accounts] ([AccountId], [ClientId], [Number], [AccountTypeId], [InitialBalance], [StatusAccountId], [CurrentBalance]) VALUES (14, 1, N'585545', 2, 1000.0000, 1, 1000.0000)
GO
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[AccountType] ON 
GO
INSERT [dbo].[AccountType] ([AccountTypeId], [Description]) VALUES (1, N'Simple')
GO
INSERT [dbo].[AccountType] ([AccountTypeId], [Description]) VALUES (2, N'Corriente')
GO
SET IDENTITY_INSERT [dbo].[AccountType] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 
GO
INSERT [dbo].[Clients] ([ClientId], [Password], [StatusClientId], [PersonId]) VALUES (1, N'Acceso.123', 2, 1)
GO
INSERT [dbo].[Clients] ([ClientId], [Password], [StatusClientId], [PersonId]) VALUES (2, N'string', 1, 8)
GO
INSERT [dbo].[Clients] ([ClientId], [Password], [StatusClientId], [PersonId]) VALUES (3, N'string', 1, 9)
GO
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Genders] ON 
GO
INSERT [dbo].[Genders] ([GenderId], [Description]) VALUES (1, N'Masculino')
GO
INSERT [dbo].[Genders] ([GenderId], [Description]) VALUES (2, N'Femenino')
GO
SET IDENTITY_INSERT [dbo].[Genders] OFF
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 
GO
INSERT [dbo].[Persons] ([PersonId], [DocumentNumber], [Name], [GenderId], [BirthDate], [Phone], [Address]) VALUES (1, N'45945554', N'Jose Lema', 1, CAST(N'2000-01-01' AS Date), N'098254785', N'Otavalo sn y principal')
GO
INSERT [dbo].[Persons] ([PersonId], [DocumentNumber], [Name], [GenderId], [BirthDate], [Phone], [Address]) VALUES (8, N'99321121', N'Marianela Montalvo', 2, CAST(N'2025-08-23' AS Date), N'097548965', N'Amazonas y NNUU')
GO
INSERT [dbo].[Persons] ([PersonId], [DocumentNumber], [Name], [GenderId], [BirthDate], [Phone], [Address]) VALUES (9, N'44400550', N'Juan Osorio', 1, CAST(N'2025-08-23' AS Date), N'098874587', N'13 junio y Equiniccial')
GO
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusAccount] ON 
GO
INSERT [dbo].[StatusAccount] ([StatusAccountId], [Description]) VALUES (1, N'Habilitada')
GO
INSERT [dbo].[StatusAccount] ([StatusAccountId], [Description]) VALUES (2, N'Bloqueada')
GO
INSERT [dbo].[StatusAccount] ([StatusAccountId], [Description]) VALUES (3, N'Suspendida')
GO
SET IDENTITY_INSERT [dbo].[StatusAccount] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 
GO
INSERT [dbo].[Transactions] ([TransactionId], [DateTransaction], [TransactionTypeId], [Amount], [Balance], [AccountId], [InitialBalance]) VALUES (10, CAST(N'2025-08-25' AS Date), 1, 575.0000, 1425.0000, 4, 2000.0000)
GO
INSERT [dbo].[Transactions] ([TransactionId], [DateTransaction], [TransactionTypeId], [Amount], [Balance], [AccountId], [InitialBalance]) VALUES (11, CAST(N'2025-08-25' AS Date), 2, 600.0000, 700.0000, 1, 100.0000)
GO
INSERT [dbo].[Transactions] ([TransactionId], [DateTransaction], [TransactionTypeId], [Amount], [Balance], [AccountId], [InitialBalance]) VALUES (12, CAST(N'2025-08-25' AS Date), 2, 150.0000, 150.0000, 13, 0.0000)
GO
INSERT [dbo].[Transactions] ([TransactionId], [DateTransaction], [TransactionTypeId], [Amount], [Balance], [AccountId], [InitialBalance]) VALUES (13, CAST(N'2025-08-25' AS Date), 1, -540.0000, 0.0000, 12, 540.0000)
GO
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_AccountType] FOREIGN KEY([AccountTypeId])
REFERENCES [dbo].[AccountType] ([AccountTypeId])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_AccountType]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Clients] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([ClientId])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Clients]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([PersonId])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_Persons]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Genders] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([GenderId])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Genders]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Accounts]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del movimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transactions', @level2type=N'COLUMN',@level2name=N'TransactionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de operacion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transactions', @level2type=N'COLUMN',@level2name=N'DateTransaction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de movimiento' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transactions', @level2type=N'COLUMN',@level2name=N'TransactionTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transactions', @level2type=N'COLUMN',@level2name=N'Amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Saldo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transactions', @level2type=N'COLUMN',@level2name=N'Balance'
GO
