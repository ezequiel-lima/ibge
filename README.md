# API de Localidades Com  Arquitetura de Minimal API 

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/ezequiel-lima/ibge/blob/master/LICENSE.txt)

A API é um serviço que oferece informações detalhadas sobre localidades no Brasil.
O projeto foi desenvolvido usando a arquitetura Minimal API do ASP.NET, 
que proporciona uma abordagem simplificada e enxuta para a criação de serviços web.

## Demonstração 

Endpoints

![Endpoints](https://github.com/ezequiel-lima/ibge/assets/81567476/0bf7a3ee-188e-41a6-9d41-2fee15b0750a)

## Funcionalidades

O Projeto inclui recursos de autenticação e autorização para proteger os dados e as funcionalidades, 
garantindo que apenas usuários autorizados tenham acesso às operações restritas.

1. Consultar informações de localidades por **Cidade**. Esta funcionalidade permite aos usuários obter informações detalhadas sobre cidades no Brasil, fornecendo o nome da cidade como parâmetro.

2. Consultar informações de localidades por **Estado**. Os usuários podem acessar informações detalhadas sobre todas as localidades dentro de um estado brasileiro específico, fornecendo o nome do estado como parâmetro.

3. Consultar informações de uma localidade por **Código IBGE**. Esta funcionalidade permite aos usuários obter informações detalhadas sobre uma localidade específica usando seu código IBGE como parâmetro de consulta.

4. Cadastrar informações de uma localidade. Os usuários autorizados podem cadastrar informações detalhadas sobre uma nova localidade no sistema.

5. Alterar informações de uma localidade. Os usuários autorizados podem atualizar de informações sobre uma localidade já cadastrada no sistema, usando seu **Código IBGE** como identificação.

6. Deletar informações de uma localidade. Os usuários autorizados podem excluir informações sobre uma localidade já cadastrada no sistema, usando seu **ID** como identificação.


