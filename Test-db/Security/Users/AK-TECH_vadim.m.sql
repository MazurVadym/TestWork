IF NOT EXISTS (SELECT * FROM master.dbo.syslogins WHERE loginname = N'AK-TECH\vadim.m')
CREATE LOGIN [AK-TECH\vadim.m] FROM WINDOWS
GO
CREATE USER [AK-TECH\vadim.m] FOR LOGIN [AK-TECH\vadim.m]
GO
