CREATE PROCEDURE [dbo].[Customer_insert](
@CustomerName varchar(100),
@ProductID int,
@Address varchar(500),
@CityID int,
@StateID int,
@Pincode int,
@DOB date

)

as 
begin
if not exists  (select 1 from customer where CustomerName=@CustomerName and ProductID=@ProductID and [Address]=@Address and CityID=@CityID and StateID=@StateID and Pincode=@Pincode and DOB=@DOB)
begin
insert into customer select @CustomerName,@ProductID,@Address,@CityID,@StateID,@Pincode,@DOB 

 select 'Customer succfully inserted in database'
end 

else
 select 'Data is already Present in database'
 end


