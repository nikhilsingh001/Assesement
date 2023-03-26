CREATE PROCEDURE [dbo].[customer_report]
	@param1 int = 0,
	@param2 int
AS
	begin
select c.CustomerName,p.Product_Name,Address,ct.CITY_Name,s.State_Name,c.Pincode,c.DOB from customer c inner join Product p on c.ProductID=p.ProductID
inner join City ct on c.CityID=ct.CityID
inner join [State] s on c.StateID=s.StateID

end


