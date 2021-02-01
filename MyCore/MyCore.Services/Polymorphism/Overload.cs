using System;
using System.Collections.Generic;
using System.Text;

namespace MyCore.Services.Polymorphism
{
    /*
     * Полиморфизм - свойство одних и тех объектов и методов принимать разные формы:
     *  1. Перегрузка методов - совершают одинаковые действия с разными типами данных
     *      Метод не идентифицируется по возвращаемому типу, с модификатором static
     *      Метод идентифицируется только по имени, типу и количеству паарметров
     */

    public class Overload
    {
        public int DisplayOverload(int a) {
            return a;
        }

        public int DisplayOverload(string a) {
            var result = 0;
            int.TryParse(a, out result);
            return result;
        }

        public int DisplayOverload(string a, int b) {
            var result = 0;
            int.TryParse(a, out result);

            result = result + b;

            return result;
        }

        // статика не пойдет.
        //public static int DisplayOverload(int a) {

        //}

        // метод с оператором out/ref будет работать.
        public static int DisplayOverload(out int a)
        {
            a = 5;

            return a + 5;
        }

        // метод конфликтует с другими по имени и сигнатуре
        //public int DisplayOverload(out int a)
        //{
        //    a = 5;

        //    return a + 5;
        //}

        // здесь массивы, благодаря params, передаются по ссылке
        public int DisplayOverload(params int[][] p)
        {
            var result = 0;

            foreach (var item1 in p)
            {
                foreach (var item2 in item1)
                {
                    result = result + item2;
                }
            }

            return result;
        }
    }
}
