## Introdução

Api criada para gerenciar pedidos e seus possíveis status. <br/>
Aplicação desenvolvida em .netcore 5.0 com c#. Aplicando padrões de desenvolvimento clean architecture, clean code, solid e DDD. Com testes unitários e integrados.

### usando a api
Para rodar a api em sua máquina, clone este repositório e em seguida rode os comandos abaixo no diretório onde o repositório foi clonado:

```
cd BackendChallenge.Pedidos.Api
dotnet run
```
A aplicação irá rodar no endereço [http://localhost:5000/swagger](http://localhost:5000/swagger)

[![](https://gui-primeiro-bucket.s3.us-east-2.amazonaws.com/swagger.png)](https://gui-primeiro-bucket.s3.us-east-2.amazonaws.com/swagger.png)

### executando testes
Os testes unitários e integrados foram feitos com xunit e moq. <br />
Para executar os testes via linha de comando, execute os passos abaixo na pasta do projeto:

```
cd BackendChallenge.Pedidos.Tests
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=Cobertura
```
A cobertura de testes:
[![](https://gui-primeiro-bucket.s3.us-east-2.amazonaws.com/testes.png)](https://gui-primeiro-bucket.s3.us-east-2.amazonaws.com/testes.png)
