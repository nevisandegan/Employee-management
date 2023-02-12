use DB
go
create trigger deletepersons on person
for delete 
as begin 
declare @personnelcode nvarchar(255);
declare @firstname nvarchar(255) ;
declare @lastname nvarchar(255);
declare @age int;
select @personnelcode=d.personnelcode from deleted d;
select @firstname=d.firstname from deleted d;
select @lastname=d.lastname from deleted d;
select @age=d.age from deleted d;
insert into deletetb (personnelcode,firstname,lastname,age) 
values (@personnelcode,@firstname,@lastname,@age);
end
go