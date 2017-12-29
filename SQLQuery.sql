create proc addDoc
(
@DocName nvarchar(max),
@quli nvarchar(max),
@contcat int,
@fee decimal(18,2),
@speclize int

)
as
begin
insert into [dbo].[Doctors]([Name],[Qualification],[Fee],[Contact],[Specilization_ID]) values (@DocName,@quli,@fee,@contcat,@speclize)
end


create proc updateDoc
(
@id int,
@DocName nvarchar(max),
@quli nvarchar(max),
@contcat int,
@fee decimal(18,2),
@speclize int

)
as 
begin
update [dbo].[Doctors] set [Name]=@DocName,[Qualification]=@quli,[Fee]=@fee,[Contact]=@contcat,[Specilization_ID]=@speclize where [ID]=@id
end