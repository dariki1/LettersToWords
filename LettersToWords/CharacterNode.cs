using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersToWords {
	class CharacterNode {
		public readonly char myChar;
		public List<CharacterNode> nextNodes = new List<CharacterNode>();
		public bool isWord = false;

		public CharacterNode(char mChar) {
			myChar = mChar;
		}
	}
}
