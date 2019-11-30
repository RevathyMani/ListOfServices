Create table ServiceCategory(Id int identity(1,1),ServiceName varchar(128))
Insert into ServiceCategory(Servicename) values ('Cleaning')
Insert into ServiceCategory(Servicename) values ('Repairs')
Insert into ServiceCategory(Servicename) values ('Salon')
Insert into ServiceCategory(Servicename) values ('Pest Control')

Create proc PrcGetServiceCategoryDetails
as
Begin
select Id as CategoryId,ServiceName Category from serviceCategory
End
