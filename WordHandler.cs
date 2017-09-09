using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersToWords {
	class WordHandler {
		//Must be in alphabetical order
		/*static String[] wList = {
			"add",
			"dear",
			"dread",
			"rear",
			"red"
		};*/

		static List<CharacterNode> wList = new List<CharacterNode>();

		static CharacterNode masterNode = new CharacterNode('|');

		public static void addWord(String w) {
			innerAdd(masterNode, w.ToLower());
		}

		private static void innerAdd(CharacterNode parentNode, String word) {
			//If the word ends on this node, make it a word
			if (word.Length == 0) {
				parentNode.isWord = true;
				return;
			}
			//If a node with the next character exists, recure without it
			foreach (CharacterNode cN in parentNode.nextNodes) {
				if (cN.myChar+"" == word.Substring(0,1)) {
					innerAdd(cN, word.Substring(1));
					return;
				}
			}
			//If a node with the next character doesn't exist, create it, then recur
			parentNode.nextNodes.Add(new CharacterNode(Char.Parse(word.Substring(0, 1))));
			innerAdd(parentNode.nextNodes.Last(), word.Substring(1));
			return;
		}

		public static List<String> getWords(String word) {
			return innerWords(masterNode, new List<Char>(word.ToLower().ToCharArray()));
		}

		private static List<String> innerWords(CharacterNode parentNode, List<Char> useableChars) {
			List<String> ret = new List<String>();
			foreach (CharacterNode c in parentNode.nextNodes) {
				//If c's character is in useableChars, recur without it
				if (useableChars.Remove(c.myChar)) {
					List<String> add = innerWords(c, useableChars);
					//Add returned partial words
					foreach (String s in add) {
						ret.Add(parentNode.myChar + s);
					}
					useableChars.Add(c.myChar);
				}
			}
			if (parentNode.nextNodes.Count > 0 && useableChars.Count > 0 && parentNode.isWord) {
				List<String> add = innerWords(masterNode, useableChars);//Check if current iteration is a word
				//Add returned partial words
				foreach (String s in add) {
					ret.Add(parentNode.myChar + "|" + s);
				}
			}
			//Add this node as a word
			if (parentNode.isWord) {
				ret.Add(parentNode.myChar + "");
			}
			//Return (possibly partial) words
			return ret;
		}
	}
}
