using System;
using System.Linq;
using System.Collections.Generic;

namespace ChatLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prog.Fundamentals Exam - Problem with Lists, Arrays 

            var inputCommands = Console.ReadLine().Split(' ').ToList();
            var result = new List<string>();

            while (!inputCommands[0].Equals("end"))
            {
                if (inputCommands[0] == "Chat")
                {
                    string messageToAdd = inputCommands[1];
                    result.Add(messageToAdd);
                }
                else if (inputCommands[0] == "Delete")
                {
                    string messageToDelete = inputCommands[1];
                    if (result.Contains(messageToDelete))
                    {
                        result.Remove(messageToDelete);
                    }
                }
                else if (inputCommands[0] == "Edit")
                {
                    string messageToEdit = inputCommands[1];
                    string editedVersion = inputCommands[2];

                    int indexOfWord = result.IndexOf(messageToEdit);
                    result.RemoveAt(indexOfWord);
                    result.Insert(indexOfWord, editedVersion);
                }
                else if (inputCommands[0] == "Pin")
                {
                    string messageToPin = inputCommands[1];
                    int indexOfWord = result.IndexOf(messageToPin);
                    result.RemoveAt(indexOfWord);
                    result.Insert(result.Count, messageToPin);
                }
                else if (inputCommands[0] == "Spam")
                {
                    List<string> current = inputCommands.Skip(1).Take(inputCommands.Count).ToList();
                    result.AddRange(current);
                }



                inputCommands = Console.ReadLine().Split(' ').ToList();
            }
            
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }
}
