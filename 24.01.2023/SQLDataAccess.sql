Select c.CompanyName,e.FirstName+' '+e.LastName as 'FullName',o.OrderID,o.ShippedDate,s.CompanyName from Orders O
Join Customers C on o.CustomerID = c.CustomerID
Join Employees E on o.EmployeeID = e.EmployeeID
Join Shippers  S on o.ShipVia = s.ShipperID 


Select FirstName,LastName,BirthDate,Year(GETDATE())-Year(BirthDate) as 'Age' from Employees


Select * from Customers where CompanyName like '%Restaurant%'


select c.CategoryID,c.CategoryName,Count(c.CategoryID) as 'Product Count' from Categories C
Join Products P on c.CategoryID = p.CategoryID 
Group by c.CategoryID,c.CategoryName


Declare @categoryId int
select top 1 @categoryId=CategoryID  from Categories where CategoryName = 'Beverages'
Insert into Products (ProductName,UnitPrice,UnitsInStock,CategoryID)
Values('Kola',5.00,500,@categoryId)

