/* A Bison parser, made by GNU Bison 2.5.  */

/* Bison implementation for Yacc-like parsers in C
   
      Copyright (C) 1984, 1989-1990, 2000-2011 Free Software Foundation, Inc.
   
   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.
   
   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.
   
   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.  */

/* As a special exception, you may create a larger work that contains
   part or all of the Bison parser skeleton and distribute that work
   under terms of your choice, so long as that work isn't itself a
   parser generator using the skeleton or a modified version thereof
   as a parser skeleton.  Alternatively, if you modify or redistribute
   the parser skeleton itself, you may (at your option) remove this
   special exception, which will cause the skeleton and the resulting
   Bison output files to be licensed under the GNU General Public
   License without this special exception.
   
   This special exception was added by the Free Software Foundation in
   version 2.2 of Bison.  */

/* C LALR(1) parser skeleton written by Richard Stallman, by
   simplifying the original so-called "semantic" parser.  */

/* All symbols defined below should begin with yy or YY, to avoid
   infringing on user name space.  This should be done even for local
   variables, as they might otherwise be expanded by user macros.
   There are some unavoidable exceptions within include files to
   define necessary library symbols; they are noted "INFRINGES ON
   USER NAME SPACE" below.  */

/* Identify Bison output.  */
#define YYBISON 1

/* Bison version.  */
#define YYBISON_VERSION "2.5"

/* Skeleton name.  */
#define YYSKELETON_NAME "yacc.c"

/* Pure parsers.  */
#define YYPURE 0

/* Push parsers.  */
#define YYPUSH 0

/* Pull parsers.  */
#define YYPULL 1

/* Using locations.  */
#define YYLSP_NEEDED 0



/* Copy the first part of user declarations.  */

/* Line 268 of yacc.c  */
#line 1 "grammar.y"

#define YYLEX_PARAM yystate


/* Line 268 of yacc.c  */
#line 76 "grammar.tab.c"

/* Enabling traces.  */
#ifndef YYDEBUG
# define YYDEBUG 0
#endif

/* Enabling verbose error messages.  */
#ifdef YYERROR_VERBOSE
# undef YYERROR_VERBOSE
# define YYERROR_VERBOSE 1
#else
# define YYERROR_VERBOSE 0
#endif

/* Enabling the token table.  */
#ifndef YYTOKEN_TABLE
# define YYTOKEN_TABLE 1
#endif


/* Tokens.  */
#ifndef YYTOKENTYPE
# define YYTOKENTYPE
   /* Put the tokens into the symbol table, so that GDB and other debuggers
      know about them.  */
   enum yytokentype {
     ID = 258,
     QSTRING = 259,
     SQSTRING = 260,
     INT32 = 261,
     INT64 = 262,
     FLOAT64 = 263,
     DOTTEDNAME = 264,
     HEXBYTE = 265,
     P_LINE = 266,
     INSTR_PHI = 267,
     INSTR_RVA = 268,
     INSTR_BRTARGET = 269,
     INSTR_FIELD = 270,
     INSTR_I = 271,
     INSTR_I8 = 272,
     INSTR_METHOD = 273,
     INSTR_NONE = 274,
     INSTR_R = 275,
     INSTR_SIG = 276,
     INSTR_STRING = 277,
     INSTR_SWITCH = 278,
     INSTR_TOK = 279,
     INSTR_TYPE = 280,
     INSTR_VAR = 281
   };
#endif



#if ! defined YYSTYPE && ! defined YYSTYPE_IS_DECLARED
typedef int YYSTYPE;
# define YYSTYPE_IS_TRIVIAL 1
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
#endif


/* Copy the second part of user declarations.  */


/* Line 343 of yacc.c  */
#line 144 "grammar.tab.c"

#ifdef short
# undef short
#endif

#ifdef YYTYPE_UINT8
typedef YYTYPE_UINT8 yytype_uint8;
#else
typedef unsigned char yytype_uint8;
#endif

#ifdef YYTYPE_INT8
typedef YYTYPE_INT8 yytype_int8;
#elif (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
typedef signed char yytype_int8;
#else
typedef short int yytype_int8;
#endif

#ifdef YYTYPE_UINT16
typedef YYTYPE_UINT16 yytype_uint16;
#else
typedef unsigned short int yytype_uint16;
#endif

#ifdef YYTYPE_INT16
typedef YYTYPE_INT16 yytype_int16;
#else
typedef short int yytype_int16;
#endif

#ifndef YYSIZE_T
# ifdef __SIZE_TYPE__
#  define YYSIZE_T __SIZE_TYPE__
# elif defined size_t
#  define YYSIZE_T size_t
# elif ! defined YYSIZE_T && (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
#  include <stddef.h> /* INFRINGES ON USER NAME SPACE */
#  define YYSIZE_T size_t
# else
#  define YYSIZE_T unsigned int
# endif
#endif

#define YYSIZE_MAXIMUM ((YYSIZE_T) -1)

#ifndef YY_
# if defined YYENABLE_NLS && YYENABLE_NLS
#  if ENABLE_NLS
#   include <libintl.h> /* INFRINGES ON USER NAME SPACE */
#   define YY_(msgid) dgettext ("bison-runtime", msgid)
#  endif
# endif
# ifndef YY_
#  define YY_(msgid) msgid
# endif
#endif

/* Suppress unused-variable warnings by "using" E.  */
#if ! defined lint || defined __GNUC__
# define YYUSE(e) ((void) (e))
#else
# define YYUSE(e) /* empty */
#endif

/* Identity function, used to suppress warnings about constant conditions.  */
#ifndef lint
# define YYID(n) (n)
#else
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static int
YYID (int yyi)
#else
static int
YYID (yyi)
    int yyi;
#endif
{
  return yyi;
}
#endif

#if ! defined yyoverflow || YYERROR_VERBOSE

/* The parser invokes alloca or malloc; define the necessary symbols.  */

# ifdef YYSTACK_USE_ALLOCA
#  if YYSTACK_USE_ALLOCA
#   ifdef __GNUC__
#    define YYSTACK_ALLOC __builtin_alloca
#   elif defined __BUILTIN_VA_ARG_INCR
#    include <alloca.h> /* INFRINGES ON USER NAME SPACE */
#   elif defined _AIX
#    define YYSTACK_ALLOC __alloca
#   elif defined _MSC_VER
#    include <malloc.h> /* INFRINGES ON USER NAME SPACE */
#    define alloca _alloca
#   else
#    define YYSTACK_ALLOC alloca
#    if ! defined _ALLOCA_H && ! defined EXIT_SUCCESS && (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
#     include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
#     ifndef EXIT_SUCCESS
#      define EXIT_SUCCESS 0
#     endif
#    endif
#   endif
#  endif
# endif

# ifdef YYSTACK_ALLOC
   /* Pacify GCC's `empty if-body' warning.  */
#  define YYSTACK_FREE(Ptr) do { /* empty */; } while (YYID (0))
#  ifndef YYSTACK_ALLOC_MAXIMUM
    /* The OS might guarantee only one guard page at the bottom of the stack,
       and a page size can be as small as 4096 bytes.  So we cannot safely
       invoke alloca (N) if N exceeds 4096.  Use a slightly smaller number
       to allow for a few compiler-allocated temporary stack slots.  */
#   define YYSTACK_ALLOC_MAXIMUM 4032 /* reasonable circa 2006 */
#  endif
# else
#  define YYSTACK_ALLOC YYMALLOC
#  define YYSTACK_FREE YYFREE
#  ifndef YYSTACK_ALLOC_MAXIMUM
#   define YYSTACK_ALLOC_MAXIMUM YYSIZE_MAXIMUM
#  endif
#  if (defined __cplusplus && ! defined EXIT_SUCCESS \
       && ! ((defined YYMALLOC || defined malloc) \
	     && (defined YYFREE || defined free)))
#   include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
#   ifndef EXIT_SUCCESS
#    define EXIT_SUCCESS 0
#   endif
#  endif
#  ifndef YYMALLOC
#   define YYMALLOC malloc
#   if ! defined malloc && ! defined EXIT_SUCCESS && (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
void *malloc (YYSIZE_T); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
#  ifndef YYFREE
#   define YYFREE free
#   if ! defined free && ! defined EXIT_SUCCESS && (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
void free (void *); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
# endif
#endif /* ! defined yyoverflow || YYERROR_VERBOSE */


#if (! defined yyoverflow \
     && (! defined __cplusplus \
	 || (defined YYSTYPE_IS_TRIVIAL && YYSTYPE_IS_TRIVIAL)))

/* A type that is properly aligned for any stack member.  */
union yyalloc
{
  yytype_int16 yyss_alloc;
  YYSTYPE yyvs_alloc;
};

/* The size of the maximum gap between one aligned stack and the next.  */
# define YYSTACK_GAP_MAXIMUM (sizeof (union yyalloc) - 1)

/* The size of an array large to enough to hold all stacks, each with
   N elements.  */
# define YYSTACK_BYTES(N) \
     ((N) * (sizeof (yytype_int16) + sizeof (YYSTYPE)) \
      + YYSTACK_GAP_MAXIMUM)

# define YYCOPY_NEEDED 1

/* Relocate STACK from its old location to the new one.  The
   local variables YYSIZE and YYSTACKSIZE give the old and new number of
   elements in the stack, and YYPTR gives the new location of the
   stack.  Advance YYPTR to a properly aligned location for the next
   stack.  */
# define YYSTACK_RELOCATE(Stack_alloc, Stack)				\
    do									\
      {									\
	YYSIZE_T yynewbytes;						\
	YYCOPY (&yyptr->Stack_alloc, Stack, yysize);			\
	Stack = &yyptr->Stack_alloc;					\
	yynewbytes = yystacksize * sizeof (*Stack) + YYSTACK_GAP_MAXIMUM; \
	yyptr += yynewbytes / sizeof (*yyptr);				\
      }									\
    while (YYID (0))

#endif

#if defined YYCOPY_NEEDED && YYCOPY_NEEDED
/* Copy COUNT objects from FROM to TO.  The source and destination do
   not overlap.  */
# ifndef YYCOPY
#  if defined __GNUC__ && 1 < __GNUC__
#   define YYCOPY(To, From, Count) \
      __builtin_memcpy (To, From, (Count) * sizeof (*(From)))
#  else
#   define YYCOPY(To, From, Count)		\
      do					\
	{					\
	  YYSIZE_T yyi;				\
	  for (yyi = 0; yyi < (Count); yyi++)	\
	    (To)[yyi] = (From)[yyi];		\
	}					\
      while (YYID (0))
#  endif
# endif
#endif /* !YYCOPY_NEEDED */

/* YYFINAL -- State number of the termination state.  */
#define YYFINAL  3
/* YYLAST -- Last index in YYTABLE.  */
#define YYLAST   2243

/* YYNTOKENS -- Number of terminals.  */
#define YYNTOKENS  251
/* YYNNTS -- Number of nonterminals.  */
#define YYNNTS  128
/* YYNRULES -- Number of rules.  */
#define YYNRULES  603
/* YYNRULES -- Number of states.  */
#define YYNSTATES  1125

/* YYTRANSLATE(YYLEX) -- Bison symbol number corresponding to YYLEX.  */
#define YYUNDEFTOK  2
#define YYMAXUTOK   490

#define YYTRANSLATE(YYX)						\
  ((unsigned int) (YYX) <= YYMAXUTOK ? yytranslate[YYX] : YYUNDEFTOK)

/* YYTRANSLATE[YYLEX] -- Bison symbol number corresponding to YYLEX.  */
static const yytype_uint8 yytranslate[] =
{
       0,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,   216,     2,     2,     2,     2,   153,     2,
      40,    39,   152,    34,    36,     2,   163,   164,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,   138,     2,
       2,    38,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,    44,     2,    45,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,    27,     2,    28,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     1,     2,     3,     4,
       5,     6,     7,     8,     9,    10,    11,    12,    13,    14,
      15,    16,    17,    18,    19,    20,    21,    22,    23,    24,
      25,    26,    29,    30,    31,    32,    33,    35,    37,    41,
      42,    43,    46,    47,    48,    49,    50,    51,    52,    53,
      54,    55,    56,    57,    58,    59,    60,    61,    62,    63,
      64,    65,    66,    67,    68,    69,    70,    71,    72,    73,
      74,    75,    76,    77,    78,    79,    80,    81,    82,    83,
      84,    85,    86,    87,    88,    89,    90,    91,    92,    93,
      94,    95,    96,    97,    98,    99,   100,   101,   102,   103,
     104,   105,   106,   107,   108,   109,   110,   111,   112,   113,
     114,   115,   116,   117,   118,   119,   120,   121,   122,   123,
     124,   125,   126,   127,   128,   129,   130,   131,   132,   133,
     134,   135,   136,   137,   139,   140,   141,   142,   143,   144,
     145,   146,   147,   148,   149,   150,   151,   154,   155,   156,
     157,   158,   159,   160,   161,   162,   165,   166,   167,   168,
     169,   170,   171,   172,   173,   174,   175,   176,   177,   178,
     179,   180,   181,   182,   183,   184,   185,   186,   187,   188,
     189,   190,   191,   192,   193,   194,   195,   196,   197,   198,
     199,   200,   201,   202,   203,   204,   205,   206,   207,   208,
     209,   210,   211,   212,   213,   214,   215,   217,   218,   219,
     220,   221,   222,   223,   224,   225,   226,   227,   228,   229,
     230,   231,   232,   233,   234,   235,   236,   237,   238,   239,
     240,   241,   242,   243,   244,   245,   246,   247,   248,   249,
     250
};

#if YYDEBUG
/* YYPRHS[YYN] -- Index of the first RHS symbol of rule number YYN in
   YYRHS.  */
static const yytype_uint16 yyprhs[] =
{
       0,     0,     3,     5,     6,     9,    14,    19,    23,    25,
      27,    29,    31,    33,    35,    40,    45,    50,    55,    57,
      59,    61,    64,    67,    71,    74,    76,    78,    82,    85,
      90,    97,   100,   105,   109,   115,   123,   127,   129,   132,
     136,   144,   145,   148,   151,   154,   157,   161,   165,   168,
     174,   175,   178,   181,   184,   187,   190,   193,   196,   199,
     202,   205,   208,   211,   214,   217,   220,   224,   228,   232,
     236,   240,   244,   247,   250,   253,   254,   257,   258,   261,
     265,   267,   268,   271,   275,   280,   285,   290,   292,   294,
     296,   298,   300,   303,   306,   311,   325,   327,   335,   336,
     339,   340,   343,   344,   348,   353,   361,   371,   379,   385,
     389,   398,   405,   407,   409,   414,   418,   419,   422,   425,
     426,   429,   439,   447,   457,   465,   475,   483,   493,   501,
     503,   505,   507,   517,   518,   521,   524,   525,   528,   538,
     546,   556,   564,   574,   582,   584,   586,   588,   590,   602,
     618,   619,   622,   625,   628,   631,   634,   637,   640,   643,
     646,   649,   652,   655,   658,   661,   664,   667,   670,   679,
     686,   692,   693,   696,   699,   702,   705,   708,   711,   714,
     717,   720,   723,   725,   727,   729,   730,   735,   740,   745,
     750,   751,   754,   757,   760,   763,   766,   769,   772,   778,
     781,   784,   787,   790,   793,   796,   797,   800,   803,   806,
     809,   812,   815,   818,   821,   824,   827,   830,   832,   835,
     837,   840,   845,   851,   853,   855,   857,   859,   862,   864,
     866,   868,   870,   875,   882,   887,   892,   894,   900,   904,
     906,   909,   912,   914,   917,   922,   927,   929,   932,   935,
     938,   941,   944,   947,   950,   952,   955,   957,   959,   961,
     966,   971,   972,   975,   978,   983,   986,   987,   989,   993,
     995,   999,  1001,  1002,  1006,  1012,  1017,  1021,  1027,  1033,
    1039,  1045,  1051,  1057,  1060,  1063,  1066,  1069,  1072,  1075,
    1080,  1085,  1090,  1095,  1100,  1105,  1110,  1115,  1120,  1125,
    1127,  1131,  1133,  1136,  1137,  1139,  1141,  1144,  1147,  1149,
    1151,  1153,  1156,  1159,  1162,  1165,  1168,  1171,  1175,  1178,
    1181,  1191,  1199,  1205,  1209,  1212,  1215,  1220,  1227,  1230,
    1233,  1236,  1241,  1244,  1245,  1247,  1249,  1253,  1255,  1258,
    1262,  1269,  1277,  1279,  1281,  1285,  1290,  1296,  1298,  1300,
    1304,  1306,  1310,  1315,  1317,  1320,  1323,  1325,  1326,  1328,
    1330,  1333,  1336,  1339,  1342,  1343,  1354,  1361,  1367,  1373,
    1375,  1377,  1379,  1381,  1383,  1385,  1387,  1389,  1391,  1393,
    1395,  1397,  1400,  1403,  1406,  1409,  1412,  1416,  1421,  1428,
    1434,  1436,  1438,  1440,  1442,  1444,  1446,  1448,  1450,  1452,
    1454,  1456,  1459,  1464,  1466,  1469,  1472,  1474,  1477,  1479,
    1482,  1484,  1487,  1489,  1490,  1492,  1494,  1496,  1498,  1500,
    1502,  1504,  1506,  1508,  1510,  1512,  1515,  1518,  1521,  1524,
    1526,  1530,  1533,  1536,  1538,  1540,  1542,  1544,  1546,  1548,
    1550,  1552,  1554,  1557,  1559,  1561,  1563,  1565,  1567,  1569,
    1571,  1573,  1575,  1577,  1579,  1581,  1583,  1585,  1588,  1590,
    1592,  1596,  1599,  1603,  1608,  1611,  1614,  1617,  1623,  1629,
    1632,  1640,  1642,  1644,  1646,  1648,  1650,  1652,  1654,  1656,
    1658,  1660,  1663,  1666,  1669,  1672,  1675,  1679,  1682,  1684,
    1688,  1689,  1691,  1693,  1697,  1700,  1701,  1705,  1709,  1711,
    1713,  1715,  1717,  1718,  1721,  1723,  1725,  1727,  1732,  1737,
    1744,  1748,  1752,  1757,  1759,  1763,  1767,  1769,  1771,  1773,
    1775,  1780,  1782,  1789,  1796,  1803,  1808,  1810,  1812,  1814,
    1816,  1818,  1820,  1822,  1824,  1826,  1828,  1830,  1832,  1834,
    1836,  1838,  1842,  1845,  1851,  1856,  1860,  1869,  1874,  1875,
    1878,  1879,  1881,  1885,  1889,  1890,  1893,  1896,  1899,  1900,
    1903,  1907,  1909,  1911,  1915,  1924,  1927,  1931,  1933,  1937,
    1941,  1945,  1949,  1955,  1956,  1959,  1963,  1965,  1969,  1974,
    1978,  1979,  1982,  1985,  1989,  1993,  1997,  2001,  2005,  2009,
    2010,  2013,  2016,  2020,  2023,  2025,  2029,  2030,  2033,  2036,
    2037,  2040,  2045,  2049
};

