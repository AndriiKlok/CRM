--=====================================================================
if exists(select * from sys.tables where name = 'Objects')
begin
	drop table crm.Objects
end
GO

create table crm.Objects(OB_TypeId int primary key
	, OB_Name varchar(max)
	, OB_Notes varchar(max)
)
GO

--=====================================================================
if exists(select * from sys.tables where name = 'Users')
begin
	drop table crm.Users
end	
GO

create table crm.Users(USR_Id int identity(1,1)
	, USR_Type int 
	, USR_Login varchar(max)
	, USR_Mail varchar(max)
	, USR_Password varbinary(512)
	, USR_Name varchar(max)
) 
GO

--=====================================================================
if exists(select * from sys.tables where name = 'Tasks')
begin
	drop table crm.Tasks
end	
GO

create table crm.Tasks(Tsk_Id int identity(1,1)
	, Tsk_Number varchar(max) 
	, Tsk_Type int
	, Tsk_State int
	, Tsk_UsrCreate int
	, Tsk_UsrRealize int
	, Tsk_Title varchar(max)
	, Tsk_Content varchar(max)
	, Tsk_Description varchar(max)
	, Tsk_DateCreate datetime2 default getdate()
	, Tsk_DateRealize datetime2
)
GO

--=====================================================================
if exists(select * from sys.tables where name = 'Actions')
begin
	drop table crm.Actions
end	
GO

create table crm.Actions(Act_Id int identity(1,1)
	, Act_TskId int
	, Act_Type int
	, Act_State int
	, Act_UsrCreate int
	, Act_UsrRealize int
	, Act_Title varchar(max)
	, Act_Content varchar(max)
	, Act_Description varchar(max)
	, Act_DateCreate datetime2
	, Act_DateRealize datetime2
)
GO

--=====================================================================
if exists(select * from sys.tables where name = 'Sessions')
begin
	drop table crm.Sessions
end	
GO

create table crm.Sessions(SES_Id int identity(1,1)
	, SES_GUID varchar(max)
	, SES_UsrId int
	, SES_Login datetime2 default getdate()
	, SES_Logout datetime2 default dateadd(minute, 30, getdate())
)
GO

