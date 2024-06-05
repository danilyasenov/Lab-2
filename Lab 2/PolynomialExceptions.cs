using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class NoComplexRootsException : Exception
    {
        public NoComplexRootsException() : base("Комплексные корни отсутствуют") { }
    }

    public class InfiniteRootsException : Exception
    {
        public InfiniteRootsException() : base("Корней бесконечно много") { }
    }

    public class UnknownEquationTypeException : Exception
    {
        public UnknownEquationTypeException() : base("Неизвестный тип уравнения") { }
    }
}
