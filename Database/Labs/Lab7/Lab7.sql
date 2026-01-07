Use ITI


--Qu(1)
create function get_Month(@date date)
returns varchar(20)
	begin
		declare @MonthName varchar(20)
		set @MonthName = format(@date,'MMMM')
		return @MonthName
	end

select dbo.get_Month('5/10/2003')



--Qu(2)
create function betweenValues(@first int, @second int)
returns @t table (num int)
as
	begin
		declare @i int
		set @i = @first + 1
		while @i < @second
			begin
				insert into @t
				select @i
				set @i = @i + 1
			end
		return
	end

select *
from dbo.betweenValues(10,15)



--Qu(3)
create function st_dept(@stud_No int)
returns table
as
	return
		(
			select s.St_Fname+SPACE(1)+s.St_Lname as FullName, d.Dept_Name
			from Student s, Department d
			where s.St_Id = @stud_No
			and s.Dept_Id = d.Dept_Id
		)

select *
from dbo.st_dept(5)



--Qu(4)
create function NameExist(@stud_No int)
returns varchar(50)
	begin
		declare @fName varchar(20)
		declare @lName varchar(20)
		select @fName = St_Fname, @lName = St_Lname
		from Student
		where St_Id = @stud_No
		return case
			when @fName is null and @lName is null then 'First name & last name are null'
			when @fName is null and @lName is not null then 'first name is null'
			when @fName is not null and @lName is null then 'last name is null'
			when @fName is not null and @lName is not null then 'First name & last name are not null'
		end
	end

select dbo.nameExist(5)



--Qu(5)
create function Dept_MGR(@MGR_Id int)
returns table
as
	return
	(
		select d.Dept_Name, i.Ins_Name, d.Manager_hiredate
		from Instructor i, Department d
		where d.Dept_Manager = @MGR_Id and d.Dept_Manager = i.Ins_Id
	)

select *
from dbo.Dept_MGR(5)



--Qu(6)
create function get_stuName(@str varchar(20))
returns @t table(st_name varchar (50))
as
	begin
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
				select isNull(St_Lname, '') + space(1) + isNull(St_Lname, '') as FullName
				from Student
			end
		return
	end

select *
from dbo.get_stuName('full name')



--Qu(7)
select St_Id, SUBSTRING(St_Fname,1,LEN(St_Fname) - 1 )
from Student



--Qu(8)
update Stud_Course
set Grade = NULL
where St_Id in (select s.St_Id
				from Student s, Department d
				where s.Dept_Id = d.Dept_Id
				and d.Dept_Name = 'SD')

-------------------------Bouns-------------------------
--Qu(1)
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(50),
    Position VARCHAR(50),
    OrgNode HIERARCHYID
);

-- Insert root node (CEO)
INSERT INTO Employees VALUES (1, 'John Smith', 'CEO', hierarchyid::GetRoot());

-- Insert direct reports to CEO
INSERT INTO Employees VALUES (2, 'Alice Johnson', 'CTO', hierarchyid::GetRoot().GetDescendant(NULL, NULL));
INSERT INTO Employees VALUES (3, 'Bob Wilson', 'CFO', hierarchyid::GetRoot().GetDescendant(
    (SELECT OrgNode FROM Employees WHERE EmployeeID = 2), NULL));

-- Insert employees under CTO
INSERT INTO Employees VALUES (4, 'Carol Davis', 'Dev Manager', 
    (SELECT OrgNode FROM Employees WHERE EmployeeID = 2).GetDescendant(NULL, NULL));
INSERT INTO Employees VALUES (5, 'David Lee', 'QA Manager', 
    (SELECT OrgNode FROM Employees WHERE EmployeeID = 2).GetDescendant(
    (SELECT OrgNode FROM Employees WHERE EmployeeID = 4), NULL));


--Qu(2)
declare @i int
set @i = 3001
while @i <= 6000
	begin
		insert into Student(St_Id,St_Fname,St_Lname)
		values(@i, iif(@i%2 = 0,'Jane','Smith'), iif(@i%2 = 0,'Smith','Jane') )
		set @i = @i + 1
	end