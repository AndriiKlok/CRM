create database CRM_DB;
go
use CRM_DB;
GO

--=====================================================================
if exists(select * from sys.schemas where name = 'WEB')
begin
	drop schema WEB;
end
GO

create schema WEB;
GO

--=====================================================================
if exists(select * from sys.schemas where name = 'ERP')
begin
	drop schema CRM;
end
GO

create schema CRM;
GO

--=====================================================================