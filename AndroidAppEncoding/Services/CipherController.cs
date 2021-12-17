using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AndroidAppEncoding.Views;

namespace Logic
{
    public class CipherController
    {
        private static readonly string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private static readonly string[][] matrix = GetTable();
        public static bool VerifyText(string text)
        {
            if (text != null)
            {
                foreach (var letter in text)
                {
                    if (alphabet.Contains(letter))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool VerifyCodeword(string text)
        {
            if (text != null)
            {
                foreach (var letter in text)
                {
                    if (!alphabet.Contains(letter))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;

        }
        public static string GateControl(string text, string code, int mode)
        {
            string codeword = NormalifyCodeWord(text, code);
            if (mode == 1)
            {
                return Cipherer(text, codeword);
            }
            else if(mode == 2)
            {
                return Decipherer(text, codeword);
            }
            return null;
        }
        private static string Cipherer(string text, string code)
        {
            bool regFlagUpper = false; //is element in upper or lower reg
            string cipheredText = "";
            int xPos; //column number
            int yPos; //row number
            int codeWordPos = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]) && alphabet.Contains(Char.ToLower(text[i])))
                {
                    regFlagUpper = Char.IsUpper(text[i]);
                    xPos = alphabet.IndexOf(Char.ToLower(text[i]));
                    yPos = alphabet.IndexOf(code[codeWordPos]);
                    cipheredText += regFlagUpper ? matrix[yPos][xPos].ToUpper() : matrix[yPos][xPos];
                    codeWordPos++;
                }
                else
                {
                    cipheredText += text[i];
                }
            }
            return cipheredText;
        }
        private static string Decipherer(string text, string code)
        {
            bool regFlagUpper = false; //is element in upper or lower reg
            string decipheredText = "";
            int xPos; //column number
            int yPos; //row number
            int codeWordPos = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]) && alphabet.Contains(Char.ToLower(text[i])))
                {
                    regFlagUpper = Char.IsUpper(text[i]);
                    yPos = alphabet.IndexOf(code[codeWordPos]);
                    xPos = Array.IndexOf(matrix[yPos], matrix[yPos].First(x => x == text[i].ToString().ToLower()));
                    decipheredText += regFlagUpper ? Char.ToUpper(alphabet[xPos]) : alphabet[xPos];
                    codeWordPos++;

                }
                else
                {
                    decipheredText += text[i];
                }
            }
            return decipheredText;
        }
        private static string NormalifyCodeWord(string text, string codeword)
        {
            if (codeword.Length > text.Length)
            {
                return codeword.Substring(0, text.Length);
            }
            else if (codeword.Length == text.Length)
            {
                return codeword;
            }
            else
            {
                codeword = codeword.ToLower();
                string oldCodeWord = codeword;
                string textOnlyLetters = new string(text.Where(c => char.IsLetter(c)).ToArray());
                for (int i = oldCodeWord.Length + 1; i <= textOnlyLetters.Length; i++)
                {
                    if (i % oldCodeWord.Length != 0)
                    {
                        codeword += oldCodeWord[(i % oldCodeWord.Length) - 1];
                    }
                    else
                    {
                        codeword += oldCodeWord[oldCodeWord.Length - 1];
                    }

                }
                return codeword;
            }

        }
        private static string[][] GetTable()
        {
            string[][] arr = new string[33][];

            string movedPart = "";
            for (int i = 0; i < 33; i++)
            {
                arr[i] = new string[33];
                if (i == 0)
                {
                    for (int j = 0; j < 33; j++)
                    {
                        arr[i][j] = alphabet[j].ToString();
                    }
                    continue;
                }
                movedPart = alphabet.Substring(0, i);
                string newStr = alphabet.Remove(0, i) + movedPart;
                for (int j = 0; j < 33; j++)
                {
                    arr[i][j] = newStr[j].ToString();
                }
            }
            return arr;
        }
    }
}
