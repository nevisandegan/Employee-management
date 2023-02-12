create procedure updateperosn
@personnelcode nvarchar(255) ,
@firstname nvarchar(255) ,
@lastname nvarchar(255),
@age int 
as
update person set firstname=@firstname ,lastname=@lastname ,age =@age  where personnelcode=@personnelcode