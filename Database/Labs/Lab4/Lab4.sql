use Company_SD

-- Qu(1)
select d.Dependent_name, d.Sex
from Dependents d, Employee e
where d.Sex = 'F'
and d.ESSN = e.SSN
and e.Sex = 'F'
union
select d.Dependent_name, d.Sex
from Dependents d, Employee e
where d.Sex = 'M'
and d.ESSN = e.SSN
and e.Sex = 'M'


-- Qu(2) Updated
select p.Pname, sum(w.Hours)
from Project p, Works_for w
where p.Pnumber = w.Pno
group by p.Pname


-- Qu(3)
select d.*
from Departments d, Employee e
where e.Dno = d.Dnum
and e.SSN = (select min(e.SSN)
			from Employee e)


-- Qu(4)
select d.Dname, min(e.Salary), max(e.Salary), avg(e.Salary)
from Employee e, Departments d
where e.Dno = d.Dnum
group by d.Dnum,d.Dname


-- Qu(5)
select e.Fname+' '+e.Lname as FullName
from Employee e, Departments dept
where dept.MGRSSN = e.SSN
and e.SSN not in (select d.ESSN
					from Dependents d)


-- Qu(6)
select d.Dnum, d.Dname, count(e.SSN)
from Departments d, Employee e
where e.Dno = d.Dnum
group by d.Dnum, d.Dname
Having avg(e.salary) < (select avg(e.Salary)
						from Employee e)


-- Qu(7)
select e.Fname+' '+e.Lname as FullName, p.Pname
from Employee e, Project p, Works_for w
where w.Pno = p.Pnumber and w.ESSn = e.SSN
order by e.Dno,e.Lname,e.Fname


-- Qu(8)
select max(e.salary)
from Employee e
union all
select max(e.salary)
from Employee e
where e.Salary < (select max(e.salary)
					from Employee e)


-- Qu(9)
select d.Dependent_name
from Dependents d
where d.Dependent_name in (select e.Fname+' '+e.Lname as FullName
							from Employee e)


-- Qu(10)
select e.SSN, e.Fname+' '+e.Lname as FullName
from Employee e
where exists (select 1 from Dependents
				where ESSN = e.SSN)


-- Qu(11)
insert into Departments
values('DEPT IT',100,112233,'1-11-2006')

-- Qu(12)
update Departments
set MGRSSN = 968574
where Dnum = 100

update Departments
set MGRSSN = 102672
where Dnum = 20

update Employee
set Superssn = 102672
where SSN = 102660


-- Qu(13) Updated
update Departments
set MGRSSN = 102672
where Dnum = (select d.Dnum
				from Departments d
				where MGRSSN = 223344)

update Employee
set Superssn = 102672
where Superssn = 223344

update Works_for
set ESSn = 102672
where ESSn = 223344

delete from Employee
where SSN = 223344

delete from Dependents
where ESSN = 223344


-- Qu(14) updated using join not subquery
update Employee
set Salary *= 1.3
from Employee e inner join Works_for w
on w.ESSn = e.SSN inner join Project p
on w.Pno = p.Pnumber
where p.Pname = 'Al Rabwah'

/*
select e.SSN, e.Salary
from Employee e, Project p, Works_for w
where w.Pno = p.Pnumber and w.ESSn = e.SSN
and p.Pname = 'Al Rabwah'*/