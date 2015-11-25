/************************************************************************
*
* Copyright (C) 2014  Jonathan H. Ballard
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*
*********************************/

/************************
* { Current-News: 2014-08-12                    }
* { Hypercard:    /tmp                          }
* { Intents:      /System,/Program,/Debian.dpkg }
* { Internet:     Offline                       }
* { Domain:       .NET                          }
* { Trademarks:   Ballard,<embed>,(-1)          }
* { Map:          Earth,(Moon),(Mars),...       }
* { Spreadsheet:  () as imaginary precedes i    }
* { Wall:         $=<compQstring/postback>      }
*/

#include <stdio.h>
extern int yydebug ;

int main( int ARGc, char** ARGv, char**ENVi )
  {
  char* what = "\"2.0\"" ;                        //(20.0)
  yydebug = (ARGc-1) ? -1 : 0 ;                   //restful?
  if( ENVi == 0 )                                 //stateful?
	  what = "\"0.9\"" ;
  else
  if( ARGv == 0 )                                 //stateless?
	  what = "\"1.1\"" ;
  else
	  what = "\"1.0\"" ;
  #if SHORTLISTED
	printf( "<?xml version=%s ?>\n<xml shortlisted=\"%s\">", what, ARGv[0] ) ;
  #else
	printf( "<?xml version=%s ?>\n<xml>", what ) ;
  #endif
  yyparse() ;
  printf( "</xml>\n" ) ;
  return 0 ;
  }

yyerror( const char* s )
  {
  printf( "<yyerror>%s</yyerror>" , s ) ;
  return ;
  }

