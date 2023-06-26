# API de Cadastro de Produtos e Fornecedores
Esta é uma API REST desenvolvida durante o curso "Desenvolvedor.io". A API permite o cadastro e gerenciamento de produtos e fornecedores. Abaixo, você encontrará informações importantes sobre a API, incluindo autenticação JWT, CORS, versionamento e documentação.

Autenticação JWT
A API utiliza autenticação JWT (JSON Web Token) para garantir a segurança das operações. Ao enviar uma requisição para a API, o cliente deve incluir um token de acesso válido no cabeçalho de autorização. Para obter um token de acesso, é necessário fazer uma requisição de autenticação fornecendo as credenciais corretas. O token de acesso recebido deverá ser utilizado nas requisições subsequentes.

CORS (Cross-Origin Resource Sharing)
A API está configurada para permitir o compartilhamento de recursos entre diferentes origens (Cross-Origin Resource Sharing). Isso permite que clientes em domínios diferentes acessem a API sem problemas de bloqueio por políticas de segurança do navegador. Certifique-se de configurar as origens permitidas corretamente para atender aos requisitos de segurança do seu aplicativo.

Versionamento
A API segue uma estratégia de versionamento para garantir a compatibilidade entre diferentes versões da API. As versões são representadas no caminho da URL. Por exemplo, para acessar a versão 1 da API, a URL seria /api/v1/.... Isso permite que você mantenha a estabilidade de suas integrações, mesmo quando novas versões da API forem lançadas.

Documentação
A documentação da API foi gerada utilizando o Swagger, uma ferramenta popular para documentação de APIs. Ela fornece informações detalhadas sobre os endpoints disponíveis, os parâmetros aceitos, as respostas retornadas e exemplos de uso. 
