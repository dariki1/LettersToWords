using LettersToWords.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersToWords {
	class Program {

		static void Main(string[] args) {
			string[] wordList = Resources.Words.Split('\n');
			foreach (string s in wordList) {
				WordHandler.addWord(s.Trim());
			}
			do {
				Console.WriteLine("Please enter a set of letters, hold control and c to exit");
				List<String> w = WordHandler.getWords(Console.ReadLine());
				foreach (String word in w) {
					Console.WriteLine(word);
				}
			} while (true);
		}
	}
}
