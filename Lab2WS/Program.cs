using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2WS
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            bool success=false;
            bool success2=false;
            while(success==false){
            try
            {
                Console.WriteLine("Enter the scrambled words manually or as a file: f - file, m = manual");

                string option = Console.ReadLine() ?? throw new Exception("String is null");

                switch (option.ToUpper())
                {
                    case "F":
                        Console.WriteLine("Enter the full path and filename >");
                        ExecuteScrambledWordsInFileScenario();
                        success=true;
                        break;
                    case "M":
                        Console.WriteLine("Enter word(s) separated by a comma");
                        ExecuteScrambledWordsManualEntryScenario();
                        success=true;
                        break;
                    default:
                        Console.WriteLine("The entered option was not recognized, please input F or M");
                        break;
                }
                if (success==true){
                    Console.WriteLine("Would you like to continue? Y/N");

                    while(success2==false){
                    string optionAgain = Console.ReadLine() ?? throw new Exception("String is null");

                    switch (optionAgain.ToUpper())
                    {
                    case "Y":
                        success=false;
                        success2=true;                        
                        break;
                    case "N":
                        success2=true;                        
                        break;
                    default:
                        Console.WriteLine("The entered option was not recognized, please input Y or N");
                        break;
                    }    
                    }
                }

                // Optional for now (when you have no loop)  (Take out when finished)
                // Console.WriteLine("Sorry");

        Console.ReadKey();
            
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry an error has occurred.. " + e.Message);
            }
            }
            


        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string fileName = Console.ReadLine();
            string[] scrambledWords = fileReader.Read(fileName);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {

            string userInput = Console.ReadLine();
            string[] scrambledWords = phrase.Split(',');
            DisplayMatchedScrambledWords(scrambledWords);

            // 1 get the user's input - comma separated string containing scrambled words
                
            // 2 Extract the words into a string (red,blue,green) 

            // 3 Call the DisplayMatchedUnscrambledWords method passing the scrambled words string array

        }

        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(@"wordlist.txt"); // Put in a constants file. CAPITAL LETTERS.  READONLY.

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);


            // Rule:  Use a formatter to display ... eg:  {0}{1}
            if (!matchedWords.Any())
            {
               Console.WriteLine("no words found");
            }
            else
            {
                foreach (MatchedWord s in matchedWords)
                {
                    String display = String.Format("MATCH FOUND FOR{0}{1}", scrambledWords, wordList);
                }
                
            }
            // Rule:  USe an IF to determine if matchedWords is empty or not......
            //            if empty - display no words found message.
            //            if NOT empty - Display the matches.... use "foreach" with the list (matchedWords)

        }
    }
}
