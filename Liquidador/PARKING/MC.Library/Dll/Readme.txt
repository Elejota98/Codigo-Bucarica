The files myOPC.dll and Interop.OPCAutomation.dll both should be referenced by your client file and their properties "Copy Local" set to true.

The file Interop.OPCAutomation.dll will have its property "Embed Interop Types" to False first.  

On every machine your client program will utilize myOPC.dll the assembly OPCDAAuto.dll must also be located and registered to the operating system.  

This registeration is done via the included update_OPCdaauto.bat file.  

If you don't do this (and you will forget) the assembly myOPC.dll will not function.  

I usually copy both OPCDAAuto.dll and the batch file to the System32 directory of the machine I'm going to use then run the batch file.  

The below is the instruction Kepware gave.

Enjoy...Kurt Swaim



Thank you for you interest in Kepware products. 

In order for the VB.net Examples to work you will need to extract the files 
in the "OPCdaauto.zip" file into the System32 folder of your Operating System. 

Once they are in place, double click on the file Update_OPCdaauto.bat to register the new DLL. 
This will allow the projects to run without error.

Thank you,

Kepware Technical Support