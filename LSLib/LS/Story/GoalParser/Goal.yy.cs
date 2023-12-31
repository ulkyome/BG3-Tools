// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  ULKYOME-PC
// DateTime: 01.10.2023 05:08:00
// UserName: Ulkyome
// Input file <E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy - 18.09.2023 11:46:58>

// options: lines

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;

namespace LSLib.LS.Story.GoalParser
{
public enum GoalTokens {
    error=61,EOF=62,VERSION=63,SUBGOALCOMBINER=64,SGC_AND=65,INITSECTION=66,
    KBSECTION=67,EXITSECTION=68,ENDEXITSECTION=69,IF=70,PROC=71,QRY=72,
    THEN=73,AND=74,NOT=75,GOAL_COMPLETED=76,PARENT_TARGET_EDGE=77,EQ_OP=78,
    NE_OP=79,LT_OP=80,LTE_OP=81,GT_OP=82,GTE_OP=83,BAD=84,
    IDENTIFIER=85,LOCAL_VAR=86,INTEGER=87,FLOAT=88,STRING=89,GUIDSTRING=90};

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public partial class GoalParser: ShiftReduceParser<System.Object, LSLib.LS.Story.GoalParser.CodeLocation>
{
#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[72];
  private static State[] states = new State[144];
  private static string[] nonTerms = new string[] {
      "GoalFile", "$accept", "Goal", "Version", "SubGoalCombiner", "InitSection", 
      "KBSection", "ExitSection", "TargetEdges", "Facts", "Rules", "TargetEdge", 
      "Fact", "FactStatement", "FactElementList", "FactElement", "TypedConstant", 
      "Constant", "Rule", "RuleType", "Conditions", "ActionList", "InitialCondition", 
      "Condition", "FuncCondition", "NotFuncCondition", "BinaryCondition", "ConditionParamList", 
      "TypedLocalVar", "ConditionParam", "Operator", "Action", "ActionStatement", 
      "ActionParamList", "ActionParam", };

  static GoalParser() {
    states[0] = new State(new int[]{63,142},new int[]{-1,1,-3,3,-4,4});
    states[1] = new State(new int[]{62,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{64,140},new int[]{-5,5});
    states[5] = new State(new int[]{66,138},new int[]{-6,6});
    states[6] = new State(new int[]{67,40},new int[]{-7,7});
    states[7] = new State(new int[]{68,13},new int[]{-8,8});
    states[8] = new State(-9,new int[]{-9,9});
    states[9] = new State(new int[]{77,11,62,-3},new int[]{-12,10});
    states[10] = new State(-10);
    states[11] = new State(new int[]{89,12});
    states[12] = new State(-11);
    states[13] = new State(-12,new int[]{-10,14});
    states[14] = new State(new int[]{69,15,85,18,75,36,76,38},new int[]{-13,16,-14,17});
    states[15] = new State(-8);
    states[16] = new State(-13);
    states[17] = new State(-14);
    states[18] = new State(new int[]{40,19});
    states[19] = new State(new int[]{90,27,89,28,87,29,88,30,40,31,41,-18,44,-18},new int[]{-15,20,-16,35,-17,25,-18,26});
    states[20] = new State(new int[]{41,21,44,23});
    states[21] = new State(new int[]{59,22});
    states[22] = new State(-17);
    states[23] = new State(new int[]{90,27,89,28,87,29,88,30,40,31},new int[]{-16,24,-17,25,-18,26});
    states[24] = new State(-20);
    states[25] = new State(-21);
    states[26] = new State(-68);
    states[27] = new State(-22);
    states[28] = new State(-23);
    states[29] = new State(-24);
    states[30] = new State(-25);
    states[31] = new State(new int[]{85,32});
    states[32] = new State(new int[]{41,33});
    states[33] = new State(new int[]{90,27,89,28,87,29,88,30},new int[]{-18,34});
    states[34] = new State(-69);
    states[35] = new State(-19);
    states[36] = new State(new int[]{85,18},new int[]{-14,37});
    states[37] = new State(-15);
    states[38] = new State(new int[]{59,39});
    states[39] = new State(-16);
    states[40] = new State(-26,new int[]{-11,41});
    states[41] = new State(new int[]{70,135,71,136,72,137,68,-7},new int[]{-19,42,-20,43});
    states[42] = new State(-27);
    states[43] = new State(new int[]{85,92,86,62,40,71},new int[]{-21,44,-23,132,-25,133,-29,134});
    states[44] = new State(new int[]{73,45,74,89});
    states[45] = new State(-55,new int[]{-22,46});
    states[46] = new State(new int[]{85,49,86,62,40,71,75,74,76,87,70,-28,71,-28,72,-28,68,-28},new int[]{-32,47,-33,48,-29,64});
    states[47] = new State(-56);
    states[48] = new State(-57);
    states[49] = new State(new int[]{40,50});
    states[50] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62,41,-63,44,-63},new int[]{-34,51,-35,63,-17,56,-18,26,-29,61});
    states[51] = new State(new int[]{41,52,44,54});
    states[52] = new State(new int[]{59,53});
    states[53] = new State(-59);
    states[54] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62},new int[]{-35,55,-17,56,-18,26,-29,61});
    states[55] = new State(-65);
    states[56] = new State(-66);
    states[57] = new State(new int[]{85,58});
    states[58] = new State(new int[]{41,59});
    states[59] = new State(new int[]{86,60,90,27,89,28,87,29,88,30},new int[]{-18,34});
    states[60] = new State(-71);
    states[61] = new State(-67);
    states[62] = new State(-70);
    states[63] = new State(-64);
    states[64] = new State(new int[]{46,65});
    states[65] = new State(new int[]{85,66});
    states[66] = new State(new int[]{40,67});
    states[67] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62,41,-63,44,-63},new int[]{-34,68,-35,63,-17,56,-18,26,-29,61});
    states[68] = new State(new int[]{41,69,44,54});
    states[69] = new State(new int[]{59,70});
    states[70] = new State(-60);
    states[71] = new State(new int[]{85,72});
    states[72] = new State(new int[]{41,73});
    states[73] = new State(new int[]{86,60});
    states[74] = new State(new int[]{85,75,86,62,40,71},new int[]{-29,80});
    states[75] = new State(new int[]{40,76});
    states[76] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62,41,-63,44,-63},new int[]{-34,77,-35,63,-17,56,-18,26,-29,61});
    states[77] = new State(new int[]{41,78,44,54});
    states[78] = new State(new int[]{59,79});
    states[79] = new State(-61);
    states[80] = new State(new int[]{46,81});
    states[81] = new State(new int[]{85,82});
    states[82] = new State(new int[]{40,83});
    states[83] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62,41,-63,44,-63},new int[]{-34,84,-35,63,-17,56,-18,26,-29,61});
    states[84] = new State(new int[]{41,85,44,54});
    states[85] = new State(new int[]{59,86});
    states[86] = new State(-62);
    states[87] = new State(new int[]{59,88});
    states[88] = new State(-58);
    states[89] = new State(new int[]{85,92,86,62,40,57,75,108,90,27,89,28,87,29,88,30},new int[]{-24,90,-25,91,-29,101,-26,107,-27,128,-30,129,-17,98,-18,26});
    states[90] = new State(-33);
    states[91] = new State(-35);
    states[92] = new State(new int[]{40,93});
    states[93] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62,41,-44,44,-44},new int[]{-28,94,-30,100,-17,98,-18,26,-29,99});
    states[94] = new State(new int[]{41,95,44,96});
    states[95] = new State(-38);
    states[96] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62},new int[]{-30,97,-17,98,-18,26,-29,99});
    states[97] = new State(-46);
    states[98] = new State(-47);
    states[99] = new State(-48);
    states[100] = new State(-45);
    states[101] = new State(new int[]{46,102,78,-48,79,-48,80,-48,81,-48,82,-48,83,-48});
    states[102] = new State(new int[]{85,103});
    states[103] = new State(new int[]{40,104});
    states[104] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62,41,-44,44,-44},new int[]{-28,105,-30,100,-17,98,-18,26,-29,99});
    states[105] = new State(new int[]{41,106,44,96});
    states[106] = new State(-39);
    states[107] = new State(-36);
    states[108] = new State(new int[]{85,109,86,62,40,57,90,27,89,28,87,29,88,30},new int[]{-29,113,-30,119,-17,98,-18,26});
    states[109] = new State(new int[]{40,110});
    states[110] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62,41,-44,44,-44},new int[]{-28,111,-30,100,-17,98,-18,26,-29,99});
    states[111] = new State(new int[]{41,112,44,96});
    states[112] = new State(-40);
    states[113] = new State(new int[]{46,114,78,-48,79,-48,80,-48,81,-48,82,-48,83,-48});
    states[114] = new State(new int[]{85,115});
    states[115] = new State(new int[]{40,116});
    states[116] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62,41,-44,44,-44},new int[]{-28,117,-30,100,-17,98,-18,26,-29,99});
    states[117] = new State(new int[]{41,118,44,96});
    states[118] = new State(-41);
    states[119] = new State(new int[]{78,122,79,123,80,124,81,125,82,126,83,127},new int[]{-31,120});
    states[120] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62},new int[]{-30,121,-17,98,-18,26,-29,99});
    states[121] = new State(-43);
    states[122] = new State(-49);
    states[123] = new State(-50);
    states[124] = new State(-51);
    states[125] = new State(-52);
    states[126] = new State(-53);
    states[127] = new State(-54);
    states[128] = new State(-37);
    states[129] = new State(new int[]{78,122,79,123,80,124,81,125,82,126,83,127},new int[]{-31,130});
    states[130] = new State(new int[]{90,27,89,28,87,29,88,30,40,57,86,62},new int[]{-30,131,-17,98,-18,26,-29,99});
    states[131] = new State(-42);
    states[132] = new State(-32);
    states[133] = new State(-34);
    states[134] = new State(new int[]{46,102});
    states[135] = new State(-29);
    states[136] = new State(-30);
    states[137] = new State(-31);
    states[138] = new State(-12,new int[]{-10,139});
    states[139] = new State(new int[]{85,18,75,36,76,38,67,-6},new int[]{-13,16,-14,17});
    states[140] = new State(new int[]{65,141});
    states[141] = new State(-5);
    states[142] = new State(new int[]{87,143});
    states[143] = new State(-4);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-2, new int[]{-1,62});
    rules[2] = new Rule(-1, new int[]{-3});
    rules[3] = new Rule(-3, new int[]{-4,-5,-6,-7,-8,-9});
    rules[4] = new Rule(-4, new int[]{63,87});
    rules[5] = new Rule(-5, new int[]{64,65});
    rules[6] = new Rule(-6, new int[]{66,-10});
    rules[7] = new Rule(-7, new int[]{67,-11});
    rules[8] = new Rule(-8, new int[]{68,-10,69});
    rules[9] = new Rule(-9, new int[]{});
    rules[10] = new Rule(-9, new int[]{-9,-12});
    rules[11] = new Rule(-12, new int[]{77,89});
    rules[12] = new Rule(-10, new int[]{});
    rules[13] = new Rule(-10, new int[]{-10,-13});
    rules[14] = new Rule(-13, new int[]{-14});
    rules[15] = new Rule(-13, new int[]{75,-14});
    rules[16] = new Rule(-13, new int[]{76,59});
    rules[17] = new Rule(-14, new int[]{85,40,-15,41,59});
    rules[18] = new Rule(-15, new int[]{});
    rules[19] = new Rule(-15, new int[]{-16});
    rules[20] = new Rule(-15, new int[]{-15,44,-16});
    rules[21] = new Rule(-16, new int[]{-17});
    rules[22] = new Rule(-18, new int[]{90});
    rules[23] = new Rule(-18, new int[]{89});
    rules[24] = new Rule(-18, new int[]{87});
    rules[25] = new Rule(-18, new int[]{88});
    rules[26] = new Rule(-11, new int[]{});
    rules[27] = new Rule(-11, new int[]{-11,-19});
    rules[28] = new Rule(-19, new int[]{-20,-21,73,-22});
    rules[29] = new Rule(-20, new int[]{70});
    rules[30] = new Rule(-20, new int[]{71});
    rules[31] = new Rule(-20, new int[]{72});
    rules[32] = new Rule(-21, new int[]{-23});
    rules[33] = new Rule(-21, new int[]{-21,74,-24});
    rules[34] = new Rule(-23, new int[]{-25});
    rules[35] = new Rule(-24, new int[]{-25});
    rules[36] = new Rule(-24, new int[]{-26});
    rules[37] = new Rule(-24, new int[]{-27});
    rules[38] = new Rule(-25, new int[]{85,40,-28,41});
    rules[39] = new Rule(-25, new int[]{-29,46,85,40,-28,41});
    rules[40] = new Rule(-26, new int[]{75,85,40,-28,41});
    rules[41] = new Rule(-26, new int[]{75,-29,46,85,40,-28,41});
    rules[42] = new Rule(-27, new int[]{-30,-31,-30});
    rules[43] = new Rule(-27, new int[]{75,-30,-31,-30});
    rules[44] = new Rule(-28, new int[]{});
    rules[45] = new Rule(-28, new int[]{-30});
    rules[46] = new Rule(-28, new int[]{-28,44,-30});
    rules[47] = new Rule(-30, new int[]{-17});
    rules[48] = new Rule(-30, new int[]{-29});
    rules[49] = new Rule(-31, new int[]{78});
    rules[50] = new Rule(-31, new int[]{79});
    rules[51] = new Rule(-31, new int[]{80});
    rules[52] = new Rule(-31, new int[]{81});
    rules[53] = new Rule(-31, new int[]{82});
    rules[54] = new Rule(-31, new int[]{83});
    rules[55] = new Rule(-22, new int[]{});
    rules[56] = new Rule(-22, new int[]{-22,-32});
    rules[57] = new Rule(-32, new int[]{-33});
    rules[58] = new Rule(-32, new int[]{76,59});
    rules[59] = new Rule(-33, new int[]{85,40,-34,41,59});
    rules[60] = new Rule(-33, new int[]{-29,46,85,40,-34,41,59});
    rules[61] = new Rule(-33, new int[]{75,85,40,-34,41,59});
    rules[62] = new Rule(-33, new int[]{75,-29,46,85,40,-34,41,59});
    rules[63] = new Rule(-34, new int[]{});
    rules[64] = new Rule(-34, new int[]{-35});
    rules[65] = new Rule(-34, new int[]{-34,44,-35});
    rules[66] = new Rule(-35, new int[]{-17});
    rules[67] = new Rule(-35, new int[]{-29});
    rules[68] = new Rule(-17, new int[]{-18});
    rules[69] = new Rule(-17, new int[]{40,85,41,-18});
    rules[70] = new Rule(-29, new int[]{86});
    rules[71] = new Rule(-29, new int[]{40,85,41,86});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)GoalTokens.error, (int)GoalTokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 3: // Goal -> Version, SubGoalCombiner, InitSection, KBSection, ExitSection, 
              //         TargetEdges
