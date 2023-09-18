%{
    double[] regs = new double[26];
    StringBuilder buffer = null;
%}

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

%union { public double dVal; 
         public char cVal; 
         public int iVal; }

%token <cVal> DIGIT 
%token <iVal> LETTER
%type <dVal> expr

%left '+' '-'
%left '*' '/'
%left UMINUS

%%

list    :   /*empty */
        |   list stat '\n'
        |   list error '\n'
                {
                    yyerrok();
                }
        ;

stat    :   expr
                {
                    System.Console.WriteLine($1);
                }
        |   LETTER '=' expr
                {
                    regs[$1] = $3;
                }
        ;

expr    :   '(' expr ')'
                {
                    $$ = $2;
                }
        |   expr '*' expr
                {
                    $$ = $1 * $3;
                }
        |   expr '/' expr
                {
                    $$ = $1 / $3;
                }
        |   expr '+' expr
                {
                    $$ = $1 + $3;
                }
        |   expr '-' expr
                {
                    $$ = $1 - $3;
                }
        |   '-' expr %prec UMINUS
                {
                    $$ = -$2;
                }
        |   LETTER
                {
                    $$ = regs[$1];
                }
        |   number
                {
                    try {
                        $$ = double.Parse(buffer.ToString());
                    } catch (FormatException) {
                        Scanner.yyerror("Illegal number \"{0}\"", buffer);
                    }
                }
        ;

number  :   DIGIT  
               { 
                   buffer = new StringBuilder();
                   buffer.Append($1);
               }
        |   number DIGIT
               { 
                   buffer.Append($2);
               }
        |   number '.' DIGIT
               { 
                   buffer.Append('.');
                   buffer.Append($3);
               }
        ;

%%

/* 
 * GPPG does not create a default parser constructor
 * Most applications will have a parser type with other
 * fields such as error handlers etc.  Here is a minimal
 * version that just adds the default scanner object.
 */
Parser(Lexer s) : base(s) { }

static void Main(string[] args)
{    
    System.IO.TextReader reader;
    if (args.Length > 0)
        reader = new System.IO.StreamReader(args[0]);
    else
        reader = System.Console.In;
        
    Parser parser = new Parser( new Lexer( reader ));
    //parser.Trace = true;
    
    Console.WriteLine("RealCalc expression evaluator, type ^C to exit");
    parser.Parse();
}

/*
 *  Version for real arithmetic.  YYSTYPE is ValueType.
 */
class Lexer: QUT.Gppg.AbstractScanner<ValueType, LexLocation>
{
     private System.IO.TextReader reader;

     public Lexer(System.IO.TextReader reader)
     {
         this.reader = reader;
     }

     public override int yylex()
     {
         char ch;
         int ord = reader.Read();
         //
         // Must check for EOF
         //
         if (ord == -1)
             return (int)Tokens.EOF;
         else
             ch = (char)ord;

         if (ch == '\n')
            return ch;
         else if (char.IsWhiteSpace(ch))
             return yylex();
         else if (char.IsDigit(ch))
         {
             yylval.cVal = ch;
             return (int)Tokens.DIGIT;
         }
         else if ((ch >= 'a' && ch <= 'z') ||
                  (ch >= 'A' && ch <= 'Z'))
         {
            yylval.iVal = char.ToLower(ch) - 'a';
            return (int)Tokens.LETTER;
         }
         else
             switch (ch)
             {
                 case '.':
                 case '+':
                 case '-':
                 case '*':
                 case '/':
                 case '(':
                 case ')':
                 case '%':
                 case '=':
                     return ch;
                 default:
                     Console.Error.WriteLine("Illegal character '{0}'", ch);
                     return yylex();
             }
     }

     public override void yyerror(string format, params object[] args)
     {
         Console.Error.WriteLine(format, args);
     }
}
