/*
 *  This specification is for a version of the RealCalc example.
 *  This version creates a abstract syntax tree from the input,
 *  and demonstrates how to use a reference type as the semantic
 *  value type.
 *
 *  The parser class is declared %partial, so that the bulk of
 *  the code can be placed in the separate file RealTreeHelper.cs
 *
 *  Process with > gppg /nolines RealTree.y
 */

%namespace RealTree
%output=RealTreeParser.cs 
%partial 
%sharetokens
%start list

/*
 * The accessibility of the Parser object must not exceed that
 * of the inherited ShiftReduceParser<,>. Thus if you want to include 
 * the *source* of ShiftReduceParser from ShiftReduceParserCode.cs, 
 * then you must either set the compilation flag EXPORT_GPPG or  
 * override the default, public visibility with %visibility internal.
 * If you reference the pre-compiled QUT.ShiftReduceParser.dll then 
 * ShiftReduceParser<> is public and either visibility will work.
 */

%visibility internal

%YYSTYPE RealTree.Node

%token LITERAL  
%token LETTER
%token PRINT
%token EVAL
%token RESET
%token EXIT
%token HELP
%token EOL

%left '+' '-'
%left '*' '/' '%'
%left UMINUS

%%

list    :   /*empty */
        |   list stat EOL
        |   list error EOL    { yyerrok(); }
        ;

stat
	: /* empty */
	| HELP				{ this.PrintHelp(); }
	| RESET				{ this.ClearRegisters(); }
	| PRINT				{ this.PrintRegisters(); }
	| EXIT				{ this.CallExit(); }
	| EVAL expr			{ this.Display($2); }
	| LITERAL			{ $$ = $1; }
	| LETTER '=' expr	{ this.AssignExpression($1, $3); }
	;

expr
	: '(' expr ')'		{ $$ = $2; }
	|  EVAL'(' expr ')' { $$ = MakeConstLeaf(Eval($3)); }
    |  expr '*' expr	{ $$ = MakeBinary(NodeTag.mul, $1, $3); }
	|  expr '/' expr	{ $$ = MakeBinary(NodeTag.div, $1, $3); }
	|  expr '%' expr	{ $$ = MakeBinary(NodeTag.rem, $1, $3); }
	|  expr '+' expr	{ $$ = MakeBinary(NodeTag.plus, $1, $3); }
	|  expr '-' expr	{ $$ = MakeBinary(NodeTag.minus, $1, $3); }
	|  LETTER           // $$ is automatically lexer.yylval
	|  LITERAL          // $$ is automatically lexer.yylval
	|  '-' expr %prec UMINUS {
				$$ = MakeUnary(NodeTag.negate, $2);
			}
	;

%%
/*
 * All the code is in the helper file RealTreeHelper.cs
 */ 

