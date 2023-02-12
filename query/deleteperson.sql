create procedure deleteperson
@personnelcode nvarchar(255)
as
delete from person where personnelcode=@personnelcode 