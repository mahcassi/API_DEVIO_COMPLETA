# API de Cadastro de Produtos e Fornecedores
Esta é uma API REST desenvolvida durante o curso "Desenvolvedor.io". A API permite o cadastro e gerenciamento de produtos e fornecedores. Abaixo, você encontrará informações importantes sobre os principais tópicos de aprendizado.

## Autenticação JWT
A API utiliza autenticação JWT (JSON Web Token) para garantir a segurança das operações. Ao enviar uma requisição para a API, o cliente deve incluir um token de acesso válido no cabeçalho de autorização. Para obter um token de acesso, é necessário fazer uma requisição de autenticação fornecendo as credenciais corretas. O token de acesso recebido deverá ser utilizado nas requisições subsequentes.

## Versionamento
A API segue uma estratégia de versionamento para garantir a compatibilidade entre diferentes versões da API. As versões são representadas no caminho da URL. Por exemplo, para acessar a versão 1 da API, a URL seria /api/v1/.... Isso permite que você mantenha a estabilidade de suas integrações, mesmo quando novas versões da API forem lançadas.

## Documentação
A documentação da API foi gerada utilizando o Swagger, uma ferramenta popular para documentação de APIs. Ela fornece informações detalhadas sobre os endpoints disponíveis, os parâmetros aceitos, as respostas retornadas e exemplos de uso. 

## Logging
A API utiliza logging para registrar informações relevantes sobre as operações e eventos do sistema. Os logs são importantes para fins de depuração, monitoramento e análise de problemas. É recomendado que você configure um sistema de logging apropriado para capturar os registros da API e armazená-los de forma adequada.

## Monitoramento
O monitoramento é essencial para garantir o desempenho e a disponibilidade da API. É altamente recomendado configurar uma solução de monitoramento para acompanhar a saúde da API, como o tempo de resposta, a taxa de erros e a disponibilidade. Existem diversas ferramentas disponíveis para isso, como o Prometheus, Grafana, New Relic, entre outras. Certifique-se de configurar e utilizar uma solução de monitoramento adequada para a sua API.
