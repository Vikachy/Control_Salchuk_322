using System;
using Control_Salchuk_322;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamGradeCalculator
{
    [TestClass]
    public class GradeCalculatorTests
    {
        [TestMethod]
        public void Test_Excellent_Grade()
        {
            string result = GradeCalculator.CalculateGrade(22, 38, 20);
            Assert.AreEqual("5 (отлично)", result);
        }

        [TestMethod]
        public void Test_Good_Grade()
        {
            string result = GradeCalculator.CalculateGrade(15, 20, 10);
            Assert.AreEqual("4 (хорошо)", result);
        }

        [TestMethod]
        public void Test_Satisfactory_Grade()
        {
            string result = GradeCalculator.CalculateGrade(10, 10, 5);
            Assert.AreEqual("3 (удовлетворительно)", result);
        }

        [TestMethod]
        public void Test_Unsatisfactory_Grade()
        {
            string result = GradeCalculator.CalculateGrade(5, 5, 5);
            Assert.AreEqual("2 (неудовлетворительно)", result);
        }

        [TestMethod]
        public void Test_Invalid_Score_Too_High()
        {
            string result = GradeCalculator.CalculateGrade(30, 40, 20);
            Assert.AreEqual("Некорректная сумма баллов", result);
        }

        [TestMethod]
        public void Test_Invalid_Score_AboveMax()
        {
            Assert.AreEqual("Некорректная сумма баллов", GradeCalculator.CalculateGrade(23, 10, 10));
            Assert.AreEqual("Некорректная сумма баллов", GradeCalculator.CalculateGrade(10, 39, 10));
            Assert.AreEqual("Некорректная сумма баллов", GradeCalculator.CalculateGrade(10, 10, 21));
        }

        [TestMethod]
        public void Test_Invalid_Score_Negative()
        {
            Assert.AreEqual("Некорректная сумма баллов", GradeCalculator.CalculateGrade(-1, 10, 10));
            Assert.AreEqual("Некорректная сумма баллов", GradeCalculator.CalculateGrade(10, -1, 10));
            Assert.AreEqual("Некорректная сумма баллов", GradeCalculator.CalculateGrade(10, 10, -1));
        }

        [TestMethod]
        public void Test_Valid_Boundary_Cases()
        {
            Assert.AreEqual("5 (отлично)", GradeCalculator.CalculateGrade(22, 38, 20));
            Assert.AreEqual("2 (неудовлетворительно)", GradeCalculator.CalculateGrade(0, 0, 0));
        }
    }
}
