using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersToWords {
	class FileHandler {

		public static String[] readFile() {
			return System.IO.File.ReadAllLines(System.Reflection.Assembly.GetExecutingAssembly().Location+"\\..\\Words.txt");
		}

	}
}