/* YYRHS -- A `-1'-separated list of the rules' RHS.  */
static const yytype_int16 yyrhs[] =
{
     252,     0,    -1,   253,    -1,    -1,   253,   254,    -1,   264,
      27,   269,    28,    -1,   263,    27,   253,    28,    -1,   289,
     311,    28,    -1,   271,    -1,   312,    -1,   261,    -1,   259,
      -1,   354,    -1,   355,    -1,   359,    27,   361,    28,    -1,
     367,    27,   368,    28,    -1,   370,    27,   373,    28,    -1,
     375,    27,   377,    28,    -1,   258,    -1,   347,    -1,   257,
      -1,    29,   344,    -1,    30,   344,    -1,    31,    32,   344,
      -1,    33,   345,    -1,   256,    -1,     4,    -1,   255,    34,
       4,    -1,    35,     5,    -1,    35,     5,    36,     5,    -1,
      35,     5,    36,     5,    36,     5,    -1,    37,   278,    -1,
      37,   278,    38,   255,    -1,   275,   321,    39,    -1,    37,
      40,   279,    39,   278,    -1,    37,    40,   279,    39,   278,
      38,   255,    -1,   276,   321,    39,    -1,    41,    -1,    41,
     330,    -1,    41,    42,   330,    -1,    43,    44,   344,    45,
     260,    46,   342,    -1,    -1,   260,    47,    -1,   260,    48,
      -1,   260,    49,    -1,   260,    50,    -1,   262,   321,    39,
      -1,    51,    38,    40,    -1,    52,   330,    -1,    53,   265,
     342,   266,   267,    -1,    -1,   265,    54,    -1,   265,    55,
      -1,   265,    56,    -1,   265,    57,    -1,   265,    58,    -1,
     265,    59,    -1,   265,    60,    -1,   265,    61,    -1,   265,
      62,    -1,   265,    63,    -1,   265,    64,    -1,   265,    65,
      -1,   265,    66,    -1,   265,    67,    -1,   265,    68,    -1,
     265,    69,    54,    -1,   265,    69,    55,    -1,   265,    69,
      70,    -1,   265,    69,    71,    -1,   265,    69,    72,    -1,
     265,    69,    73,    -1,   265,    74,    -1,   265,    75,    -1,
     265,    76,    -1,    -1,    77,   331,    -1,    -1,    78,   268,
      -1,   268,    36,   331,    -1,   331,    -1,    -1,   269,   270,
      -1,   289,   311,    28,    -1,   264,    27,   269,    28,    -1,
     280,    27,   282,    28,    -1,   284,    27,   286,    28,    -1,
     271,    -1,   312,    -1,   347,    -1,   354,    -1,   257,    -1,
      79,   344,    -1,    80,   344,    -1,   371,    27,   373,    28,
      -1,    81,   333,    82,   292,    83,   334,   338,   333,    82,
     292,    40,   327,    39,    -1,   256,    -1,    84,   274,   294,
     338,   342,   272,   273,    -1,    -1,    46,   342,    -1,    -1,
      38,   319,    -1,    -1,    44,   344,    45,    -1,    37,   278,
      38,    40,    -1,    37,    40,   279,    39,   278,    38,    40,
      -1,   325,   334,   338,   333,    82,   292,    40,   327,    39,
      -1,   325,   334,   338,   292,    40,   327,    39,    -1,    85,
     338,   333,    82,   342,    -1,    85,   338,   342,    -1,   334,
     338,   333,    82,    86,    40,   327,    39,    -1,   334,   338,
      86,    40,   327,    39,    -1,   333,    -1,   277,    -1,    87,
     281,   333,   342,    -1,    87,   281,   342,    -1,    -1,   281,
      76,    -1,   281,    75,    -1,    -1,   282,   283,    -1,    88,
     334,   338,   333,    82,   292,    40,   327,    39,    -1,    88,
     334,   338,   292,    40,   327,    39,    -1,    89,   334,   338,
     333,    82,   292,    40,   327,    39,    -1,    89,   334,   338,
     292,    40,   327,    39,    -1,    90,   334,   338,   333,    82,
     292,    40,   327,    39,    -1,    90,   334,   338,   292,    40,
     327,    39,    -1,    91,   334,   338,   333,    82,   292,    40,
     327,    39,    -1,    91,   334,   338,   292,    40,   327,    39,
      -1,   354,    -1,   257,    -1,   256,    -1,    92,   285,   334,
     338,   342,    40,   327,    39,   273,    -1,    -1,   285,    76,
      -1,   285,    75,    -1,    -1,   286,   287,    -1,    93,   334,
     338,   333,    82,   292,    40,   327,    39,    -1,    93,   334,
     338,   292,    40,   327,    39,    -1,    94,   334,   338,   333,
      82,   292,    40,   327,    39,    -1,    94,   334,   338,   292,
      40,   327,    39,    -1,    91,   334,   338,   333,    82,   292,
      40,   327,    39,    -1,    91,   334,   338,   292,    40,   327,
      39,    -1,   257,    -1,   354,    -1,   256,    -1,    95,    -1,
     288,   290,   334,   293,   338,   292,    40,   327,    39,   295,
      27,    -1,   288,   290,   334,   293,   338,    96,    40,   336,
      39,   292,    40,   327,    39,   295,    27,    -1,    -1,   290,
      97,    -1,   290,    54,    -1,   290,    55,    -1,   290,    70,
      -1,   290,    98,    -1,   290,    75,    -1,   290,    99,    -1,
     290,    60,    -1,   290,    71,    -1,   290,    72,    -1,   290,
      73,    -1,   290,   100,    -1,   290,   101,    -1,   290,   102,
      -1,   290,    76,    -1,   290,   103,    -1,   290,   104,    -1,
     290,   105,    40,   255,   106,   255,   291,    39,    -1,   290,
     105,    40,   255,   291,    39,    -1,   290,   105,    40,   291,
      39,    -1,    -1,   291,   107,    -1,   291,    64,    -1,   291,
      65,    -1,   291,    66,    -1,   291,   108,    -1,   291,   109,
      -1,   291,   110,    -1,   291,   111,    -1,   291,   112,    -1,
     291,   113,    -1,    86,    -1,   114,    -1,   330,    -1,    -1,
     293,    44,   115,    45,    -1,   293,    44,   116,    45,    -1,
     293,    44,   117,    45,    -1,   293,    44,   344,    45,    -1,
      -1,   294,    97,    -1,   294,    54,    -1,   294,    55,    -1,
     294,    70,    -1,   294,   118,    -1,   294,    76,    -1,   294,
      75,    -1,   294,    96,    40,   336,    39,    -1,   294,    71,
      -1,   294,    72,    -1,   294,    73,    -1,   294,   100,    -1,
     294,   119,    -1,   294,   120,    -1,    -1,   295,   121,    -1,
     295,   122,    -1,   295,   123,    -1,   295,   124,    -1,   295,
     125,    -1,   295,   126,    -1,   295,   127,    -1,   295,   128,
      -1,   295,   129,    -1,   295,   130,    -1,   295,   131,    -1,
     132,    -1,   133,   344,    -1,   300,    -1,   134,   344,    -1,
     296,    40,   327,    39,    -1,   296,   135,    40,   327,    39,
      -1,   136,    -1,   137,    -1,   312,    -1,   326,    -1,   342,
     138,    -1,   347,    -1,   354,    -1,   256,    -1,   257,    -1,
     139,    44,   344,    45,    -1,   139,    44,   344,    45,   106,
     342,    -1,   140,   344,   138,   344,    -1,    81,   333,    82,
     292,    -1,   298,    -1,   141,    44,   344,    45,   273,    -1,
     299,   311,    28,    -1,    27,    -1,   302,   301,    -1,   304,
     301,    -1,   304,    -1,   303,   298,    -1,   303,   342,   142,
     342,    -1,   303,   344,   142,   344,    -1,   143,    -1,   307,
     310,    -1,   305,   310,    -1,   308,   310,    -1,   309,   310,
      -1,   306,   298,    -1,   306,   342,    -1,   306,   344,    -1,
     144,    -1,   145,   331,    -1,   146,    -1,   147,    -1,   298,
      -1,   148,   342,   142,   342,    -1,   148,   344,   142,   344,
      -1,    -1,   311,   297,    -1,   313,   315,    -1,   149,   314,
     342,    38,    -1,   149,   314,    -1,    -1,   150,    -1,    27,
     316,    28,    -1,   318,    -1,   318,    36,   316,    -1,   318,
      -1,    -1,    44,   344,    45,    -1,   151,   152,    40,   255,
      39,    -1,   153,    40,   342,    39,    -1,   320,   321,    39,
      -1,   154,    40,   346,    39,   317,    -1,   155,    40,   346,
      39,   317,    -1,    48,    40,   345,    39,   317,    -1,    47,
      40,   344,    39,   317,    -1,   156,    40,   344,    39,   317,
      -1,   157,    40,   344,    39,   317,    -1,   154,   317,    -1,
     155,   317,    -1,    48,   317,    -1,    47,   317,    -1,   156,
     317,    -1,   157,   317,    -1,   154,    40,   346,    39,    -1,
     155,    40,   346,    39,    -1,   154,    40,   345,    39,    -1,
     155,    40,   345,    39,    -1,    48,    40,   345,    39,    -1,
      47,    40,   345,    39,    -1,   156,    40,   345,    39,    -1,
     151,    40,   345,    39,    -1,   157,    40,   345,    39,    -1,
     158,    40,   351,    39,    -1,   255,    -1,   320,   321,    39,
      -1,   159,    -1,   160,    40,    -1,    -1,   322,    -1,    10,
      -1,   322,    10,    -1,    20,    40,    -1,    24,    -1,   161,
      -1,    19,    -1,    26,   344,    -1,    26,   342,    -1,    16,
     344,    -1,    17,   345,    -1,    20,   346,    -1,    20,   345,
      -1,   323,   321,    39,    -1,    14,   344,    -1,    14,   342,
      -1,    18,   334,   338,   333,    82,   292,    40,   327,    39,
      -1,    18,   334,   338,   292,    40,   327,    39,    -1,    15,
     338,   333,    82,   342,    -1,    15,   338,   342,    -1,    25,
     333,    -1,    22,   255,    -1,    22,   320,   321,    39,    -1,
      21,   334,   338,    40,   327,    39,    -1,    13,   342,    -1,
      13,   344,    -1,   324,   279,    -1,    23,    40,   341,    39,
      -1,    12,   343,    -1,    -1,   328,    -1,   329,    -1,   328,
      36,   329,    -1,   162,    -1,   293,   338,    -1,   293,   338,
     342,    -1,   293,   338,    96,    40,   336,    39,    -1,   293,
     338,    96,    40,   336,    39,   342,    -1,   342,    -1,     9,
      -1,   330,   163,   330,    -1,    44,   330,    45,   332,    -1,
      44,    41,   330,    45,   332,    -1,   332,    -1,   330,    -1,
     332,   164,   330,    -1,   331,    -1,    44,   330,    45,    -1,
      44,    41,   330,    45,    -1,   338,    -1,   165,   334,    -1,
      63,   334,    -1,   335,    -1,    -1,   166,    -1,   167,    -1,
     125,   110,    -1,   125,   111,    -1,   125,   112,    -1,   125,
     113,    -1,    -1,   168,    40,   255,    36,   255,    36,   255,
      36,   255,    39,    -1,   168,    40,   255,    36,   255,    39,
      -1,   169,   170,    44,   344,    45,    -1,   169,   171,    44,
     344,    45,    -1,   172,    -1,   173,    -1,   174,    -1,   175,
      -1,   158,    -1,   157,    -1,   156,    -1,    47,    -1,    48,
      -1,   154,    -1,   155,    -1,   176,    -1,   177,   157,    -1,
     177,   156,    -1,   177,    47,    -1,   177,    48,    -1,   336,
     152,    -1,   336,    44,    45,    -1,   336,    44,   344,    45,
      -1,   336,    44,   344,    34,   344,    45,    -1,   336,    44,
      34,   344,    45,    -1,   178,    -1,   179,    -1,   180,    -1,
     181,    -1,   182,    -1,   183,    -1,   184,    -1,   185,    -1,
     186,    -1,   187,    -1,    58,    -1,   188,   337,    -1,   188,
     337,    36,   255,    -1,   189,    -1,   177,   189,    -1,    69,
     187,    -1,   190,    -1,    64,   180,    -1,   191,    -1,   172,
     158,    -1,   325,    -1,   106,   192,    -1,   193,    -1,    -1,
     194,    -1,   172,    -1,   173,    -1,   175,    -1,   158,    -1,
     157,    -1,   156,    -1,    47,    -1,    48,    -1,   154,    -1,
     155,    -1,   177,   157,    -1,   177,   156,    -1,   177,    47,
      -1,   177,    48,    -1,   152,    -1,   337,    44,    45,    -1,
     337,   195,    -1,   337,   153,    -1,   178,    -1,   179,    -1,
     180,    -1,   181,    -1,   182,    -1,   185,    -1,   186,    -1,
     188,    -1,   189,    -1,   177,   189,    -1,   176,    -1,   196,
      -1,   197,    -1,   198,    -1,   199,    -1,   200,    -1,   201,
      -1,   202,    -1,   203,    -1,   204,    -1,   205,    -1,   206,
      -1,   207,    -1,   208,    -1,   209,   331,    -1,   210,    -1,
     211,    -1,    56,   209,   331,    -1,   212,   331,    -1,   338,
      44,    45,    -1,   338,    44,   339,    45,    -1,   338,   153,
      -1,   338,   152,    -1,   338,   213,    -1,   338,   214,    40,
     331,    39,    -1,   338,   215,    40,   331,    39,    -1,   216,
     344,    -1,   325,   334,   338,   152,    40,   327,    39,    -1,
     217,    -1,   151,    -1,   175,    -1,   158,    -1,   157,    -1,
     156,    -1,    47,    -1,    48,    -1,   154,    -1,   155,    -1,
     177,   157,    -1,   177,   156,    -1,   177,    47,    -1,   177,
      48,    -1,   121,   189,    -1,   121,   177,   189,    -1,   121,
     218,    -1,   340,    -1,   339,    36,   340,    -1,    -1,   162,
      -1,   344,    -1,   344,   162,   344,    -1,   344,   162,    -1,
      -1,   342,    36,   341,    -1,   344,    36,   341,    -1,   342,
      -1,   344,    -1,     3,    -1,     5,    -1,    -1,   343,   344,
      -1,     7,    -1,     7,    -1,     8,    -1,   154,    40,   344,
      39,    -1,   155,    40,   345,    39,    -1,   219,   353,   333,
      40,   349,    39,    -1,   219,   353,   333,    -1,   348,   321,
      39,    -1,   220,   353,    38,    40,    -1,   350,    -1,   350,
      36,   349,    -1,   255,    38,   352,    -1,   221,    -1,   222,
      -1,   351,    -1,   344,    -1,    47,    40,   344,    39,    -1,
     255,    -1,   331,    40,   157,   138,   344,    39,    -1,   331,
      40,   156,   138,   344,    39,    -1,   331,    40,    47,   138,
     344,    39,    -1,   331,    40,   344,    39,    -1,   223,    -1,
     224,    -1,   225,    -1,   226,    -1,   227,    -1,   228,    -1,
     229,    -1,   230,    -1,   231,    -1,   232,    -1,   233,    -1,
     234,    -1,   235,    -1,   236,    -1,   237,    -1,   238,   344,
       5,    -1,   238,   344,    -1,   238,   344,   138,   344,     5,
      -1,   238,   344,   138,   344,    -1,    11,   344,     4,    -1,
      31,   356,   330,   357,   358,   321,    39,   357,    -1,    31,
     356,   330,   357,    -1,    -1,   356,   239,    -1,    -1,   136,
      -1,   240,    38,    40,    -1,   241,   360,   330,    -1,    -1,
     360,   242,    -1,   360,   243,    -1,   360,   244,    -1,    -1,
     361,   362,    -1,   240,   245,   344,    -1,   347,    -1,   363,
      -1,   364,   321,    39,    -1,   246,   344,   138,   344,   138,
     344,   138,   344,    -1,   247,   255,    -1,   366,   321,    39,
      -1,   257,    -1,   248,    38,    40,    -1,   249,    38,    40,
      -1,   247,    38,    40,    -1,   241,    42,   330,    -1,   241,
      42,   330,   106,   330,    -1,    -1,   368,   369,    -1,   358,
     321,    39,    -1,   363,    -1,   365,   321,    39,    -1,    53,
      42,   372,   330,    -1,   139,   372,   330,    -1,    -1,   372,
      55,    -1,   372,    54,    -1,   372,    69,    54,    -1,   372,
      69,    55,    -1,   372,    69,    70,    -1,   372,    69,    71,
      -1,   372,    69,    72,    -1,   372,    69,    73,    -1,    -1,
     373,   374,    -1,    31,   330,    -1,    53,    42,   330,    -1,
      53,   344,    -1,   257,    -1,   250,   376,   330,    -1,    -1,
     376,    54,    -1,   376,    55,    -1,    -1,   377,   378,    -1,
      31,   330,    46,   344,    -1,   241,    42,   330,    -1,   257,
      -1
};

