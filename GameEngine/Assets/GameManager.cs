using System;

/// <summary>
/// This is a "Hello World" C# sample that you can try out with CS-Script.
/// The code is normal C# code. The point of this sample is to show how you can
/// pass in command-line arguments, get input from the user, output text,
/// and return an exit code.
///
/// To see more you can run this directly from a DOS prompt using CS-Script go to:
/// http://www.members.optusnet.com.au/~olegshilo/
/// </summary>
class GameManager
{
	// note the string array variable "args". it contains all of your passed in command-line arguments.
	static int MainC(string[] args)
	{
		// loop thru all passed in command-line arguments in the "args" string array and print them out
		foreach (string arg in args)
			Console.WriteLine("passed in argument: " + arg);

		// print a prompt
		Console.Write("What is your name? ");
		// get input from the user
		// string name = Console.ReadLine();

		// print out a message
		// Console.WriteLine("Hello " + name);

		// everything worked so return a zero exit code (0 typically means "success")
		return 0;
	}
}