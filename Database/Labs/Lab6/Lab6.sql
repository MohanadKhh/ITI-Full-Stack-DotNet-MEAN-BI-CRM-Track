use SD

--Qu(1)
--Create Departement table
create table Departement
(DeptNo varchar(10) primary key,
DeptName varchar(20) not null,
Location varchar(20)
)

--insert Departement data
insert into Departement
values('d1','Research','NY'),
('d2','Accounting','DS'),
('d3','Markiting','KW')

--create type loc with rule and default value
create type loc from nchar(2)
go

create rule r1 as @x in ('NY','DS','KW')
go
sp_bindrule r1, loc
go

create default df1 as 'NY'
go
sp_bindefault df1, loc

--update data type of location column
alter table Departement
alter Column Location loc


--Create Empolyee table
create table Empolyee
(EmpNo int primary key,
EmpFname varchar(20) not null,
EmpLname varchar(20) not null ,
DeptNo varchar(10) foreign key references Departement(DeptNo),
salary float unique
)


--insert Empolyee data
bulk insert Empolyee
from 'D:\Mohanad.Khh\ITI\Database\Labs\Lab6\Empolyee_Data.txt'
WITH (
    FIELDTERMINATOR = '	',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
)

--RULE ON SALARY
go
create rule r2 as @x < 6000
go
sp_bindrule r2, 'HR.Empolyee.salary'
go


--insert projects data
bulk insert [dbo].[Project]
from 'D:\Mohanad.Khh\ITI\Database\Labs\Lab6\project_Data.txt'
WITH (
    FIELDTERMINATOR = '	',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
)

--insert work_on data
bulk insert [dbo].[Works_on]
from 'D:\Mohanad.Khh\ITI\Database\Labs\Lab6\work_on_Data.txt'
WITH (
    FIELDTERMINATOR = '	',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
)


-------------Testing-------------
--Qu(1)
insert into [dbo].[Works_on]
values (11111,'p1', 'Engenieer',GETDATE())

--Qu(2)
update Works_on
set EmpNo = 11111
where EmpNo = 10102

--Qu(3)
update Empolyee
set EmpNo = 22222
where EmpNo = 10102

--Qu(4)
delete from Empolyee
where EmpNo = 10102

-------------Modification-------------
--Qu(1)
alter table Empolyee 
alter column TelephoneNumber int

--Qu(2)
alter table Empolyee 
drop column TelephoneNumber



-------------------------------------------------------
--Qu(2)
--(a)
go
create schema company
go
alter schema company transfer Departement

--(b)
go
create schema HR
go
alter schema HR transfer Empolyee

--Qu(3) Not Sure
SELECT CONSTRAINT_NAME, CONSTRAINT_TYPE, TABLE_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME = 'Empolyee';

--Qu(4)
create synonym Emp
for HR.Empolyee

Select * from Empolyee
Select * from [HR].Empolyee
Select * from Emp
Select * from [HR].Emp

--Qu(5)
create synonym proj
for company.project

update proj
set Budget *= 1.1
from proj p, emp e, Works_on w
where p.ProjectNo = w.ProjectNo and e.EmpNo = w.EmpNo
and w.EmpNo = 10102 and w.Job = 'Manager'

--Qu(6)
create synonym dept
for company.Departement

update dept
set DeptName = 'sales'
from Emp e, dept d
where e.DeptNo = d.DeptNo and e.EmpFname = 'James'

--Qu(7)
update Works_on
set Enter_Date = '12/12/2007'
from Works_on w, dept d, Emp e, proj p
where w.EmpNo = e.EmpNo and p.ProjectNo = w.ProjectNo
and e.DeptNo = d.DeptNo and d.DeptName = 'sales'
and p.ProjectNo = 'p1'

--Qu(8)
delete from Works_on
where EmpNo in (select e.EmpNo
                from Emp e, dept d
                where e.DeptNo = d.DeptNo
                and d.Location = 'KW')

--Qu(9)
--done
