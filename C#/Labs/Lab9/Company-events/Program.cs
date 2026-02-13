namespace Company_events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department dept = new Department();
            Club club = new Club();

            Employee emp = new Employee(); //employee that has no vacation stock
            club.AddMember(emp);
            dept.AddStaff(emp);
            emp.RequestVacation(new DateTime(2026, 2, 20), new DateTime(2026, 2, 25));

            Employee emp2 = new Employee(new DateTime(1964,10,18), 50);     //employee that older than 60
            club.AddMember(emp2);
            dept.AddStaff(emp2);
            emp2.EndOfYearOperation();

            SalesPerson salesEmp = new SalesPerson();       //sales that not achieved target
            club.AddMember(salesEmp);
            dept.AddStaff(salesEmp);
            salesEmp.CheckTarget(3);

            BoardMember boardEmp = new BoardMember();       //board member that resign
            club.AddMember(boardEmp);
            dept.AddStaff(boardEmp);
            boardEmp.Resign();
        }
    }   
}
