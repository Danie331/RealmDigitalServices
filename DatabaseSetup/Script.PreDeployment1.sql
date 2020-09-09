/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


create database Assessment
go

use Assessment
go

create table dbo.Employee
(
	Id int primary key identity(1,1),
	EmployeeId int not null,
	EmailAddress varchar(255) not null,
	BirthdayWishSentDate datetime null
)
go