#line 58 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
     { CurrentSemanticValue = MakeGoal(CurrentLocationSpan, ValueStack[ValueStack.Depth-6], ValueStack[ValueStack.Depth-5], ValueStack[ValueStack.Depth-4], ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-2], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 4: // Version -> VERSION, INTEGER
#line 61 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
    { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 5: // SubGoalCombiner -> SUBGOALCOMBINER, SGC_AND
#line 64 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
    { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 6: // InitSection -> INITSECTION, Facts
#line 67 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
    { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 7: // KBSection -> KBSECTION, Rules
#line 70 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
    { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 8: // ExitSection -> EXITSECTION, Facts, ENDEXITSECTION
#line 73 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
    { CurrentSemanticValue = ValueStack[ValueStack.Depth-2]; }
#line default
        break;
      case 9: // TargetEdges -> /* empty */
#line 75 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                          { CurrentSemanticValue = MakeParentTargetEdgeList(); }
#line default
        break;
      case 10: // TargetEdges -> TargetEdges, TargetEdge
#line 76 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                     { CurrentSemanticValue = MakeParentTargetEdgeList(ValueStack[ValueStack.Depth-2], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 11: // TargetEdge -> PARENT_TARGET_EDGE, STRING
#line 80 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
    { CurrentSemanticValue = MakeParentTargetEdge(CurrentLocationSpan, ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 12: // Facts -> /* empty */
#line 82 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                    { CurrentSemanticValue = MakeFactList(); }
#line default
        break;
      case 13: // Facts -> Facts, Fact
#line 83 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                   { CurrentSemanticValue = MakeFactList(ValueStack[ValueStack.Depth-2], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 14: // Fact -> FactStatement
#line 86 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                     { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 15: // Fact -> NOT, FactStatement
#line 87 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                         { CurrentSemanticValue = MakeNotFact(CurrentLocationSpan, ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 16: // Fact -> GOAL_COMPLETED, ';'
#line 88 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                          { CurrentSemanticValue = MakeGoalCompletedFact(CurrentLocationSpan); }
#line default
        break;
      case 17: // FactStatement -> IDENTIFIER, '(', FactElementList, ')', ';'
#line 92 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
    { CurrentSemanticValue = MakeFactStatement(CurrentLocationSpan, ValueStack[ValueStack.Depth-5], ValueStack[ValueStack.Depth-3]); }
#line default
        break;
      case 18: // FactElementList -> /* empty */
#line 94 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                              { CurrentSemanticValue = MakeFactElementList(); }
#line default
        break;
      case 19: // FactElementList -> FactElement
#line 95 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                              { CurrentSemanticValue = MakeFactElementList(ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 20: // FactElementList -> FactElementList, ',', FactElement
#line 96 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                  { CurrentSemanticValue = MakeFactElementList(ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 21: // FactElement -> TypedConstant
#line 100 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
    { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 22: // Constant -> GUIDSTRING
#line 102 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                      { CurrentSemanticValue = MakeConstGuidString(CurrentLocationSpan, ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 23: // Constant -> STRING
#line 103 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                  { CurrentSemanticValue = MakeConstString(CurrentLocationSpan, ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 24: // Constant -> INTEGER
#line 104 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                   { CurrentSemanticValue = MakeConstInteger(CurrentLocationSpan, ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 25: // Constant -> FLOAT
#line 105 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                 { CurrentSemanticValue = MakeConstFloat(CurrentLocationSpan, ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 26: // Rules -> /* empty */
#line 108 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                    { CurrentSemanticValue = MakeRuleList(); }
#line default
        break;
      case 27: // Rules -> Rules, Rule
#line 109 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                   { CurrentSemanticValue = MakeRuleList(ValueStack[ValueStack.Depth-2], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 28: // Rule -> RuleType, Conditions, THEN, ActionList
#line 113 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
    { CurrentSemanticValue = MakeRule(CurrentLocationSpan, ValueStack[ValueStack.Depth-4], ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 29: // RuleType -> IF
#line 115 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
              { CurrentSemanticValue = MakeRuleType(RuleType.Rule); }
#line default
        break;
      case 30: // RuleType -> PROC
#line 116 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                { CurrentSemanticValue = MakeRuleType(RuleType.Proc); }
#line default
        break;
      case 31: // RuleType -> QRY
#line 117 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
               { CurrentSemanticValue = MakeRuleType(RuleType.Query); }
#line default
        break;
      case 32: // Conditions -> InitialCondition
#line 120 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                              { CurrentSemanticValue = MakeConditionList(ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 33: // Conditions -> Conditions, AND, Condition
#line 121 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                      { CurrentSemanticValue = MakeConditionList(ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 38: // FuncCondition -> IDENTIFIER, '(', ConditionParamList, ')'
#line 131 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                      { CurrentSemanticValue = MakeFuncCondition(CurrentLocationSpan, ValueStack[ValueStack.Depth-4], ValueStack[ValueStack.Depth-2], false); }
#line default
        break;
      case 39: // FuncCondition -> TypedLocalVar, '.', IDENTIFIER, '(', ConditionParamList, ')'
#line 132 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                                        { CurrentSemanticValue = MakeObjectFuncCondition(CurrentLocationSpan, ValueStack[ValueStack.Depth-6], ValueStack[ValueStack.Depth-4], ValueStack[ValueStack.Depth-2], false); }
#line default
        break;
      case 40: // NotFuncCondition -> NOT, IDENTIFIER, '(', ConditionParamList, ')'
#line 135 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                             { CurrentSemanticValue = MakeFuncCondition(CurrentLocationSpan, ValueStack[ValueStack.Depth-4], ValueStack[ValueStack.Depth-2], true); }
#line default
        break;
      case 41: // NotFuncCondition -> NOT, TypedLocalVar, '.', IDENTIFIER, '(', 
               //                     ConditionParamList, ')'
#line 136 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                                               { CurrentSemanticValue = MakeObjectFuncCondition(CurrentLocationSpan, ValueStack[ValueStack.Depth-6], ValueStack[ValueStack.Depth-4], ValueStack[ValueStack.Depth-2], true); }
#line default
        break;
      case 42: // BinaryCondition -> ConditionParam, Operator, ConditionParam
#line 139 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                         { CurrentSemanticValue = MakeBinaryCondition(CurrentLocationSpan, ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-2], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 43: // BinaryCondition -> NOT, ConditionParam, Operator, ConditionParam
#line 140 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                             { CurrentSemanticValue = MakeNegatedBinaryCondition(CurrentLocationSpan, ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-2], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 44: // ConditionParamList -> /* empty */
#line 143 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                 { CurrentSemanticValue = MakeConditionParamList(); }
#line default
        break;
      case 45: // ConditionParamList -> ConditionParam
#line 144 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                    { CurrentSemanticValue = MakeConditionParamList(ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 46: // ConditionParamList -> ConditionParamList, ',', ConditionParam
#line 145 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                           { CurrentSemanticValue = MakeConditionParamList(ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 47: // ConditionParam -> TypedConstant
#line 148 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                               { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 48: // ConditionParam -> TypedLocalVar
#line 149 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                               { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 49: // Operator -> EQ_OP
#line 152 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                 { CurrentSemanticValue = MakeOperator(RelOpType.Equal); }
#line default
        break;
      case 50: // Operator -> NE_OP
#line 153 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                 { CurrentSemanticValue = MakeOperator(RelOpType.NotEqual); }
#line default
        break;
      case 51: // Operator -> LT_OP
#line 154 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                 { CurrentSemanticValue = MakeOperator(RelOpType.Less); }
#line default
        break;
      case 52: // Operator -> LTE_OP
#line 155 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                  { CurrentSemanticValue = MakeOperator(RelOpType.LessOrEqual); }
#line default
        break;
      case 53: // Operator -> GT_OP
#line 156 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                 { CurrentSemanticValue = MakeOperator(RelOpType.Greater); }
#line default
        break;
      case 54: // Operator -> GTE_OP
#line 157 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                  { CurrentSemanticValue = MakeOperator(RelOpType.GreaterOrEqual); }
#line default
        break;
      case 55: // ActionList -> /* empty */
#line 160 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                         { CurrentSemanticValue = MakeActionList(); }
#line default
        break;
      case 56: // ActionList -> ActionList, Action
#line 161 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                               { CurrentSemanticValue = MakeActionList(ValueStack[ValueStack.Depth-2], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 57: // Action -> ActionStatement
#line 164 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                         { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 58: // Action -> GOAL_COMPLETED, ';'
#line 165 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                            { CurrentSemanticValue = MakeGoalCompletedAction(CurrentLocationSpan); }
#line default
        break;
      case 59: // ActionStatement -> IDENTIFIER, '(', ActionParamList, ')', ';'
#line 168 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                         { CurrentSemanticValue = MakeActionStatement(CurrentLocationSpan, ValueStack[ValueStack.Depth-5], ValueStack[ValueStack.Depth-3], false); }
#line default
        break;
      case 60: // ActionStatement -> TypedLocalVar, '.', IDENTIFIER, '(', ActionParamList, ')', 
               //                    ';'
#line 169 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                                           { CurrentSemanticValue = MakeActionStatement(CurrentLocationSpan, ValueStack[ValueStack.Depth-7], ValueStack[ValueStack.Depth-5], ValueStack[ValueStack.Depth-3], false); }
#line default
        break;
      case 61: // ActionStatement -> NOT, IDENTIFIER, '(', ActionParamList, ')', ';'
#line 170 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                             { CurrentSemanticValue = MakeActionStatement(CurrentLocationSpan, ValueStack[ValueStack.Depth-5], ValueStack[ValueStack.Depth-3], true); }
#line default
        break;
      case 62: // ActionStatement -> NOT, TypedLocalVar, '.', IDENTIFIER, '(', ActionParamList, 
               //                    ')', ';'
#line 171 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                                               { CurrentSemanticValue = MakeActionStatement(CurrentLocationSpan, ValueStack[ValueStack.Depth-7], ValueStack[ValueStack.Depth-5], ValueStack[ValueStack.Depth-3], true); }
#line default
        break;
      case 63: // ActionParamList -> /* empty */
#line 174 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                              { CurrentSemanticValue = MakeActionParamList(); }
#line default
        break;
      case 64: // ActionParamList -> ActionParam
#line 175 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                              { CurrentSemanticValue = MakeActionParamList(ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 65: // ActionParamList -> ActionParamList, ',', ActionParam
#line 176 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                                  { CurrentSemanticValue = MakeActionParamList(ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 66: // ActionParam -> TypedConstant
#line 179 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                            { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 67: // ActionParam -> TypedLocalVar
#line 180 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                            { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 68: // TypedConstant -> Constant
#line 183 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                         { CurrentSemanticValue = ValueStack[ValueStack.Depth-1]; }
#line default
        break;
      case 69: // TypedConstant -> '(', IDENTIFIER, ')', Constant
#line 184 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                            { CurrentSemanticValue = MakeTypedConstant(CurrentLocationSpan, ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 70: // TypedLocalVar -> LOCAL_VAR
#line 187 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                          { CurrentSemanticValue = MakeLocalVar(CurrentLocationSpan, ValueStack[ValueStack.Depth-1]); }
#line default
        break;
      case 71: // TypedLocalVar -> '(', IDENTIFIER, ')', LOCAL_VAR
#line 188 "E:\source\repos\BG3_Tran\LSLib\\LS\Story\GoalParser\Goal.yy"
                                             { CurrentSemanticValue = MakeLocalVar(CurrentLocationSpan, ValueStack[ValueStack.Depth-3], ValueStack[ValueStack.Depth-1]); }
#line default
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((GoalTokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((GoalTokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

}
}
