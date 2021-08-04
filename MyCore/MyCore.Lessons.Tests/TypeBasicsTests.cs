using MyCore.TypeBasics;
using NUnit.Framework;

namespace MyCore.Lessons.Tests
{
    public class TypeBasicsTests
    {
        [Test]
        public void Equals_classes()
        {
            // True - ������ ����������
            var myClass1 = new MyClass();
            var result1 = myClass1.Equals(myClass1);
            Assert.IsTrue(result1);

            // False - ������ ������
            var myClass2 = new MyClass();
            var result2 = myClass1.Equals(myClass2);
            Assert.IsFalse(result2);

            // True - ������ ����������
            var myClass3 = myClass1;
            myClass1.FieldA = "123";
            var result3 = myClass3.Equals(myClass1);
            Assert.IsTrue(result3);
        }

        [Test]
        public void Equals_structs()
        {
            // True - ��������� ������ � ���� �� ������� �����
            var myStruct1 = new MyStruct();
            Assert.IsTrue(myStruct1.Equals(myStruct1));

            // False - ���������� ����� ���� ��� ������ �������
            var myStruct2 = myStruct1;
            myStruct2.FieldA = "1";
            Assert.IsFalse(myStruct1.Equals(myStruct2));
        }
    }
}