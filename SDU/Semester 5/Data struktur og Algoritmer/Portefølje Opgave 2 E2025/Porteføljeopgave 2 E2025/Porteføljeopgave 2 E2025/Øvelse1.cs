using System;
using System.Collections.Generic;

namespace Porteføljeopgave_2_E2025
{
    internal class Øvelse1
    {
        private static char[] delimiterChars = {' ', ',', '.', ':', '\t'};

        private static string textToAnalyse = "The cattle were running back and forth, " +
                                              "but there was no wolf to be seen, heard, or smelled, so the shepherd decided to take a " +
                                              "little nap in a bed of grass and early summer flowers. Soon he was awakened by a " +
                                              "sound he had never heard before.";

        
        static void Main(string[] args)
        {
            Console.WriteLine("Most frequent word is: " + MostFrequentlyOccurringWord(textToAnalyse));
         }

        private static string MostFrequentlyOccurringWord(string phrase)
        {
            string[] words = phrase.Split(delimiterChars);
            List<Word> wordsObjects = new List<Word>();

            foreach (var word in words)
            {
                if(word == "") continue;
                Word currentWord = new Word
                {
                    word = word,
                    amount = 0
                };
                
                Console.WriteLine("Added new word: " + currentWord.word);
                foreach (var wordToCompare in words)
                {
                    if (wordToCompare == currentWord.word)
                    {
                        currentWord.amount++;
                    }
                }
                wordsObjects.Add(currentWord);
            }

            string mostFrequentWord = "";
            int highestAmount = 0;
            foreach (var word in wordsObjects)
            {
                if (word.amount > highestAmount)
                {
                    mostFrequentWord = word.word;
                    highestAmount = word.amount;
                }
            }

            return mostFrequentWord;
        }
        
        [Serializable]
        public class Word
        {
            public string word;
            public int amount;
        }

       
    }
}