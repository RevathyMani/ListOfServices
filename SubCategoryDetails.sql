--Create table ServiceSubcategory (SubcategoryId int identity(1,1),SubcategoryName varchar(128),CategoryId int)
--insert into ServiceSubcategory(SubcategoryName,CategoryId) values('Residential Cleaning',1)
--insert into ServiceSubcategory(SubcategoryName,CategoryId) values('Water tank cleaning',1)
--insert into ServiceSubcategory(SubcategoryName,CategoryId) values('Sump Cleaning',1)

--insert into ServiceSubcategory(SubcategoryName,CategoryId) values('AC',2)
--insert into ServiceSubcategory(SubcategoryName,CategoryId) values('Washing Machine',2)
--insert into ServiceSubcategory(SubcategoryName,CategoryId) values('TV',2)

--insert into ServiceSubcategory(SubcategoryName,CategoryId) values('Mens',3)
--insert into ServiceSubcategory(SubcategoryName,CategoryId) values('Womens',3)
--insert into ServiceSubcategory(SubcategoryName,CategoryId) values('Kids',3)

--insert into ServiceSubcategory(SubcategoryName,CategoryId) values('House Type',4)
--insert into ServiceSubcategory(SubcategoryName,CategoryId) values('Control Type',4)

create Proc prc_GetSubcategoryDetailsbyCategory @categoryid int
as
Begin
select SubcategoryId,SubcategoryName as Subcategory from ServiceSubcategory where categoryid=@categoryid
End

