--Part 1:
use ITI


--Question(1):
go
create view vStudents
as
	select s.St_Fname + ' ' + s.St_Lname as Full_Name , c.[Crs_Name]
	from [dbo].[Student] as s, [dbo].[Course] as c, [dbo].[Stud_Course] as sc
	where s.St_Id = sc.St_Id and c.Crs_Id = sc.Crs_Id and sc.Grade > 50


--Question(2):
go
create view vManagers
with encryption
as 
	select ins.[Ins_Name], t.Top_Name
	from Topic as t, Ins_Course as ic, Department as d, Course as c, Instructor as ins
	where d.Dept_Manager = ins.Ins_Id and ins.Ins_Id = ic.Ins_Id
		and c.Crs_Id = ic.Crs_Id and t.Top_Id = c.Top_Id


--Question(3):
go
create view vInstructors
as
	select ins.[Ins_Name], d.Dept_Name
	from Instructor as ins, Department as d
	where d.Dept_Manager = ins.Ins_Id and d.Dept_Name in ('SD','Java')


--Question(4):
go
create view V1
as
	select *
	from Student
	where St_Address in ('alex', 'cairo')
with check option
go

Update V1
	set st_address='tanta'
	Where st_address='alex';


--Question(5):
use SD
go
create view vProjects
as
	select p.ProjectName, count (w.EmpNo) as No_of_employees
	from [company].[Project] as p, Works_on as w
	where p.ProjectNo = w.ProjectNo
	group by w.ProjectNo, p.ProjectName
go

--Question(6):
use ITI
create NonClustered index HiredateIndex
on [dbo].[Department] (Manager_hiredate)


--Question(7):
create unique index ageIndex
on [dbo].[Student] ([St_Age])

-- if ages values has unique index will be created
-- and can't enter duplicated ages
--if ages values has non unique, so it will give error


--Question(8):
/*

merge Last_Transactions as l 
using Daily_Transactions as d
on l.User_ID = d.User_ID
when matched then
	action
when Not Matched then
	action
;

*/


----------------------------------------------------------
--Part(2):
use SD


----Question(1):
go
create view v_clerk
as
	select e.EmpNo, p.ProjectNo, w.Enter_Date
	from HR.Empolyee as e, Company.Project as p, Works_on as w
	where e.EmpNo = w.EmpNo and p.ProjectNo = w.ProjectNo and w.Job = 'Clerk'


----Question(2):
go
create view v_without_budget
as
	select ProjectNo, ProjectName
	from company.Project


----Question(3):
go
create view v_count
as
	select p.ProjectName, count(w.Job) as No_of_jobs
	from Company.Project as p, Works_on as w
	where p.ProjectNo = w.ProjectNo
	group by p.ProjectName


----Question(4):
go
create view v_project_p2
as
	select EmpNo
	from v_clerk
	where ProjectNo = 'p2'


----Question(5):
go
alter view v_without_budget
as
	select *
	from Company.Project as p
	where p.ProjectNo in ('p1','p2')
go

----Question(6):
drop view v_clerk, v_count


----Question(7):
go
create view vEmp_Dep
as
	select e.EmpNo, e.EmpLname
	from HR.Empolyee as e, company.Departement as d
	where e.DeptNo = d.DeptNo and d.DeptNo = 'd2'
go

----Question(8):
select EmpLname
from vEmp_Dep
where EmpLname like '%J%'


----Question(9):
go
create view v_dept
as
	select DeptNo, DeptName
	from company.Departement
go

----Question(10):
insert into v_dept
values('d4','Development')


----Question(11):
go
create view v_2006_check
as
	select e.EmpNo, p.ProjectNo, d.Location ,w.Enter_Date
	from Company.Project as p, Works_on as w, HR.Empolyee as e, company.Departement as d
	where e.EmpNo = w.EmpNo and p.ProjectNo = w.ProjectNo
		and e.DeptNo = d.DeptNo and w.Enter_Date between '2006/1/1' and '2006/12/31'

go