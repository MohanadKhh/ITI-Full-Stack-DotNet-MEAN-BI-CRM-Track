namespace Task1_Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NIC nic = NIC.Obj;
            NIC nic2 = NIC.Obj;
            NIC nic3 = NIC.Obj;

            Console.WriteLine(nic.GetHashCode());
            Console.WriteLine(nic2.GetHashCode());
            Console.WriteLine(nic3.GetHashCode());
        }
    }
}
