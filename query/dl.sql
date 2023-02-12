create procedure selectdeletetb
@personnelcode nvarchar(255)
as
select * from deletetb where personnelcode=@personnelcode or @personnelcode is null