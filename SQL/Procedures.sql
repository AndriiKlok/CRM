--=======================================================================================
if exists(select 1 from sys.procedures where name = 'AddError')
begin
	drop procedure WEB.AddError;
end
GO

create procedure WEB.AddError
	@class varchar(max)
	, @method varchar(max)
	, @notes varchar(max)
as
begin
	insert into WEB.Errors(ERR_Class, ERR_Method, ERR_Notes)
	VALUES(@class, @method, @notes)
end
GO

--=======================================================================================
if exists(select 1 from sys.procedures where name = 'LoginUser')
begin
	drop procedure WEB.LoginUser;
end
GO

create procedure WEB.LoginUser
	@Login varchar(max)
	, @Password varchar(max)
	, @GUID varchar(max)
as
begin
	if exists(select 1 from crm.Users where USR_Login = @Login and PWDCOMPARE(@Password, USR_Password) = 1)
	begin
		insert into crm.Sessions(SES_GUID, SES_UsrId)
		select @GUID, USR_Id from crm.Users where USR_Login = @Login and PWDCOMPARE(@Password, USR_Password) = 1
	end

	select USR_Id
		, USR_Type
		, USR_Login
		, USR_Mail
		, USR_Name
	from crm.Users
	where USR_Login = @Login
		and PWDCOMPARE(@Password, USR_Password) = 1
end
GO

--=======================================================================================
if exists(select 1 from sys.procedures where name = 'LoginedUser')
begin
	drop procedure WEB.LoginedUser;
end
GO

create procedure WEB.LoginedUser
	@GUID varchar(max)
as
begin

	if exists(select 1 from crm.Sessions where SES_GUID = @GUID and getdate() between SES_Login and SES_Logout)
	begin
		update crm.Sessions
		set SES_Logout = dateadd(minute, 30, getdate())
		where SES_GUID = @GUID
	end

	select USR_Id
		, USR_Type
		, USR_Login
		, USR_Mail
		, USR_Name
	from crm.Sessions
	inner join crm.Users
		on USR_Id = SES_UsrId
	where SES_GUID = @GUID
		and getdate() between SES_Login and SES_Logout;
end
GO

--=======================================================================================
if exists(select 1 from sys.procedures where name = 'LogoutUser')
begin
	drop procedure WEB.LogoutUser;
end
GO

create procedure WEB.LogoutUser
	@GUID varchar(max)
as
begin
	update crm.Sessions
	set SES_Logout = getdate()
	where SES_GUID = @GUID
end
GO

--=======================================================================================
if exists(select 1 from sys.procedures where name = 'AddTask')
begin
	drop procedure WEB.AddTask;
end
GO

create procedure WEB.AddTask
	@GUID varchar(max)
	, @UsrRealize int = null
	, @Title varchar(max) = null
	, @Content varchar(max) = null
	, @Description varchar(max) = null
as
begin
	insert into crm.Tasks(Tsk_Number, Tsk_Type, Tsk_State, Tsk_UsrCreate, Tsk_UsrRealize, Tsk_Title, Tsk_Content, Tsk_Description)
	select (select 'TSK-' + convert(varchar(max), (isnull((select count(1) from crm.Tasks where year(Tsk_DateCreate) = year(getdate()) and month(Tsk_DateCreate) = month(getdate())),0) + 1)) + '/' + format(getdate(),'yyyy/MM'))
		, (select top 1 OB_TypeId from crm.Objects where OB_Name = 'task' and OB_Notes = 'task')
		, (select top 1 OB_TypeId from crm.Objects where OB_Name = 'state' and OB_Notes = 'new')
		, SES_UsrId
		, @UsrRealize
		, @Title
		, @Content
		, @Description
	from crm.Sessions
	where SES_GUID = @GUID

	declare @TskId int = (select SCOPE_IDENTITY());

	select Tsk_Id
		, Tsk_Number
	from crm.Tasks
	where Tsk_Id = @TskId
end
go

--=======================================================================================
if exists(select 1 from sys.procedures where name = 'ClientTasksList')
begin
	drop procedure WEB.ClientTasksList;
end
GO

create procedure WEB.ClientTasksList
	@GUID varchar(max)
as
begin
	
	declare @UsrId int = (select top 1 SES_UsrId from crm.Sessions where SES_Guid = @GUID);

	select Tsk_Id
		, Tsk_Number
		, Tsk_Type
		, sType.OB_Notes as Tsk_SType
		, Tsk_State
		, sState.OB_Notes as Tsk_SState
		, Tsk_UsrCreate
		, ucreate.USR_Name as usrCreateName
		, isnull(Tsk_UsrRealize,0) as Tsk_UsrRealize
		, usrealize.USR_Name as usrRealizeName
		, Tsk_Title
		, Tsk_Content
		, Tsk_Description
		, Tsk_DateCreate
		, Tsk_DateRealize
	from crm.Tasks
	inner join crm.objects sType
		on sType.OB_TypeId = Tsk_Type
	inner join crm.objects sState
		on sState.OB_TypeId = Tsk_State
	inner join crm.Users ucreate
		on ucreate.USR_Id = Tsk_UsrCreate
	left join crm.Users usrealize
		on usrealize.USR_Id = Tsk_UsrRealize
	where Tsk_UsrCreate = @UsrId
end
GO