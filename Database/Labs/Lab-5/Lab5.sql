---------- Lab 5 - Part 1 ---------- 
use ITI

--Qu(1)
select count(s.St_Id)
from Student s
where s.St_Age is null

--Qu(2)
select distinct ins.Ins_Name
from Instructor ins

--Qu(3)
select s.St_Id, isnull(s.St_Fname, ' ') + ' ' + isnull(s.St_Lname, ' ') as StudentFullName, isnull(d.Dept_Name, ' ')
from Student s, Department d
where s.Dept_Id = d.Dept_Id

--Qu(4)
select ins.Ins_Name, d.Dept_Name
from Instructor ins left join Department d
on ins.Dept_Id = d.Dept_Id

--QU(5)
select concat_ws(' ', s.St_Fname, s.St_Lname) as FullName, c.Crs_Name
from Student s, Stud_Course sc, Course c
where s.St_Id = sc.St_Id and c.Crs_Id = sc.Crs_Id and sc.Grade is not null


--QU(6)
select count(c.Crs_Id)
from Course c, Topic t
where c.Top_Id = t.Top_Id
group by t.Top_Id

--Qu(7)
select max(Salary), min(Salary)
from Instructor

--Qu(8)
select *
from Instructor
where Salary < (select avg(salary) from Instructor)

--Qu(9)
select top(1)d.Dept_Name
from Instructor ins inner join Department d
on ins.Dept_Id = d.Dept_Id
order by ins.Salary


--Qu(10)
select top(2) ins.Salary
from Instructor ins
order by ins .Salary desc

--Qu(11)
select coalesce(convert(varchar(50),salary), 'Bouns')
from Instructor

--Qu(12)
select avg(salary) from Instructor

--Qu(13)
select s.St_Fname, su.*
from Student s, Student su
where s.St_super = su.St_Id

--Qu(14)
select *
from (select *, ROW_NUMBER() over (partition by Dept_Id order by salary desc) as RN
		from Instructor) as newTable
where RN <= 2

--Qu(15) Updated
select *
from (SELECT *, ROW_NUMBER() OVER (PARTITION BY Dept_Id ORDER BY NEWID()) AS RN
		FROM Student) as newTable
where RN = 1

---------- Lab 5 - Part 2 ---------- 

use AdventureWorks2012

--Qu(1)
select SalesOrderID, ShipDate
from Sales.SalesOrderHeader
where OrderDate between '7/28/2002' and '7/29/2014'

--Qu(2)
select ProductID, Name
from Production.product
where StandardCost < 110

--Qu(3)
select ProductID, Name
from Production.product
where Weight is null

--Qu(4)
select *
from Production.product
where Color in ('Silver','Black', 'Red')

--Qu(5)
select *
from Production.product
where Name like 'B%'

--Qu(6)
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

select *
from Production.ProductDescription
where Description like '%[_]%'

--Qu(7)
select OrderDate, sum(TotalDue) as SumOfTotalDue 
from Sales.SalesOrderHeader
where OrderDate between '7/1/2001' and '7/31/2014'
group by OrderDate

--Qu(8)
select distinct HireDate
from [HumanResources].[Employee]

--Qu(9)
select avg(distinct ListPrice)
from Production.product

--Qu(10)
select CONCAT_ws(' ','The',Name,'is only!',ListPrice)
from Production.product
where ListPrice between 100 and 120
order by ListPrice

--Qu(11)
--(a)
select rowguid ,Name, SalesPersonID, Demographics
into store_Archive
from Sales.Store

--(b) Updated
--Try the previous query but without transferring the data? 
select rowguid ,Name, SalesPersonID, Demographics
into store_Archivee
from Sales.Store
where 1 =10

--Qu(12)
select convert(varchar,GETDATE())
union all
select FORMAT(getDate(), 'dd/mm/yyyy - hh:mm')
union all
select convert(varchar,GETDATE(),100) --u have hundereds of code that refer to different styles
