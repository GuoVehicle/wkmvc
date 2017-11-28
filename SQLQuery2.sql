USE [wkmvc_db]
GO
/****** Object:  Table [dbo].[SYS_USER]    Script Date: 2016/5/9 15:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_USER](
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [NAME] [nvarchar](50) NULL,
    [ACCOUNT] [nvarchar](20) NULL,
    [PASSWORD] [nvarchar](1000) NULL,
    [ISCANLOGIN] [int] NULL,
    [SHOWORDER1] [int] NULL,
    [SHOWORDER2] [int] NULL,
    [PINYIN1] [nvarchar](50) NULL,
    [PINYIN2] [nvarchar](50) NULL,
    [FACE_IMG] [nvarchar](200) NULL,
    [LEVELS] [nvarchar](36) NULL,
    [DPTID] [nvarchar](36) NULL,
    [CREATEPER] [nvarchar](36) NULL,
    [CREATEDATE] [datetime] NULL,
    [UPDATEUSER] [nvarchar](36) NULL,
    [UPDATEDATE] [datetime] NULL,
    [LastLoginIP] [nvarchar](50) NULL,
 CONSTRAINT [PK_SYS_USER] PRIMARY KEY CLUSTERED 
(
    [ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʵ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û��ʺ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ACCOUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'PASSWORD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�������0��1�ǣ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'ISCANLOGIN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����ڵ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'SHOWORDER1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��˾�ڵ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'SHOWORDER2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ȫƴ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'PINYIN1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������ַ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'PINYIN2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�ͷ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'FACE_IMG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���𣨶Խ�SYS_CODE��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'LEVELS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ID���û����ڵĲ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'DPTID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'CREATEPER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'CREATEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޸���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'UPDATEUSER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�޸�ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'UPDATEDATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���һ�ε�¼IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_USER', @level2type=N'COLUMN',@level2name=N'LastLoginIP'
GO