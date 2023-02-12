create procedure selectperson
@personnelcode nvarchar(255)
as
select * from person where personnelcode=@personnelcode or @personnelcode is null