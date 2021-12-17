using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AndroidAppEncoding.Views;
using Logic;

namespace AndroidAppEncoding.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Cipherer_Test1()
        {
            string text = "Карл у Клары украл кораллы";
            string codeword = "Кларнет";
            string expected = "Хлрь б Пюкьы дшхтц цобнрюё";


            string str = CipherController.GateControl(text, codeword, 1);

            Assert.AreEqual(str,expected);

        }
        [TestMethod]
        public void Cipherer_Test2()
        {
            string text = "Карл у Клары украл кораллы";
            string codeword = "Каб";
            string expected = "Хасц у Лцасё улыам хосклмё";


            string str = CipherController.GateControl(text, codeword, 1);

            Assert.AreEqual(str, expected);

        }
        [TestMethod]
        public void Cipherer_Test3()
        {
            string text = "хасц у лцасё улыам хосклмё";
            string codeword = "Каб";
            string expected = "карл у клары украл кораллы";


            string str = CipherController.GateControl(text, codeword, 2);

            Assert.AreEqual(str, expected);
        }
    }
}
