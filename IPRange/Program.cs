using System;
using System.IO;
using System.Text;
namespace ConsoleApplication1 {
	class Program {
		static void Main(string[] args) {
			string[] orig = File.ReadAllLines(@"..\..\original.txt", Encoding.Default);
			string[] subtract = File.ReadAllLines(@"..\..\subtract.txt", Encoding.Default);
			StreamWriter sw = new StreamWriter(@"..\..\result.txt");
			IPRange ipOrig, ipSub;
			bool excluded;
			foreach (string origItem in orig) {

				ipOrig = IPRange.Parse(origItem);
				excluded = false;

				foreach (string subtractItem in subtract) {

					ipSub = IPRange.Parse(subtractItem);
					IPRange[] res = ipOrig.Exclude(ipSub);
					if (res.Length > 0) {
						sw.WriteLine(res[0].ToString());
						sw.WriteLine(res[1].ToString());
						Console.WriteLine(res[0].ToString());
						Console.WriteLine(res[1].ToString());
						excluded = true;
					}

				}

				if (!excluded) {
					sw.WriteLine(ipOrig.ToString());
					Console.WriteLine(ipOrig.ToString());
				}

			}
			sw.Close();
			Console.Read();
		}
	}
}
