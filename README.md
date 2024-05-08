# API Modelo Dotnet

API desenvolvida em Dotnet v8.0.204 e utilizando como Banco de Dados PostgreSQL 12

### Organização do Projeto

Os diretórios são separados conforme a sua Função.

### Data

Contém as entidades de banco de dados, separado em `Entities` contem a mesma estrutura da tabela e `Repository` os métodos para manipulação de dados.

### Presentation

Aqui temos a informação separada para a forma de exibição, o `Controllers` temos rotas juntamente ao seu método que manipula as informações de entrada. Em `ViewModels` define o formato que a informação é exibida.

### Services

Aqui estão os serviços e interfaces que trabalham a informação, e chamam os métodos que manipulam os dados.

### Instalação

Criação de usuário

    CREATE USER andre WITH PASSWORD 'qwepoi123'
    ALTER USER andre WITH SUPERUSER;
    \q

Crie também um schema específico para o projeto

    create database prototipo owner = "andre"

Depois dessa etapa já é possível executar o DDL para criar as estruturas necessárias

    psql -U andre -d prototipo -f ./scripts/ddl.sql

Caso o comando acima tenha ocorrido como o esperado, separei 30 registros que podem ser utilizados inicialmente

    psql -U andre -d prototipo -f ./scripts/dml.sql

### Rodando o Ambiente

Para iniciar o ambiente utilize o comando, o servidor irá rodar por definição na porta 5269. Essa porta pode mudar, por isso a porta ao rodar o comando.

    dotnet run

### Swagger

O serviço está disponível no endereço http://localhost:5269/swagger/index.html

### Autenticação

Todos os End points são autenticados, para poder acessar eles utilize o end-point de `login`. Após obter o token é necessário adicionar a autenticação Bearer Token com o token obtido.
