# :computer: Desafio - Pesquisa de entrega - API em DotNet  :computer:
API para consulta de múltiplos CEPs usando ViaCEP, utilizando a tecnologia DontNet com C#

## :pushpin: Visão Geral

Esta API permite consultar informações de múltiplos CEPs utilizando o serviço ViaCEP. Retorna os dados dos endereços em formato JSON.

## Pré-requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/) (opcional, mas recomendado)
- [Git](https://git-scm.com/)

## Instalação
1. Clone o repositório:

    ```bash
    git clone https://github.com/seu-usuario/ConsultaCEPAPIDotNet.git
    cd ConsultaCEPAPIDotNet
    ```

2. Restaure os pacotes NuGet:

    ```bash
    dotnet restore
    ```

## Como Rodar a Aplicação

1. Compile a aplicação:

    ```bash
    dotnet build
    ```

2. Execute a aplicação:

    ```bash
    dotnet run
    ```

3. A aplicação estará disponível em `http://localhost:5104`.

## Rotas da API

### Consulta de CEPs

- **Rota:** `/api/ConsultaCep/search/local/{ceps}`
- **Método:** `GET`
- **Descrição:** Consulta múltiplos CEPs fornecidos na URL e retorna as informações dos endereços.
- **Parâmetros:**
  - `ceps` (obrigatório): Uma lista de CEPs separados por vírgula. Exemplo: `01001000,17560246`.
- **Exemplo de Requisição:**

    ```http
    GET http://localhost:5104/api/ConsultaCep/search/local/01001000,17560246
    Accept: application/json  
	```
***OBS: verifica qual código o sistema irá gerar quando der o donet run, pois a numeração 5104 pode variar, ai deverá atyaluzar***

- *Exemplo de Resposta:*****


    ```json
    {
      "validResults": [
        {
          "cep": "01001000",
          "logradouro": "Praça da Sé",
          "complemento": "lado ímpar",
          "bairro": "Sé",
          "localidade": "São Paulo",
          "uf": "SP",
          "ibge": "3550308",
          "gia": "1004",
          "ddd": "11",
          "siafi": "7107",
          "label": "Praça da Sé, São Paulo"
        },
        {
          "cep": "17560246",
          "logradouro": "Avenida Paulista",
          "complemento": "de 1600/1601 a 1698/1699",
          "bairro": "CECAP",
          "localidade": "Vera Cruz",
          "uf": "SP",
          "ibge": "3556602",
          "gia": "7134",
          "ddd": "14",
          "siafi": "7235",
          "label": "Avenida Paulista, Vera Cruz"
        }
      ],
      "invalidCeps": []
    }
    ```

### Tratamento de Erros

- **CEP não fornecido:**

    ```json
    {
      "message": "Não identificado CEP. Por favor, forneça um número de CEP válido."
    }
    ```

- **CEP inválido:**

    ```json
    {
      "message": "CEPs inválidos: 12345678"
    }
    ```

## Tecnologias Utilizadas

- .NET 8.0
- ASP.NET Core
- Newtonsoft.Json

## Contribuição

Se você deseja contribuir com este projeto, por favor, faça um fork do repositório, crie uma branch para suas alterações e envie um pull request.

1. Faça o fork do projeto
2. Crie uma nova branch (`git checkout -b feature/nova-feature`)
3. Commit suas alterações (`git commit -m 'Adicionando nova feature'`)
4. Envie para o branch (`git push origin feature/nova-feature`)
5. Abra um pull request

## Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.