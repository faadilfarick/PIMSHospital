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

CREATE proc [dbo].[cancelAppoinment]
(
@id int
)
as
begin

BEGIN TRANSACTION [Tran1]

BEGIN TRY

INSERT INTO [dbo].[Patient_Channel_Cancel] ([ID],[ChannelDate],[ChannelTime],[Fee],[RoomNumber],[ChannelNumber],[Patient_ID],[Patient_Contact],[Doctor_ID])
SELECT [ID],[ChannelDate],[ChannelTime],[Fee],[RoomNumber],[ChannelNumber],[Patient_ID],[Patient_Contact],[Doctor_ID]
FROM [dbo].[Patient_Channel]
WHERE [ID]=@id;

DELETE FROM [dbo].[Patient_Channel]
WHERE [ID]=@id;


COMMIT TRANSACTION [Tran1]

END TRY
BEGIN CATCH
 SELECT   
        ERROR_NUMBER() AS ErrorNumber  
       ,ERROR_MESSAGE() AS ErrorMessage; 

  ROLLBACK TRANSACTION [Tran1]
END CATCH  
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

go

create proc GetSalesReportDay
(
@date date
)
as
begin

SELECT        Prescription_details.ID, Prescription_details.Name,Prescription_details.TrackNo, Prescription_details.Quantity, Prescription_details.Price
FROM            Prescription_details INNER JOIN
                         Prescriptions ON Prescription_details.TrackNo = Prescriptions.TrackNo where Prescriptions.DateTime=@date

end

go

create proc GetSumSalesReportDay
(
@date date
)
as
begin

SELECT        sum( Prescription_details.Price)
FROM            Prescription_details INNER JOIN
                         Prescriptions ON Prescription_details.TrackNo = Prescriptions.TrackNo where Prescriptions.DateTime=@date

end


go

create proc PurchaseDrugInventry
(
@drugId int,
@date date,
@qty int,
@suppId int
)
as
begin

BEGIN TRANSACTION [Tran1]

BEGIN TRY

declare @AvQty int

select @AvQty=[availableQuantity] from [dbo].[Drug_Inventory] where [ID]=@drugId

declare @newQty int

set @newQty=@AvQty+@qty

update [dbo].[Drug_Inventory] set [availableQuantity]=@newQty where [ID]=@drugId

insert into [dbo].[Drug_Purchase] ([Drug_Inventry_ID],[Date],[Quantity],[Drug_Supplier_ID]) 
values (@drugId,@date,@qty,@suppId)

COMMIT TRANSACTION [Tran1]

END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran1]
END CATCH  

end



go

create proc GetPurchaseReportDay
(
@date date
)
as
begin

SELECT        Drug_Purchase.ID, Drug_Inventory.Name, Drug_Purchase.Quantity, Drug_Supplier.Name AS Expr1
FROM            Drug_Inventory INNER JOIN
                         Drug_Purchase ON Drug_Inventory.ID = Drug_Purchase.Drug_Inventry_ID INNER JOIN
                         Drug_Supplier ON Drug_Purchase.Drug_Supplier_ID = Drug_Supplier.ID where  Drug_Purchase.Date=@date
end


go



create proc GetSalesReportDayChart
(
@date date,
@date2 date
)
as
begin

SELECT         Prescriptions.DateTime as date,sum(Prescription_details.Price) as total
FROM            Prescription_details INNER JOIN
                         Prescriptions ON Prescription_details.TrackNo = Prescriptions.TrackNo where Prescriptions.DateTime between @date and @date2
						 group by  Prescriptions.DateTime

end


GetSalesReportDayChart '2017-01-01','2018-01-03'

GetPurchaseReportChart '12/31/2017','1/3/2018'

go

create proc GetPurchaseReportChart
(
@date date,
@date2 date
)
as
begin

SELECT         Drug_Purchase.Date,SUM( Drug_Purchase.Quantity) AS QTY,Drug_Inventory.Name AS Expr1
FROM            Drug_Inventory INNER JOIN
                         Drug_Purchase ON Drug_Inventory.ID = Drug_Purchase.Drug_Inventry_ID INNER JOIN
                         Drug_Supplier ON Drug_Purchase.Drug_Supplier_ID = Drug_Supplier.ID where  Drug_Purchase.Date between @date and @date2
						 GROUP BY Drug_Purchase.Date,Drug_Inventory.Name ORDER BY Drug_Purchase.Date
