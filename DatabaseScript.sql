USE [master]
GO
/****** Object:  Database [ReminderDB]    Script Date: 5/12/2019 3:00:15 PM ******/
CREATE DATABASE [ReminderDB]
GO
USE [ReminderDB]
GO
/****** Object:  Table [dbo].[tblReminder]    Script Date: 5/12/2019 3:00:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblReminder](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Time] [time](7) NULL,
	[Reminder] [varchar](max) NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_tblReminder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ReminderDB] SET  READ_WRITE 
GO
