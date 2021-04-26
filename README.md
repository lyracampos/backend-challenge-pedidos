## introdução
Api para processamento de pedido e controle de seus status. <br/>
Api escrita em c# com .net5.0. Usei este case para colocar em prática padrões de clean architecture, clean code, solid, ddd, api restful.

## quick start
### rodando com docker
a imagem está disponível [nesse](https://hub.docker.com/r/guilhermelyracampos/backendchallenge-pedidos "nesse") repositório do dockerhub. Execute a imagem com o comando abaixo:
```
docker run -d -p 8090:80 --name pedidos guilhermelyracampos/backendchallenge-pedidos:latest
```


### rodando local
clone este repositório e abra a solution no visual studio 2019, ou execute os comandos abaixo:
```
cd BackendChallenge.Pedidos.Api
dotnet run
```
### executando testes
os testes unitários e integrados foram feitos com xunit e moq. para executar os testes rode script abaixo:
```
cd BackendChallenge.Pedidos.Tests
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=Cobertura
```
[![testes](https://gui-primeiro-bucket.s3.us-east-2.amazonaws.com/testes1.png "testes")](https://gui-primeiro-bucket.s3.us-east-2.amazonaws.com/testes1.png "testes")

### author
[Guilherme Lyra](https://github.com/lyracampos "Guilherme Lyra")