/* YYRLINE[YYN] -- source line where rule number YYN was defined.  */
static const yytype_uint16 yyrline[] =
{
       0,    33,    33,    35,    37,    40,    41,    42,    43,    44,
      45,    46,    47,    48,    49,    50,    51,    52,    53,    54,
      55,    56,    57,    58,    59,    60,    63,    64,    67,    68,
      69,    72,    73,    74,    75,    76,    77,    80,    81,    82,
      85,    87,    89,    90,    91,    92,    95,    98,   101,   104,
     106,   108,   109,   110,   111,   112,   113,   114,   115,   116,
     117,   118,   119,   120,   121,   122,   123,   124,   125,   126,
     127,   128,   129,   130,   131,   133,   135,   137,   139,   142,
     143,   145,   147,   150,   151,   152,   153,   154,   155,   156,
     157,   158,   159,   160,   161,   162,   163,   166,   168,   170,
     172,   174,   176,   178,   181,   184,   187,   188,   189,   190,
     193,   194,   196,   197,   200,   201,   203,   205,   206,   208,
     210,   213,   214,   215,   216,   217,   218,   219,   220,   221,
     222,   223,   226,   228,   230,   231,   233,   235,   238,   239,
     240,   241,   242,   243,   244,   245,   246,   249,   252,   253,
     255,   257,   258,   259,   260,   261,   262,   263,   264,   265,
     266,   267,   268,   269,   270,   271,   272,   273,   274,   275,
     276,   278,   280,   281,   282,   283,   284,   285,   286,   287,
     288,   289,   292,   293,   294,   296,   298,   299,   300,   301,
     303,   305,   306,   307,   308,   309,   310,   311,   317,   318,
     319,   320,   321,   322,   323,   325,   327,   328,   329,   330,
     331,   332,   333,   334,   335,   336,   337,   340,   343,   344,
     345,   346,   347,   348,   349,   350,   351,   352,   353,   354,
     355,   356,   357,   358,   359,   360,   361,   362,   365,   368,
     371,   374,   375,   378,   379,   380,   383,   386,   387,   388,
     389,   392,   393,   394,   397,   400,   403,   406,   409,   410,
     411,   413,   415,   418,   421,   422,   424,   426,   429,   430,
     433,   434,   436,   438,   441,   442,   443,   444,   445,   446,
     447,   448,   449,   450,   451,   452,   453,   454,   455,   458,
     459,   460,   461,   462,   463,   464,   465,   466,   467,   468,
     469,   470,   473,   475,   477,   480,   481,   484,   487,   490,
     493,   494,   495,   496,   497,   498,   499,   500,   501,   502,
     503,   504,   505,   506,   507,   508,   509,   510,   511,   512,
     513,   514,   515,   517,   519,   522,   523,   526,   527,   528,
     529,   530,   533,   534,   535,   538,   539,   540,   543,   544,
     547,   548,   549,   550,   553,   554,   555,   557,   559,   560,
     561,   562,   563,   564,   566,   568,   569,   570,   571,   572,
     573,   574,   575,   576,   577,   578,   579,   580,   581,   582,
     583,   584,   585,   586,   587,   588,   589,   590,   591,   592,
     593,   594,   595,   596,   597,   598,   599,   600,   601,   602,
     603,   604,   605,   606,   607,   608,   609,   610,   611,   612,
     613,   614,   615,   617,   619,   620,   621,   622,   623,   624,
     625,   626,   627,   628,   629,   630,   631,   632,   633,   634,
     635,   636,   637,   638,   639,   640,   641,   642,   643,   644,
     645,   646,   647,   648,   649,   650,   651,   652,   653,   654,
     655,   656,   657,   658,   659,   660,   661,   664,   665,   666,
     667,   668,   669,   670,   675,   676,   677,   678,   679,   680,
     681,   682,   683,   684,   685,   686,   687,   688,   689,   690,
     691,   692,   693,   694,   695,   696,   697,   698,   701,   702,
     704,   706,   707,   708,   709,   711,   713,   714,   715,   716,
     718,   719,   721,   723,   726,   729,   732,   733,   734,   737,
     738,   739,   742,   745,   746,   749,   752,   753,   756,   757,
     758,   759,   760,   761,   762,   763,   766,   767,   768,   769,
     770,   771,   772,   773,   774,   775,   776,   777,   778,   779,
     780,   783,   784,   785,   786,   787,   790,   791,   793,   795,
     797,   799,   802,   805,   807,   809,   810,   811,   813,   815,
     818,   819,   820,   823,   824,   825,   826,   827,   830,   833,
     836,   839,   840,   842,   844,   847,   848,   849,   852,   855,
     857,   859,   860,   861,   862,   863,   864,   865,   866,   868,
     870,   873,   874,   875,   876,   879,   881,   883,   884,   886,
     888,   891,   892,   893
};
#endif

#if YYDEBUG || YYERROR_VERBOSE || YYTOKEN_TABLE
/* YYTNAME[SYMBOL-NUM] -- String name of the symbol SYMBOL-NUM.
   First, the terminals, then, starting at YYNTOKENS, nonterminals.  */
static const char *const yytname[] =
{
  "$end", "error", "$undefined", "ID", "QSTRING", "SQSTRING", "INT32",
  "INT64", "FLOAT64", "DOTTEDNAME", "HEXBYTE", "P_LINE", "INSTR_PHI",
  "INSTR_RVA", "INSTR_BRTARGET", "INSTR_FIELD", "INSTR_I", "INSTR_I8",
  "INSTR_METHOD", "INSTR_NONE", "INSTR_R", "INSTR_SIG", "INSTR_STRING",
  "INSTR_SWITCH", "INSTR_TOK", "INSTR_TYPE", "INSTR_VAR", "'{'", "'}'",
  "\".subsystem\"", "\".corflags\"", "\".file\"", "\"alignment\"",
  "\".imagebase\"", "'+'", "\".language\"", "','", "\".custom\"", "'='",
  "')'", "'('", "\".module\"", "\"extern\"", "\".vtfixup\"", "'['", "']'",
  "\"at\"", "\"int32\"", "\"int64\"", "\"fromunmanaged\"",
  "\"callmostderived\"", "\".vtable\"", "\".namespace\"", "\".class\"",
  "\"public\"", "\"private\"", "\"value\"", "\"enum\"", "\"interface\"",
  "\"sealed\"", "\"abstract\"", "\"auto\"", "\"sequential\"",
  "\"explicit\"", "\"ansi\"", "\"unicode\"", "\"autochar\"", "\"import\"",
  "\"serializable\"", "\"nested\"", "\"family\"", "\"assembly\"",
  "\"famandassem\"", "\"famorassem\"", "\"beforefieldinit\"",
  "\"specialname\"", "\"rtspecialname\"", "\"extends\"", "\"implements\"",
  "\".size\"", "\".pack\"", "\".override\"", "\"::\"", "\"with\"",
  "\".field\"", "\"field\"", "\".ctor\"", "\".event\"", "\".addon\"",
  "\".removeon\"", "\".fire\"", "\".other\"", "\".property\"", "\".set\"",
  "\".get\"", "\".method\"", "\"marshal\"", "\"static\"", "\"final\"",
  "\"virtual\"", "\"privatescope\"", "\"hidebysig\"", "\"newslot\"",
  "\"unmanagedexp\"", "\"reqsecobj\"", "\"pinvokeimpl\"", "\"as\"",
  "\"nomangle\"", "\"lasterr\"", "\"winapi\"", "\"cdecl\"", "\"stdcall\"",
  "\"thiscall\"", "\"fastcall\"", "\".cctor\"", "\"in\"", "\"out\"",
  "\"opt\"", "\"initonly\"", "\"literal\"", "\"notserialized\"",
  "\"native\"", "\"cil\"", "\"optil\"", "\"managed\"", "\"unmanaged\"",
  "\"forwardref\"", "\"preservesig\"", "\"runtime\"", "\"internalcall\"",
  "\"synchronized\"", "\"noinlining\"", "\".locals\"", "\".emitbyte\"",
  "\".maxstack\"", "\"init\"", "\".entrypoint\"", "\".zeroinit\"", "':'",
  "\".export\"", "\".vtentry\"", "\".param\"", "\"to\"", "\".try\"",
  "\"filter\"", "\"catch\"", "\"finally\"", "\"fault\"", "\"handler\"",
  "\".data\"", "\"tls\"", "\"char\"", "'*'", "'&'", "\"float32\"",
  "\"float64\"", "\"int16\"", "\"int8\"", "\"bool\"", "\"nullref\"",
  "\"bytearray\"", "\"method\"", "\"...\"", "'.'", "'/'", "\"instance\"",
  "\"default\"", "\"vararg\"", "\"custom\"", "\"fixed\"", "\"sysstring\"",
  "\"array\"", "\"variant\"", "\"currency\"", "\"syschar\"", "\"void\"",
  "\"error\"", "\"unsigned\"", "\"decimal\"", "\"date\"", "\"bstr\"",
  "\"lpstr\"", "\"lpwstr\"", "\"lptstr\"", "\"objectref\"", "\"iunknown\"",
  "\"idispatch\"", "\"struct\"", "\"safearray\"", "\"int\"",
  "\"byvalstr\"", "\"tbstr\"", "\"any\"", "\"lpstruct\"", "\"null\"",
  "\"vector\"", "\"hresult\"", "\"carray\"", "\"userdefined\"",
  "\"record\"", "\"filetime\"", "\"blob\"", "\"stream\"", "\"storage\"",
  "\"streamed_object\"", "\"stored_object\"", "\"blob_object\"", "\"cf\"",
  "\"clsid\"", "\"class\"", "\"object\"", "\"string\"", "\"valuetype\"",
  "\"pinned\"", "\"modreq\"", "\"modopt\"", "'!'", "\"typedref\"",
  "\"float\"", "\".permission\"", "\".permissionset\"", "\"true\"",
  "\"false\"", "\"request\"", "\"demand\"", "\"assert\"", "\"deny\"",
  "\"permitonly\"", "\"linkcheck\"", "\"inheritcheck\"", "\"reqmin\"",
  "\"reqopt\"", "\"reqrefuse\"", "\"prejitgrant\"", "\"prejitdeny\"",
  "\"noncasdemand\"", "\"noncaslinkdemand\"", "\"noncasinheritance\"",
  "\".line\"", "\"nometadata\"", "\".hash\"", "\".assembly\"",
  "\"noappdomain\"", "\"noprocess\"", "\"nomachine\"", "\"algorithm\"",
  "\".ver\"", "\".locale\"", "\".publickey\"", "\".publickeytoken\"",
  "\".mresource\"", "$accept", "START", "decls", "decl", "compQstring",
  "languageDecl", "customAttrDecl", "moduleHead", "vtfixupDecl",
  "vtfixupAttr", "vtableDecl", "vtableHead", "nameSpaceHead", "classHead",
  "classAttr", "extendsClause", "implClause", "classNames", "classDecls",
  "classDecl", "fieldDecl", "atOpt", "initOpt", "repeatOpt", "customHead",
  "customHeadWithOwner", "memberRef", "customType", "ownerType",
  "eventHead", "eventAttr", "eventDecls", "eventDecl", "propHead",
  "propAttr", "propDecls", "propDecl", "methodHeadPart1", "methodHead",
  "methAttr", "pinvAttr", "methodName", "paramAttr", "fieldAttr",
  "implAttr", "localsHead", "methodDecl", "scopeBlock", "scopeOpen",
  "sehBlock", "sehClauses", "tryBlock", "tryHead", "sehClause",
  "filterClause", "filterHead", "catchClause", "finallyClause",
  "faultClause", "handlerBlock", "methodDecls", "dataDecl", "ddHead",
  "tls", "ddBody", "ddItemList", "ddItemCount", "ddItem", "fieldInit",
  "bytearrayhead", "bytes", "hexbytes", "instr_r_head", "instr_tok_head",
  "methodSpec", "instr", "sigArgs0", "sigArgs1", "sigArg", "name1",
  "className", "slashedName", "typeSpec", "callConv", "callKind",
  "nativeType", "variantType", "type", "bounds1", "bound", "labels", "id",
  "int16s", "int32", "int64", "float64", "secDecl", "psetHead",
  "nameValPairs", "nameValPair", "truefalse", "caValue", "secAction",
  "extSourceSpec", "fileDecl", "fileAttr", "fileEntry", "hashHead",
  "assemblyHead", "asmAttr", "assemblyDecls", "assemblyDecl",
  "asmOrRefDecl", "publicKeyHead", "publicKeyTokenHead", "localeHead",
  "assemblyRefHead", "assemblyRefDecls", "assemblyRefDecl", "comtypeHead",
  "exportHead", "comtAttr", "comtypeDecls", "comtypeDecl",
  "manifestResHead", "manresAttr", "manifestResDecls", "manifestResDecl", 0
};
#endif

# ifdef YYPRINT
/* YYTOKNUM[YYLEX-NUM] -- Internal token number corresponding to
   token YYLEX-NUM.  */
static const yytype_uint16 yytoknum[] =
{
       0,   256,   257,   258,   259,   260,   261,   262,   263,   264,
     265,   266,   267,   268,   269,   270,   271,   272,   273,   274,
     275,   276,   277,   278,   279,   280,   281,   123,   125,   282,
     283,   284,   285,   286,    43,   287,    44,   288,    61,    41,
      40,   289,   290,   291,    91,    93,   292,   293,   294,   295,
     296,   297,   298,   299,   300,   301,   302,   303,   304,   305,
     306,   307,   308,   309,   310,   311,   312,   313,   314,   315,
     316,   317,   318,   319,   320,   321,   322,   323,   324,   325,
     326,   327,   328,   329,   330,   331,   332,   333,   334,   335,
     336,   337,   338,   339,   340,   341,   342,   343,   344,   345,
     346,   347,   348,   349,   350,   351,   352,   353,   354,   355,
     356,   357,   358,   359,   360,   361,   362,   363,   364,   365,
     366,   367,   368,   369,   370,   371,   372,   373,   374,   375,
     376,   377,   378,   379,   380,   381,   382,   383,    58,   384,
     385,   386,   387,   388,   389,   390,   391,   392,   393,   394,
     395,   396,    42,    38,   397,   398,   399,   400,   401,   402,
     403,   404,   405,    46,    47,   406,   407,   408,   409,   410,
     411,   412,   413,   414,   415,   416,   417,   418,   419,   420,
     421,   422,   423,   424,   425,   426,   427,   428,   429,   430,
     431,   432,   433,   434,   435,   436,   437,   438,   439,   440,
     441,   442,   443,   444,   445,   446,   447,   448,   449,   450,
     451,   452,   453,   454,   455,   456,    33,   457,   458,   459,
     460,   461,   462,   463,   464,   465,   466,   467,   468,   469,
     470,   471,   472,   473,   474,   475,   476,   477,   478,   479,
     480,   481,   482,   483,   484,   485,   486,   487,   488,   489,
     490
};
# endif

/* YYR1[YYN] -- Symbol number of symbol that rule YYN derives.  */
static const yytype_uint16 yyr1[] =
{
       0,   251,   252,   253,   253,   254,   254,   254,   254,   254,
     254,   254,   254,   254,   254,   254,   254,   254,   254,   254,
     254,   254,   254,   254,   254,   254,   255,   255,   256,   256,
     256,   257,   257,   257,   257,   257,   257,   258,   258,   258,
     259,   260,   260,   260,   260,   260,   261,   262,   263,   264,
     265,   265,   265,   265,   265,   265,   265,   265,   265,   265,
     265,   265,   265,   265,   265,   265,   265,   265,   265,   265,
     265,   265,   265,   265,   265,   266,   266,   267,   267,   268,
     268,   269,   269,   270,   270,   270,   270,   270,   270,   270,
     270,   270,   270,   270,   270,   270,   270,   271,   272,   272,
     273,   273,   274,   274,   275,   276,   277,   277,   277,   277,
     278,   278,   279,   279,   280,   280,   281,   281,   281,   282,
     282,   283,   283,   283,   283,   283,   283,   283,   283,   283,
     283,   283,   284,   285,   285,   285,   286,   286,   287,   287,
     287,   287,   287,   287,   287,   287,   287,   288,   289,   289,
     290,   290,   290,   290,   290,   290,   290,   290,   290,   290,
     290,   290,   290,   290,   290,   290,   290,   290,   290,   290,
     290,   291,   291,   291,   291,   291,   291,   291,   291,   291,
     291,   291,   292,   292,   292,   293,   293,   293,   293,   293,
     294,   294,   294,   294,   294,   294,   294,   294,   294,   294,
     294,   294,   294,   294,   294,   295,   295,   295,   295,   295,
     295,   295,   295,   295,   295,   295,   295,   296,   297,   297,
     297,   297,   297,   297,   297,   297,   297,   297,   297,   297,
     297,   297,   297,   297,   297,   297,   297,   297,   298,   299,
     300,   301,   301,   302,   302,   302,   303,   304,   304,   304,
     304,   305,   305,   305,   306,   307,   308,   309,   310,   310,
     310,   311,   311,   312,   313,   313,   314,   314,   315,   315,
     316,   316,   317,   317,   318,   318,   318,   318,   318,   318,
     318,   318,   318,   318,   318,   318,   318,   318,   318,   319,
     319,   319,   319,   319,   319,   319,   319,   319,   319,   319,
     319,   319,   320,   321,   321,   322,   322,   323,   324,   325,
     326,   326,   326,   326,   326,   326,   326,   326,   326,   326,
     326,   326,   326,   326,   326,   326,   326,   326,   326,   326,
     326,   326,   326,   327,   327,   328,   328,   329,   329,   329,
     329,   329,   330,   330,   330,   331,   331,   331,   332,   332,
     333,   333,   333,   333,   334,   334,   334,   335,   335,   335,
     335,   335,   335,   335,   336,   336,   336,   336,   336,   336,
     336,   336,   336,   336,   336,   336,   336,   336,   336,   336,
     336,   336,   336,   336,   336,   336,   336,   336,   336,   336,
     336,   336,   336,   336,   336,   336,   336,   336,   336,   336,
     336,   336,   336,   336,   336,   336,   336,   336,   336,   336,
     336,   336,   336,   337,   337,   337,   337,   337,   337,   337,
     337,   337,   337,   337,   337,   337,   337,   337,   337,   337,
     337,   337,   337,   337,   337,   337,   337,   337,   337,   337,
     337,   337,   337,   337,   337,   337,   337,   337,   337,   337,
     337,   337,   337,   337,   337,   337,   337,   338,   338,   338,
     338,   338,   338,   338,   338,   338,   338,   338,   338,   338,
     338,   338,   338,   338,   338,   338,   338,   338,   338,   338,
     338,   338,   338,   338,   338,   338,   338,   338,   339,   339,
     340,   340,   340,   340,   340,   341,   341,   341,   341,   341,
     342,   342,   343,   343,   344,   345,   346,   346,   346,   347,
     347,   347,   348,   349,   349,   350,   351,   351,   352,   352,
     352,   352,   352,   352,   352,   352,   353,   353,   353,   353,
     353,   353,   353,   353,   353,   353,   353,   353,   353,   353,
     353,   354,   354,   354,   354,   354,   355,   355,   356,   356,
     357,   357,   358,   359,   360,   360,   360,   360,   361,   361,
     362,   362,   362,   363,   363,   363,   363,   363,   364,   365,
     366,   367,   367,   368,   368,   369,   369,   369,   370,   371,
     372,   372,   372,   372,   372,   372,   372,   372,   372,   373,
     373,   374,   374,   374,   374,   375,   376,   376,   376,   377,
     377,   378,   378,   378
};

