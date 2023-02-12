use DB
go
Create Trigger Trg_Update On person
 After Update
 As Begin
Update person Set datee = GETDATE()
Where person.personnelcode = (Select d.personnelcode from deleted d)
End
go