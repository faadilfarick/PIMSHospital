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


create proc GetAppoinmentNum 
(
@DocId int,
@date nvarchar(50)
)
as
begin
select max([ChannelNumber]) from [dbo].[Patient_Channel] where  [Doctor_ID]=@DocId and [ChannelDate]=@date
end




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



