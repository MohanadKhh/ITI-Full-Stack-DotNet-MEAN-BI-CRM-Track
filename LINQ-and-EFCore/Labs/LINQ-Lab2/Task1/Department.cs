namespace Task1
{
    public class Department
    {
        /*------------------------------------------------------------------*/
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        /*------------------------------------------------------------------*/
        public override string ToString()
        {
            return $"Department Id: {DeptId}, Department Name: {DeptName}";
        }
        /*------------------------------------------------------------------*/
    }
}
