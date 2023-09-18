
These are the sources for the RealTree example for the GPPG distribution.

The example shows a typical use of a hierarchy of class types as the semantic value 
objects of a GPPG parser.

The file RealTreeParser.cs was produced from the command -
> gppg /nolines RealTree.y
All the user-written code is in the helper file RealTreeHelper.cs

Compile with csc /out:RealTree.exe RealTreeParser.cs RealTreeHelper.cs ShiftReduceParserCode.cs

A full description of the program and its design is in the 2012 March 23 edition of 
my blog John Gough on Software Tools.  Also see the release notes of GPPG.

http://softwareautomata.blogspot.com.au/

John

