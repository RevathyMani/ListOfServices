--Create table ServiceTimings(ServiceTimingId int identity(1,1),SubcategoryId int,Timings varchar(128))
--insert into ServiceTimings(Timings,SubcategoryId) values ('9 AM to 6 PM',1)
--insert into ServiceTimings(Timings,SubcategoryId) values ('9 AM to 6 PM',2)
--insert into ServiceTimings(Timings,SubcategoryId) values ('9 AM to 6 PM',3)

--insert into ServiceTimings(Timings,SubcategoryId) values ('9 AM to 6 PM',4)
--insert into ServiceTimings(Timings,SubcategoryId) values ('9 AM to 6 PM',5)
--insert into ServiceTimings(Timings,SubcategoryId) values ('9 AM to 6 PM',6)

--insert into ServiceTimings(Timings,SubcategoryId) values ('8 AM to 8 PM',7)
--insert into ServiceTimings(Timings,SubcategoryId) values ('8 AM to 8 PM',8)
--insert into ServiceTimings(Timings,SubcategoryId) values ('8 AM to 8 PM',9)

--insert into ServiceTimings(Timings,SubcategoryId) values ('10 AM to 5 PM',10)
--insert into ServiceTimings(Timings,SubcategoryId) values ('10 AM to 5 PM',11)

Create proc prc_GetServiceTimingBySubcategory @subcategoryId int
as
Begin
select Timings from ServiceTimings where subcategoryid=@subcategoryId
End