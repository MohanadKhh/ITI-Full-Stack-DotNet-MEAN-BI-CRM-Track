using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Task1
{
    internal class EmpComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id;
        }
    }
}
