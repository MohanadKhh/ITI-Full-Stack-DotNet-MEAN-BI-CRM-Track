--Question(1):
use Company

declare c1 cursor
for select salary from empolyee
for update
declare @sal int
open c1
fetch c1 into @sal
while @@FETCH_STATUS = 0
	begin 
		if(@sal >= 3000)
		begin
			update empolyee
			set Salary+=Salary*0.2
			where current of c1
		end
		else if(@sal < 3000)
		begin
			update empolyee
			set Salary+=Salary*0.1
			where current of c1
		end
		fetch c1 into @sal
	end
close c1
deallocate c1


--Question(2):
use ITI

declare c1 cursor
for select d.Dept_Name, ins.Ins_Name
	from Department as d, Instructor as ins
	where d.Dept_Manager = Ins_Id
for read only
declare @DeptName nvarchar(50), @InstName nvarchar(50)
open c1
fetch c1 into @DeptName, @InstName
while @@FETCH_STATUS = 0
	begin
		select @DeptName as Department_Name , @InstName as Instructor_Name
		fetch c1 into @DeptName, @InstName 
	end
close c1
deallocate c1


--Question(3):
declare c1 cursor
for select St_Fname
	from Student
	where St_Fname is not Null
for read only
declare @StFName nvarchar(50), @allStNames nvarchar(max) = ''
open c1
fetch c1 into @StFName

if @@FETCH_STATUS = 0
	set @allStNames = @StFName

while @@FETCH_STATUS = 0
	begin
		set @allStNames = CONCAT(@allStNames , ', ' , @StFName)
		fetch c1 into @StFName
	end
select @allStNames
close c1
deallocate c1


--Question(4):
backup database SD
to disk='d:\iti_full.bak'

backup database SD
to disk='d:\iti_differential.bak'
with differential


--Question(5):
use SD

create sequence seq
	start with 1
	increment BY 1
	minvalue 1
	maxvalue 10

insert INTO HR.Empolyee(EmpNo,EmpFname,EmpLname)
values(next value for seq, 'Mohanad','Khaled')

select next value for seq


--Question(6):
use ITI

select *
from student


--Question(7):
--Qu(1)
create proc get_Mon @date date, @MonthName varchar(20) output
as
	set @MonthName = format(@date,'MMMM')

declare @month varchar(20)
exec get_Mon '2006/12/31', @month output
select @month


--Question(7):
--Qu(2)
create proc betweenValues @first int, @second int
as
	declare @i int
	declare @t table (num int)
	set @i = @first + 1
	while @i < @second
		begin
			insert into @t
			select @i
			set @i = @i + 1
		end
	select * from @t

betweenValues 1,15


--Question(7):
--Qu(3)
create proc proc_st_dept @stud_No int
as
	select s.St_Fname+SPACE(1)+s.St_Lname as FullName, d.Dept_Name
	from Student s, Department d
	where s.St_Id = @stud_No
	and s.Dept_Id = d.Dept_Id

proc_st_dept 1


--Question(7):
--Qu(4)
create proc proc_NameExist @stud_No int, @result varchar(50) output
as
	declare @fName varchar(20)
	declare @lName varchar(20)
	select @fName = St_Fname, @lName = St_Lname
	from Student
	where St_Id = @stud_No
	if @fName is null and @lName is null
		set @result = 'First name & last name are null'
	else if @fName is null and @lName is not null
		set @result = 'first name is null'
	else if @fName is not null and @lName is null
		set @result = 'last name is null'
	else if @fName is not null and @lName is not null
		set @result = 'First name & last name are not null'

declare @res varchar(50)
exec proc_NameExist 2, @res output
select @res


--Question(7):
--Qu(5)
create proc proc_Dept_MGR @MGR_Id int
as
	select d.Dept_Name, i.Ins_Name, d.Manager_hiredate
	from Instructor i, Department d
	where d.Dept_Manager = @MGR_Id and d.Dept_Manager = i.Ins_Id

proc_Dept_MGR 5


--Question(7):
--Qu(6)
alter proc proc_get_stuName @str varchar(20)
as
	declare @t table(st_name varchar (50))
	if @str = 'first name'
		begin
			insert into @t
			select isNull(St_Fname, ' ') from Student
		end

	else if @str = 'last name' 
		begin
			insert into @t
			select isNull(St_Lname, ' ') from Student
		end

	else if @str = 'full name'
		begin
			insert into @t
			select isNull(St_Fname, '') + space(1) + isNull(St_Lname, '') as FullName
			from Student
		end

	select * from @t

proc_get_stuName 'full name'


--Question(8):
create database snapAdventureWorks
on
(
 name='AdventureWorks2012_Data',  --mdf file name
 filename='d:\snap1.ss'
)
as snapshot of AdventureWorks2012

use AdventureWorks2012
select * from [HumanResources].[Employee]

use snapAdventureWorks
select * from [HumanResources].[Employee]

