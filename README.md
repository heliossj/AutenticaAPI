#### AutenticaAPI

Endpoints (Postman)
```sh
https://drive.google.com/drive/folders/192vemLYH2yTxT2ZqbgIDKqkg9qLx9-rb?usp=share_link
```
## Observações
- Alterar as credenciais do banco de dados no arquivo "appsettings.json";
- Gerar e aplicar o migrations;


Para rodar a aplicação no container é necessário descomentar o arquivo Dockerfile existente no projeto
- acessar a pasta raiz pelo terminal
- Possuir a JDK da versão usada
```sh
docker pull mcr.microsoft.com/dotnet/nightly/sdk:6.0
```
Aplicar a build :

```sh
docker build -t AutenticaAPI:1.0 .
```

Definir a porta e a imagem o qual deseja iniciar

```sh
docker run —name autenticaapi -d -p 5050:80 AutenticaAPI:1.0
```
*É preciso alterar as portas dos endpoints* [Porta ilustrativa]


Grato pela oportunidade de participar :)
