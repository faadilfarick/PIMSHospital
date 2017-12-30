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
@issued int=0
)
as 
begin
insert into [dbo].[Drug_Inventory]([Name],[Description],[Unit_Selling_Price],[Reorder_Level],[Unit_Buying_Price],[Drug_Type],[Shelf],[Drug_Category_ID],[Issued_Quantity])
values(@Name,@disc,@unitSellingPrice,@reorder,@unitBuyingPri,@drugType,@shelf,@category,@issued)
end




