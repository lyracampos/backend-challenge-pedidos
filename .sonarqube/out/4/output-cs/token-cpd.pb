Â7
í/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Api/Controllers/PedidoController.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Api# &
.& '
Controllers' 2
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
PedidoController !
:" #
ControllerBase$ 2
{ 
private 
readonly 
IPedidoRepository *
pedidoRepository+ ;
;; <
public 
PedidoController 
(  
IPedidoRepository  1
pedidoRepository2 B
)B C
{ 	
this 
. 
pedidoRepository !
=" #
pedidoRepository$ 4
;4 5
} 	
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
CriarPedido) 4
(4 5
[5 6
FromBody6 >
]> ?
PedidoCommand@ M
commandN U
,U V
[W X
FromServicesX d
]d e
ICriarPedidoHandlerf y
handler	z Å
)
Å Ç
{ 	
try   
{!! 
var"" 
pedido"" 
="" 
await"" "
handler""# *
.""* +
ExecutarAsync""+ 8
(""8 9
command""9 @
)""@ A
;""A B
return## 
Created## 
(## 
$"## !
api/pedido/##! ,
{##, -
pedido##- 3
.##3 4
Numero##4 :
}##: ;
"##; <
,##< =
pedido##> D
)##D E
;##E F
}$$ 
catch%% 
(%% 
	Exception%% 
ex%% 
)%%  
{&& 
return'' 

StatusCode'' !
(''! "
$num''" %
,''% &
ex''' )
.'') *
Message''* 1
)''1 2
;''2 3
}(( 
})) 	
[00 	
HttpPut00	 
(00 
$str00 
)00 
]00 
public11 
async11 
Task11 
<11 
IActionResult11 '
>11' (
AtualizarPedido11) 8
(118 9
int119 <
id11= ?
,11? @
[11A B
FromBody11B J
]11J K
PedidoCommand11L Y
command11Z a
,11a b
[11c d
FromServices11d p
]11p q$
IAtualizarPedidoHandler	11r â
handler
11ä ë
)
11ë í
{22 	
try33 
{44 
var55 
pedido55 
=55 
await55 "
handler55# *
.55* +
ExecutarAsync55+ 8
(558 9
id559 ;
,55; <
command55= D
)55D E
;55E F
return66 
Ok66 
(66 
pedido66  
)66  !
;66! "
}77 
catch88 
(88 (
PedidoNaoEncontradoException88 /
ex880 2
)882 3
{99 
return:: 
NotFound:: 
(::  
ex::  "
.::" #
Message::# *
)::* +
;::+ ,
};; 
catch<< 
(<< 
	Exception<< 
ex<< 
)<<  
{== 
return>> 

StatusCode>> !
(>>! "
$num>>" %
,>>% &
ex>>' )
.>>) *
Message>>* 1
)>>1 2
;>>2 3
}?? 
}@@ 	
[GG 	
HttpGetGG	 
(GG 
$strGG 
)GG 
]GG 
[HH 	 
ProducesResponseTypeHH	 
(HH 
typeofHH $
(HH$ %
PedidoResultHH% 1
)HH1 2
,HH2 3
StatusCodesHH4 ?
.HH? @
Status201CreatedHH@ P
)HHP Q
]HHQ R
[II 	 
ProducesResponseTypeII	 
(II 
StatusCodesII )
.II) *
Status400BadRequestII* =
)II= >
]II> ?
[JJ 	 
ProducesResponseTypeJJ	 
(JJ 
StatusCodesJJ )
.JJ) *(
Status500InternalServerErrorJJ* F
)JJF G
]JJG H
publicKK 
asyncKK 
TaskKK 
<KK 
IActionResultKK '
>KK' (
BuscarPedidoKK) 5
(KK5 6
intKK6 9
idKK: <
)KK< =
{LL 	
tryMM 
{NN 
varOO 
pedidoOO 
=OO 
awaitOO "
pedidoRepositoryOO# 3
.OO3 4
BuscarAsyncOO4 ?
(OO? @
idOO@ B
)OOB C
;OOC D
ifPP 
(PP 
pedidoPP 
!=PP 
nullPP "
)PP" #
returnQQ 
OkQQ 
(QQ 
newQQ !
PedidoResultQQ" .
(QQ. /
pedidoQQ/ 5
)QQ5 6
)QQ6 7
;QQ7 8
elseRR 
returnSS 
NotFoundSS #
(SS# $
$"SS$ &
Pedido SS& -
{SS- .
idSS. 0
}SS0 1
 n√£o encontrado.SS1 A
"SSA B
)SSB C
;SSC D
}TT 
catchUU 
(UU 
	ExceptionUU 
exUU 
)UU  
{VV 
returnWW 

StatusCodeWW !
(WW! "
$numWW" %
,WW% &
exWW' )
.WW) *
MessageWW* 1
)WW1 2
;WW2 3
}XX 
}YY 	
[__ 	

HttpDelete__	 
(__ 
$str__ 
)__ 
]__ 
public`` 
async`` 
Task`` 
<`` 
IActionResult`` '
>``' (
RemoverPedido``) 6
(``6 7
int``7 :
id``; =
,``= >
[``? @
FromServices``@ L
]``L M!
IRemoverPedidoHandler``N c
handler``d k
)``k l
{aa 	
trybb 
{cc 
awaitdd 
handlerdd 
.dd 
ExecutarAsyncdd +
(dd+ ,
iddd, .
)dd. /
;dd/ 0
returnee 
NotFoundee 
(ee  
)ee  !
;ee! "
}ff 
catchgg 
(gg (
PedidoNaoEncontradoExceptiongg /
exgg0 2
)gg2 3
{hh 
returnii 
NotFoundii 
(ii  
exii  "
.ii" #
Messageii# *
)ii* +
;ii+ ,
}jj 
catchkk 
(kk 
	Exceptionkk 
exkk 
)kk  
{ll 
returnmm 

StatusCodemm !
(mm! "
$nummm" %
,mm% &
exmm' )
.mm) *
Messagemm* 1
)mm1 2
;mm2 3
}nn 
}oo 	
}pp 
}qq „
í/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Api/Controllers/StatusController.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Api# &
.& '
Controllers' 2
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 
)

 
]

 
public 

class 
StatusController !
:" #
ControllerBase$ 2
{ 
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
Status) /
(/ 0
[0 1
FromBody1 9
]9 :
StatusPedidoCommand; N
commandO V
,V W
[X Y
FromServicesY e
]e f 
IStatusPedidoHandlerg {
handler	| É
)
É Ñ
{ 	
try 
{ 
var 
statusResult  
=! "
await# (
handler) 0
.0 1
ExecutarAsync1 >
(> ?
command? F
)F G
;G H
return 
Ok 
( 
statusResult &
)& '
;' (
} 
catch 
( 
	Exception 
ex 
)  
{ 
return 

StatusCode !
(! "
$num" %
,% &
ex' )
.) *
Message* 1
)1 2
;2 3
} 
} 	
}   
}!! ü
}/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Api/Program.cs
	namespace

 	
BackendChallenge


 
.

 
Pedidos

 "
.

" #
Api

# &
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} Ω!
}/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Api/Startup.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Api# &
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddControllers #
(# $
)$ %
;% &
services 
. 
AddSwaggerGen "
(" #
c# $
=>% '
{ 
c   
.   

SwaggerDoc   
(   
$str   !
,  ! "
new  # &
OpenApiInfo  ' 2
{  3 4
Title  5 :
=  ; <
$str  = [
,  [ \
Version  ] d
=  e f
$str  g k
}  l m
)  m n
;  n o
}!! 
)!! 
;!! 
services"" 
."" 
AddTransient"" !
<""! "
ICriarPedidoHandler""" 5
,""5 6
CriarPedidoHandler""7 I
>""I J
(""J K
)""K L
;""L M
services## 
.## 
AddTransient## !
<##! "#
IAtualizarPedidoHandler##" 9
,##9 :"
AtualizarPedidoHandler##; Q
>##Q R
(##R S
)##S T
;##T U
services$$ 
.$$ 
AddTransient$$ !
<$$! "!
IRemoverPedidoHandler$$" 7
,$$7 8 
RemoverPedidoHandler$$9 M
>$$M N
($$N O
)$$O P
;$$P Q
services%% 
.%% 
AddTransient%% !
<%%! "
IPedidoRepository%%" 3
,%%3 4
PedidoRepository%%5 E
>%%E F
(%%F G
)%%G H
;%%H I
services&& 
.&& 
AddTransient&& !
<&&! " 
IStatusPedidoHandler&&" 6
,&&6 7
StatusPedidoHandler&&8 K
>&&K L
(&&L M
)&&M N
;&&N O
services'' 
.'' 
AddDbContext'' !
<''! "
PedidoContext''" /
>''/ 0
(''0 1
)''1 2
;''2 3
}(( 	
public++ 
void++ 
	Configure++ 
(++ 
IApplicationBuilder++ 1
app++2 5
,++5 6
IWebHostEnvironment++7 J
env++K N
)++N O
{,, 	
if-- 
(-- 
env-- 
.-- 
IsDevelopment-- !
(--! "
)--" #
)--# $
{.. 
app// 
.// %
UseDeveloperExceptionPage// -
(//- .
)//. /
;/// 0
app00 
.00 

UseSwagger00 
(00 
)00  
;00  !
app11 
.11 
UseSwaggerUI11  
(11  !
c11! "
=>11# %
c11& '
.11' (
SwaggerEndpoint11( 7
(117 8
$str118 R
,11R S
$str11T u
)11u v
)11v w
;11w x
}22 
app44 
.44 
UseHttpsRedirection44 #
(44# $
)44$ %
;44% &
app66 
.66 

UseRouting66 
(66 
)66 
;66 
app88 
.88 
UseAuthorization88  
(88  !
)88! "
;88" #
app:: 
.:: 
UseEndpoints:: 
(:: 
	endpoints:: &
=>::' )
{;; 
	endpoints<< 
.<< 
MapControllers<< (
(<<( )
)<<) *
;<<* +
}== 
)== 
;== 
}>> 	
}?? 
}@@ 