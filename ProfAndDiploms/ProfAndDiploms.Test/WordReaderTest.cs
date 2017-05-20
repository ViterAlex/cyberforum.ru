using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProfAndDiploms.Test
{
    [TestClass]
    public class WordReaderTest
    {
        private static WordReader _wordReader;

        [ClassInitialize]
        public static void Init(TestContext context)
        {

            _wordReader = new WordReader(Path.GetFullPath("..\\..\\..\\ProfAndDiploms\\Приказ о закреплении тем на ДП.docx"));
            _wordReader.GetProfs();
            foreach (var proffesor in _wordReader.Professors)
            {
                Debug.WriteLine($"{proffesor}");
            }
        }

        [ClassCleanup]
        public static void Clean()
        {
            _wordReader.Clean();
        }

        [TestMethod]
        public void GetProffesors_NotEmpty()
        {
            Assert.IsTrue(_wordReader.Professors.Count > 0);
        }

        [TestMethod]
        public void Diplomas_Count_NotEqual_0()
        {
            var profs = _wordReader.Professors.Where(p => p.Diplomas.Count == 0);
            foreach (var proffesor in profs)
            {
                Debug.WriteLine(proffesor);
            }
            var count = _wordReader.Professors.Count(p => p.Diplomas.Count == 0);
            Assert.AreEqual(0, count);
        }
    }
}
