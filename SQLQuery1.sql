
//Adding Prescriptions
create proc addPresc
(
@deseasetype nvarchar(max),
@description nvarchar(max),
@patient int,
@doctor int,
@prescdesc int

)
as
begin
insert into [dbo].[Prescriptions]([Deseas_Type],[Description],[Patient_ID],[Doctor_ID],[Prescription_Details_ID]) 
values (@deseasetype,@description,@patient,@doctor,@prescdesc)
end

go


prediction report

sales stock

user creation(name email etc, dropdown roles)