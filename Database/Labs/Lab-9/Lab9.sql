--Part 1

--Question(1):
use ITI
alter proc getStPerDep
as
	select d.Dept_Name, count(s.St_Id)
	from student as s, Department as d
	where s.Dept_Id = d.Dept_Id
	group by d.Dept_Name

getStPerDep


--Question(2):
use Company
alter proc No_Emp_Per_P1
as
	declare @num int
	select @num = count(ESSN)
	from works_on
	where PNO = 1

	if(@num > 3)
	begin
		select 'The number of employees in the project p1 is 3 or more'
	end

	else
	begin
		select 'The following employees work for the project p1'
		select e.FName + ' ' + e.LName as Full_Name
		from empolyee as e, works_on as w
		where e.SSN = w.ESSN and w.PNO = 1
	end

No_Emp_Per_P1


--Question(3):
create proc update_Emp_Per_Pj @oldEmp int, @newEmp int, @_PNO int
as
	update works_on
	set ESSN = @newEmp
	where PNO = @_PNO AND ESSN = @oldEmp


update_Emp_Per_Pj 1,2,1


--Question(4):
alter table project
add budget int

create table projcetAudit (
	ProjectNo int,
	UserName varchar(50),
	ModifiedDate date,
	Budget_Old int,
	Budget_New int
)

create trigger budget_Updated
on project
after update
as
	if update(budget)
	begin
		declare @_PNO int, @oldBudget int, @newBudget int
		select @_PNO = d.PNumber, @oldBudget = d.budget, @newBudget = i.budget
		from deleted as d, inserted as i

		insert into projcetAudit
		values(@_PNO,SUSER_NAME(),GETDATE(),@oldBudget,@newBudget)
	end

update project
set budget = 5
where PNumber = 2


--Question(5):
use ITI

alter trigger noInsert
on Department
instead of insert
as
	select 'you can’t insert a new record in that table'

insert into Department(Dept_Id)
values(500)


--Question(6):
use Company

alter trigger NoInsert_In_March
on empolyee
after insert
as
	if(FORMAT(GETDATE(),'MMMM') = 'December')
	begin
		delete from empolyee
		where SSN = (select SSN FROM inserted)
	end

insert into empolyee(SSN, FName)
values(50000, 'Mohanad')


--Question(7):
use ITI

create table studentAudit(
	serverUserName varchar(50),
	insertionDate date,
	note nvarchar(max)
)

alter trigger InsertSt
on student
after insert
as
	insert into studentAudit
	values(SUSER_NAME(), GETDATE(),
	SUSER_NAME() + ' Insert New Row with Key = [' + convert(varchar(20), (select St_Id from inserted)) + '] in table [Student]')

insert into student(St_Id)
values(50000)


--Question(8):
create trigger TrDeleteSt
on student
instead of delete
as
	insert into studentAudit
	values(SUSER_NAME(), GETDATE(),
	SUSER_NAME() + ' Try to delete Row with Key = [' + convert(varchar(20), (select St_Id from deleted)) + '] in table [Student]')

delete from Student
where St_Id = 1