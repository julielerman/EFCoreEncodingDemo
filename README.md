# EFCoreEncodingDemo
Shows how to ensure special characters can be output in EF Core logs to deal with Windows console defaults. 

This problem waas reaised by a Pluralsight viewer, Mir Newaz. 

The CONSOLE targetted logging output  was not showing the nonenglish characters - specifically Arabic.
Although the Visual STudio IDE and the database were displaying them correctly.

In solving this I got a good lesson on encoding as I tried to figure out how to impact it. Console defaults to UTF8 (code page 65001).

Arabic letters cannot be displayed via that code page. There is a special code page 1256 for Arabic. (https://en.wikipedia.org/wiki/Windows-1256)

I tried changing the code page in windows registry but the .NET console overrides that. 

I finally found this stackoverflow q&a (https://stackoverflow.com/questions/38533903/set-c-sharp-console-application-to-unicode-output) where the FIRST upvoted response did NOT solve the problem but the second one did. 

The program.cs shows how I resolved in my code.

Note that you do NOT have to change any of the default properties of your console windows such as the suggestion (in that first answer) to change it to Lucida Console.
