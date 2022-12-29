use Northwind
Select FirstName,LastName from Employees

1-
Select FirstName,LastName from Employees where FirstName  Like '%a_e%'
2-
Select FirstName,LastName from Employees where FirstName  Like '%a__e%'
3-
Select FirstName,LastName from Employees where  Left(FirstName,1) != 'M'
4-
Select FirstName,LastName from Employees where  Right(FirstName,1) != 'N'
5-
Select FirstName,LastName from Employees where  FirstName NOT LIKE  '[A-I]%' 
6-
Select FirstName,LastName from Employees where  FirstName Not LIKE  '%A%A%' Or FirstName Not LIKE  '%T%T%'
7-
Select FirstName,LastName from Employees where
FirstName LIKE  'LA%' Or FirstName LIKE  'LN%' Or FirstName LIKE  'AA%' Or FirstName LIKE  'AN%'
8-
Select FirstName,LastName from Employees where FirstName  Like '%\_%' ESCAPE '\'
