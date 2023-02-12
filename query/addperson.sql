create procedure addperosn
@personnelcode nvarchar(255) ,
@firstname nvarchar(255) ,
@lastname nvarchar(255),
@age int 
as
insert into person (personnelcode,firstname,lastname,age) values (@personnelcode,@firstname,@lastname,@age)