/* YYR2[YYN] -- Number of symbols composing right hand side of rule YYN.  */
static const yytype_uint8 yyr2[] =
{
       0,     2,     1,     0,     2,     4,     4,     3,     1,     1,
       1,     1,     1,     1,     4,     4,     4,     4,     1,     1,
       1,     2,     2,     3,     2,     1,     1,     3,     2,     4,
       6,     2,     4,     3,     5,     7,     3,     1,     2,     3,
       7,     0,     2,     2,     2,     2,     3,     3,     2,     5,
       0,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     3,     3,     3,     3,
       3,     3,     2,     2,     2,     0,     2,     0,     2,     3,
       1,     0,     2,     3,     4,     4,     4,     1,     1,     1,
       1,     1,     2,     2,     4,    13,     1,     7,     0,     2,
       0,     2,     0,     3,     4,     7,     9,     7,     5,     3,
       8,     6,     1,     1,     4,     3,     0,     2,     2,     0,
       2,     9,     7,     9,     7,     9,     7,     9,     7,     1,
       1,     1,     9,     0,     2,     2,     0,     2,     9,     7,
       9,     7,     9,     7,     1,     1,     1,     1,    11,    15,
       0,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     8,     6,
       5,     0,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     1,     1,     1,     0,     4,     4,     4,     4,
       0,     2,     2,     2,     2,     2,     2,     2,     5,     2,
       2,     2,     2,     2,     2,     0,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     1,     2,     1,
       2,     4,     5,     1,     1,     1,     1,     2,     1,     1,
       1,     1,     4,     6,     4,     4,     1,     5,     3,     1,
       2,     2,     1,     2,     4,     4,     1,     2,     2,     2,
       2,     2,     2,     2,     1,     2,     1,     1,     1,     4,
       4,     0,     2,     2,     4,     2,     0,     1,     3,     1,
       3,     1,     0,     3,     5,     4,     3,     5,     5,     5,
       5,     5,     5,     2,     2,     2,     2,     2,     2,     4,
       4,     4,     4,     4,     4,     4,     4,     4,     4,     1,
       3,     1,     2,     0,     1,     1,     2,     2,     1,     1,
       1,     2,     2,     2,     2,     2,     2,     3,     2,     2,
       9,     7,     5,     3,     2,     2,     4,     6,     2,     2,
       2,     4,     2,     0,     1,     1,     3,     1,     2,     3,
       6,     7,     1,     1,     3,     4,     5,     1,     1,     3,
       1,     3,     4,     1,     2,     2,     1,     0,     1,     1,
       2,     2,     2,     2,     0,    10,     6,     5,     5,     1,
       1,     1,     1,     1,     1,     1,     1,     1,     1,     1,
       1,     2,     2,     2,     2,     2,     3,     4,     6,     5,
       1,     1,     1,     1,     1,     1,     1,     1,     1,     1,
       1,     2,     4,     1,     2,     2,     1,     2,     1,     2,
       1,     2,     1,     0,     1,     1,     1,     1,     1,     1,
       1,     1,     1,     1,     1,     2,     2,     2,     2,     1,
       3,     2,     2,     1,     1,     1,     1,     1,     1,     1,
       1,     1,     2,     1,     1,     1,     1,     1,     1,     1,
       1,     1,     1,     1,     1,     1,     1,     2,     1,     1,
       3,     2,     3,     4,     2,     2,     2,     5,     5,     2,
       7,     1,     1,     1,     1,     1,     1,     1,     1,     1,
       1,     2,     2,     2,     2,     2,     3,     2,     1,     3,
       0,     1,     1,     3,     2,     0,     3,     3,     1,     1,
       1,     1,     0,     2,     1,     1,     1,     4,     4,     6,
       3,     3,     4,     1,     3,     3,     1,     1,     1,     1,
       4,     1,     6,     6,     6,     4,     1,     1,     1,     1,
       1,     1,     1,     1,     1,     1,     1,     1,     1,     1,
       1,     3,     2,     5,     4,     3,     8,     4,     0,     2,
       0,     1,     3,     3,     0,     2,     2,     2,     0,     2,
       3,     1,     1,     3,     8,     2,     3,     1,     3,     3,
       3,     3,     5,     0,     2,     3,     1,     3,     4,     3,
       0,     2,     2,     3,     3,     3,     3,     3,     3,     0,
       2,     2,     3,     2,     1,     3,     0,     2,     2,     0,
       2,     4,     3,     1
};

/* YYDEFACT[STATE-NAME] -- Default reduction number in state STATE-NUM.
   Performed when YYTABLE doesn't specify something else to do.  Zero
   means the default is an error.  */
static const yytype_uint16 yydefact[] =
{
       3,     0,     2,     1,     0,     0,     0,   548,     0,     0,
     357,    37,     0,     0,     0,    50,   102,   147,   266,     0,
       0,     0,   554,   596,     4,    25,    20,    18,    11,    10,
     303,     0,     0,     8,   303,   303,   150,   261,     9,     0,
      19,   303,    12,    13,     0,     0,     0,     0,   504,     0,
      21,    22,     0,     0,   505,    24,    28,     0,   357,     0,
     357,   358,   359,    31,     0,   356,   500,   501,   343,     0,
      38,   342,     0,     0,    48,   580,     0,     0,   190,   267,
     265,   526,   527,   528,   529,   530,   531,   532,   533,   534,
     535,   536,   537,   538,   539,   540,     0,     0,   542,     0,
       0,     0,   305,     0,   304,     3,    81,     0,     0,   357,
       0,     0,   272,   272,     0,     0,   272,   272,   272,   272,
       0,   263,   269,   303,     0,   558,   573,   589,   599,   545,
      23,   549,   550,     0,     0,   477,   478,     0,     0,     0,
     472,   479,   480,   476,   475,   474,   309,   473,     0,     0,
     458,   459,     0,     0,   471,   113,     0,   357,   348,   350,
     347,   112,   353,   355,   360,   361,   362,   363,   354,     0,
     357,     0,    39,     0,     0,    47,     0,    51,    52,    53,
      54,    55,    56,    57,    58,    59,    60,    61,    62,    63,
      64,    65,     0,    72,    73,    74,    75,     0,     0,     0,
     510,     0,   541,     0,   571,   555,   556,   557,   553,   597,
     598,   595,    46,   306,     0,     0,    33,    36,   152,   153,
     158,   154,   159,   160,   161,   156,   165,   151,   155,   157,
     162,   163,   164,   166,   167,     0,   185,   502,     0,     0,
       0,     0,     0,   357,   310,     0,   357,     0,     0,   308,
       0,     0,   239,     7,     0,   217,     0,     0,   223,   224,
       0,     0,     0,   246,   230,   231,     0,   262,   236,   261,
     219,     0,     0,   225,   303,     0,   226,     0,   228,   229,
       0,   271,     0,     0,   286,     0,   285,     0,     0,     0,
     283,     0,   284,     0,   287,     0,   288,   302,     0,   511,
       0,     0,     0,     0,   551,   547,    29,     0,     0,     0,
       0,     0,   485,   487,   483,   484,   482,   481,     0,   457,
     461,   469,   357,     0,     0,   490,   465,   464,   466,     0,
       0,    26,   104,    32,     0,   490,     0,     0,   344,    41,
     582,   581,     0,   578,    66,    67,    68,    69,    70,    71,
       0,    77,   103,   192,   193,   194,   199,   200,   201,   197,
     196,     0,   191,   202,   195,   203,   204,     0,   264,     0,
     512,   544,     0,     6,     5,    50,     0,     0,     0,   116,
     133,   580,    96,    91,     0,    82,    87,     0,     0,   261,
      88,    89,    90,     0,   171,     0,   332,   328,   329,   319,
     318,     0,   313,   314,     0,   506,   307,     0,     0,   316,
     315,     0,   325,   303,   495,   324,   312,   311,     0,   218,
     220,     0,     0,     0,   185,     0,     0,   254,     0,   256,
     257,   240,   242,     0,     0,     0,     0,     0,   243,     0,
       0,     0,   330,   227,   268,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,   276,    14,     0,     0,     0,
       0,   567,   561,   559,   562,   303,   303,    15,     0,     0,
     303,   576,   303,   574,    16,     0,     0,   594,   590,    17,
       0,     0,   603,   600,   303,     0,     0,   351,   460,     0,
     109,   486,     0,     0,    34,     0,   349,   462,   491,     0,
     488,   492,     0,     0,     0,     0,   185,     0,     0,   583,
     584,   585,   586,   587,   588,    76,     0,    49,   364,    98,
       0,     0,   513,   543,   572,    92,    93,     0,     0,   357,
       0,    81,   119,   136,     0,   589,   171,     0,     0,     0,
     503,     0,   323,     0,     0,     0,     0,     0,     0,   498,
     499,     0,     0,     0,     0,   337,     0,     0,   334,   335,
     185,   238,   255,   241,     0,   258,   248,   251,   252,   253,
     247,   249,   250,     0,     0,   317,   270,   272,   273,   272,
       0,   275,   272,   272,   272,   272,     0,     0,     0,   565,
       0,     0,     0,     0,     0,     0,     0,   591,     0,   593,
       0,     0,     0,    30,   352,   345,     0,     0,     0,     0,
     182,   183,   465,     0,   348,     0,   490,   463,   494,     0,
       0,    27,     0,     0,     0,    42,    43,    44,    45,    78,
      80,   376,   377,   400,     0,     0,     0,   378,   379,   375,
     374,   373,     0,     0,   369,   370,   371,   372,   380,     0,
     390,   391,   392,   393,   394,   395,   396,   397,   398,   399,
     413,   403,   406,   408,   412,   410,     0,     0,   100,     0,
     509,     0,     0,   118,   117,     0,   342,   135,   134,     0,
     579,     0,     0,     0,    83,     0,     0,     0,   170,   173,
     174,   175,   172,   176,   177,   178,   179,   180,   181,     0,
       0,     0,     0,     0,     0,   184,     0,     0,     0,     0,
       0,   185,   326,   331,   495,   495,   235,   232,   234,   100,
     338,   221,   185,     0,     0,     0,   244,   245,   280,   279,
     274,   277,   278,   281,   282,   560,     0,   570,   568,   563,
     566,   552,   569,   575,   577,   592,     0,   602,   550,   346,
     108,     0,   105,    35,   185,   185,     0,   489,   493,   467,
     468,   111,   185,    40,     0,   407,   405,   411,     0,     0,
       0,   409,   383,   384,   382,   381,   404,   421,   422,   429,
     423,   424,   420,   419,   418,   415,   416,   417,   443,     0,
     433,   434,   435,   436,   437,   438,   439,   440,   441,   414,
     444,   445,   446,   447,   448,   449,   450,   451,   452,   453,
     454,   455,   456,   401,   198,     0,   385,    99,     0,    97,
       0,   516,   517,   521,     0,   519,   518,   515,   514,     0,
     114,     0,    84,    85,   357,   357,   357,   357,   131,   130,
     120,   129,    86,   357,   357,   357,   146,   144,   137,   145,
      94,   171,   169,   186,   187,   188,   189,   364,   185,   322,
     185,     0,   507,   508,     0,   496,   497,     0,   237,     0,
     339,   336,   222,     0,     0,     0,   601,   546,     0,     0,
       0,     0,    79,     0,     0,     0,   427,   428,   426,   425,
     442,     0,     0,   432,   431,     0,   386,     0,     0,     0,
       0,     0,     0,     0,     0,     0,   301,   299,   101,   303,
       0,     0,   357,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,   327,   233,   364,   259,
     260,     0,   470,   107,   185,   110,     0,     0,     0,   402,
     430,     0,     0,   387,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,   185,
       0,     0,     0,     0,     0,     0,     0,   168,     0,   205,
     321,   185,     0,     0,     0,     0,   367,   368,   389,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
     300,   520,     0,     0,     0,   525,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,   340,     0,   106,     0,   366,
     388,   294,   293,   296,   291,   289,   292,   290,   295,   297,
     298,     0,     0,     0,     0,   100,   185,     0,   185,     0,
     185,     0,   185,     0,   185,     0,   185,     0,   185,     0,
     185,   148,   206,   207,   208,   209,   210,   211,   212,   213,
     214,   215,   216,   320,   341,   564,     0,   524,   523,   522,
       0,   132,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,   122,
     185,   124,   185,   126,   185,   128,   185,   143,   185,   139,
     185,   141,   185,   205,     0,   185,     0,     0,     0,     0,
       0,     0,     0,     0,   365,     0,   121,   123,   125,   127,
     142,   138,   140,   149,    95
};

/* YYDEFGOTO[NTERM-NUM].  */
static const yytype_int16 yydefgoto[] =
{
      -1,     1,     2,    24,   520,   264,   265,    27,    28,   508,
      29,    30,    31,    32,    76,   351,   517,   629,   215,   385,
      33,   668,   819,    78,    34,    35,   155,    63,   156,   387,
     528,   682,   840,   388,   529,   683,   848,    36,    37,   109,
     537,   613,   556,   198,  1013,   266,   267,   565,   269,   270,
     431,   271,   272,   432,   433,   434,   435,   436,   437,   566,
     110,   273,    39,    80,   121,   280,   284,   281,   908,   123,
     103,   104,   274,   275,   170,   276,   557,   558,   559,   158,
     159,   160,   161,    64,    65,   666,   813,   162,   499,   500,
     548,    71,   396,   501,    55,   410,   278,    41,   521,   522,
     826,   827,    96,   279,    43,    53,   305,   470,    44,   100,
     300,   463,   464,   465,   472,   466,    45,   301,   473,    46,
     393,   176,   302,   478,    47,   101,   303,   483
};

/* YYPACT[STATE-NUM] -- Index in YYTABLE of the portion describing
   STATE-NUM.  */
#define YYPACT_NINF -791
static const yytype_int16 yypact[] =
{
    -791,    82,  1040,  -791,    62,    62,    62,    87,    91,   130,
     235,   366,    97,   109,   427,   157,   183,  -791,    83,  1358,
    1358,    62,   173,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
     240,   232,   254,  -791,   240,   240,  -791,  -791,  -791,   596,
    -791,   240,  -791,  -791,   287,   294,   329,   346,  -791,   384,
    -791,  -791,    62,    28,  -791,  -791,   362,  1675,   262,   520,
     262,  -791,  -791,   361,  1877,  -791,  -791,  -791,  -791,   427,
     241,  -791,    62,   367,   241,  -791,  1116,    62,  -791,  -791,
     365,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
    -791,  -791,  -791,  -791,  -791,  -791,  1790,   374,    44,   427,
      35,   337,  -791,   387,   428,  -791,  -791,   407,   412,  1804,
    1083,   358,   248,   292,   311,   426,   375,   408,   413,   461,
     435,  -791,  -791,   240,   443,  -791,  -791,  -791,  -791,  -791,
    -791,  -791,   -45,   483,   127,  -791,  -791,   281,  1877,   -97,
    -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,   238,   486,
    -791,  -791,   486,    62,  -791,  -791,   454,   262,   241,  -791,
     335,  -791,   264,  -791,  -791,  -791,  -791,  -791,  -791,    66,
     262,  1485,   241,   427,   455,  -791,   524,  -791,  -791,  -791,
    -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
    -791,  -791,   595,  -791,  -791,  -791,   431,   465,  1949,   485,
     495,   496,  -791,    62,    55,  -791,  -791,  -791,   241,  -791,
    -791,   241,  -791,  -791,   968,   592,  -791,  -791,  -791,  -791,
    -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
    -791,  -791,  -791,  -791,  -791,   502,  -791,  -791,   491,   491,
    1877,    62,    91,   262,  -791,    54,   262,    37,   503,  -791,
    1790,   491,  -791,  -791,  1790,  -791,    62,    62,  -791,  -791,
     481,    62,   487,  -791,  -791,  -791,    25,  -791,  -791,  -791,
    -791,   513,   415,  -791,   240,  1675,  -791,   388,  -791,  -791,
     522,   515,    62,    62,  -791,    91,  -791,   512,   365,   100,
    -791,   100,  -791,    62,  -791,    62,  -791,  -791,   516,  -791,
     118,   105,   517,    22,  -791,   318,   523,   427,     6,   486,
    1600,   372,  -791,  -791,  -791,  -791,  -791,  -791,   432,  -791,
    -791,  -791,   262,  1877,   427,    23,  -791,  -791,  -791,   529,
     531,  -791,  -791,   542,  1877,   171,   537,   498,   241,  -791,
    -791,  -791,   662,   241,  -791,  -791,  -791,  -791,  -791,  -791,
     486,   507,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
    -791,   548,  -791,  -791,  -791,  -791,  -791,   257,  -791,   559,
    -791,   584,   427,  -791,  -791,  -791,    62,    62,  1790,  -791,
    -791,  -791,  -791,  -791,   565,  -791,  -791,   567,   568,  -791,
    -791,  -791,  -791,   571,   559,  1801,    62,  -791,  -791,  -791,
    -791,  1600,  -791,  -791,  1877,  -791,  -791,   561,   562,  -791,
    -791,  1877,   542,   240,   491,  -791,  -791,  -791,   527,  -791,
    -791,    62,   466,    62,    17,   577,  1131,  -791,   486,  -791,
    -791,  -791,   513,     1,   415,     1,     1,     1,  -791,   457,
     463,   580,  -791,  -791,  -791,   358,   582,   579,   583,   559,
     587,   589,   601,   602,   607,  -791,  -791,   410,    62,   187,
     614,  -791,  -791,  -791,  -791,   240,   240,  -791,   616,   624,
     240,  -791,   240,  -791,  -791,   427,   108,  -791,  -791,  -791,
     427,   621,  -791,  -791,   240,   669,    41,   427,  -791,   593,
      85,  -791,   427,    48,   626,  1350,   241,  -791,  -791,   162,
    -791,   521,   486,   486,   673,   272,    17,   599,   659,  -791,
    -791,  -791,  -791,  -791,  -791,  -791,   486,  -791,  2050,   632,
     482,   647,   652,  -791,   241,  -791,  -791,   617,  1611,   471,
     524,  -791,  -791,  -791,  1311,  -791,    42,   779,   174,   369,
    -791,   618,    85,  1363,    62,    91,   166,   650,   671,   665,
     676,   154,   653,    62,   681,  -791,  1801,   679,   691,  -791,
      17,  -791,  -791,  -791,   491,  -791,  -791,  -791,  -791,  -791,
    -791,  -791,  -791,   365,    62,  -791,  -791,   684,  -791,   684,
     156,  -791,   684,   684,   684,   684,    62,   604,   690,   542,
     697,   700,   704,   708,   715,   705,   718,   241,   427,  -791,
      29,   427,   719,  -791,   427,   335,   365,    50,   427,   124,
    -791,  -791,   720,   721,    26,   677,    38,  -791,    62,   723,
     724,  -791,   726,   727,   365,  -791,  -791,  -791,  -791,   730,
    -791,  -791,  -791,  -791,   588,   585,   578,  -791,  -791,  -791,
    -791,  -791,   729,   178,   613,  -791,  -791,  -791,  -791,    31,
    -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
    1995,  -791,  -791,  -791,  -791,  -791,    65,   365,   735,   107,
    -791,   559,   154,  -791,  -791,   365,   748,  -791,  -791,  1877,
     241,  1158,    36,    46,  -791,   544,   559,  1276,  -791,  -791,
    -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,   753,
     754,   757,   758,   764,   765,   241,   365,   767,   728,   769,
     770,    17,  -791,  -791,   491,   491,  -791,   707,  -791,   735,
     170,  -791,   654,   778,   678,   685,  -791,  -791,  -791,  -791,
    -791,  -791,  -791,  -791,  -791,  -791,    62,  -791,  -791,  -791,
    -791,  -791,  -791,  -791,  -791,   241,    62,   241,   683,   335,
    -791,   427,  -791,   542,    17,    17,   154,  -791,  -791,  -791,
    -791,  -791,    17,  -791,   486,  -791,  -791,  -791,   559,   777,
     782,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
    -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,   146,
    -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
    -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
    -791,  -791,  -791,    69,  -791,   348,  -791,  -791,   456,  -791,
     788,  -791,  -791,   542,   789,  -791,  -791,  -791,  -791,   751,
    -791,   257,  -791,  -791,   262,   262,   262,   262,  -791,  -791,
    -791,  -791,  -791,   262,   262,   262,  -791,  -791,  -791,  -791,
    -791,   542,  -791,  -791,  -791,  -791,  -791,  2050,    17,  -791,
      17,   154,  -791,  -791,   796,  -791,  -791,   365,  -791,   797,
    -791,  -791,  -791,   365,    62,   698,  -791,  -791,   799,   801,
     802,   807,  -791,   397,    62,    62,  -791,  -791,  -791,  -791,
    -791,   559,   803,  -791,  -791,    62,  -791,    86,   809,   812,
     813,   814,   815,   817,   818,   827,  -791,   542,  -791,   240,
      62,    96,   262,   828,  1877,  1877,  1877,  1877,  1877,  1877,
    1877,  1315,    78,   808,   830,   831,  -791,  -791,  2050,  -791,
    -791,    62,  -791,  -791,    17,  -791,   559,   825,   838,   542,
    -791,   849,    62,  -791,    91,    91,    91,    47,    47,    91,
      91,   141,   834,   836,   703,   759,   760,   857,  1877,    17,
    1363,  1363,  1363,  1363,  1363,  1363,  1363,  -791,   154,  -791,
    -791,    17,    90,   761,   862,   237,  -791,  -791,  -791,   858,
     863,   866,   867,   868,   869,   870,   874,   875,   876,   878,
    -791,  -791,    62,    62,    62,  -791,  1600,   880,   881,   841,
     887,   847,   892,   851,   894,   853,   896,   855,   898,   859,
     899,   861,   900,   655,   905,   365,    62,  -791,   559,  -791,
    -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
    -791,   906,   907,   908,   883,   735,    17,   154,    17,   154,
      17,   154,    17,   154,    17,   154,    17,   154,    17,   154,
      17,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
    -791,  -791,  -791,  -791,  -791,  -791,   409,  -791,  -791,  -791,
     154,  -791,   917,   927,   929,   931,   930,   933,   936,   937,
     942,   943,   945,   946,   948,   949,   951,   559,   955,  -791,
      17,  -791,    17,  -791,    17,  -791,    17,  -791,    17,  -791,
      17,  -791,    17,  -791,   231,    17,   952,   961,   963,   965,
     967,   969,   971,   666,  -791,   973,  -791,  -791,  -791,  -791,
    -791,  -791,  -791,  -791,  -791
};

