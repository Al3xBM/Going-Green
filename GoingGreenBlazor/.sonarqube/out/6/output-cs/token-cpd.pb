�
KD:\Git Repos\Going-Green\EmailService\Controllers\EmailServiceController.cs
	namespace		 	
EmailService		
 
.		 
Controllers		 "
{

 
[ 
Route 

(
 
$str  
)  !
]! "
[ 

] 
public

class
EmailServiceController
:
ControllerBase
{ 
private 
readonly 

	_template' 0
=1 2
new3 6

(D E
)E F
;F G
[ 	
HttpPost	 
] 
public 
void 
Post 
( 
[ 
FromBody "
]" #

Dictionary$ .
<. /
string/ 5
,5 6
string7 =
>= >
data? C
)C D
{ 	
string 
from 
= 
$str <
;< =
if 
( 
! 
data 
. 
ContainsKey !
(! "
$str" &
)& '
)' (
{ 
throw 
new !
ArgumentNullException /
(/ 0
$"0 2
{2 3
nameof3 9
(9 :
Post: >
)> ?
}? @.
" destination mail must not be null@ b
"b c
)c d
;d e
} 
string 
to 
= 
data 
[ 
$str !
]! "
;" #
MailMessage 
message 
=  !
new" %
MailMessage& 1
(1 2
from2 6
,6 7
to8 :
): ;
;; <
string 
mailbody 
= 
	_template '
.' (
confirmRequestMail( :
(: ;
float; @
.@ A
ParseA F
(F G
dataG K
[K L
$strL S
]S T
)T U
)U V
;V W
message 
. 
Subject 
= 
$str *
;* +
message 
. 
Body 
= 
mailbody #
;# $
message 
. 
BodyEncoding  
=! "
Encoding# +
.+ ,
UTF8, 0
;0 1
message   
.   

IsBodyHtml   
=    
true  ! %
;  % &

SmtpClient!! 
client!! 
=!! 
new!!  #

SmtpClient!!$ .
(!!. /
$str!!/ ?
,!!? @
$num!!A D
)!!D E
;!!E F
NetworkCredential"" 
basicCredential1"" .
=""/ 0
new""1 4
NetworkCredential## 
(## 
from## "
,##" #
$str##$ 4
)##4 5
;##5 6
client$$ 
.$$ 
	EnableSsl$$ 
=$$ 
true$$ #
;$$# $
client%% 
.%% !
UseDefaultCredentials%% (
=%%) *
false%%+ 0
;%%0 1
client&& 
.&& 
Credentials&& 
=&&  
basicCredential1&&! 1
;&&1 2
try'' 
{(( 
client)) 
.)) 
Send)) 
()) 
message)) #
)))# $
;))$ %
}** 
catch,, 
(,, 
	Exception,, 
ex,, 
),,  
{-- 
throw.. 
ex.. 
;.. 
}// 
}00 	
}11 
}22 �
?D:\Git Repos\Going-Green\EmailService\Entities\EmailTemplate.cs
	namespace 	
EmailService
 
. 
Entities 
{ 
public 

class 

{ 
public 

( 
) 
{  
}! "
public 
string 
confirmRequestMail (
(( )
float) .
price/ 4
)4 5
{ 	
string		 
messageBody		 
=		  
$str		! A
;		A B
messageBody 
+= 
$str _
;_ `
messageBody 
+= 
$" H
<<p>Your product was estimated by our program to be worth <b> Y
{Y Z
priceZ _
}_ `0
#</b> RON. This value may change</p>	` �
"
� �
+
� �
$"
'<p>based on our workers' assessment</p>
"
;
return 
messageBody 
; 
} 	
} 
} �

0D:\Git Repos\Going-Green\EmailService\Program.cs
	namespace 	
EmailService
 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{		 	
CreateHostBuilder

 
(

 
args

 "
)

" #
.

# $
Build

$ )
(

) *
)

* +
.

+ ,
Run

, /
(

/ 0
)

0 1
;

1 2
} 	
public
static
IHostBuilder
CreateHostBuilder
(
string
[
]
args
)
=>
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} �
0D:\Git Repos\Going-Green\EmailService\Startup.cs
	namespace 	
EmailService
 
{		 
public

 

class

 
Startup

 
{ 
public 
Startup 
( 
IConfiguration %

)3 4
{

= 

;) *
} 	
public 
IConfiguration 

{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddCors 
( 
options $
=>% '
{ 
options 
. 
AddDefaultPolicy (
(( )
builder) 0
=>1 3
{ 
builder 
. 
AllowAnyOrigin *
(* +
)+ ,
;, -
builder 
. 
AllowAnyMethod *
(* +
)+ ,
;, -
builder 
. 
AllowAnyHeader *
(* +
)+ ,
;, -
} 
) 
; 
} 
)
; 
services 
. 
AddControllers #
(# $
)$ %
;% &
services   
.   

(  " #
c  # $
=>  % '
{!! 
c"" 
."" 

SwaggerDoc"" 
("" 
$str"" !
,""! "
new""# &
OpenApiInfo""' 2
{""3 4
Title""5 :
=""; <
$str""= K
,""K L
Version""M T
=""U V
$str""W [
}""\ ]
)""] ^
;""^ _
}## 
)##
;## 
}$$ 	
public'' 
void'' 
	Configure'' 
('' 
IApplicationBuilder'' 1
app''2 5
,''5 6
IWebHostEnvironment''7 J
env''K N
)''N O
{(( 	
if)) 
()) 
env)) 
.)) 

())! "
)))" #
)))# $
{** 
app++ 
.++ %
UseDeveloperExceptionPage++ -
(++- .
)++. /
;++/ 0
},, 
app.. 
... 
UseHttpsRedirection.. #
(..# $
)..$ %
;..% &
app00 
.00 

UseRouting00 
(00 
)00 
;00 
app22 
.22 
UseCors22 
(22 
)22 
;22 
app44 
.44 
UseAuthorization44  
(44  !
)44! "
;44" #
app66 
.66 
UseEndpoints66 
(66 
	endpoints66 &
=>66' )
{77 
	endpoints88 
.88 
MapControllers88 (
(88( )
)88) *
;88* +
}99 
)99
;99 
}:: 	
};; 
}<< 