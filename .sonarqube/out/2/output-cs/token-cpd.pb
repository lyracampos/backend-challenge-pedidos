ô
¥/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/Exceptions/PedidoNaoEncontradoException.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /

Exceptions/ 9
{ 
public 

class (
PedidoNaoEncontradoException -
:. /
	Exception0 9
{ 
public (
PedidoNaoEncontradoException +
(+ ,
string, 2
message3 :
): ;
:< =
base> B
(B C
messageC J
)J K
{ 	
} 	
}		 
}

 Ý	
œ/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/Repositories/IPedidoRepository.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
Repositories/ ;
{ 
public 

	interface 
IPedidoRepository &
:' (
IDisposable) 4
{		 
Task

 
AdicionarAsync

 
(

 
Pedido

 "
pedido

# )
)

) *
;

* +
Task 
AtualizarAsync 
( 
Pedido "
pedido# )
)) *
;* +
Task 
RemoverAsync 
( 
int 
id  
)  !
;! "
Task 
< 
Pedido 
> 
BuscarAsync  
(  !
int! $
id% '
)' (
;( )
Task 
< 
IEnumerable 
< 
Pedido 
>  
>  !
ListarAsync" -
(- .
). /
;/ 0
} 
} ¿
Ž/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Command.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
{ 
public 

abstract 
class 
Command !
{ 
} 
} Ê
¯/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Pedidos/Atualizar/AtualizarPedidoHandler.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Pedidos8 ?
.? @
	Atualizar@ I
{ 
public 

class "
AtualizarPedidoHandler '
:( )#
IAtualizarPedidoHandler* A
{ 
private		 
readonly		 
IPedidoRepository		 *
pedidoRepository		+ ;
;		; <
public "
AtualizarPedidoHandler %
(% &
IPedidoRepository& 7
pedidoRepository8 H
)H I
{ 	
this 
. 
pedidoRepository !
=" #
pedidoRepository$ 4
;4 5
} 	
public 
async 
Task 
< 
PedidoResult &
>& '
ExecutarAsync( 5
(5 6
int6 9
id: <
,< =
PedidoCommand> K
commandL S
)S T
{ 	
var 
pedidoDb 
= 
await  
pedidoRepository! 1
.1 2
BuscarAsync2 =
(= >
id> @
)@ A
;A B
if 
( 
pedidoDb 
== 
null  
)  !
throw 
new (
PedidoNaoEncontradoException 6
(6 7
$"7 9
Pedido 9 @
{@ A
idA C
}C D
 nÃ£o encontradoD S
"S T
)T U
;U V
pedidoDb 
. 
	Atualizar 
( 
command &
.& '
	MapEntity' 0
(0 1
)1 2
)2 3
;3 4
await 
pedidoRepository "
." #
AtualizarAsync# 1
(1 2
pedidoDb2 :
): ;
;; <
return 
new 
PedidoResult #
(# $
pedidoDb$ ,
), -
;- .
} 	
private 
bool 
disposedValue "
=# $
false% *
;* +
	protected 
virtual 
void 
Dispose &
(& '
bool' +
	disposing, 5
)5 6
{   	
if!! 
(!! 
!!! 
disposedValue!! 
)!! 
{"" 
disposedValue## 
=## 
true##  $
;##$ %
pedidoRepository$$  
.$$  !
Dispose$$! (
($$( )
)$$) *
;$$* +
}%% 
}&& 	
public'' 
void'' 
Dispose'' 
('' 
)'' 
=>''  
Dispose''! (
(''( )
true'') -
)''- .
;''. /
}(( 
})) Ã
°/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Pedidos/Atualizar/IAtualizarPedidoHandler.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Pedidos8 ?
.? @
	Atualizar@ I
{ 
public 

	interface #
IAtualizarPedidoHandler ,
:- .
IDisposable/ :
{ 
Task 
< 
PedidoResult 
> 
ExecutarAsync (
(( )
int) ,
id- /
,/ 0
PedidoCommand1 >
command? F
)F G
;G H
}		 
}

 «
§/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Pedidos/Criar/CriarPedidoHandler.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Pedidos8 ?
.? @
Criar@ E
{ 
public 

class 
CriarPedidoHandler #
:$ %
ICriarPedidoHandler& 9
{ 
private 
readonly 
IPedidoRepository *
pedidoRepository+ ;
;; <
public

 
CriarPedidoHandler

 !
(

! "
IPedidoRepository

" 3
pedidoRepository

4 D
)

D E
{ 	
this 
. 
pedidoRepository !
=" #
pedidoRepository$ 4
;4 5
} 	
public 
async 
Task 
< 
PedidoResult &
>& '
ExecutarAsync( 5
(5 6
PedidoCommand6 C
commandD K
)K L
{ 	
var 
pedido 
= 
command  
.  !
	MapEntity! *
(* +
)+ ,
;, -
await 
pedidoRepository "
." #
AdicionarAsync# 1
(1 2
pedido2 8
)8 9
;9 :
return 
new 
PedidoResult #
(# $
pedido$ *
)* +
;+ ,
} 	
private 
bool 
disposedValue "
=# $
false% *
;* +
	protected 
virtual 
void 
Dispose &
(& '
bool' +
	disposing, 5
)5 6
{ 	
if 
( 
! 
disposedValue 
) 
{ 
disposedValue 
= 
true  $
;$ %
pedidoRepository  
.  !
Dispose! (
(( )
)) *
;* +
} 
}   	
public!! 
void!! 
Dispose!! 
(!! 
)!! 
=>!!  
Dispose!!! (
(!!( )
true!!) -
)!!- .
;!!. /
}"" 
}## ƒ
¨/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Pedidos/Criar/ICriarPedidoHandler.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Pedidos8 ?
.? @
Criar@ E
{ 
public 

	interface 
ICriarPedidoHandler (
:) *
IDisposable+ 6
{ 
Task 
< 
PedidoResult 
> 
ExecutarAsync (
(( )
PedidoCommand) 6
command7 >
)> ?
;? @
}		 
}

 ›
œ/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Pedidos/PedidoCommand.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Pedidos8 ?
{ 
public 

class 
PedidoCommand 
{ 
public		 
IList		 
<		 
ItemCommand		  
>		  !
Itens		" '
{		( )
get		* -
;		- .
set		/ 2
;		2 3
}		4 5
public 
Pedido 
	MapEntity 
(  
)  !
=>" $
new% (
Pedido) /
(/ 0
MapItens0 8
(8 9
)9 :
): ;
;; <
private 
List 
< 
Item 
> 
MapItens #
(# $
)$ %
=>& (
Itens) .
.. /
Select/ 5
(5 6
p6 7
=>8 :
p; <
.< =
	MapEntity= F
(F G
)G H
)H I
.I J
ToListJ P
(P Q
)Q R
;R S
} 
public 

class 
ItemCommand 
{ 
public 
string 
Produto 
{ 
get  #
;# $
set% (
;( )
}* +
public 
decimal 
Preco 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 

Quantidade 
{ 
get  #
;# $
set% (
;( )
}* +
public 
Item 
	MapEntity 
( 
) 
=>  "
new# &
Item' +
(+ ,
Produto, 3
,3 4
Preco5 :
,: ;

Quantidade< F
)F G
;G H
} 
} Í
›/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Pedidos/PedidoResult.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Pedidos8 ?
{ 
public 

class 
PedidoResult 
{ 
public		 
PedidoResult		 
(		 
Pedido		 "
pedido		# )
)		) *
{

 	
Numero 
= 
pedido 
. 
Id 
; 
Itens 
= 
pedido 
. 
Itens  
.  !
Select! '
(' (
p( )
=>* ,
new- 0

ItemResult1 ;
(; <
p< =
.= >
Produto> E
,E F
pG H
.H I
PrecoI N
,N O
pP Q
.Q R

QuantidadeR \
)\ ]
)] ^
.^ _
ToList_ e
(e f
)f g
;g h
} 	
public 
int 
Numero 
{ 
get 
;  
set! $
;$ %
}& '
public 
IList 
< 

ItemResult 
>  
Itens! &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
int 
TotalDeItens 
{  !
get" %
{& '
return( .
Itens/ 4
!=5 7
null8 <
?= >
Itens? D
.D E
CountE J
:K L
$numM N
;N O
}P Q
}R S
public 
decimal 

ValorTotal !
{" #
get$ '
{( )
return* 0
Itens1 6
!=7 9
null: >
?? @
ItensA F
.F G
SumG J
(J K
pK L
=>M O
pP Q
.Q R
TotalR W
)W X
:Y Z
$num[ \
;\ ]
}^ _
}` a
} 
public 

class 

ItemResult 
{ 
public 

ItemResult 
( 
string  
produto! (
,( )
decimal* 1
preco2 7
,7 8
int9 <

quantidade= G
)G H
{ 	
Produto 
= 
produto 
; 
Preco 
= 
preco 
; 

Quantidade 
= 

quantidade #
;# $
} 	
public 
string 
Produto 
{ 
get  #
;# $
set% (
;( )
}* +
public 
decimal 
Preco 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 

Quantidade 
{ 
get  #
;# $
set% (
;( )
}* +
public   
decimal   
Total   
{   
get   "
{  # $
return  % +
(  , -
Preco  - 2
*  3 4

Quantidade  5 ?
)  ? @
;  @ A
}  B C
}  D E
}!! 
}"" Ä
¬/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Pedidos/Remover/IRemoverPedidoHandler.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Pedidos8 ?
.? @
Remover@ G
{ 
public 

	interface !
IRemoverPedidoHandler *
:+ ,
IDisposable- 8
{ 
Task 
ExecutarAsync 
( 
int 
id !
)! "
;" #
} 
}		 û
«/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Pedidos/Remover/RemoverPedidoHandler.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Pedidos8 ?
.? @
Remover@ G
{ 
public 

class  
RemoverPedidoHandler %
:& '!
IRemoverPedidoHandler( =
{ 
private		 
readonly		 
IPedidoRepository		 *
pedidoRepository		+ ;
;		; <
public  
RemoverPedidoHandler #
(# $
IPedidoRepository$ 5
pedidoRepository6 F
)F G
{ 	
this 
. 
pedidoRepository !
=" #
pedidoRepository$ 4
;4 5
} 	
public 
async 
Task 
ExecutarAsync '
(' (
int( +
id, .
). /
{ 	
var 
pedidoDb 
= 
await  
pedidoRepository! 1
.1 2
BuscarAsync2 =
(= >
id> @
)@ A
;A B
if 
( 
pedidoDb 
== 
null  
)  !
throw 
new (
PedidoNaoEncontradoException 6
(6 7
$"7 9
Pedido 9 @
{@ A
idA C
}C D
 nÃ£o encontradoD S
"S T
)T U
;U V
await 
pedidoRepository "
." #
RemoverAsync# /
(/ 0
id0 2
)2 3
;3 4
} 	
private 
bool 
disposedValue "
=# $
false% *
;* +
	protected 
virtual 
void 
Dispose &
(& '
bool' +
	disposing, 5
)5 6
{ 	
if 
( 
! 
disposedValue 
) 
{ 
disposedValue 
= 
true  $
;$ %
pedidoRepository  
.  !
Dispose! (
(( )
)) *
;* +
}   
}!! 	
public"" 
void"" 
Dispose"" 
("" 
)"" 
=>""  
Dispose""! (
(""( )
true"") -
)""- .
;"". /
}## 
}$$ 
¯/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Status/StatusPedido/IStatusPedidoHandler.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Status8 >
.> ?
StatusPedido? K
{ 
public 

	interface  
IStatusPedidoHandler )
:* +
IDisposable, 7
{ 
Task	 
< 
StatusPedidoResult  
>  !
ExecutarAsync" /
(/ 0
StatusPedidoCommand0 C
commandD K
)K L
;L M
} 
}		 ñK
®/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Status/StatusPedido/StatusPedidoHandler.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Status8 >
.> ?
StatusPedido? K
{ 
public		 

class		 
StatusPedidoHandler		 $
:		% & 
IStatusPedidoHandler		' ;
{

 
private 
readonly 
IPedidoRepository *
pedidoRepository+ ;
;; <
private 
Pedido 
pedido 
{ 
get  #
;# $
set% (
;( )
}* +
private 
StatusPedidoCommand #
command$ +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
private 
bool 
pedidoExisteNoBanco (
;( )
public 
StatusPedidoHandler "
(" #
IPedidoRepository# 4
pedidoReposito5 C
)C D
{ 	
this 
. 
pedidoRepository !
=" #
pedidoReposito$ 2
;2 3
} 	
public 
async 
Task 
< 
StatusPedidoResult ,
>, -
ExecutarAsync. ;
(; <
StatusPedidoCommand< O
commandP W
)W X
{ 	
this 
. 
command 
= 
command "
;" #
this 
. 
pedido 
= 
await 
pedidoRepository  0
.0 1
BuscarAsync1 <
(< =
command= D
.D E
PedidoE K
)K L
;L M
var 
verificarStatus 
=  !"
RetornarStatusDoPedido" 8
(8 9
)9 :
;: ;
return 
new 
StatusPedidoResult )
() *
)* +
{, -
Pedido. 4
=5 6
command7 >
.> ?
Pedido? E
,E F
StatusG M
=N O
verificarStatusP _
}` a
;a b
} 	
public   
string   
[   
]   "
RetornarStatusDoPedido   .
(  . /
)  / 0
{!! 	
var"" #
valoresDeStatusDoPedido"" '
=""( )
new""* -

Dictionary"". 8
<""8 9
StatusPedidoType""9 I
,""I J
bool""K O
>""O P
{## 
{$$ 
StatusPedidoType$$ "
.$$" #"
CODIGO_PEDIDO_INVALIDO$$# 9
,$$9 :
SePedidoInvalido$$; K
($$K L
)$$L M
}$$N O
,$$O P
{%% 
StatusPedidoType%% "
.%%" #
	REPROVADO%%# ,
,%%, -
SePedidoReprovado%%. ?
(%%? @
)%%@ A
}%%B C
,%%C D
{&& 
StatusPedidoType&& "
.&&" #
APROVADO&&# +
,&&+ ,
SePedidoAprovado&&- =
(&&= >
)&&> ?
}&&@ A
,&&A B
{'' 
StatusPedidoType'' "
.''" #"
APROVADO_VALOR_A_MENOR''# 9
,''9 :&
SePedidoAprovadoValorMenor''; U
(''U V
)''V W
}''X Y
,''Y Z
{(( 
StatusPedidoType(( "
.((" # 
APROVADO_QTD_A_MENOR((# 7
,((7 8+
SePedidoAprovadoQuantidadeMenor((9 X
(((X Y
)((Y Z
}(([ \
,((\ ]
{)) 
StatusPedidoType)) "
.))" #"
APROVADO_VALOR_A_MAIOR))# 9
,))9 :&
SePedidoAprovadoValorMaior)); U
())U V
)))V W
}))X Y
,))Y Z
{** 
StatusPedidoType** "
.**" # 
APROVADO_QTD_A_MAIOR**# 7
,**7 8+
SePedidoAprovadoQuantidadeMaior**9 X
(**X Y
)**Y Z
}**[ \
,**\ ]
}++ 
;++ 
return-- #
valoresDeStatusDoPedido-- *
.--* +
Where--+ 0
(--0 1
p--1 2
=>--3 5
p--6 7
.--7 8
Value--8 =
==--> @
true--A E
)--E F
.--F G
Select--G M
(--M N
p--N O
=>--P R
p--S T
.--T U
Key--U X
.--X Y
ToString--Y a
(--a b
)--b c
)--c d
.--d e
ToArray--e l
(--l m
)--m n
;--n o
}.. 	
private00 
bool00 
SePedidoInvalido00 %
(00% &
)00& '
=>00( *
!00+ ,
this00, 0
.000 1
pedidoExisteNoBanco001 D
;00D E
private22 
bool22 
SePedidoReprovado22 &
(22& '
)22' (
=>22) +
this22, 0
.220 1
pedidoExisteNoBanco221 D
&&22E G
this22H L
.22L M
command22M T
.22T U
Status22U [
==22\ ^
StatusPedidoType22_ o
.22o p
	REPROVADO22p y
.22y z
ToString	22z ‚
(
22‚ ƒ
)
22ƒ „
;
22„ …
private44 
bool44 
SePedidoAprovado44 %
(44% &
)44& '
=>44( *
this55 
.55 
pedidoExisteNoBanco55 $
&&55% '
this55( ,
.55, -
command55- 4
.554 5
ItensAprovados555 C
==55D F
this55G K
.55K L
pedido55L R
.55R S
TotalDeItens55S _
&&55` b
this66 
.66 
command66 
.66 
ValorAprovado66 &
==66' )
this66* .
.66. /
pedido66/ 5
.665 6

ValorTotal666 @
&&66A C
this77 
.77 
command77 
.77 
Status77 
==77  "
StatusPedidoType77# 3
.773 4
APROVADO774 <
.77< =
ToString77= E
(77E F
)77F G
;77G H
private99 
bool99 &
SePedidoAprovadoValorMenor99 /
(99/ 0
)990 1
=>992 4
pedidoExisteNoBanco:: 
&&::  "
this;; 
.;; 
command;; 
.;; 
ValorAprovado;; &
<;;' (
this;;) -
.;;- .
pedido;;. 4
.;;4 5

ValorTotal;;5 ?
&&;;@ B
this<< 
.<< 
command<< 
.<< 
Status<< 
==<<  "
StatusPedidoType<<# 3
.<<3 4
APROVADO<<4 <
.<<< =
ToString<<= E
(<<E F
)<<F G
;<<G H
private>> 
bool>> +
SePedidoAprovadoQuantidadeMenor>> 4
(>>4 5
)>>5 6
=>>>7 9
pedidoExisteNoBanco?? 
&&??  "
this@@ 
.@@ 
command@@ 
.@@ 
ItensAprovados@@ '
<@@( )
this@@* .
.@@. /
pedido@@/ 5
.@@5 6
TotalDeItens@@6 B
&&@@C E
thisAA 
.AA 
commandAA 
.AA 
StatusAA 
==AA  "
StatusPedidoTypeAA# 3
.AA3 4
APROVADOAA4 <
.AA< =
ToStringAA= E
(AAE F
)AAF G
;AAG H
privateDD 
boolDD &
SePedidoAprovadoValorMaiorDD /
(DD/ 0
)DD0 1
=>DD2 4
pedidoExisteNoBancoEE 
&&EE  "
thisFF 
.FF 
commandFF 
.FF 
ValorAprovadoFF &
>FF' (
thisFF) -
.FF- .
pedidoFF. 4
.FF4 5

ValorTotalFF5 ?
&&FF@ B
thisGG 
.GG 
commandGG 
.GG 
StatusGG 
==GG  "
StatusPedidoTypeGG# 3
.GG3 4
APROVADOGG4 <
.GG< =
ToStringGG= E
(GGE F
)GGF G
;GGG H
privateII 
boolII +
SePedidoAprovadoQuantidadeMaiorII 4
(II4 5
)II5 6
=>II7 9
pedidoExisteNoBancoJJ 
&&JJ  "
thisKK 
.KK 
commandKK 
.KK 
ItensAprovadosKK '
>KK( )
thisKK* .
.KK. /
pedidoKK/ 5
.KK5 6
TotalDeItensKK6 B
&&KKC E
thisLL 
.LL 
commandLL 
.LL 
StatusLL 
==LL  "
StatusPedidoTypeLL# 3
.LL3 4
APROVADOLL4 <
.LL< =
ToStringLL= E
(LLE F
)LLF G
;LLG H
privateNN 
boolNN 
disposedValueNN "
=NN# $
falseNN% *
;NN* +
	protectedOO 
virtualOO 
voidOO 
DisposeOO &
(OO& '
boolOO' +
	disposingOO, 5
)OO5 6
{PP 	
ifQQ 
(QQ 
!QQ 
disposedValueQQ 
)QQ 
{RR 
disposedValueSS 
=SS 
trueSS  $
;SS$ %
}TT 
}UU 	
publicVV 
voidVV 
DisposeVV 
(VV 
)VV 
=>VV  
DisposeVV! (
(VV( )
trueVV) -
)VV- .
;VV. /
}WW 
}XX ‘
¡/Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Status/StatusPedidoCommand.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Status8 >
{ 
public 

class 
StatusPedidoCommand $
{ 
[ 	
Required	 
( 
ErrorMessage 
= 
$str <
)< =
]= >
public 
string 
Status 
{ 
get "
;" #
set$ '
;' (
}) *
[		 	
Required			 
(		 
ErrorMessage		 
=		 
$str		 C
)		C D
]		D E
public

 
int

 
ItensAprovados

 !
{

" #
get

$ '
;

' (
set

) ,
;

, -
}

. /
[ 	
Required	 
( 
ErrorMessage 
= 
$str C
)C D
]D E
public 
decimal 
ValorAprovado $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	
Required	 
( 
ErrorMessage 
= 
$str <
)< =
]= >
public 
int 
Pedido 
{ 
get 
;  
set! $
;$ %
}& '
} 
} à	
 /Users/guilhermelyracampos/Documents/programacao/source/git/backend-challenge-pedidos/BackendChallenge.Pedidos.Application/UseCases/Status/StatusPedidoResult.cs
	namespace 	
BackendChallenge
 
. 
Pedidos "
." #
Application# .
.. /
UseCases/ 7
.7 8
Status8 >
{ 
public 

class 
StatusPedidoResult #
{ 
public 
int 
Pedido 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
[ 
] 
Status 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
public		 

enum		 
StatusPedidoType		  
{

 "
CODIGO_PEDIDO_INVALIDO 
, 
	REPROVADO 
, 
APROVADO 
, "
APROVADO_VALOR_A_MENOR 
,  
APROVADO_QTD_A_MENOR 
, "
APROVADO_VALOR_A_MAIOR 
,  
APROVADO_QTD_A_MAIOR 
, 
} 
} 