/* YYPGOTO[NTERM-NUM].  */
static const yytype_int16 yypgoto[] =
{
    -791,  -791,   902,  -791,  -162,    14,     9,  -791,  -791,  -791,
    -791,  -791,  -791,  -207,  -791,  -791,  -791,  -791,   484,  -791,
    -201,  -791,  -692,  -791,  -791,  -791,  -791,   692,   713,  -791,
    -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -189,  -791,
    -507,    -2,   781,  -791,   -90,  -791,  -791,   -95,  -791,  -791,
     586,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -791,  -131,
    -206,    32,  -791,  -791,  -791,   597,   -17,   983,  -791,  -245,
     -16,  -791,  -791,  -791,   -56,  -791,  -120,  -791,   301,   -11,
    -113,  -452,   -84,   -12,  -791,  -790,  -791,   -54,  -791,   411,
    -388,   -67,  -791,     0,  -225,  -267,    30,  -791,   353,  -791,
      74,  -791,  1009,    21,  -791,  -791,   283,   739,  -791,  -791,
    -791,  -791,   732,  -791,  -791,  -791,  -791,  -791,  -791,  -791,
    -791,   667,   505,  -791,  -791,  -791,  -791,  -791
};

/* YYTABLE[YYPACT[STATE-NUM]].  What to do in state STATE-NUM.  If
   positive, shift that token.  If negative, reduce the rule which
   number is the opposite.  If YYTABLE_NINF, syntax error.  */
#define YYTABLE_NINF -343
static const yytype_int16 yytable[] =
{
      70,   157,   413,    74,    49,    50,    51,   333,   384,   196,
     171,    26,   200,   199,   386,   268,    25,   403,   107,   108,
     409,    98,   451,    42,   452,   124,   389,   868,   252,   687,
      48,    66,    40,    67,    38,   605,   319,    68,    66,   320,
      67,   331,   132,   277,    68,    48,   163,     4,   168,   202,
     479,   487,   130,   480,    54,   405,  -333,     4,   172,    10,
     448,    54,   405,   426,   833,   424,  -184,   922,   497,    48,
     331,     9,   174,    10,   842,   746,   504,   197,   772,   773,
     311,     9,     3,    10,   310,   412,   604,   337,   204,   208,
     211,   304,   312,   608,   406,   751,   286,   236,    54,   290,
     292,   294,   296,    48,   814,   891,   332,   298,   405,   815,
      66,   331,    67,   892,    48,    48,    68,   968,   173,    52,
     942,   313,   815,   308,   834,   835,   836,   837,   331,  1015,
      66,   943,    67,   467,   815,    56,    68,   843,   972,   844,
     845,    72,    10,   954,   367,   323,   456,    73,   686,   564,
     598,   318,   749,   321,   820,    10,   605,    66,   334,    67,
     425,   372,   338,    68,   752,   343,   415,  -342,   307,   173,
     418,   397,   399,    66,    66,    67,    67,   438,    48,   555,
      68,    48,   203,   534,   416,   498,   401,   774,   775,   173,
     504,   331,   173,   886,   887,   730,   488,   120,   616,    75,
     498,   407,   408,   371,   173,   439,   711,   617,   407,   408,
     325,   173,   307,   173,   325,    99,   497,   816,   173,   157,
     776,   450,   893,    26,   383,   588,   489,    77,    25,   382,
     816,   404,   536,    79,   411,    42,   392,   515,   398,   400,
     610,   402,   816,   490,    40,   391,    38,   390,  -342,  -342,
     102,   417,   955,   956,   407,   408,   419,   420,   441,   105,
      66,   422,    67,   481,   894,   504,   869,   131,   611,   495,
    1114,   504,   440,  1018,    21,    57,  1019,   205,   206,   207,
     505,   106,   446,   447,    21,   314,   315,   580,   282,   699,
     700,   701,   283,   453,   527,   454,   486,   589,    58,   749,
     519,   325,   888,   889,   570,   571,   572,   493,   325,   461,
     461,   477,   482,   496,   125,   562,   325,   541,   326,   327,
     710,   126,   326,   327,   308,    58,   865,   866,   821,   822,
     462,   268,   285,   498,   542,   890,   283,    19,    20,   567,
      66,   539,    67,  1071,   921,   468,    68,   549,   769,   770,
     543,   458,   459,   460,   469,    48,   127,   546,   457,   277,
      59,   524,   821,   822,   458,   459,   460,   568,    66,    66,
      67,    67,    66,   128,    67,    68,   525,   526,    68,   328,
     329,   330,   895,   328,   329,   330,   622,    59,   129,   619,
     620,   209,   210,   896,   316,   317,   540,   547,   133,   169,
      60,    61,    62,   630,   173,   112,   113,   175,    69,   326,
     327,   615,   201,   325,   550,   289,   326,   327,    66,   283,
      67,   552,    48,   554,   612,   327,   212,    60,    61,    62,
      66,   504,    67,   936,   569,    66,    68,    67,   213,   268,
     723,    68,   252,   504,   675,  1087,   216,   753,   291,   591,
     592,   217,   283,   293,   595,   610,   596,   283,   587,   708,
     331,   676,   665,   287,   597,   703,   288,   277,   602,   600,
     328,   329,   330,   492,   384,   297,   599,   328,   329,   330,
     386,   607,   299,   611,   614,   328,   329,   330,   306,    66,
     309,    67,   389,   322,    66,    68,    67,   724,    48,   324,
     339,   295,   720,   898,   899,   283,   726,   823,   350,   114,
     352,   115,   116,   117,   118,   119,   504,   679,   120,   680,
     669,   326,   327,   368,   851,   421,   443,    66,   705,    67,
     318,   423,   614,    68,    58,   369,   370,   704,   702,   750,
     705,   707,   394,   414,   709,   474,   677,   678,   475,   716,
     444,   445,   449,   718,    10,   455,   824,   763,   468,   485,
     728,   491,   729,   331,   725,   731,   732,   733,   734,   502,
     476,   503,   850,   909,   727,   475,   504,   506,   340,   341,
     507,    10,   328,   329,   330,   516,   735,   745,   518,   523,
     747,   864,   531,   342,   532,   533,    59,   476,   535,   573,
     817,   544,   545,     4,   553,   574,   883,   900,   830,   551,
     901,   902,   903,   904,   905,   906,   120,   560,   758,   575,
     374,   577,   579,   111,   578,   831,   581,     9,   582,    10,
     164,   165,   166,   167,   878,   879,    60,    61,    62,   859,
     583,   584,   881,   112,   113,   375,   585,   549,   549,   344,
     345,   882,   590,   870,   593,   586,   907,   427,   428,   429,
     430,   705,   594,   601,   609,   346,   347,   348,   349,   825,
     829,   376,   377,   378,   603,   606,    16,   621,   667,   379,
     984,   986,  1051,   618,   380,   623,   670,    17,   671,   712,
     383,   839,   847,  1123,   477,   382,   838,   846,   717,   672,
     706,   714,   392,   841,   849,   624,   625,   626,   627,   628,
     713,   391,   715,   390,   550,   550,   509,   510,   721,   980,
     981,   982,   983,   985,   987,   988,   719,   722,   283,   939,
     737,   381,   511,   512,   513,   514,   875,   738,   923,   739,
     924,    18,   736,   740,   743,   705,   876,   114,   741,   115,
     116,   117,   118,   119,   880,   742,   120,   744,   748,   756,
     754,   755,   759,   760,   913,   761,   764,   762,   765,   768,
     767,   771,   766,   818,   975,  -115,  1052,  1053,  1054,  1055,
    1056,  1057,  1058,  1059,  1060,  1061,  1062,  1052,  1053,  1054,
    1055,  1056,  1057,  1058,  1059,  1060,  1061,  1062,   853,   854,
     927,   665,   855,   856,   857,   858,   929,   860,   862,   863,
     861,    19,    20,   867,   974,   897,   555,   872,   688,   304,
     873,   884,   914,   915,   916,   917,   885,   874,   910,   911,
      21,   918,   919,   920,   912,   926,   931,   928,   932,   997,
     933,   992,   934,   689,   690,   691,   935,   969,   940,   944,
     705,  1014,   945,   946,   947,   948,  1066,   949,   950,   925,
     960,   961,   962,   963,   964,   965,   966,   951,   959,   970,
     976,   971,   665,   990,   930,   991,   999,  1001,  1003,  1005,
    1007,  1009,  1011,   977,   937,   938,   692,   693,   694,   695,
     696,   697,   698,   952,   978,   941,   995,   993,   994,  1016,
     958,  1017,  1021,  1020,   996,  1022,  1023,  1024,  1025,  1026,
     953,   957,  1034,  1027,  1028,  1029,  1072,  1030,  1074,  1035,
    1076,  1036,  1078,  1037,  1080,  1104,  1082,  1038,  1084,  1039,
    1086,   973,  1040,  1041,  1042,  1043,  1044,  1045,  1046,  1048,
    1050,  1047,   979,  1049,  1063,  1067,  1068,  1069,  1064,   614,
     614,   614,   614,   614,   614,   614,  1089,   705,   998,  1000,
    1002,  1004,  1006,  1008,  1010,  1070,  1012,  1090,  1091,  1093,
    1106,  1092,  1107,  1094,  1108,  1095,  1109,  1096,  1110,     4,
    1111,  1097,  1112,  1098,  1099,  1115,  1100,  1101,   442,  1102,
    1103,  1116,  1031,  1032,  1033,  1105,   373,     5,     6,     7,
    1117,     8,  1118,     9,  1119,    10,  1120,   214,  1121,    11,
    1122,    12,  1124,  1113,   494,   681,  1065,   395,   563,    13,
      14,    15,   122,   871,   828,   989,   705,   757,   705,    97,
     705,   877,   705,   471,   705,  1073,   705,  1075,   705,  1077,
     685,  1079,   576,  1081,   484,  1083,     0,  1085,   530,     0,
       0,     4,    16,     0,     0,     0,     0,     0,     0,   705,
       0,     0,     0,    17,     0,     0,     0,     0,  1088,     5,
       6,     7,     0,     8,     0,     9,     0,    10,     0,     0,
       0,    11,     0,    12,     0,     0,    66,     0,    67,     0,
       0,    13,    14,    15,     4,   237,   238,   239,   240,   241,
     242,   243,   244,   245,   246,   247,   248,   249,   250,   251,
     252,   253,     0,     0,     0,     0,     0,    18,     9,    66,
      10,    67,     0,     0,    16,     0,     0,     0,     0,     0,
       0,     0,     0,     0,    66,    17,    67,     0,     0,     0,
       0,     0,     4,   237,   238,   239,   240,   241,   242,   243,
     244,   245,   246,   247,   248,   249,   250,   251,   252,   561,
       0,     0,     0,     0,   254,     0,     9,     0,    10,     4,
     177,   178,   179,   180,   181,   182,   183,   184,   185,   186,
     187,   188,   189,   190,   191,   192,   832,    19,    20,    18,
     193,   194,   195,     9,     0,    10,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,    21,     0,     0,    22,
       0,   375,   254,     0,     0,   255,   256,   257,    23,   258,
     259,     0,   260,   261,   262,     0,   263,     0,     0,     0,
       0,     0,    18,     0,     0,     0,     0,   376,   377,   378,
       0,     0,    16,     0,     0,   379,     0,     0,     0,     0,
     380,     0,     0,    17,     0,     0,     0,     0,     0,    19,
      20,     0,     0,   255,   256,   257,     0,   258,   259,     0,
     260,   261,   262,     0,   263,     0,     0,     0,    21,     0,
      18,    22,     0,     0,     0,     0,     0,     0,     0,     0,
      23,     0,     0,     0,     0,     0,     0,   381,     0,     0,
       0,     0,    19,    20,     0,     0,     0,    18,     0,     0,
       0,     0,     0,     0,    66,   852,    67,     0,     0,     0,
       0,    21,     4,   237,   238,   239,   240,   241,   242,   243,
     244,   245,   246,   247,   248,   249,   250,   251,   252,   684,
     689,   690,   691,     0,     0,     0,     9,     0,    10,     0,
      19,    20,     0,    66,   967,    67,     0,     0,     0,    68,
       0,     0,     0,     0,     0,     0,    66,     0,    67,    21,
       0,     0,    68,     0,     0,     0,     0,    19,    20,   689,
     690,   691,     0,   692,   693,   694,   695,   696,   697,   698,
       0,     0,   254,     0,   335,     0,    21,   135,   136,     0,
       0,     0,     0,     0,     0,     0,   137,   335,     0,     0,
     135,   136,     0,     0,     0,     0,     0,     0,     0,   137,
       0,     0,   692,   693,   694,   695,   696,   697,   698,     0,
       0,     0,     0,     0,     0,     0,   610,     0,     0,     0,
       0,     0,     0,   255,   256,   257,     0,   258,   259,   610,
     260,   261,   262,     0,   263,     0,     0,     0,     0,     0,
      18,     0,     0,     0,   611,     0,     0,     0,     0,     0,
       0,   139,     0,     0,     0,     0,     0,   611,     0,     0,
       0,     0,     0,     0,   139,     0,     0,     0,    66,     0,
      67,     0,     0,     0,    68,     0,     0,     0,     0,     0,
       0,   140,   612,   327,   141,   142,   143,   144,   145,     0,
       0,   146,     0,     0,   140,   326,   327,   141,   142,   143,
     144,   145,     0,     0,   146,   147,     0,   148,     0,   335,
      19,    20,   135,   136,     0,     0,     0,     0,   147,     0,
     148,   137,     0,     0,     0,     0,     0,     0,     0,    21,
       0,     0,     0,     0,     0,     0,     0,     0,     0,   149,
     150,   151,   152,   328,   329,   330,   153,   154,     0,     0,
       0,   336,   149,   150,   151,   152,   328,   329,   330,   153,
     154,    81,    82,    83,    84,    85,    86,    87,    88,    89,
      90,    91,    92,    93,    94,    95,     0,     0,     0,     0,
       0,     0,     0,    66,     0,    67,   139,     0,     0,    68,
       0,     0,     0,     0,    66,     0,    67,     0,     0,     0,
      68,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,   140,   326,   327,   141,
     142,   143,   144,   145,   335,     0,   146,   135,   136,     0,
       0,     0,     0,     0,     0,   134,   137,     0,   135,   136,
     147,     0,   148,     0,     0,     0,     0,   137,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,    66,     0,
      67,     0,     0,     0,    68,     0,   673,   674,     0,     0,
       0,     0,     0,     0,   149,   150,   151,   152,   328,   329,
     330,   153,   154,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,   134,
       0,   139,   135,   136,     0,     0,     0,     0,     0,     0,
       0,   137,   139,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,   140,   326,   327,   141,   142,   143,   144,   145,     0,
     138,   146,   140,     0,     0,   141,   142,   143,   144,   145,
       0,     0,   146,     0,     0,   147,     0,   148,     0,     0,
       0,     0,     0,     0,     0,     0,   147,     0,   148,     0,
       0,     0,     0,    66,     0,    67,   139,     0,     0,    68,
       0,     0,     0,     0,     0,     0,     0,     0,     0,   149,
     150,   151,   152,   328,   329,   330,   153,   154,     0,     0,
     149,   150,   151,   152,     0,     0,   140,   153,   154,   141,
     142,   143,   144,   145,   134,     0,   146,   135,   136,     0,
       0,     0,     0,     0,     0,   538,   137,     0,   135,   136,
     147,     0,   148,     0,     0,     0,     0,   137,   218,   219,
       0,     0,     0,     0,   220,     0,     0,    58,     0,     0,
       0,     0,     0,     0,   221,   222,   223,   224,     0,   225,
     226,     0,     0,     0,   149,   150,   151,   152,     0,     0,
       0,   153,   154,     0,     0,     0,     0,     0,     0,     0,
       0,   227,   228,   229,   230,   231,   232,   233,   234,   235,
       0,   139,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,   139,     0,   135,   136,     0,     0,     0,    59,
       0,     0,     0,   137,     0,     0,     0,     0,     0,     0,
       0,   140,     0,     0,   141,   142,   143,   144,   145,     0,
       0,   146,   140,     0,     0,   141,   142,   143,   144,   145,
       0,     0,   146,     0,     0,   147,     0,   148,     0,    60,
      61,    62,     0,     0,     0,     0,   147,     0,   148,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,   135,   136,   139,   149,
     150,   151,   152,   353,   354,   137,   153,   154,     0,     0,
     149,   150,   151,   152,     0,     0,     0,   153,   154,   355,
     356,   357,   358,     0,   359,   360,     0,     0,   140,     0,
       0,   141,   142,   143,   144,   145,     0,     0,   146,     0,
       0,     0,   777,   778,     0,   361,   362,     0,     0,   363,
       0,     0,   147,     0,   148,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,   364,   365,   366,
     139,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,   149,   150,   151,   152,
       0,     0,     0,   153,   154,     0,     0,   631,   632,     0,
     140,     0,     0,   141,   142,   143,   144,   145,   633,     0,
     146,     0,     0,     0,   634,     0,     0,     0,     0,   635,
       0,     0,     0,     0,   147,     0,   148,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,   779,     0,   780,
     781,   782,   783,   784,     0,     0,   636,     0,   149,   150,
     151,   152,     0,     0,     0,   153,   154,   785,   786,     0,
     787,   788,   789,   790,   791,   792,   793,   794,     0,     0,
     795,   796,     0,   797,   798,     0,     0,     0,     0,   799,
       0,   800,   801,   802,   803,   804,   805,   806,   807,   808,
     809,   810,   811,   812,   637,   638,   639,   640,   641,     0,
       0,   146,     0,     0,     0,     0,     0,     0,   642,   643,
       0,     0,   644,   645,   646,   647,   648,   649,   650,   651,
     652,   653,   654,   655,   656,   657,   658,   659,   660,   661,
     662,   663,     0,   664
};

