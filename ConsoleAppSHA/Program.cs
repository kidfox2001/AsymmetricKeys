using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EasyEncryption;

namespace ConsoleAppSHA
{
    class Program
    {
		private static string HashPassword(string input)
		{ // Create a function to easily hash passwords
			return SHA.ComputeSHA256Hash(input); // One function to hash using SHA256 with EasyEncryption library, returns a string.
		}

		private static bool PasswordsMatch(string userInput, string savedTextFilePassword)
		{ // Function to check if the user input the correct password
			string hashedInput = HashPassword(userInput); // Hash user input to check it against the one stored in a file
			bool doPasswordsMatch = string.Equals(hashedInput, savedTextFilePassword); // Check both passwords
			return doPasswordsMatch; // Return the result of comparing both hashed strings
		}

		static void Main(string[] args)
        {
			string myPassword = "password123"; // Password that user wants
			string hashedSavedPassword = HashPassword(myPassword); // What you store in the actual text file
			Console.WriteLine("The hashed version of the users password is:       {0} (this is what gets saved to the text file)", hashedSavedPassword); // Log the hashed version

			string userInputPassword = "password123"; // Password the user enters to login
			Console.WriteLine("The hashed version of the good entered password is {0} (it should match the one in the text file)", HashPassword(userInputPassword)); // Log the hashed version

			string userInputPasswordFails = "not the correct password"; // A test if the user enters an incorrect password
			Console.WriteLine("The hashed version of the bad entered password is  {0} (this will not match the one in the text file)", HashPassword(userInputPasswordFails)); // Log the hashed version

			if (PasswordsMatch(userInputPassword, hashedSavedPassword)) // Check that the good password is correct
				Console.WriteLine("The good Password is correct");  // This should happen
			else
				Console.WriteLine("The good Password is not correct"); // This should not happen

			if (PasswordsMatch(userInputPasswordFails, hashedSavedPassword)) // Check that the bad password is incorrect
				Console.WriteLine("The bad Password is correct");   // This should not happen
			else
				Console.WriteLine("The bad Password is not correct"); // This should happen

			Console.ReadLine();
		}
    }
}
