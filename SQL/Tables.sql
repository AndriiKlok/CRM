--=====================================================================
if exists(select * from sys.tables where name = 'Users')
begin
	drop table WEB.Errors
end	
GO

create table WEB.Errors(Err_Id int identity(1,1)
	, Err_Class varchar(max)
	, Err_Method varchar(max)
	, Err_Notes varchar(max)
)
GO