#define yypact_value_is_default(yystate) \
  ((yystate) == (-791))

#define yytable_value_is_error(yytable_value) \
  YYID (0)

static const yytype_int16 yycheck[] =
{
      11,    57,   247,    14,     4,     5,     6,   169,   215,    76,
      64,     2,    96,    80,   215,   110,     2,   242,    34,    35,
     245,    21,   289,     2,   291,    41,   215,   719,    27,   536,
       7,     3,     2,     5,     2,   487,   149,     9,     3,   152,
       5,     4,    53,   110,     9,     7,    58,    11,    60,     5,
      28,    45,    52,    31,     7,     8,    39,    11,    69,    37,
     285,     7,     8,   269,    28,    40,    40,   857,    45,     7,
       4,    35,    72,    37,    28,    46,    34,    77,    47,    48,
     177,    35,     0,    37,   138,   247,    45,   171,    99,   100,
     101,   136,   189,    45,    40,    45,   113,   109,     7,   116,
     117,   118,   119,     7,    39,    36,    40,   123,     8,    44,
       3,     4,     5,    44,     7,     7,     9,    39,   163,    32,
      34,   218,    44,   134,    88,    89,    90,    91,     4,    39,
       3,    45,     5,    28,    44,     5,     9,    91,   928,    93,
      94,    44,    37,    47,   198,   157,    28,    38,   106,   148,
      42,    44,   604,   153,    47,    37,   608,     3,   170,     5,
     135,   106,   173,     9,    40,   176,   250,    82,    41,   163,
     254,   238,   239,     3,     3,     5,     5,   272,     7,   162,
       9,     7,   138,   389,   251,   162,   240,   156,   157,   163,
      34,     4,   163,    47,    48,    39,   309,   160,    36,    42,
     162,   154,   155,   203,   163,   272,    40,    45,   154,   155,
      44,   163,    41,   163,    44,    42,    45,   152,   163,   275,
     189,   288,   153,   214,   215,    38,   310,    44,   214,   215,
     152,   243,   394,   150,   246,   214,   215,   350,   238,   239,
      86,   241,   152,   310,   214,   215,   214,   215,   163,   164,
      10,   251,   156,   157,   154,   155,   256,   257,   274,    27,
       3,   261,     5,   241,   195,    34,    96,   239,   114,   323,
      39,    34,   272,    36,   238,    40,    39,   242,   243,   244,
     334,    27,   282,   283,   238,    47,    48,   449,    40,   115,
     116,   117,    44,   293,   378,   295,   307,   459,    63,   751,
     367,    44,   156,   157,   435,   436,   437,   318,    44,   300,
     301,   302,   303,   324,    27,   428,    44,   401,   152,   153,
     545,    27,   152,   153,   335,    63,   714,   715,   221,   222,
     300,   426,    40,   162,   401,   189,    44,   219,   220,   434,
       3,   395,     5,  1035,   851,   240,     9,   414,   170,   171,
     404,   246,   247,   248,   249,     7,    27,   411,   240,   426,
     125,   372,   221,   222,   246,   247,   248,   434,     3,     3,
       5,     5,     3,    27,     5,     9,   376,   377,     9,   213,
     214,   215,    34,   213,   214,   215,   506,   125,     4,   502,
     503,    54,    55,    45,   156,   157,   396,   413,    36,    38,
     165,   166,   167,   516,   163,    47,    48,    40,    42,   152,
     153,   495,    38,    44,   414,    40,   152,   153,     3,    44,
       5,   421,     7,   423,   152,   153,    39,   165,   166,   167,
       3,    34,     5,    36,   434,     3,     9,     5,    10,   534,
     560,     9,    27,    34,   528,    36,    39,   609,    40,   465,
     466,    39,    44,    40,   470,    86,   472,    44,   458,   543,
       4,   528,   518,   152,   475,    96,    40,   534,   484,   480,
     213,   214,   215,    41,   681,    40,   476,   213,   214,   215,
     681,   492,    39,   114,   495,   213,   214,   215,     5,     3,
     209,     5,   681,    39,     3,     9,     5,   564,     7,   164,
      45,    40,   556,    47,    48,    44,   573,   669,    77,   151,
      45,   153,   154,   155,   156,   157,    34,   529,   160,   530,
      38,   152,   153,    38,   686,    44,   138,     3,   539,     5,
      44,    44,   543,     9,    63,    40,    40,   539,   538,   606,
     551,   543,    40,    40,   544,    28,    75,    76,    31,   551,
      28,    36,    40,   553,    37,    39,   669,   624,   240,    36,
     577,   189,   579,     4,   564,   582,   583,   584,   585,    40,
      53,    40,    28,   818,   574,    31,    34,    40,    54,    55,
      82,    37,   213,   214,   215,    78,   586,   598,    40,     5,
     601,   711,    27,    69,    27,    27,   125,    53,    27,   142,
     667,    40,    40,    11,   138,   142,   768,   151,   675,    82,
     154,   155,   156,   157,   158,   159,   160,    40,   618,    39,
      28,    39,    39,    27,    45,   679,    39,    35,    39,    37,
     110,   111,   112,   113,   754,   755,   165,   166,   167,   706,
      39,    39,   762,    47,    48,    53,    39,   714,   715,    54,
      55,   764,    38,   720,    38,   245,   818,   144,   145,   146,
     147,   672,    38,    42,    38,    70,    71,    72,    73,   669,
     672,    79,    80,    81,     5,    82,    84,     4,    46,    87,
     947,   948,    27,   162,    92,    86,    39,    95,    36,    39,
     681,   682,   683,    27,   685,   681,   682,   683,    45,    82,
      82,    36,   681,   682,   683,    46,    47,    48,    49,    50,
      39,   681,    36,   681,   714,   715,    54,    55,    39,   944,
     945,   946,   947,   948,   949,   950,    45,    36,    44,   891,
      40,   139,    70,    71,    72,    73,   736,    40,   858,    39,
     860,   149,   138,    39,    39,   756,   746,   151,    40,   153,
     154,   155,   156,   157,   756,    40,   160,    39,    39,    82,
      40,    40,    39,    39,   831,    39,    36,    40,   180,    40,
     192,   158,   187,    38,   936,    27,   121,   122,   123,   124,
     125,   126,   127,   128,   129,   130,   131,   121,   122,   123,
     124,   125,   126,   127,   128,   129,   130,   131,    45,    45,
     867,   857,    45,    45,    40,    40,   873,    40,    39,    39,
      82,   219,   220,   106,   934,   815,   162,    39,    39,   136,
     142,    44,   834,   835,   836,   837,    44,   142,    40,    40,
     238,   843,   844,   845,    83,    39,   138,    40,    39,   959,
      39,   138,    40,    64,    65,    66,    39,    39,    45,    40,
     861,   971,    40,    40,    40,    40,  1018,    40,    40,   861,
     914,   915,   916,   917,   918,   919,   920,    40,    40,    39,
      45,    40,   928,    39,   874,    39,   960,   961,   962,   963,
     964,   965,   966,    45,   884,   885,   107,   108,   109,   110,
     111,   112,   113,   909,    45,   895,    39,   138,   138,   138,
     912,    39,    39,    45,   958,    39,    39,    39,    39,    39,
     910,   911,   996,    39,    39,    39,  1036,    39,  1038,    39,
    1040,    40,  1042,    82,  1044,  1087,  1046,    40,  1048,    82,
    1050,   931,    40,    82,    40,    82,    40,    82,    40,    40,
      40,    82,   942,    82,    39,    39,    39,    39,  1015,   960,
     961,   962,   963,   964,   965,   966,    39,   968,   960,   961,
     962,   963,   964,   965,   966,    82,   968,    40,    39,    39,
    1090,    40,  1092,    40,  1094,    39,  1096,    40,  1098,    11,
    1100,    39,  1102,    40,    39,  1105,    40,    39,   275,    40,
      39,    39,   992,   993,   994,    40,    28,    29,    30,    31,
      39,    33,    39,    35,    39,    37,    39,   105,    39,    41,
      39,    43,    39,  1103,   322,   531,  1016,   236,   432,    51,
      52,    53,    39,   722,   671,   951,  1037,   616,  1039,    20,
    1041,   748,  1043,   301,  1045,  1037,  1047,  1039,  1049,  1041,
     535,  1043,   445,  1045,   305,  1047,    -1,  1049,   381,    -1,
      -1,    11,    84,    -1,    -1,    -1,    -1,    -1,    -1,  1070,
      -1,    -1,    -1,    95,    -1,    -1,    -1,    -1,  1070,    29,
      30,    31,    -1,    33,    -1,    35,    -1,    37,    -1,    -1,
      -1,    41,    -1,    43,    -1,    -1,     3,    -1,     5,    -1,
      -1,    51,    52,    53,    11,    12,    13,    14,    15,    16,
      17,    18,    19,    20,    21,    22,    23,    24,    25,    26,
      27,    28,    -1,    -1,    -1,    -1,    -1,   149,    35,     3,
      37,     5,    -1,    -1,    84,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,     3,    95,     5,    -1,    -1,    -1,
      -1,    -1,    11,    12,    13,    14,    15,    16,    17,    18,
      19,    20,    21,    22,    23,    24,    25,    26,    27,    28,
      -1,    -1,    -1,    -1,    81,    -1,    35,    -1,    37,    11,
      54,    55,    56,    57,    58,    59,    60,    61,    62,    63,
      64,    65,    66,    67,    68,    69,    28,   219,   220,   149,
      74,    75,    76,    35,    -1,    37,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,   238,    -1,    -1,   241,
      -1,    53,    81,    -1,    -1,   132,   133,   134,   250,   136,
     137,    -1,   139,   140,   141,    -1,   143,    -1,    -1,    -1,
      -1,    -1,   149,    -1,    -1,    -1,    -1,    79,    80,    81,
      -1,    -1,    84,    -1,    -1,    87,    -1,    -1,    -1,    -1,
      92,    -1,    -1,    95,    -1,    -1,    -1,    -1,    -1,   219,
     220,    -1,    -1,   132,   133,   134,    -1,   136,   137,    -1,
     139,   140,   141,    -1,   143,    -1,    -1,    -1,   238,    -1,
     149,   241,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
     250,    -1,    -1,    -1,    -1,    -1,    -1,   139,    -1,    -1,
      -1,    -1,   219,   220,    -1,    -1,    -1,   149,    -1,    -1,
      -1,    -1,    -1,    -1,     3,    39,     5,    -1,    -1,    -1,
      -1,   238,    11,    12,    13,    14,    15,    16,    17,    18,
      19,    20,    21,    22,    23,    24,    25,    26,    27,    28,
      64,    65,    66,    -1,    -1,    -1,    35,    -1,    37,    -1,
     219,   220,    -1,     3,    39,     5,    -1,    -1,    -1,     9,
      -1,    -1,    -1,    -1,    -1,    -1,     3,    -1,     5,   238,
      -1,    -1,     9,    -1,    -1,    -1,    -1,   219,   220,    64,
      65,    66,    -1,   107,   108,   109,   110,   111,   112,   113,
      -1,    -1,    81,    -1,    44,    -1,   238,    47,    48,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    56,    44,    -1,    -1,
      47,    48,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    56,
      -1,    -1,   107,   108,   109,   110,   111,   112,   113,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    86,    -1,    -1,    -1,
      -1,    -1,    -1,   132,   133,   134,    -1,   136,   137,    86,
     139,   140,   141,    -1,   143,    -1,    -1,    -1,    -1,    -1,
     149,    -1,    -1,    -1,   114,    -1,    -1,    -1,    -1,    -1,
      -1,   121,    -1,    -1,    -1,    -1,    -1,   114,    -1,    -1,
      -1,    -1,    -1,    -1,   121,    -1,    -1,    -1,     3,    -1,
       5,    -1,    -1,    -1,     9,    -1,    -1,    -1,    -1,    -1,
      -1,   151,   152,   153,   154,   155,   156,   157,   158,    -1,
      -1,   161,    -1,    -1,   151,   152,   153,   154,   155,   156,
     157,   158,    -1,    -1,   161,   175,    -1,   177,    -1,    44,
     219,   220,    47,    48,    -1,    -1,    -1,    -1,   175,    -1,
     177,    56,    -1,    -1,    -1,    -1,    -1,    -1,    -1,   238,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,   209,
     210,   211,   212,   213,   214,   215,   216,   217,    -1,    -1,
      -1,    86,   209,   210,   211,   212,   213,   214,   215,   216,
     217,   223,   224,   225,   226,   227,   228,   229,   230,   231,
     232,   233,   234,   235,   236,   237,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,     3,    -1,     5,   121,    -1,    -1,     9,
      -1,    -1,    -1,    -1,     3,    -1,     5,    -1,    -1,    -1,
       9,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,   151,   152,   153,   154,
     155,   156,   157,   158,    44,    -1,   161,    47,    48,    -1,
      -1,    -1,    -1,    -1,    -1,    44,    56,    -1,    47,    48,
     175,    -1,   177,    -1,    -1,    -1,    -1,    56,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,     3,    -1,
       5,    -1,    -1,    -1,     9,    -1,    75,    76,    -1,    -1,
      -1,    -1,    -1,    -1,   209,   210,   211,   212,   213,   214,
     215,   216,   217,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    44,
      -1,   121,    47,    48,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    56,   121,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,   151,   152,   153,   154,   155,   156,   157,   158,    -1,
      85,   161,   151,    -1,    -1,   154,   155,   156,   157,   158,
      -1,    -1,   161,    -1,    -1,   175,    -1,   177,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,   175,    -1,   177,    -1,
      -1,    -1,    -1,     3,    -1,     5,   121,    -1,    -1,     9,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,   209,
     210,   211,   212,   213,   214,   215,   216,   217,    -1,    -1,
     209,   210,   211,   212,    -1,    -1,   151,   216,   217,   154,
     155,   156,   157,   158,    44,    -1,   161,    47,    48,    -1,
      -1,    -1,    -1,    -1,    -1,    44,    56,    -1,    47,    48,
     175,    -1,   177,    -1,    -1,    -1,    -1,    56,    54,    55,
      -1,    -1,    -1,    -1,    60,    -1,    -1,    63,    -1,    -1,
      -1,    -1,    -1,    -1,    70,    71,    72,    73,    -1,    75,
      76,    -1,    -1,    -1,   209,   210,   211,   212,    -1,    -1,
      -1,   216,   217,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    97,    98,    99,   100,   101,   102,   103,   104,   105,
      -1,   121,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,   121,    -1,    47,    48,    -1,    -1,    -1,   125,
      -1,    -1,    -1,    56,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,   151,    -1,    -1,   154,   155,   156,   157,   158,    -1,
      -1,   161,   151,    -1,    -1,   154,   155,   156,   157,   158,
      -1,    -1,   161,    -1,    -1,   175,    -1,   177,    -1,   165,
     166,   167,    -1,    -1,    -1,    -1,   175,    -1,   177,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    47,    48,   121,   209,
     210,   211,   212,    54,    55,    56,   216,   217,    -1,    -1,
     209,   210,   211,   212,    -1,    -1,    -1,   216,   217,    70,
      71,    72,    73,    -1,    75,    76,    -1,    -1,   151,    -1,
      -1,   154,   155,   156,   157,   158,    -1,    -1,   161,    -1,
      -1,    -1,    47,    48,    -1,    96,    97,    -1,    -1,   100,
      -1,    -1,   175,    -1,   177,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,   118,   119,   120,
     121,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,   209,   210,   211,   212,
      -1,    -1,    -1,   216,   217,    -1,    -1,    47,    48,    -1,
     151,    -1,    -1,   154,   155,   156,   157,   158,    58,    -1,
     161,    -1,    -1,    -1,    64,    -1,    -1,    -1,    -1,    69,
      -1,    -1,    -1,    -1,   175,    -1,   177,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,   152,    -1,   154,
     155,   156,   157,   158,    -1,    -1,   106,    -1,   209,   210,
     211,   212,    -1,    -1,    -1,   216,   217,   172,   173,    -1,
     175,   176,   177,   178,   179,   180,   181,   182,    -1,    -1,
     185,   186,    -1,   188,   189,    -1,    -1,    -1,    -1,   194,
      -1,   196,   197,   198,   199,   200,   201,   202,   203,   204,
     205,   206,   207,   208,   154,   155,   156,   157,   158,    -1,
      -1,   161,    -1,    -1,    -1,    -1,    -1,    -1,   168,   169,
      -1,    -1,   172,   173,   174,   175,   176,   177,   178,   179,
     180,   181,   182,   183,   184,   185,   186,   187,   188,   189,
     190,   191,    -1,   193
};

/* YYSTOS[STATE-NUM] -- The (internal number of the) accessing
   symbol of state STATE-NUM.  */
