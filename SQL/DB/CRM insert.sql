use CRM_DB;
GO

--=====================================================================
insert into CRM.Objects (OB_TypeId, OB_Name, OB_Notes) values (100, 'user', 'admin');
insert into CRM.Objects (OB_TypeId, OB_Name, OB_Notes) values (101, 'user', 'worker');
insert into CRM.Objects (OB_TypeId, OB_Name, OB_Notes) values (102, 'user', 'client');

insert into CRM.Objects (OB_TypeId, OB_Name, OB_Notes) values (200, 'task', 'task');
insert into CRM.Objects (OB_TypeId, OB_Name, OB_Notes) values (201, 'task', 'action');

insert into CRM.Objects (OB_TypeId, OB_Name, OB_Notes) values (300, 'state', 'new');
insert into CRM.Objects (OB_TypeId, OB_Name, OB_Notes) values (301, 'state', 'in realization');
insert into CRM.Objects (OB_TypeId, OB_Name, OB_Notes) values (302, 'state', 'realized');

insert into CRM.Objects (OB_TypeId, OB_Name, OB_Notes) values (400, 'rule', 'Bid');
insert into CRM.Objects (OB_TypeId, OB_Name, OB_Notes) values (401, 'rule', 'Tasks');
insert into CRM.Objects (OB_TypeId, OB_Name, OB_Notes) values (402, 'rule', 'Users');


--=====================================================================

insert into CRM.Users (USR_Type, USR_Login, USR_Mail, USR_Password, USR_Name) VALUES (100, 'admin', '', (select PWDENCRYPT('P@ssw0rd!')), 'administrator')
insert into CRM.Users (USR_Type, USR_Login, USR_Mail, USR_Password, USR_Name) VALUES (101, 'worker', '', (select PWDENCRYPT('work1')), 'worker 1')
insert into CRM.Users (USR_Type, USR_Login, USR_Mail, USR_Password, USR_Name) VALUES (102, 'client', '', (select PWDENCRYPT('client1')), 'client 1')











