# API de Cadastro de Produtos e Fornecedores
Esta é uma API REST desenvolvida durante o curso "Desenvolvedor.io". A API permite o cadastro e gerenciamento de produtos e fornecedores. Abaixo, você encontrará informações importantes sobre os principais tópicos de aprendizado.

## Autenticação JWT
A API utiliza autenticação JWT (JSON Web Token) para garantir a segurança das operações. Ao enviar uma requisição para a API, o cliente deve incluir um token de acesso válido no cabeçalho de autorização. Para obter um token de acesso, é necessário fazer uma requisição de autenticação fornecendo as credenciais corretas. O token de acesso recebido deverá ser utilizado nas requisições subsequentes.

## Versionamento
A API segue uma estratégia de versionamento para garantir a compatibilidade entre diferentes versões da API. As versões são representadas no caminho da URL. Por exemplo, para acessar a versão 1 da API, a URL seria /api/v1/.... Isso permite que você mantenha a estabilidade de suas integrações, mesmo quando novas versões da API forem lançadas.

## Documentação
A documentação da API foi gerada utilizando o Swagger, uma ferramenta popular para documentação de APIs. Ela fornece informações detalhadas sobre os endpoints disponíveis, os parâmetros aceitos, as respostas retornadas e exemplos de uso. 

## Logging
A API utiliza logging para registrar informações relevantes sobre as operações e eventos do sistema. Os logs são importantes para fins de depuração, monitoramento e análise de problemas. 

## Monitoramento
O monitoramento é uma parte crucial da operação da API de Cadastro de Produtos e Fornecedores. É altamente recomendado configurar uma solução de monitoramento para acompanhar o desempenho, a disponibilidade e a integridade da API.

Nossa API utiliza o elmah.io e HealthCheck para monitoramento.