static const yytype_uint16 yystos[] =
{
       0,   252,   253,     0,    11,    29,    30,    31,    33,    35,
      37,    41,    43,    51,    52,    53,    84,    95,   149,   219,
     220,   238,   241,   250,   254,   256,   257,   258,   259,   261,
     262,   263,   264,   271,   275,   276,   288,   289,   312,   313,
     347,   348,   354,   355,   359,   367,   370,   375,     7,   344,
     344,   344,    32,   356,     7,   345,     5,    40,    63,   125,
     165,   166,   167,   278,   334,   335,     3,     5,     9,    42,
     330,   342,    44,    38,   330,    42,   265,    44,   274,   150,
     314,   223,   224,   225,   226,   227,   228,   229,   230,   231,
     232,   233,   234,   235,   236,   237,   353,   353,   344,    42,
     360,   376,    10,   321,   322,    27,    27,   321,   321,   290,
     311,    27,    47,    48,   151,   153,   154,   155,   156,   157,
     160,   315,   318,   320,   321,    27,    27,    27,    27,     4,
     344,   239,   330,    36,    44,    47,    48,    56,    85,   121,
     151,   154,   155,   156,   157,   158,   161,   175,   177,   209,
     210,   211,   212,   216,   217,   277,   279,   325,   330,   331,
     332,   333,   338,   334,   110,   111,   112,   113,   334,    38,
     325,   338,   330,   163,   344,    40,   372,    54,    55,    56,
      57,    58,    59,    60,    61,    62,    63,    64,    65,    66,
      67,    68,    69,    74,    75,    76,   342,   344,   294,   342,
     333,    38,     5,   138,   330,   242,   243,   244,   330,    54,
      55,   330,    39,    10,   253,   269,    39,    39,    54,    55,
      60,    70,    71,    72,    73,    75,    76,    97,    98,    99,
     100,   101,   102,   103,   104,   105,   334,    12,    13,    14,
      15,    16,    17,    18,    19,    20,    21,    22,    23,    24,
      25,    26,    27,    28,    81,   132,   133,   134,   136,   137,
     139,   140,   141,   143,   256,   257,   296,   297,   298,   299,
     300,   302,   303,   312,   323,   324,   326,   342,   347,   354,
     316,   318,    40,    44,   317,    40,   317,   152,    40,    40,
     317,    40,   317,    40,   317,    40,   317,    40,   321,    39,
     361,   368,   373,   377,   136,   357,     5,    41,   330,   209,
     338,   177,   189,   218,    47,    48,   156,   157,    44,   331,
     331,   344,    39,   334,   164,    44,   152,   153,   213,   214,
     215,     4,    40,   255,   334,    44,    86,   333,   330,    45,
      54,    55,    69,   330,    54,    55,    70,    71,    72,    73,
      77,   266,    45,    54,    55,    70,    71,    72,    73,    75,
      76,    96,    97,   100,   118,   119,   120,   338,    38,    40,
      40,   344,   106,    28,    28,    53,    79,    80,    81,    87,
      92,   139,   256,   257,   264,   270,   271,   280,   284,   289,
     312,   347,   354,   371,    40,   293,   343,   342,   344,   342,
     344,   338,   344,   345,   334,     8,    40,   154,   155,   345,
     346,   334,   255,   320,    40,   333,   342,   344,   333,   344,
     344,    44,   344,    44,    40,   135,   311,   144,   145,   146,
     147,   301,   304,   305,   306,   307,   308,   309,   298,   342,
     344,   321,   279,   138,    28,    36,   344,   344,   345,    40,
     342,   346,   346,   344,   344,    39,    28,   240,   246,   247,
     248,   257,   347,   362,   363,   364,   366,    28,   240,   249,
     358,   363,   365,   369,    28,    31,    53,   257,   374,    28,
      31,   241,   257,   378,   358,    36,   330,    45,   331,   333,
     342,   189,    41,   330,   278,   338,   330,    45,   162,   339,
     340,   344,    40,    40,    34,   338,    40,    82,   260,    54,
      55,    70,    71,    72,    73,   331,    78,   267,    40,   342,
     255,   349,   350,     5,   330,   344,   344,   333,   281,   285,
     372,    27,    27,    27,   311,    27,   255,   291,    44,   338,
     344,   333,   342,   338,    40,    40,   338,   321,   341,   342,
     344,    82,   344,   138,   344,   162,   293,   327,   328,   329,
      40,    28,   331,   301,   148,   298,   310,   298,   342,   344,
     310,   310,   310,   142,   142,    39,   316,    39,    45,    39,
     255,    39,    39,    39,    39,    39,   245,   344,    38,   255,
      38,   321,   321,    38,    38,   321,   321,   330,    42,   344,
     330,    42,   321,     5,    45,   332,    82,   330,    45,    38,
      86,   114,   152,   292,   330,   333,    36,    45,   162,   331,
     331,     4,   327,    86,    46,    47,    48,    49,    50,   268,
     331,    47,    48,    58,    64,    69,   106,   154,   155,   156,
     157,   158,   168,   169,   172,   173,   174,   175,   176,   177,
     178,   179,   180,   181,   182,   183,   184,   185,   186,   187,
     188,   189,   190,   191,   193,   325,   336,    46,   272,    38,
      39,    36,    82,    75,    76,   333,   342,    75,    76,   334,
     330,   269,   282,   286,    28,   373,   106,   291,    39,    64,
      65,    66,   107,   108,   109,   110,   111,   112,   113,   115,
     116,   117,   344,    96,   292,   330,    82,   292,   333,   344,
     345,    40,    39,    39,    36,    36,   292,    45,   344,    45,
     338,    39,    36,   327,   342,   344,   342,   344,   317,   317,
      39,   317,   317,   317,   317,   344,   138,    40,    40,    39,
      39,    40,    40,    39,    39,   330,    46,   330,    39,   332,
     342,    45,    40,   255,    40,    40,    82,   340,   344,    39,
      39,    39,    40,   342,    36,   180,   187,   192,    40,   170,
     171,   158,    47,    48,   156,   157,   189,    47,    48,   152,
     154,   155,   156,   157,   158,   172,   173,   175,   176,   177,
     178,   179,   180,   181,   182,   185,   186,   188,   189,   194,
     196,   197,   198,   199,   200,   201,   202,   203,   204,   205,
     206,   207,   208,   337,    39,    44,   152,   342,    38,   273,
      47,   221,   222,   255,   331,   344,   351,   352,   349,   292,
     342,   338,    28,    28,    88,    89,    90,    91,   256,   257,
     283,   354,    28,    91,    93,    94,   256,   257,   287,   354,
      28,   255,    39,    45,    45,    45,    45,    40,    40,   342,
      40,    82,    39,    39,   327,   341,   341,   106,   273,    96,
     342,   329,    39,   142,   142,   344,   344,   357,   327,   327,
     292,   327,   331,   255,    44,    44,    47,    48,   156,   157,
     189,    36,    44,   153,   195,    34,    45,   344,    47,    48,
     151,   154,   155,   156,   157,   158,   159,   255,   319,   320,
      40,    40,    83,   342,   334,   334,   334,   334,   334,   334,
     334,   291,   336,   327,   327,   292,    39,   342,    40,   342,
     344,   138,    39,    39,    40,    39,    36,   344,   344,   255,
      45,   344,    34,    45,    40,    40,    40,    40,    40,    40,
      40,    40,   321,   344,    47,   156,   157,   344,   334,    40,
     338,   338,   338,   338,   338,   338,   338,    39,    39,    39,
      39,    40,   336,   344,   327,   255,    45,    45,    45,   344,
     345,   345,   345,   345,   346,   345,   346,   345,   345,   351,
      39,    39,   138,   138,   138,    39,   338,   327,   292,   333,
     292,   333,   292,   333,   292,   333,   292,   333,   292,   333,
     292,   333,   292,   295,   327,    39,   138,    39,    36,    39,
      45,    39,    39,    39,    39,    39,    39,    39,    39,    39,
      39,   344,   344,   344,   333,    39,    40,    82,    40,    82,
      40,    82,    40,    82,    40,    82,    40,    82,    40,    82,
      40,    27,   121,   122,   123,   124,   125,   126,   127,   128,
     129,   130,   131,    39,   342,   344,   255,    39,    39,    39,
      82,   273,   327,   292,   327,   292,   327,   292,   327,   292,
     327,   292,   327,   292,   327,   292,   327,    36,   292,    39,
      40,    39,    40,    39,    40,    39,    40,    39,    40,    39,
      40,    39,    40,    39,   255,    40,   327,   327,   327,   327,
     327,   327,   327,   295,    39,   327,    39,    39,    39,    39,
      39,    39,    39,    27,    39
};

#define yyerrok		(yyerrstatus = 0)
#define yyclearin	(yychar = YYEMPTY)
#define YYEMPTY		(-2)
#define YYEOF		0

#define YYACCEPT	goto yyacceptlab
#define YYABORT		goto yyabortlab
#define YYERROR		goto yyerrorlab


/* Like YYERROR except do call yyerror.  This remains here temporarily
   to ease the transition to the new meaning of YYERROR, for GCC.
   Once GCC version 2 has supplanted version 1, this can go.  However,
   YYFAIL appears to be in use.  Nevertheless, it is formally deprecated
   in Bison 2.4.2's NEWS entry, where a plan to phase it out is
   discussed.  */

#define YYFAIL		goto yyerrlab
#if defined YYFAIL
  /* This is here to suppress warnings from the GCC cpp's
     -Wunused-macros.  Normally we don't worry about that warning, but
     some users do, and we want to make it easy for users to remove
     YYFAIL uses, which will produce warnings from Bison 2.5.  */
#endif

#define YYRECOVERING()  (!!yyerrstatus)

#define YYBACKUP(Token, Value)					\
do								\
  if (yychar == YYEMPTY && yylen == 1)				\
    {								\
      yychar = (Token);						\
      yylval = (Value);						\
      YYPOPSTACK (1);						\
      goto yybackup;						\
    }								\
  else								\
    {								\
      yyerror (YY_("syntax error: cannot back up")); \
      YYERROR;							\
    }								\
while (YYID (0))


#define YYTERROR	1
#define YYERRCODE	256


/* YYLLOC_DEFAULT -- Set CURRENT to span from RHS[1] to RHS[N].
   If N is 0, then set CURRENT to the empty location which ends
   the previous symbol: RHS[0] (always defined).  */

#define YYRHSLOC(Rhs, K) ((Rhs)[K])
#ifndef YYLLOC_DEFAULT
# define YYLLOC_DEFAULT(Current, Rhs, N)				\
    do									\
      if (YYID (N))                                                    \
	{								\
	  (Current).first_line   = YYRHSLOC (Rhs, 1).first_line;	\
	  (Current).first_column = YYRHSLOC (Rhs, 1).first_column;	\
	  (Current).last_line    = YYRHSLOC (Rhs, N).last_line;		\
	  (Current).last_column  = YYRHSLOC (Rhs, N).last_column;	\
	}								\
      else								\
	{								\
	  (Current).first_line   = (Current).last_line   =		\
	    YYRHSLOC (Rhs, 0).last_line;				\
	  (Current).first_column = (Current).last_column =		\
	    YYRHSLOC (Rhs, 0).last_column;				\
	}								\
    while (YYID (0))
#endif


/* This macro is provided for backward compatibility. */

#ifndef YY_LOCATION_PRINT
# define YY_LOCATION_PRINT(File, Loc) ((void) 0)
#endif


/* YYLEX -- calling `yylex' with the right arguments.  */

#ifdef YYLEX_PARAM
# define YYLEX yylex (YYLEX_PARAM)
#else
# define YYLEX yylex ()
#endif

/* Enable debugging if requested.  */
#if YYDEBUG

# ifndef YYFPRINTF
#  include <stdio.h> /* INFRINGES ON USER NAME SPACE */
#  define YYFPRINTF fprintf
# endif

# define YYDPRINTF(Args)			\
do {						\
  if (yydebug)					\
    YYFPRINTF Args;				\
} while (YYID (0))

# define YY_SYMBOL_PRINT(Title, Type, Value, Location)			  \
do {									  \
  if (yydebug)								  \
    {									  \
      YYFPRINTF (stderr, "%s ", Title);					  \
      yy_symbol_print (stderr,						  \
		  Type, Value); \
      YYFPRINTF (stderr, "\n");						  \
    }									  \
} while (YYID (0))


/*--------------------------------.
| Print this symbol on YYOUTPUT.  |
`--------------------------------*/

/*ARGSUSED*/
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static void
yy_symbol_value_print (FILE *yyoutput, int yytype, YYSTYPE const * const yyvaluep)
#else
static void
yy_symbol_value_print (yyoutput, yytype, yyvaluep)
    FILE *yyoutput;
    int yytype;
    YYSTYPE const * const yyvaluep;
#endif
{
  if (!yyvaluep)
    return;
# ifdef YYPRINT
  if (yytype < YYNTOKENS)
    YYPRINT (yyoutput, yytoknum[yytype], *yyvaluep);
# else
  YYUSE (yyoutput);
# endif
  switch (yytype)
    {
      default:
	break;
    }
}


/*--------------------------------.
| Print this symbol on YYOUTPUT.  |
`--------------------------------*/

#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static void
yy_symbol_print (FILE *yyoutput, int yytype, YYSTYPE const * const yyvaluep)
#else
static void
yy_symbol_print (yyoutput, yytype, yyvaluep)
    FILE *yyoutput;
    int yytype;
    YYSTYPE const * const yyvaluep;
#endif
{
  if (yytype < YYNTOKENS)
    YYFPRINTF (yyoutput, "token %s (", yytname[yytype]);
  else
    YYFPRINTF (yyoutput, "nterm %s (", yytname[yytype]);

  yy_symbol_value_print (yyoutput, yytype, yyvaluep);
  YYFPRINTF (yyoutput, ")");
}

/*------------------------------------------------------------------.
| yy_stack_print -- Print the state stack from its BOTTOM up to its |
| TOP (included).                                                   |
`------------------------------------------------------------------*/

#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static void
yy_stack_print (yytype_int16 *yybottom, yytype_int16 *yytop)
#else
static void
yy_stack_print (yybottom, yytop)
    yytype_int16 *yybottom;
    yytype_int16 *yytop;
#endif
{
  YYFPRINTF (stderr, "Stack now");
  for (; yybottom <= yytop; yybottom++)
    {
      int yybot = *yybottom;
      YYFPRINTF (stderr, " %d", yybot);
    }
  YYFPRINTF (stderr, "\n");
}

# define YY_STACK_PRINT(Bottom, Top)				\
do {								\
  if (yydebug)							\
    yy_stack_print ((Bottom), (Top));				\
} while (YYID (0))


/*------------------------------------------------.
| Report that the YYRULE is going to be reduced.  |
`------------------------------------------------*/

#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static void
yy_reduce_print (YYSTYPE *yyvsp, int yyrule)
#else
static void
yy_reduce_print (yyvsp, yyrule)
    YYSTYPE *yyvsp;
    int yyrule;
#endif
{
  int yynrhs = yyr2[yyrule];
  int yyi;
  unsigned long int yylno = yyrline[yyrule];
  YYFPRINTF (stderr, "Reducing stack by rule %d (line %lu):\n",
	     yyrule - 1, yylno);
  /* The symbols being reduced.  */
  for (yyi = 0; yyi < yynrhs; yyi++)
    {
      YYFPRINTF (stderr, "   $%d = ", yyi + 1);
      yy_symbol_print (stderr, yyrhs[yyprhs[yyrule] + yyi],
		       &(yyvsp[(yyi + 1) - (yynrhs)])
		       		       );
      YYFPRINTF (stderr, "\n");
    }
}

# define YY_REDUCE_PRINT(Rule)		\
do {					\
  if (yydebug)				\
    yy_reduce_print (yyvsp, Rule); \
} while (YYID (0))

/* Nonzero means print parse trace.  It is left uninitialized so that
   multiple parsers can coexist.  */
int yydebug;
#else /* !YYDEBUG */
# define YYDPRINTF(Args)
# define YY_SYMBOL_PRINT(Title, Type, Value, Location)
# define YY_STACK_PRINT(Bottom, Top)
# define YY_REDUCE_PRINT(Rule)
#endif /* !YYDEBUG */


/* YYINITDEPTH -- initial size of the parser's stacks.  */
#ifndef	YYINITDEPTH
# define YYINITDEPTH 200
#endif

/* YYMAXDEPTH -- maximum size the stacks can grow to (effective only
   if the built-in stack extension method is used).

   Do not make this value too large; the results are undefined if
   YYSTACK_ALLOC_MAXIMUM < YYSTACK_BYTES (YYMAXDEPTH)
   evaluated with infinite-precision integer arithmetic.  */

#ifndef YYMAXDEPTH
# define YYMAXDEPTH 10000
#endif


#if YYERROR_VERBOSE

# ifndef yystrlen
#  if defined __GLIBC__ && defined _STRING_H
#   define yystrlen strlen
#  else
/* Return the length of YYSTR.  */
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static YYSIZE_T
yystrlen (const char *yystr)
#else
static YYSIZE_T
yystrlen (yystr)
    const char *yystr;
#endif
{
  YYSIZE_T yylen;
  for (yylen = 0; yystr[yylen]; yylen++)
    continue;
  return yylen;
}
#  endif
# endif

# ifndef yystpcpy
#  if defined __GLIBC__ && defined _STRING_H && defined _GNU_SOURCE
#   define yystpcpy stpcpy
#  else
/* Copy YYSRC to YYDEST, returning the address of the terminating '\0' in
   YYDEST.  */
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static char *
yystpcpy (char *yydest, const char *yysrc)
#else
static char *
yystpcpy (yydest, yysrc)
    char *yydest;
    const char *yysrc;
#endif
{
  char *yyd = yydest;
  const char *yys = yysrc;

  while ((*yyd++ = *yys++) != '\0')
    continue;

  return yyd - 1;
}
#  endif
# endif

# ifndef yytnamerr
/* Copy to YYRES the contents of YYSTR after stripping away unnecessary
   quotes and backslashes, so that it's suitable for yyerror.  The
   heuristic is that double-quoting is unnecessary unless the string
   contains an apostrophe, a comma, or backslash (other than
   backslash-backslash).  YYSTR is taken from yytname.  If YYRES is
   null, do not copy; instead, return the length of what the result
   would have been.  */
static YYSIZE_T
yytnamerr (char *yyres, const char *yystr)
{
  if (*yystr == '"')
    {
      YYSIZE_T yyn = 0;
      char const *yyp = yystr;

      for (;;)
	switch (*++yyp)
	  {
	  case '\'':
	  case ',':
	    goto do_not_strip_quotes;

	  case '\\':
	    if (*++yyp != '\\')
	      goto do_not_strip_quotes;
	    /* Fall through.  */
	  default:
	    if (yyres)
	      yyres[yyn] = *yyp;
	    yyn++;
	    break;

	  case '"':
	    if (yyres)
	      yyres[yyn] = '\0';
	    return yyn;
	  }
    do_not_strip_quotes: ;
    }

  if (! yyres)
    return yystrlen (yystr);

  return yystpcpy (yyres, yystr) - yyres;
}
# endif

/* Copy into *YYMSG, which is of size *YYMSG_ALLOC, an error message
   about the unexpected token YYTOKEN for the state stack whose top is
   YYSSP.

   Return 0 if *YYMSG was successfully written.  Return 1 if *YYMSG is
   not large enough to hold the message.  In that case, also set
   *YYMSG_ALLOC to the required number of bytes.  Return 2 if the
   required number of bytes is too large to store.  */
