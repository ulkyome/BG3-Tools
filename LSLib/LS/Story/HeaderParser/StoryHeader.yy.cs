// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  ULKYOME-PC
// DateTime: 19.09.2023 11:38:17
// UserName: Ulkyome
// Input file <E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy - 18.08.2023 04:17:07>

// options: lines

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using LSLib.LS.Story.Compiler;

namespace LSLib.LS.Story.HeaderParser
{
public enum HeaderTokens {
    error=127,EOF=128,OPTION=129,TYPE=130,ALIAS_TYPE=131,SYSCALL=132,
    SYSQUERY=133,QUERY=134,CALL=135,EVENT=136,IN=137,OUT=138,
    BAD=139,IDENTIFIER=140,INTEGER=141};

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public partial class HeaderParser: ShiftReduceParser<LSLib.LS.Story.HeaderParser.ASTNode, LexLocation>
{
#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[28];
  private static State[] states = new State[68];
  private static string[] nonTerms = new string[] {
      "StoryHeaderFile", "$accept", "StoryHeader", "Declarations", "Declaration", 
      "Option", "Alias", "Function", "InOutFunctionType", "InOutFunctionParams", 
      "FunctionMetadata", "InFunctionType", "InFunctionParams", "InOutFunctionParam", 
      "InFunctionParam", };

  static HeaderParser() {
    states[0] = new State(-4,new int[]{-1,1,-3,3,-4,4});
    states[1] = new State(new int[]{128,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{129,7,131,10,133,50,134,51,132,65,135,66,136,67,128,-3},new int[]{-5,5,-6,6,-7,9,-8,18,-9,19,-12,52});
    states[5] = new State(-5);
    states[6] = new State(-6);
    states[7] = new State(new int[]{140,8});
    states[8] = new State(-9);
    states[9] = new State(-7);
    states[10] = new State(new int[]{123,11});
    states[11] = new State(new int[]{140,12});
    states[12] = new State(new int[]{44,13});
    states[13] = new State(new int[]{141,14});
    states[14] = new State(new int[]{44,15});
    states[15] = new State(new int[]{141,16});
    states[16] = new State(new int[]{125,17});
    states[17] = new State(-10);
    states[18] = new State(-8);
    states[19] = new State(new int[]{140,20});
    states[20] = new State(new int[]{40,21});
    states[21] = new State(new int[]{91,36,41,-19,44,-19},new int[]{-10,22,-14,49});
    states[22] = new State(new int[]{41,23,44,34});
    states[23] = new State(new int[]{40,25},new int[]{-11,24});
    states[24] = new State(-11);
    states[25] = new State(new int[]{141,26});
    states[26] = new State(new int[]{44,27});
    states[27] = new State(new int[]{141,28});
    states[28] = new State(new int[]{44,29});
    states[29] = new State(new int[]{141,30});
    states[30] = new State(new int[]{44,31});
    states[31] = new State(new int[]{141,32});
    states[32] = new State(new int[]{41,33});
    states[33] = new State(-13);
    states[34] = new State(new int[]{91,36},new int[]{-14,35});
    states[35] = new State(-21);
    states[36] = new State(new int[]{137,37,138,43});
    states[37] = new State(new int[]{93,38});
    states[38] = new State(new int[]{40,39});
    states[39] = new State(new int[]{140,40});
    states[40] = new State(new int[]{41,41});
    states[41] = new State(new int[]{140,42});
    states[42] = new State(-25);
    states[43] = new State(new int[]{93,44});
    states[44] = new State(new int[]{40,45});
    states[45] = new State(new int[]{140,46});
    states[46] = new State(new int[]{41,47});
    states[47] = new State(new int[]{140,48});
    states[48] = new State(-26);
    states[49] = new State(-20);
    states[50] = new State(-14);
    states[51] = new State(-15);
    states[52] = new State(new int[]{140,53});
    states[53] = new State(new int[]{40,54});
    states[54] = new State(new int[]{40,60,41,-22,44,-22},new int[]{-13,55,-15,64});
    states[55] = new State(new int[]{41,56,44,58});
    states[56] = new State(new int[]{40,25},new int[]{-11,57});
    states[57] = new State(-12);
    states[58] = new State(new int[]{40,60},new int[]{-15,59});
    states[59] = new State(-24);
    states[60] = new State(new int[]{140,61});
    states[61] = new State(new int[]{41,62});
    states[62] = new State(new int[]{140,63});
    states[63] = new State(-27);
    states[64] = new State(-23);
    states[65] = new State(-16);
    states[66] = new State(-17);
    states[67] = new State(-18);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-2, new int[]{-1,128});
    rules[2] = new Rule(-1, new int[]{-3});
    rules[3] = new Rule(-3, new int[]{-4});
    rules[4] = new Rule(-4, new int[]{});
    rules[5] = new Rule(-4, new int[]{-4,-5});
    rules[6] = new Rule(-5, new int[]{-6});
    rules[7] = new Rule(-5, new int[]{-7});
    rules[8] = new Rule(-5, new int[]{-8});
    rules[9] = new Rule(-6, new int[]{129,140});
    rules[10] = new Rule(-7, new int[]{131,123,140,44,141,44,141,125});
    rules[11] = new Rule(-8, new int[]{-9,140,40,-10,41,-11});
    rules[12] = new Rule(-8, new int[]{-12,140,40,-13,41,-11});
    rules[13] = new Rule(-11, new int[]{40,141,44,141,44,141,44,141,41});
    rules[14] = new Rule(-9, new int[]{133});
    rules[15] = new Rule(-9, new int[]{134});
    rules[16] = new Rule(-12, new int[]{132});
    rules[17] = new Rule(-12, new int[]{135});
    rules[18] = new Rule(-12, new int[]{136});
    rules[19] = new Rule(-10, new int[]{});
    rules[20] = new Rule(-10, new int[]{-14});
    rules[21] = new Rule(-10, new int[]{-10,44,-14});
    rules[22] = new Rule(-13, new int[]{});
    rules[23] = new Rule(-13, new int[]{-15});
    rules[24] = new Rule(-13, new int[]{-13,44,-15});
    rules[25] = new Rule(-14, new int[]{91,137,93,40,140,41,140});
    rules[26] = new Rule(-14, new int[]{91,138,93,40,140,41,140});
    rules[27] = new Rule(-15, new int[]{40,140,41,140});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)HeaderTokens.error, (int)HeaderTokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 4: // Declarations -> /* empty */
#line 37 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                           { CurrentSemanticValue = MakeDeclarationList(); }
#line default
        break;
      case 5: // Declarations -> Declarations, Declaration
#line 38 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                                        { CurrentSemanticValue = MakeDeclarationList(ValueStack[ValueStack.Depth-2], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 9: // Option -> OPTION, IDENTIFIER
#line 46 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                           { CurrentSemanticValue = MakeOption(ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 10: // Alias -> ALIAS_TYPE, '{', IDENTIFIER, ',', INTEGER, ',', INTEGER, '}'
#line 49 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
       { CurrentSemanticValue = MakeAlias(ValueStack[ValueStack.Depth-6], ValueStack[ValueStack.Depth-4], ValueStack[ValueStack.Depth-2]); }
#line default
        break;
      case 11: // Function -> InOutFunctionType, IDENTIFIER, '(', InOutFunctionParams, ')', 
               //             FunctionMetadata
#line 51 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                                                                                     { CurrentSemanticValue = MakeFunction(ValueStack[ValueStack.Depth-6], ValueStack[ValueStack.Depth-5], ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 12: // Function -> InFunctionType, IDENTIFIER, '(', InFunctionParams, ')', 
               //             FunctionMetadata
#line 52 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                                                                               { CurrentSemanticValue = MakeFunction(ValueStack[ValueStack.Depth-6], ValueStack[ValueStack.Depth-5], ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 13: // FunctionMetadata -> '(', INTEGER, ',', INTEGER, ',', INTEGER, ',', INTEGER, ')'
#line 56 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                 { CurrentSemanticValue = MakeFunctionMetadata(ValueStack[ValueStack.Depth-8], ValueStack[ValueStack.Depth-6], ValueStack[ValueStack.Depth-4], ValueStack[ValueStack.Depth-2]); }
#line default
        break;
      case 14: // InOutFunctionType -> SYSQUERY
#line 58 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                             { CurrentSemanticValue = MakeFunctionType(Compiler.FunctionType.SysQuery); }
#line default
        break;
      case 15: // InOutFunctionType -> QUERY
#line 59 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                          { CurrentSemanticValue = MakeFunctionType(Compiler.FunctionType.Query); }
#line default
        break;
      case 16: // InFunctionType -> SYSCALL
#line 62 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                         { CurrentSemanticValue = MakeFunctionType(Compiler.FunctionType.SysCall); }
#line default
        break;
      case 17: // InFunctionType -> CALL
#line 63 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                      { CurrentSemanticValue = MakeFunctionType(Compiler.FunctionType.Call); }
#line default
        break;
      case 18: // InFunctionType -> EVENT
#line 64 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                       { CurrentSemanticValue = MakeFunctionType(Compiler.FunctionType.Event); }
#line default
        break;
      case 19: // InOutFunctionParams -> /* empty */
#line 67 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                                  { CurrentSemanticValue = MakeFunctionParamList(); }
#line default
        break;
      case 20: // InOutFunctionParams -> InOutFunctionParam
#line 68 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                                         { CurrentSemanticValue = MakeFunctionParamList(ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 21: // InOutFunctionParams -> InOutFunctionParams, ',', InOutFunctionParam
#line 69 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                                                                 { CurrentSemanticValue = MakeFunctionParamList(ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 22: // InFunctionParams -> /* empty */
#line 72 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                               { CurrentSemanticValue = MakeFunctionParamList(); }
#line default
        break;
      case 23: // InFunctionParams -> InFunctionParam
#line 73 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                                   { CurrentSemanticValue = MakeFunctionParamList(ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 24: // InFunctionParams -> InFunctionParams, ',', InFunctionParam
#line 74 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                                                        { CurrentSemanticValue = MakeFunctionParamList(ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 25: // InOutFunctionParam -> '[', IN, ']', '(', IDENTIFIER, ')', IDENTIFIER
#line 77 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                                                              { CurrentSemanticValue = MakeParam(ParamDirection.In, ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 26: // InOutFunctionParam -> '[', OUT, ']', '(', IDENTIFIER, ')', IDENTIFIER
#line 78 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                                                               { CurrentSemanticValue = MakeParam(ParamDirection.Out, ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 27: // InFunctionParam -> '(', IDENTIFIER, ')', IDENTIFIER
#line 81 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\HeaderParser\StoryHeader.yy"
                                                { CurrentSemanticValue = MakeParam(ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((HeaderTokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((HeaderTokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

}
}
