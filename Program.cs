using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersToWords {
	class Program {

		static void Main(string[] args) {
			String[] wordList = FileHandler.readFile();
			foreach (String s in wordList) {
				WordHandler.addWord(s);
			}
			do {
				Console.WriteLine("Please enter a set of letters");
				List<String> w = WordHandler.getWords(Console.ReadLine());
				foreach (String word in w) {
					Console.WriteLine(word);
				}
			} while (true);
		}
	}
}