static int
yysyntax_error (YYSIZE_T *yymsg_alloc, char **yymsg,
                yytype_int16 *yyssp, int yytoken)
{
  YYSIZE_T yysize0 = yytnamerr (0, yytname[yytoken]);
  YYSIZE_T yysize = yysize0;
  YYSIZE_T yysize1;
  enum { YYERROR_VERBOSE_ARGS_MAXIMUM = 5 };
  /* Internationalized format string. */
  const char *yyformat = 0;
  /* Arguments of yyformat. */
  char const *yyarg[YYERROR_VERBOSE_ARGS_MAXIMUM];
  /* Number of reported tokens (one for the "unexpected", one per
     "expected"). */
  int yycount = 0;

  /* There are many possibilities here to consider:
     - Assume YYFAIL is not used.  It's too flawed to consider.  See
       <http://lists.gnu.org/archive/html/bison-patches/2009-12/msg00024.html>
       for details.  YYERROR is fine as it does not invoke this
       function.
     - If this state is a consistent state with a default action, then
       the only way this function was invoked is if the default action
       is an error action.  In that case, don't check for expected
       tokens because there are none.
     - The only way there can be no lookahead present (in yychar) is if
       this state is a consistent state with a default action.  Thus,
       detecting the absence of a lookahead is sufficient to determine
       that there is no unexpected or expected token to report.  In that
       case, just report a simple "syntax error".
     - Don't assume there isn't a lookahead just because this state is a
       consistent state with a default action.  There might have been a
       previous inconsistent state, consistent state with a non-default
       action, or user semantic action that manipulated yychar.
     - Of course, the expected token list depends on states to have
       correct lookahead information, and it depends on the parser not
       to perform extra reductions after fetching a lookahead from the
       scanner and before detecting a syntax error.  Thus, state merging
       (from LALR or IELR) and default reductions corrupt the expected
       token list.  However, the list is correct for canonical LR with
       one exception: it will still contain any token that will not be
       accepted due to an error action in a later state.
  */
  if (yytoken != YYEMPTY)
    {
      int yyn = yypact[*yyssp];
      yyarg[yycount++] = yytname[yytoken];
      if (!yypact_value_is_default (yyn))
        {
          /* Start YYX at -YYN if negative to avoid negative indexes in
             YYCHECK.  In other words, skip the first -YYN actions for
             this state because they are default actions.  */
          int yyxbegin = yyn < 0 ? -yyn : 0;
          /* Stay within bounds of both yycheck and yytname.  */
          int yychecklim = YYLAST - yyn + 1;
          int yyxend = yychecklim < YYNTOKENS ? yychecklim : YYNTOKENS;
          int yyx;

          for (yyx = yyxbegin; yyx < yyxend; ++yyx)
            if (yycheck[yyx + yyn] == yyx && yyx != YYTERROR
                && !yytable_value_is_error (yytable[yyx + yyn]))
              {
                if (yycount == YYERROR_VERBOSE_ARGS_MAXIMUM)
                  {
                    yycount = 1;
                    yysize = yysize0;
                    break;
                  }
                yyarg[yycount++] = yytname[yyx];
                yysize1 = yysize + yytnamerr (0, yytname[yyx]);
                if (! (yysize <= yysize1
                       && yysize1 <= YYSTACK_ALLOC_MAXIMUM))
                  return 2;
                yysize = yysize1;
              }
        }
    }

  switch (yycount)
    {
# define YYCASE_(N, S)                      \
      case N:                               \
        yyformat = S;                       \
      break
      YYCASE_(0, YY_("syntax error"));
      YYCASE_(1, YY_("syntax error, unexpected %s"));
      YYCASE_(2, YY_("syntax error, unexpected %s, expecting %s"));
      YYCASE_(3, YY_("syntax error, unexpected %s, expecting %s or %s"));
      YYCASE_(4, YY_("syntax error, unexpected %s, expecting %s or %s or %s"));
      YYCASE_(5, YY_("syntax error, unexpected %s, expecting %s or %s or %s or %s"));
# undef YYCASE_
    }

  yysize1 = yysize + yystrlen (yyformat);
  if (! (yysize <= yysize1 && yysize1 <= YYSTACK_ALLOC_MAXIMUM))
    return 2;
  yysize = yysize1;

  if (*yymsg_alloc < yysize)
    {
      *yymsg_alloc = 2 * yysize;
      if (! (yysize <= *yymsg_alloc
             && *yymsg_alloc <= YYSTACK_ALLOC_MAXIMUM))
        *yymsg_alloc = YYSTACK_ALLOC_MAXIMUM;
      return 1;
    }

  /* Avoid sprintf, as that infringes on the user's name space.
     Don't have undefined behavior even if the translation
     produced a string with the wrong number of "%s"s.  */
  {
    char *yyp = *yymsg;
    int yyi = 0;
    while ((*yyp = *yyformat) != '\0')
      if (*yyp == '%' && yyformat[1] == 's' && yyi < yycount)
        {
          yyp += yytnamerr (yyp, yyarg[yyi++]);
          yyformat += 2;
        }
      else
        {
          yyp++;
          yyformat++;
        }
  }
  return 0;
}
#endif /* YYERROR_VERBOSE */

/*-----------------------------------------------.
| Release the memory associated to this symbol.  |
`-----------------------------------------------*/

/*ARGSUSED*/
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static void
yydestruct (const char *yymsg, int yytype, YYSTYPE *yyvaluep)
#else
static void
yydestruct (yymsg, yytype, yyvaluep)
    const char *yymsg;
    int yytype;
    YYSTYPE *yyvaluep;
#endif
{
  YYUSE (yyvaluep);

  if (!yymsg)
    yymsg = "Deleting";
  YY_SYMBOL_PRINT (yymsg, yytype, yyvaluep, yylocationp);

  switch (yytype)
    {

      default:
	break;
    }
}


/* Prevent warnings from -Wmissing-prototypes.  */
#ifdef YYPARSE_PARAM
#if defined __STDC__ || defined __cplusplus
int yyparse (void *YYPARSE_PARAM);
#else
int yyparse ();
#endif
#else /* ! YYPARSE_PARAM */
#if defined __STDC__ || defined __cplusplus
int yyparse (void);
#else
int yyparse ();
#endif
#endif /* ! YYPARSE_PARAM */


/* The lookahead symbol.  */
int yychar;

/* The semantic value of the lookahead symbol.  */
YYSTYPE yylval;

/* Number of syntax errors so far.  */
int yynerrs;


/*----------.
| yyparse.  |
`----------*/

#ifdef YYPARSE_PARAM
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
int
yyparse (void *YYPARSE_PARAM)
#else
int
yyparse (YYPARSE_PARAM)
    void *YYPARSE_PARAM;
#endif
#else /* ! YYPARSE_PARAM */
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
int
yyparse (void)
#else
int
yyparse ()

#endif
#endif
{
    int yystate;
    /* Number of tokens to shift before error messages enabled.  */
    int yyerrstatus;

    /* The stacks and their tools:
       `yyss': related to states.
       `yyvs': related to semantic values.

       Refer to the stacks thru separate pointers, to allow yyoverflow
       to reallocate them elsewhere.  */

    /* The state stack.  */
    yytype_int16 yyssa[YYINITDEPTH];
    yytype_int16 *yyss;
    yytype_int16 *yyssp;

    /* The semantic value stack.  */
    YYSTYPE yyvsa[YYINITDEPTH];
    YYSTYPE *yyvs;
    YYSTYPE *yyvsp;

    YYSIZE_T yystacksize;

  int yyn;
  int yyresult;
  /* Lookahead token as an internal (translated) token number.  */
  int yytoken;
  /* The variables used to return semantic value and location from the
     action routines.  */
  YYSTYPE yyval;

#if YYERROR_VERBOSE
  /* Buffer for error messages, and its allocated size.  */
  char yymsgbuf[128];
  char *yymsg = yymsgbuf;
  YYSIZE_T yymsg_alloc = sizeof yymsgbuf;
#endif

#define YYPOPSTACK(N)   (yyvsp -= (N), yyssp -= (N))

  /* The number of symbols on the RHS of the reduced rule.
     Keep to zero when no symbol should be popped.  */
  int yylen = 0;

  yytoken = 0;
  yyss = yyssa;
  yyvs = yyvsa;
  yystacksize = YYINITDEPTH;

  YYDPRINTF ((stderr, "Starting parse\n"));

  yystate = 0;
  yyerrstatus = 0;
  yynerrs = 0;
  yychar = YYEMPTY; /* Cause a token to be read.  */

  /* Initialize stack pointers.
     Waste one element of value and location stack
     so that they stay on the same level as the state stack.
     The wasted elements are never initialized.  */
  yyssp = yyss;
  yyvsp = yyvs;

  goto yysetstate;

/*------------------------------------------------------------.
| yynewstate -- Push a new state, which is found in yystate.  |
`------------------------------------------------------------*/
 yynewstate:
  /* In all cases, when you get here, the value and location stacks
     have just been pushed.  So pushing a state here evens the stacks.  */
  yyssp++;

 yysetstate:
  *yyssp = yystate;

  if (yyss + yystacksize - 1 <= yyssp)
    {
      /* Get the current used size of the three stacks, in elements.  */
      YYSIZE_T yysize = yyssp - yyss + 1;

#ifdef yyoverflow
      {
	/* Give user a chance to reallocate the stack.  Use copies of
	   these so that the &'s don't force the real ones into
	   memory.  */
	YYSTYPE *yyvs1 = yyvs;
	yytype_int16 *yyss1 = yyss;

	/* Each stack pointer address is followed by the size of the
	   data in use in that stack, in bytes.  This used to be a
	   conditional around just the two extra args, but that might
	   be undefined if yyoverflow is a macro.  */
	yyoverflow (YY_("memory exhausted"),
		    &yyss1, yysize * sizeof (*yyssp),
		    &yyvs1, yysize * sizeof (*yyvsp),
		    &yystacksize);

	yyss = yyss1;
	yyvs = yyvs1;
      }
#else /* no yyoverflow */
# ifndef YYSTACK_RELOCATE
      goto yyexhaustedlab;
# else
      /* Extend the stack our own way.  */
      if (YYMAXDEPTH <= yystacksize)
	goto yyexhaustedlab;
      yystacksize *= 2;
      if (YYMAXDEPTH < yystacksize)
	yystacksize = YYMAXDEPTH;

      {
	yytype_int16 *yyss1 = yyss;
	union yyalloc *yyptr =
	  (union yyalloc *) YYSTACK_ALLOC (YYSTACK_BYTES (yystacksize));
	if (! yyptr)
	  goto yyexhaustedlab;
	YYSTACK_RELOCATE (yyss_alloc, yyss);
	YYSTACK_RELOCATE (yyvs_alloc, yyvs);
#  undef YYSTACK_RELOCATE
	if (yyss1 != yyssa)
	  YYSTACK_FREE (yyss1);
      }
# endif
#endif /* no yyoverflow */

      yyssp = yyss + yysize - 1;
      yyvsp = yyvs + yysize - 1;

      YYDPRINTF ((stderr, "Stack size increased to %lu\n",
		  (unsigned long int) yystacksize));

      if (yyss + yystacksize - 1 <= yyssp)
	YYABORT;
    }

  YYDPRINTF ((stderr, "Entering state %d\n", yystate));

  if (yystate == YYFINAL)
    YYACCEPT;

  goto yybackup;

/*-----------.
| yybackup.  |
`-----------*/
yybackup:

  /* Do appropriate processing given the current state.  Read a
     lookahead token if we need one and don't already have one.  */

  /* First try to decide what to do without reference to lookahead token.  */
  yyn = yypact[yystate];
  if (yypact_value_is_default (yyn))
    goto yydefault;

  /* Not known => get a lookahead token if don't already have one.  */

  /* YYCHAR is either YYEMPTY or YYEOF or a valid lookahead symbol.  */
  if (yychar == YYEMPTY)
    {
      YYDPRINTF ((stderr, "Reading a token: "));
      yychar = YYLEX;
    }

  if (yychar <= YYEOF)
    {
      yychar = yytoken = YYEOF;
      YYDPRINTF ((stderr, "Now at end of input.\n"));
    }
  else
    {
      yytoken = YYTRANSLATE (yychar);
      YY_SYMBOL_PRINT ("Next token is", yytoken, &yylval, &yylloc);
    }

  /* If the proper action on seeing token YYTOKEN is to reduce or to
     detect an error, take that action.  */
  yyn += yytoken;
  if (yyn < 0 || YYLAST < yyn || yycheck[yyn] != yytoken)
    goto yydefault;
  yyn = yytable[yyn];
  if (yyn <= 0)
    {
      if (yytable_value_is_error (yyn))
        goto yyerrlab;
      yyn = -yyn;
      goto yyreduce;
    }

  /* Count tokens shifted since error; after three, turn off error
     status.  */
  if (yyerrstatus)
    yyerrstatus--;

  /* Shift the lookahead token.  */
  YY_SYMBOL_PRINT ("Shifting", yytoken, &yylval, &yylloc);

  /* Discard the shifted token.  */
  yychar = YYEMPTY;

  yystate = yyn;
  *++yyvsp = yylval;

  goto yynewstate;


/*-----------------------------------------------------------.
| yydefault -- do the default action for the current state.  |
`-----------------------------------------------------------*/
yydefault:
  yyn = yydefact[yystate];
  if (yyn == 0)
    goto yyerrlab;
  goto yyreduce;


/*-----------------------------.
| yyreduce -- Do a reduction.  |
`-----------------------------*/
yyreduce:
  /* yyn is the number of a rule to reduce with.  */
  yylen = yyr2[yyn];

  /* If YYLEN is nonzero, implement the default value of the action:
     `$$ = $1'.

     Otherwise, the following line sets YYVAL to garbage.
     This behavior is undocumented and Bison
     users should not rely upon it.  Assigning to YYVAL
     unconditionally makes the parser a bit smaller, and it avoids a
     GCC warning that YYVAL may be used uninitialized.  */
  yyval = yyvsp[1-yylen];


  YY_REDUCE_PRINT (yyn);
  switch (yyn)
    {
      

/* Line 1806 of yacc.c  */
#line 2732 "grammar.tab.c"
      default: break;
    }
  /* User semantic actions sometimes alter yychar, and that requires
     that yytoken be updated with the new translation.  We take the
     approach of translating immediately before every use of yytoken.
     One alternative is translating here after every semantic action,
     but that translation would be missed if the semantic action invokes
     YYABORT, YYACCEPT, or YYERROR immediately after altering yychar or
     if it invokes YYBACKUP.  In the case of YYABORT or YYACCEPT, an
     incorrect destructor might then be invoked immediately.  In the
     case of YYERROR or YYBACKUP, subsequent parser actions might lead
     to an incorrect destructor call or verbose syntax error message
     before the lookahead is translated.  */
  YY_SYMBOL_PRINT ("-> $$ =", yyr1[yyn], &yyval, &yyloc);

  YYPOPSTACK (yylen);
  yylen = 0;
  YY_STACK_PRINT (yyss, yyssp);

  *++yyvsp = yyval;

  /* Now `shift' the result of the reduction.  Determine what state
     that goes to, based on the state we popped back to and the rule
     number reduced by.  */

  yyn = yyr1[yyn];

  yystate = yypgoto[yyn - YYNTOKENS] + *yyssp;
  if (0 <= yystate && yystate <= YYLAST && yycheck[yystate] == *yyssp)
    yystate = yytable[yystate];
  else
    yystate = yydefgoto[yyn - YYNTOKENS];

  goto yynewstate;


/*------------------------------------.
| yyerrlab -- here on detecting error |
`------------------------------------*/
yyerrlab:
  /* Make sure we have latest lookahead translation.  See comments at
     user semantic actions for why this is necessary.  */
  yytoken = yychar == YYEMPTY ? YYEMPTY : YYTRANSLATE (yychar);

  /* If not already recovering from an error, report this error.  */
  if (!yyerrstatus)
    {
      ++yynerrs;
#if ! YYERROR_VERBOSE
      yyerror (YY_("syntax error"));
#else
# define YYSYNTAX_ERROR yysyntax_error (&yymsg_alloc, &yymsg, \
                                        yyssp, yytoken)
      {
        char const *yymsgp = YY_("syntax error");
        int yysyntax_error_status;
        yysyntax_error_status = YYSYNTAX_ERROR;
        if (yysyntax_error_status == 0)
          yymsgp = yymsg;
        else if (yysyntax_error_status == 1)
          {
            if (yymsg != yymsgbuf)
              YYSTACK_FREE (yymsg);
            yymsg = (char *) YYSTACK_ALLOC (yymsg_alloc);
            if (!yymsg)
              {
                yymsg = yymsgbuf;
                yymsg_alloc = sizeof yymsgbuf;
                yysyntax_error_status = 2;
              }
            else
              {
                yysyntax_error_status = YYSYNTAX_ERROR;
                yymsgp = yymsg;
              }
          }
        yyerror (yymsgp);
        if (yysyntax_error_status == 2)
          goto yyexhaustedlab;
      }
# undef YYSYNTAX_ERROR
#endif
    }



  if (yyerrstatus == 3)
    {
      /* If just tried and failed to reuse lookahead token after an
	 error, discard it.  */

      if (yychar <= YYEOF)
	{
	  /* Return failure if at end of input.  */
	  if (yychar == YYEOF)
	    YYABORT;
	}
      else
	{
	  yydestruct ("Error: discarding",
		      yytoken, &yylval);
	  yychar = YYEMPTY;
	}
    }

  /* Else will try to reuse lookahead token after shifting the error
     token.  */
  goto yyerrlab1;


/*---------------------------------------------------.
| yyerrorlab -- error raised explicitly by YYERROR.  |
`---------------------------------------------------*/
yyerrorlab:

  /* Pacify compilers like GCC when the user code never invokes
     YYERROR and the label yyerrorlab therefore never appears in user
     code.  */
  if (/*CONSTCOND*/ 0)
     goto yyerrorlab;

  /* Do not reclaim the symbols of the rule which action triggered
     this YYERROR.  */
  YYPOPSTACK (yylen);
  yylen = 0;
  YY_STACK_PRINT (yyss, yyssp);
  yystate = *yyssp;
  goto yyerrlab1;


/*-------------------------------------------------------------.
| yyerrlab1 -- common code for both syntax error and YYERROR.  |
`-------------------------------------------------------------*/
yyerrlab1:
  yyerrstatus = 3;	/* Each real token shifted decrements this.  */

  for (;;)
    {
      yyn = yypact[yystate];
      if (!yypact_value_is_default (yyn))
	{
	  yyn += YYTERROR;
	  if (0 <= yyn && yyn <= YYLAST && yycheck[yyn] == YYTERROR)
	    {
	      yyn = yytable[yyn];
	      if (0 < yyn)
		break;
	    }
	}

      /* Pop the current state because it cannot handle the error token.  */
      if (yyssp == yyss)
	YYABORT;


      yydestruct ("Error: popping",
		  yystos[yystate], yyvsp);
      YYPOPSTACK (1);
      yystate = *yyssp;
      YY_STACK_PRINT (yyss, yyssp);
    }

  *++yyvsp = yylval;


  /* Shift the error token.  */
  YY_SYMBOL_PRINT ("Shifting", yystos[yyn], yyvsp, yylsp);

  yystate = yyn;
  goto yynewstate;


/*-------------------------------------.
| yyacceptlab -- YYACCEPT comes here.  |
`-------------------------------------*/
yyacceptlab:
  yyresult = 0;
  goto yyreturn;

/*-----------------------------------.
| yyabortlab -- YYABORT comes here.  |
`-----------------------------------*/
yyabortlab:
  yyresult = 1;
  goto yyreturn;

#if !defined(yyoverflow) || YYERROR_VERBOSE
/*-------------------------------------------------.
| yyexhaustedlab -- memory exhaustion comes here.  |
`-------------------------------------------------*/
yyexhaustedlab:
  yyerror (YY_("memory exhausted"));
  yyresult = 2;
  /* Fall through.  */
#endif

yyreturn:
  if (yychar != YYEMPTY)
    {
      /* Make sure we have latest lookahead translation.  See comments at
         user semantic actions for why this is necessary.  */
      yytoken = YYTRANSLATE (yychar);
      yydestruct ("Cleanup: discarding lookahead",
                  yytoken, &yylval);
    }
  /* Do not reclaim the symbols of the rule which action triggered
     this YYABORT or YYACCEPT.  */
  YYPOPSTACK (yylen);
  YY_STACK_PRINT (yyss, yyssp);
  while (yyssp != yyss)
    {
      yydestruct ("Cleanup: popping",
		  yystos[*yyssp], yyvsp);
      YYPOPSTACK (1);
    }
#ifndef yyoverflow
  if (yyss != yyssa)
    YYSTACK_FREE (yyss);
#endif
#if YYERROR_VERBOSE
  if (yymsg != yymsgbuf)
    YYSTACK_FREE (yymsg);
#endif
  /* Make sure YYID is used.  */
  return YYID (yyresult);
}



