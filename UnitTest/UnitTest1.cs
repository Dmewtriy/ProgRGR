using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryViewer;

namespace UnitTest
{
    [TestClass]
    public class FileManagerTests
    {
        private const string TestFilePath = "testfile.bin";
        private FileManager fm;

        [TestInitialize]
        public void Setup()
        {
            if (File.Exists(TestFilePath))
            {
                try
                {
                    File.Delete(TestFilePath); // Удаляем, если вдруг остался после прошлого теста
                }
                catch (IOException)
                {
                    Assert.Fail("Не удалось удалить testfile.bin. Возможно, файл занят.");
                }
            }

            // Создаем файл размером 1500 байт
            byte[] data = new byte[1500];
            for (int i = 0; i < data.Length; i++) data[i] = (byte)(i % 256);
            File.WriteAllBytes(TestFilePath, data);

            fm = new FileManager(1000);
        }

        [TestCleanup]
        public void Cleanup()
        {
            fm?.CloseFile();

            if (File.Exists(TestFilePath))
            {
                try
                {
                    File.Delete(TestFilePath);
                }
                catch (IOException)
                {
                    Assert.Fail("Не удалось удалить testfile.bin в Cleanup. Возможно, файл всё еще занят.");
                }
            }
        }

        [TestMethod]
        public void Test_ReadPageFromValidFile()
        {
            fm.Open(TestFilePath);
            var page = fm.GetNewPage();
            Assert.AreEqual(1000, page.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Test_OpenNonexistentFile()
        {
            fm.Open("fakefile.bin");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_ReadWithoutOpeningFile()
        {
            var newFm = new FileManager(1000);
            newFm.GetNewPage();
        }

        [TestMethod]
        public void Test_EndOfFileReturnsEmptyArray()
        {
            fm.Open(TestFilePath);

            var page1 = fm.GetNewPage(); // 1000 байт
            var page2 = fm.GetNewPage(); // 500 байт
            var page3 = fm.GetNewPage(); // конец файла -> []

            Assert.AreEqual(1000, page1.Length);
            Assert.AreEqual(500, page2.Length);
            Assert.AreEqual(0, page3.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_InvalidPageSize()
        {
            var newFm = new FileManager(0); // недопустимый размер страницы
        }
    }
}
