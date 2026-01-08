use Company_SD

select d.Dname,d.Dnum,d.MGRSSN
from Departments d, Employee e
where d.MGRSSN = e.SSN

select d.Dname, p.Pname
from Departments d, Project p
where d.Dnum = p.Pnumber

select d.*, fullname = e.Fname + ' ' + e.Lname
from Dependent d, Employee e
where d.ESSN = e.SSN

select p.Pnumber, p.Pname, p.Plocation
from Project p
where p.Plocation = 'cairo' or p.Plocation = 'alex'

select p.*
from Project p
where p.Pname like 'a%'

select e.*
from Employee e
where e.Dno = 30 and e.Salary between 1000 and 2000

select fullname = e.Fname + ' ' + e.Lname
from Employee e, Works_for w, Project p
where e.Dno = 10
and w.ESSn = e.SSN
and w.Pno = p.Pnumber
and w.ESSn >= 10
and p.Pname = 'AL Rabwah'

select fullname = e.Fname + ' ' + e.Lname
from Employee e, Employee s
where e.Superssn = s.SSN and s.Fname = 'Kamel' and s.Lname = 'Mohamed'

select fullname = e.Fname + ' ' + e.Lname, p.Pname
from Works_for w inner join Employee e
on w.ESSn = e.SSN
inner join Project p
on w.Pno = p.Pnumber
order by p.Pname

select p.Pnumber, d.Dname, Manager_LName = e.Lname, e.Address, e.Bdate
from Project p, Departments d, Employee e
where p.Dnum = d.Dnum
and p.City = 'Cairo'
and d.MGRSSN = e.SSN

select e.*
from Employee e inner join Departments d
on d.MGRSSN = e.SSN

select e.*, d.*
from Employee e left join Dependent d
on e.SSN = d.ESSN

insert into Employee
values('Mohanad','Khaled',102672,10/4/2002,'Obour city - Dar Masr','M',3000,112233,30)

insert into Employee (Fname,Lname,SSN,Bdate,Address,Sex,Dno)
values('Ziad','Hisham',102660,10/4/2002,'Mohandesen city - Ard Al lwa','F',30)

update Employee
set Salary *= 1.2
where SSN = 102672