end



go
--monthly sales

create proc monthlySales

as
begin
SELECT        Year(Prescriptions.DateTime)as SalesYear, MONTH(Prescriptions.DateTime) as SalesMonth,sum(Prescription_details.Price) as total
FROM            Prescription_details INNER JOIN
                         Prescriptions ON Prescription_details.TrackNo = Prescriptions.TrackNo 
						 GROUP BY YEAR(Prescriptions.DateTime), MONTH(Prescriptions.DateTime)
						 ORDER BY YEAR(Prescriptions.DateTime), MONTH(Prescriptions.DateTime)
end



select * from [dbo].[Patient_Channel]
select * from [dbo].[Patient_Channel_Cancel]

go

create proc appoinmentCountMonth
as
begin

select year([dbo].[Patient_Channel].[ChannelDate]) as Years,month([dbo].[Patient_Channel].[ChannelDate]) as Months,count([dbo].[Patient_Channel].ID) as appoinmentCount from 
[dbo].[Patient_Channel]
GROUP BY YEAR([dbo].[Patient_Channel].[ChannelDate]), MONTH([dbo].[Patient_Channel].[ChannelDate])
						 ORDER BY YEAR([dbo].[Patient_Channel].[ChannelDate]), MONTH([dbo].[Patient_Channel].[ChannelDate])

end

go

create proc appoinmentCancelCountMonth
as
begin

select year([dbo].[Patient_Channel_Cancel].[ChannelDate]) as Years,month([dbo].[Patient_Channel_Cancel].[ChannelDate]) as Months,count([dbo].[Patient_Channel_Cancel].ID) as appoinmentCancelCount from 
[dbo].[Patient_Channel_Cancel]
GROUP BY YEAR([dbo].[Patient_Channel_Cancel].[ChannelDate]), MONTH([dbo].[Patient_Channel_Cancel].[ChannelDate])
						 ORDER BY YEAR([dbo].[Patient_Channel_Cancel].[ChannelDate]), MONTH([dbo].[Patient_Channel_Cancel].[ChannelDate])

end

go

create proc DrugqtyPurchasedForTheMonth 
(
@DID int
)
as
begin

select year(Drug_Purchase.Date) as Years,month(Drug_Purchase.Date) as Months,Drug_Inventory.Name, Drug_Category.Name AS Cat, sum( Drug_Purchase.Quantity)as Qty
FROM            Drug_Category INNER JOIN
                         Drug_Inventory ON Drug_Category.ID = Drug_Inventory.Drug_Category_ID INNER JOIN
                         Drug_Purchase ON Drug_Inventory.ID = Drug_Purchase.Drug_Inventry_ID where Drug_Inventory.ID=@DID
GROUP BY YEAR(Drug_Purchase.Date), MONTH(Drug_Purchase.Date),Drug_Category.Name,Drug_Inventory.Name
						 ORDER BY YEAR(Drug_Purchase.Date), MONTH(Drug_Purchase.Date) 

end

go

create proc DrugqtyPurchasedForTheMonthAll

as
begin

select year(Drug_Purchase.Date) as Years,month(Drug_Purchase.Date) as Months,Drug_Inventory.Name, Drug_Category.Name AS Cat, sum( Drug_Purchase.Quantity)as Qty
FROM            Drug_Category INNER JOIN
                         Drug_Inventory ON Drug_Category.ID = Drug_Inventory.Drug_Category_ID INNER JOIN
                         Drug_Purchase ON Drug_Inventory.ID = Drug_Purchase.Drug_Inventry_ID 
GROUP BY YEAR(Drug_Purchase.Date), MONTH(Drug_Purchase.Date),Drug_Category.Name,Drug_Inventory.Name
						 ORDER BY YEAR(Drug_Purchase.Date), MONTH(Drug_Purchase.Date) 

end