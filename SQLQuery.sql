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

go

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

go

create proc GetAppoinmentNum 
(
@DocId int,
@date nvarchar(50)
)
as
begin
select max([ChannelNumber]) from [dbo].[Patient_Channel] where  [Doctor_ID]=@DocId and [ChannelDate]=@date
end


go

create proc makeAppoinment
(
@date date,
@time time,
@fee decimal(18,2),
@roomNum int,
@channelNum int,
@patientContcat int,
@docId int
)
as
begin
insert into [dbo].[Patient_Channel]([ChannelDate],[ChannelTime],[Fee],[RoomNumber],[ChannelNumber],[Patient_Contact],[Doctor_ID])
values (@date,@time,@fee,@roomNum,@channelNum,@patientContcat,@docId)
end

go

create proc addDrugInventry
(
@Name nvarchar(max),
@disc nvarchar(max),
@unitSellingPrice decimal(18,2),
@reorder int,
@unitBuyingPri decimal(18,2),
@drugType nvarchar(max),
@shelf nvarchar(max),
@category int,
@issued int=0,
@available int =0
)
as 
begin
insert into [dbo].[Drug_Inventory]([Name],[Description],[Unit_Selling_Price],[Reorder_Level],[Unit_Buying_Price],[Drug_Type],[Shelf],[Drug_Category_ID],[Issued_Quantity],[availableQuantity])
values(@Name,@disc,@unitSellingPrice,@reorder,@unitBuyingPri,@drugType,@shelf,@category,@issued,@available)
end


go


create proc updateDrugInventry
(
@Name nvarchar(max),
@disc nvarchar(max),
@unitSellingPrice decimal(18,2),
@reorder int,
@unitBuyingPri decimal(18,2),
@drugType nvarchar(max),
@shelf nvarchar(max),
@category int,
@DrugID int
)
as 
begin

update [dbo].[Drug_Inventory] set [Description]=@disc,[Unit_Selling_Price]=@unitSellingPrice,[Reorder_Level]=@reorder,[Unit_Buying_Price]=@unitBuyingPri,
[Drug_Type]=@drugType,[Shelf]=@shelf,[Name]=@Name where [ID]=@DrugID
end



select * from [dbo].[Patient_Channel] where [Patient_Contact]=0776005535




go
create proc cancelAppoinment
(
@id int
)
as
begin

INSERT INTO [dbo].[Patient_Channel_Cancel] ([ChannelDate],[ChannelTime],[Fee],[RoomNumber],[ChannelNumber],[Patient_ID],[Patient_Contact],[Doctor_ID])
SELECT [ChannelDate],[ChannelTime],[Fee],[RoomNumber],[ChannelNumber],[Patient_ID],[Patient_Contact],[Doctor_ID]
FROM [dbo].[Patient_Channel]
WHERE [ID]=@id;

DELETE FROM [dbo].[Patient_Channel]
WHERE [ID]=@id;

end

go

create proc addPresc1
(
@deseasetype nvarchar(max),
@description nvarchar(max),
@patientContact int,
@doctorId int,
@tracking int,
@date Datetime

)
as
begin
insert into [dbo].[Prescriptions] ([Deseas_Type],[Description],[Doctor_ID],[Patient_Contact],[TrackNo],[DateTime]) 
values(@deseasetype,@description,@doctorId,@patientContact,@tracking,@date)
end

go



create proc AddDrugToList
(
@DrugID int,
@disc nvarchar(max),
@qty int,
@track int,
@price decimal(18,2)
)
as 
begin

BEGIN TRANSACTION [Tran1]

BEGIN TRY

declare @name nvarchar(max)

select @name= [Name] from [dbo].[Drug_Inventory] where [ID]=@DrugID--getting the drugname

declare @drugQty int
declare @drugUpdatedQty int

select @drugQty=[availableQuantity] from [dbo].[Drug_Inventory]where [ID]=@DrugID--getting available qty

set @drugUpdatedQty=@drugQty-@qty
declare @issuedCurrent int
declare @issuedUpdated int

select @issuedCurrent=[Issued_Quantity]  from [dbo].[Drug_Inventory]where [ID]=@DrugID--getting current issued stock
set @issuedUpdated =@issuedCurrent+@qty

update [dbo].[Drug_Inventory] set [availableQuantity]=@drugUpdatedQty,[Issued_Quantity]=@issuedUpdated where[ID]=@DrugID --udating stock 

insert into [dbo].[Prescription_details] ([Name],[discription],[Quantity],[TrackNo],[Price]) 
values(@name,@disc,@qty,@track,@price) 

COMMIT TRANSACTION [Tran1]

END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran1]
END CATCH  

end

go
 
create proc PayForPriscription
(
@prisID int,
@track int,
@amount decimal(18,2),
@dateTime datetime,
@paymentType nvarchar(50),
@contact int
)
as
begin
insert into [dbo].[Payments] ([Prescription_ID],[TrackNo],[Amount],[dateTime],[PaymentType],[Contact]) 
values (@prisID,@track,@amount,@dateTime,@paymentType,@contact)
end





