�
RD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Controllers\FormController.cs
	namespace 	

 
. 
Controllers #
{ 
[ 
Route 

(
 
$str  
)  !
]! "
[ 

] 
public		 

class		 
FormController		 
:		  !
ControllerBase		" 0
{

 
[ 	
HttpPost	 
] 
public 
ActionResult 
< 
List  
<  !
string! '
>' (
>( )

(7 8
[8 9
FromBody9 A
]A B
stringB H
applienceCategoryI Z
)Z [
{
return 
new 
ProductList "
(" #
)# $
.$ % 
GetProductProperties% 9
(9 :
applienceCategory: K
)K L
;L M
} 	
[ 	
HttpGet	 
] 
public 
ActionResult 
< 
List  
<  !
string! '
>' (
>( )
GetAllProductTypes* <
(< =
)= >
{ 	
var 
listOfProducts 
=  
new  #
ProductList$ /
(/ 0
)0 1
.1 2
GetAllProductNames2 D
(D E
)E F
;F G
listOfProducts 
. 
Remove !
(! "
$str" /
)/ 0
;0 1
return 
listOfProducts !
;! "
} 	
} 
} � 
XD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Controllers\RepositoryController.cs
	namespace

 	



 
.

 
Controllers

 #
{ 
[ 
Route 

(
 
$str  
)  !
]! "
[

]
public 

class  
RepositoryController %
:& '
ControllerBase( 6
{ 
public 
IRepository 
< 
BaseProduct &
>& '
_repository( 3
{4 5
get6 9
;9 :
}; <
public  
RepositoryController #
(# $
IRepository$ /
</ 0
BaseProduct0 ;
>; <

reposotory= G
)G H
{ 	
_repository 
= 

reposotory $
;$ %
} 	
[ 	
HttpGet	 
] 
public 
ActionResult 
< 
IEnumerable '
<' (
BaseProduct( 3
>3 4
>4 5
GetAll6 <
(< =
)= >
{ 	
return 
_repository 
. 
GetAll %
(% &
)& '
.' (
ToList( .
(. /
)/ 0
;0 1
} 	
[ 	
HttpGet	 
( 
$str 
) 
] 
public 
async 
Task 
< 
ActionResult &
<& '
BaseProduct' 2
>2 3
>3 4
Get5 8
(8 9
Guid9 =
id> @
)@ A
{ 	
return   
await   
_repository   $
.  $ %
GetById  % ,
(  , -
id  - /
)  / 0
;  0 1
}!! 	
[## 	
HttpPost##	 
]## 
public$$ 
void$$ 
Post$$ 
($$ 
[$$ 
FromBody$$ "
]$$" #

Dictionary$$$ .
<$$. /
string$$/ 5
,$$5 6
string$$7 =
>$$= >
product$$? F
)$$F G
{%% 	
var&& 
listOfProducts&& 
=&&  
new&&  #
ProductList&&$ /
(&&/ 0
)&&0 1
.&&1 2
GetAllProductTypes&&2 D
(&&D E
)&&E F
;&&F G
foreach(( 
((( 
var(( 
type(( 
in((  
listOfProducts((! /
)((/ 0
{)) 
if** 
(** 
type** 
.** 
Name** 
==**  
product**! (
[**( )
$str**) /
]**/ 0
)**0 1
{++ 
var,, 
instance,,  
=,,! "
	Activator,,# ,
.,,, -
CreateInstance,,- ;
(,,; <
type,,< @
),,@ A
;,,A B
foreach.. 
(.. 
var.. 
prop..  $
in..% '
product..( /
)../ 0
{// 
PropertyInfo00 $
propInfo00% -
=00. /
type000 4
.004 5
GetProperty005 @
(00@ A
prop00A E
.00E F
Key00F I
)00I J
;00J K
var11 
val11 
=11  !
new11! $
ProductList11% 0
(110 1
)111 2
.112 3
CastPropertyValue113 D
(11D E
propInfo11E M
,11M N
prop11O S
.11S T
Value11T Y
)11Y Z
;11Z [
propInfo22  
.22  !
SetValue22! )
(22) *
instance22* 2
,222 3
val224 7
)227 8
;228 9
}33 
_repository55 
.55  
CreateAsync55  +
(55+ ,
(55, -
BaseProduct55- 8
)558 9
instance559 A
)55A B
;55B C
break66 
;66 
}77 
}88 
}:: 	
};; 
}<< �
HD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Data\DataContext.cs
	namespace 	

 
. 
Data 
{ 
public 

class 
DataContext 
: 
	DbContext (
{ 
public 
DataContext 
( 
DbContextOptions +
options, 3
)3 4
:5 6
base7 ;
(; <
options< C
)C D
{		 	
}

 	
public 
DataContext 
( 
) 
: 
base #
(# $
)$ %
{ 	
} 	
public 
DbSet 
< 
Fridge 
> 
Fridges $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
DbSet 
< 

Television 
>  
Televisions! ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
public 
DbSet 
< 
BaseProduct  
>  !
Products" *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
base 
. 
OnModelCreating  
(  !
modelBuilder! -
)- .
;. /
} 	
} 
} �	
HD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Data\IRepository.cs
	namespace 	

 
. 
Data 
{ 
public 

	interface 
IRepository  
<  !
T! "
>" #
where$ )
T* +
:, -
class. 3
,3 4
new5 8
(8 9
)9 :
{ 
Task		 
<		 
T		
>		 
GetById		 
(		 
Guid		 
id		 
)		  
;		  !
IEnumerable

 
<

 
T

 
>

 
GetAll

 
(

 
)

 
;

  
Task 
< 
T
> 
CreateAsync 
( 
T 
entity $
)$ %
;% &
Task 
< 
T
> 
UpdateAsync 
( 
T 
entity $
)$ %
;% &
Task
<
T
>
DeleteAsync
(
T
entity
)
;
} 
} �$
eD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Data\Migrations\20210411123356_InitialCreate3.cs
	namespace 	

 
. 
Data 
. 

Migrations '
{ 
public 

partial 
class 
InitialCreate3 '
:( )
	Migration* 3
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder		 
.		 
	AddColumn		 &
<		& '
float		' ,
>		, -
(		- .
name

 
:

 
$str

 
,

 
table 
: 
$str !
,! "
type 
: 
$str 
, 
nullable
:
true
)
;
migrationBuilder 
. 
	AddColumn &
<& '
int' *
>* +
(+ ,
name 
: 
$str 
, 
table 
: 
$str !
,! "
type 
: 
$str 
,  
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
bool' +
>+ ,
(, -
name 
: 
$str "
," #
table 
: 
$str !
,! "
type 
: 
$str 
,  
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
float' ,
>, -
(- .
name 
: 
$str 
, 
table 
: 
$str !
,! "
type 
: 
$str 
, 
nullable 
: 
true 
) 
;  
migrationBuilder!! 
.!! 
	AddColumn!! &
<!!& '
float!!' ,
>!!, -
(!!- .
name"" 
:"" 
$str"" 
,"" 
table## 
:## 
$str## !
,##! "
type$$ 
:$$ 
$str$$ 
,$$ 
nullable%% 
:%% 
true%% 
)%% 
;%%  
migrationBuilder'' 
.'' 
	AddColumn'' &
<''& '
float''' ,
>'', -
(''- .
name(( 
:(( 
$str(( 
,(( 
table)) 
:)) 
$str)) !
,))! "
type** 
:** 
$str** 
,** 
nullable++ 
:++ 
true++ 
)++ 
;++  
},, 	
	protected.. 
override.. 
void.. 
Down..  $
(..$ %
MigrationBuilder..% 5
migrationBuilder..6 F
)..F G
{// 	
migrationBuilder00 
.00 

DropColumn00 '
(00' (
name11 
:11 
$str11 
,11 
table22 
:22 
$str22 !
)22! "
;22" #
migrationBuilder44 
.44 

DropColumn44 '
(44' (
name55 
:55 
$str55 
,55 
table66 
:66 
$str66 !
)66! "
;66" #
migrationBuilder88 
.88 

DropColumn88 '
(88' (
name99 
:99 
$str99 "
,99" #
table:: 
::: 
$str:: !
)::! "
;::" #
migrationBuilder<< 
.<< 

DropColumn<< '
(<<' (
name== 
:== 
$str== 
,== 
table>> 
:>> 
$str>> !
)>>! "
;>>" #
migrationBuilder@@ 
.@@ 

DropColumn@@ '
(@@' (
nameAA 
:AA 
$strAA 
,AA 
tableBB 
:BB 
$strBB !
)BB! "
;BB" #
migrationBuilderDD 
.DD 

DropColumnDD '
(DD' (
nameEE 
:EE 
$strEE 
,EE 
tableFF 
:FF 
$strFF !
)FF! "
;FF" #
}GG 	
}HH 
}II �
eD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Data\Migrations\20210411123445_InitialCreate4.cs
	namespace 	

 
. 
Data 
. 

Migrations '
{ 
public 

partial 
class 
InitialCreate4 '
:( )
	Migration* 3
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
}

 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{
} 	
} 
} �
dD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Data\Migrations\20210411130103_InitialCreate.cs
	namespace 	

 
. 
Data 
. 

Migrations '
{ 
public 

partial 
class 

:' (
	Migration) 2
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder		 
.		 
	AddColumn		 &
<		& '
string		' -
>		- .
(		. /
name

 
:

 
$str

 
,

 
table 
: 
$str !
,! "
type 
: 
$str 
, 
nullable
:
true
)
;
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str 
, 
table 
: 
$str !
)! "
;" #
} 	
} 
} �
eD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Data\Migrations\20210411130118_InitialCreate6.cs
	namespace 	

 
. 
Data 
. 

Migrations '
{ 
public 

partial 
class 
InitialCreate6 '
:( )
	Migration* 3
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
}

 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{
} 	
} 
} �
dD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Data\Migrations\20210417123123_AddedImageURL.cs
	namespace 	

 
. 
Data 
. 

Migrations '
{ 
public 

partial 
class 

:' (
	Migration) 2
{ 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder		 
.		 
	AddColumn		 &
<		& '
string		' -
>		- .
(		. /
name

 
:

 
$str

  
,

  !
table 
: 
$str !
,! "
type 
: 
$str 
, 
nullable
:
true
)
;
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str  
,  !
table 
: 
$str !
)! "
;" #
} 	
} 
} �/
HD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Data\ProductList.cs
	namespace 	

 
. 
Data 
{ 
public		 

class		 
ProductList		 
{

 
public 
List 
< 
Type 
> 
GetAllProductTypes ,
(, -
)- .
{ 	
return
(
from 
domainAssembly )
in* ,
	AppDomain- 6
.6 7

.D E

(R S
)S T
from 
assemblyType '
in( *
domainAssembly+ 9
.9 :
GetTypes: B
(B C
)C D
where 
typeof "
(" #
BaseProduct# .
). /
./ 0
IsAssignableFrom0 @
(@ A
assemblyTypeA M
)M N
select 
assemblyType )
) 
. 
ToList 
( 
) 
; 
} 	
public 
object 
CastPropertyValue '
(' (
PropertyInfo( 4
property5 =
,= >
string? E
valueF K
)K L
{ 	
if 
( 
property 
== 
null  
||! #
String$ *
.* +

(8 9
value9 >
)> ?
)? @
return 
null 
; 
if 
( 
property 
. 
PropertyType %
.% &
IsEnum& ,
), -
{ 
Type 
enumType 
= 
property  (
.( )
PropertyType) 5
;5 6
if 
( 
Enum 
. 
	IsDefined "
(" #
enumType# +
,+ ,
value- 2
)2 3
)3 4
return 
Enum 
.  
Parse  %
(% &
enumType& .
,. /
value0 5
)5 6
;6 7
} 
if 
( 
property 
. 
PropertyType %
==& (
typeof) /
(/ 0
bool0 4
)4 5
)5 6
return   
value   
==   
$str    #
||  $ &
value  ' ,
==  - /
$str  0 6
||  7 9
value  : ?
==  @ B
$str  C G
||  H J
value  K P
==  Q S
$str  T ]
;  ] ^
else!! 
if!! 
(!! 
property!! 
.!! 
PropertyType!! *
==!!+ -
typeof!!. 4
(!!4 5
Uri!!5 8
)!!8 9
)!!9 :
return"" 
new"" 
Uri"" 
("" 
Convert"" &
.""& '
ToString""' /
(""/ 0
value""0 5
)""5 6
)""6 7
;""7 8
else## 
return$$ 
Convert$$ 
.$$ 

ChangeType$$ )
($$) *
value$$* /
,$$/ 0
property$$1 9
.$$9 :
PropertyType$$: F
)$$F G
;$$G H
}%% 	
public'' 
List'' 
<'' 
string'' 
>'' 
GetAllProductNames'' .
(''. /
)''/ 0
{(( 	
return)) 
()) 
from** 
domainAssembly** %
in**& (
	AppDomain**) 2
.**2 3

.**@ A

(**N O
)**O P
from++ 
assemblyType++ #
in++$ &
domainAssembly++' 5
.++5 6
GetTypes++6 >
(++> ?
)++? @
where,, 
typeof,, 
(,, 
BaseProduct,, *
),,* +
.,,+ ,
IsAssignableFrom,,, <
(,,< =
assemblyType,,= I
),,I J
select-- 
assemblyType-- %
.--% &
Name--& *
).. 
... 
ToList.. 
(.. 
).. 
;.. 
}// 	
public11 
List11 
<11 
string11 
>11  
GetProductProperties11 0
(110 1
string111 7
applienceCategory118 I
)11I J
{22 	
var33 
listOfProducts33 
=33  
GetAllProductTypes33! 3
(333 4
)334 5
;335 6
List55 
<55 
string55 
>55 

properties55 #
=55$ %
new55& )
List55* .
<55. /
string55/ 5
>555 6
(556 7
)557 8
;558 9
foreach77 
(77 
var77 
type77 
in77  
listOfProducts77! /
)77/ 0
{88 
if99 
(99 
type99 
.99 
Name99 
==99  
applienceCategory99! 2
)992 3
{:: 
foreach;; 
(;; 
var;;  
prop;;! %
in;;& (
type;;) -
.;;- .

(;;; <
);;< =
);;= >
{<< 

properties== "
.==" #
Add==# &
(==& '
prop==' +
.==+ ,
Name==, 0
)==0 1
;==1 2
}>> 
break?? 
;?? 
}@@ 
}AA 

propertiesCC 
.CC 
RemoveCC 
(CC 
$strCC "
)CC" #
;CC# $

propertiesDD 
.DD 
RemoveDD 
(DD 
$strDD $
)DD$ %
;DD% &
returnFF 

propertiesFF 
;FF 
}GG 	
}HH 
}JJ �9
GD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Data\Repository.cs
	namespace 	

 
. 
Data 
{ 
public 

class 

Repository 
< 
T 
> 
:  
IRepository! ,
<, -
T- .
>. /
where0 5
T6 7
:8 9
class: ?
,? @
newA D
(D E
)E F
{ 
public		 

Repository		 
(		 
DataContext		 %
context		& -
)		- .
{

 	
_context 
= 
context 
; 
} 	
public 
DataContext 
_context #
{$ %
get& )
;) *
}+ ,
public 
async 
Task 
< 
T 
> 
CreateAsync (
(( )
T) *
entity+ 1
)1 2
{ 	
if 
( 
entity 
== 
null 
) 
{ 
throw 
new !
ArgumentNullException /
(/ 0
$"0 2
{2 3
nameof3 9
(9 :
CreateAsync: E
)E F
}F G$
 entity must not be nullG _
"_ `
)` a
;a b
} 
try 
{ 
await 
_context 
. 
AddAsync '
(' (
entity( .
). /
;/ 0
await 
_context 
. 
SaveChangesAsync /
(/ 0
)0 1
;1 2
return 
entity 
; 
} 
catch 
( 
	Exception 
ex 
)  
{ 
throw 
new 
	Exception #
(# $
$"$ &
{& '
nameof' -
(- .
CreateAsync. 9
)9 :
}: ; 
 could not be saved:; O
{O P
exP R
.R S
MessageS Z
}Z [
"[ \
)\ ]
;] ^
} 
}   	
public"" 
async"" 
Task"" 
<"" 
T"" 
>"" 
DeleteAsync"" (
(""( )
T"") *
entity""+ 1
)""1 2
{## 	
if$$ 
($$ 
entity$$ 
==$$ 
null$$ 
)$$ 
{%% 
throw&& 
new&& !
ArgumentNullException&& /
(&&/ 0
$"&&0 2
{&&2 3
nameof&&3 9
(&&9 :
DeleteAsync&&: E
)&&E F
}&&F G$
 entity must not be null&&G _
"&&_ `
)&&` a
;&&a b
}'' 
try(( 
{)) 
_context** 
.** 
Remove** 
(**  
entity**  &
)**& '
;**' (
await++ 
_context++ 
.++ 
SaveChangesAsync++ /
(++/ 0
)++0 1
;++1 2
return,, 
entity,, 
;,, 
}-- 
catch.. 
(.. 
	Exception.. 
ex.. 
)..  
{// 
throw00 
new00 
	Exception00 #
(00# $
$"00$ &
{00& '
nameof00' -
(00- .
DeleteAsync00. 9
)009 :
}00: ;"
 could not be deleted:00; Q
{00Q R
ex00R T
.00T U
Message00U \
}00\ ]
"00] ^
)00^ _
;00_ `
}11 
}22 	
public44 
IEnumerable44 
<44 
T44 
>44 
GetAll44 $
(44$ %
)44% &
{55 	
try66 
{77 
return88 
_context88 
.88  
Set88  #
<88# $
T88$ %
>88% &
(88& '
)88' (
;88( )
}99 
catch:: 
(:: 
	Exception:: 
ex:: 
)::  
{;; 
throw== 
new== 
	Exception== #
(==# $
$"==$ &'
Couldn't retrive entities: ==& A
{==A B
ex==B D
.==D E
Message==E L
}==L M
"==M N
)==N O
;==O P
}?? 
}@@ 	
publicBB 
asyncBB 
TaskBB 
<BB 
TBB 
>BB 
GetByIdBB $
(BB$ %
GuidBB% )
idBB* ,
)BB, -
{CC 	
ifDD 
(DD 
idDD 
==DD 
GuidDD 
.DD 
EmptyDD  
)DD  !
{EE 
throwFF 
newFF 
ArgumentExceptionFF +
(FF+ ,
$"FF, .
{FF. /
nameofFF/ 5
(FF5 6
GetByIdFF6 =
)FF= >
}FF> ?!
 id must not be emptyFF? T
"FFT U
)FFU V
;FFV W
}GG 
tryHH 
{II 
returnJJ 
awaitJJ 
_contextJJ %
.JJ% &
	FindAsyncJJ& /
<JJ/ 0
TJJ0 1
>JJ1 2
(JJ2 3
idJJ3 5
)JJ5 6
;JJ6 7
}KK 
catchLL 
(LL 
	ExceptionLL 
exLL 
)LL  
{MM 
throwOO 
newOO 
	ExceptionOO #
(OO# $
$"OO$ &%
Couldn't retrive entity: OO& ?
{OO? @
exOO@ B
.OOB C
MessageOOC J
}OOJ K
"OOK L
)OOL M
;OOM N
}PP 
}QQ 	
publicSS 
asyncSS 
TaskSS 
<SS 
TSS 
>SS 
UpdateAsyncSS (
(SS( )
TSS) *
entitySS+ 1
)SS1 2
{TT 	
ifUU 
(UU 
entityUU 
==UU 
nullUU 
)UU 
{VV 
throwWW 
newWW !
ArgumentNullExceptionWW /
(WW/ 0
$"WW0 2
{WW2 3
nameofWW3 9
(WW9 :
UpdateAsyncWW: E
)WWE F
}WWF G$
 entity must not be nullWWG _
"WW_ `
)WW` a
;WWa b
}XX 
tryYY 
{ZZ 
_context[[ 
.[[ 
Update[[ 
([[  
entity[[  &
)[[& '
;[[' (
await\\ 
_context\\ 
.\\ 
SaveChangesAsync\\ /
(\\/ 0
)\\0 1
;\\1 2
return]] 
entity]] 
;]] 
}^^ 
catch__ 
(__ 
	Exception__ 
ex__ 
)__  
{`` 
throwaa 
newaa 
	Exceptionaa #
(aa# $
$"aa$ &
{aa& '
nameofaa' -
(aa- .
UpdateAsyncaa. 9
)aa9 :
}aa: ;!
 could not be update:aa; P
{aaP Q
exaaQ S
.aaS T
MessageaaT [
}aa[ \
"aa\ ]
)aa] ^
;aa^ _
}bb 
}cc 	
}dd 
}ee �
LD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Entities\BaseProduct.cs
	namespace 	

 
. 
Entities  
{ 
public 

class 
BaseProduct 
{ 
public 
Guid 
ID 
{ 
get 
; 
set !
;! "
}# $
public		 
string		 
Brand		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public 
string 
Series 
{ 
get "
;" #
set$ '
;' (
}) *
public
string
Consumption
{
get
;
set
;
}
public 
string 
EnergyClass !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
Colour 
{ 
get "
;" #
set$ '
;' (
}) *
public 
float 
Weight 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Type 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
ImageURL 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} �	
GD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Entities\Fridge.cs
	namespace 	

 
. 
Entities  
{ 
public 

class 
Fridge 
: 
BaseProduct %
{ 
public 
float 
Height 
{ 
get !
;! "
set# &
;& '
}( )
public		 
float		 
Width		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public 
float 
Depth 
{ 
get  
;  !
set" %
;% &
}' (
public
float
Volume
{
get
;
set
;
}
public 
int 
Doors 
{ 
get 
; 
set  #
;# $
}% &
public 
Boolean 

HasFreezer !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} �
KD:\Git Repos\Going-Green\FormGenerator\FormGenerator\Entities\Television.cs
	namespace 	

 
. 
Entities  
{ 
public 

class 

Television 
: 
BaseProduct )
{ 
public 
float 
Diagonal 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
string		 

Resolution		  
{		! "
get		# &
;		& '
set		( +
;		+ ,
}		- .
public 
Boolean 
IsSmart 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}

?D:\Git Repos\Going-Green\FormGenerator\FormGenerator\Program.cs
	namespace 	

 
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
} �"
?D:\Git Repos\Going-Green\FormGenerator\FormGenerator\Startup.cs
	namespace

 	



 
{ 
public 

class 
Startup 
{
public 
Startup 
( 
IConfiguration %

)3 4
{ 	

= 

;) *
} 	
public 
IConfiguration 

{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddDbContext !
<! "
DataContext" -
>- .
(. /
options/ 6
=>7 9
{: ;
options 
. 
	UseSqlite !
(! "
this" &
.& '

.4 5
GetConnectionString5 H
(H I
$strI \
)\ ]
)] ^
;^ _
} 
)
; 
services 
. 
AddCors 
( 
options $
=>% '
{ 
options 
. 
AddDefaultPolicy (
(( )
builder) 0
=>1 3
{ 
builder   
.   
AllowAnyOrigin   *
(  * +
)  + ,
;  , -
builder!! 
.!! 
AllowAnyMethod!! *
(!!* +
)!!+ ,
;!!, -
builder"" 
."" 
AllowAnyHeader"" *
(""* +
)""+ ,
;"", -
}## 
)## 
;## 
}$$ 
)$$
;$$ 
services%% 
.%% 
	AddScoped%% 
(%% 
typeof%% %
(%%% &
IRepository%%& 1
<%%1 2
>%%2 3
)%%3 4
,%%4 5
typeof%%6 <
(%%< =

Repository%%= G
<%%G H
>%%H I
)%%I J
)%%J K
;%%K L
services&& 
.&& 
AddControllers&& #
(&&# $
)&&$ %
;&&% &
services'' 
.'' 

(''" #
c''# $
=>''% '
{(( 
c)) 
.)) 

SwaggerDoc)) 
()) 
$str)) !
,))! "
new))# &
OpenApiInfo))' 2
{))3 4
Title))5 :
=)); <
$str))= L
,))L M
Version))N U
=))V W
$str))X \
}))] ^
)))^ _
;))_ `
}** 
)**
;** 
}++ 	
public.. 
void.. 
	Configure.. 
(.. 
IApplicationBuilder.. 1
app..2 5
,..5 6
IWebHostEnvironment..7 J
env..K N
)..N O
{// 	
if00 
(00 
env00 
.00 

(00! "
)00" #
)00# $
{11 
app22 
.22 %
UseDeveloperExceptionPage22 -
(22- .
)22. /
;22/ 0
app33 
.33 

UseSwagger33 
(33 
)33  
;33  !
app44 
.44 
UseSwaggerUI44  
(44  !
c44! "
=>44# %
c44& '
.44' (
SwaggerEndpoint44( 7
(447 8
$str448 R
,44R S
$str44T f
)44f g
)44g h
;44h i
}55 
app77 
.77 
UseHttpsRedirection77 #
(77# $
)77$ %
;77% &
app99 
.99 

UseRouting99 
(99 
)99 
;99 
app;; 
.;; 
UseCors;; 
(;; 
);; 
;;; 
app== 
.== 
UseAuthorization==  
(==  !
)==! "
;==" #
app?? 
.?? 
UseEndpoints?? 
(?? 
	endpoints?? &
=>??' )
{@@ 
	endpointsAA 
.AA 
MapControllersAA (
(AA( )
)AA) *
;AA* +
}BB 
)BB
;BB 
}CC 	
}DD 
}EE 