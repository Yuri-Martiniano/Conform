# Documento de Interface - Contract Analyzer

## 1. Introdução

O objetivo deste documento é detalhar as interfaces do **Contract Analyzer**, especificando cada tela e os componentes que compõem o design e funcionalidade da aplicação. Aqui você encontrará descrições sobre os layouts, componentes de interface, fluxo de navegação e interações previstas para cada funcionalidade.

## 2. Estrutura de Interface

### 2.1. Tela de Login

- **Descrição**: Tela inicial onde o usuário realiza login para acessar o sistema.
- **Componentes**:
  - **Campo de Usuário**: Input para o nome de usuário ou e-mail.
  - **Campo de Senha**: Input para senha do usuário.
  - **Botão de Login**: Botão para enviar as credenciais.
  - **Link de Esqueceu a Senha**: Link para redirecionar para recuperação de senha.
- **Fluxo de Interação**:
  1. O usuário insere suas credenciais.
  2. Clica no botão de Login.
  3. Caso as credenciais sejam válidas, é redirecionado para a **Tela de Dashboard**.
- **Mensagens de Erro**:
  - "Nome de usuário ou senha incorretos" em caso de falha de autenticação.

### 2.2. Tela de Dashboard

- **Descrição**: Tela principal do sistema, onde o usuário pode ver uma visão geral dos contratos e acessa funcionalidades principais.
- **Componentes**:
  - **Menu Lateral**: Lista de links para navegação (Upload de Contrato, Listagem, Configurações).
  - **Resumo de Contratos**: Cards com informações sobre o número de contratos pendentes, analisados e em revisão.
  - **Botão de Ação Rápida**: Botão para adicionar um novo contrato.
  - **Tabela de Contratos Recentes**: Exibe contratos adicionados recentemente com informações básicas (Título, Data de Upload, Status).
- **Fluxo de Interação**:
  1. O usuário pode clicar no menu lateral para navegar entre diferentes funcionalidades.
  2. Ao clicar no **Botão de Ação Rápida**, o usuário é redirecionado para a **Tela de Upload de Contrato**.

### 2.3. Tela de Upload de Contrato

- **Descrição**: Tela onde o usuário pode fazer o upload de novos contratos para análise.
- **Componentes**:
  - **Campo de Título**: Input para o título do contrato.
  - **Campo de Conteúdo**: Área de texto para o conteúdo do contrato (ou upload de arquivo PDF/DOCX).
  - **Botão de Upload**: Envia o contrato para o backend para processamento.
- **Fluxo de Interação**:
  1. O usuário preenche o título e o conteúdo do contrato.
  2. Clica no **Botão de Upload**.
  3. O sistema exibe uma mensagem de sucesso e redireciona para a **Tela de Listagem de Contratos**.

### 2.4. Tela de Listagem de Contratos

- **Descrição**: Tela que exibe todos os contratos que foram enviados e processados pelo sistema.
- **Componentes**:
  - **Tabela de Contratos**: Exibe todos os contratos com colunas de Título, Data de Upload, Status e Ações.
  - **Filtro de Status**: Filtro para exibir apenas contratos em um determinado status (Pendentes, Analisados, Em Revisão).
  - **Botão de Visualizar Detalhes**: Link em cada linha para acessar a **Tela de Detalhes do Contrato**.
- **Fluxo de Interação**:
  1. O usuário pode usar o filtro para buscar contratos específicos.
  2. Clicar no **Botão de Visualizar Detalhes** para ver mais informações sobre um contrato específico.

### 2.5. Tela de Detalhes do Contrato

- **Descrição**: Tela que exibe os detalhes completos de um contrato, incluindo as análises realizadas e sugestões de alterações.
- **Componentes**:
  - **Visualização do Contrato**: Exibe o conteúdo completo do contrato.
  - **Painel de Análises**: Mostra as cláusulas destacadas e informações extraídas pelo processamento de linguagem natural (NLP).
  - **Sugestões de Alterações**: Lista de alterações sugeridas para conformidade ou melhoria.
  - **Botões de Ação**: Ações disponíveis como "Enviar para Revisão", "Editar Contrato", ou "Enviar para Assinatura".
- **Fluxo de Interação**:
  1. O usuário pode revisar as cláusulas destacadas e sugerir alterações.
  2. Clicar no botão "Enviar para Assinatura" para integrar o contrato com a API de DocuSign ou Adobe Sign.

## 3. Padrões de Interface

### 3.1. Cores Utilizadas
- **Primária**: Azul (#007bff) para botões e destaques.
- **Secundária**: Cinza (#6c757d) para textos secundários.
- **Sucesso**: Verde (#28a745) para mensagens de sucesso.
- **Erro**: Vermelho (#dc3545) para mensagens de erro e alertas.

### 3.2. Tipografia
- **Fonte Primária**: Roboto.
- **Tamanhos**:
  - Título Principal: 24px, Negrito.
  - Subtítulo: 20px, Negrito.
  - Texto Normal: 16px.
- **Estilo**:
  - Botões e links possuem bordas arredondadas para um visual mais moderno.
  - Campos de input com bordas finas e sombra leve para destacar os pontos de interação.

### 3.3. Ícones Utilizados
Utilizamos o conjunto de ícones do [FontAwesome](https://fontawesome.com/) para indicar ações e status.

- **Ícones de Ação**:
  - "upload": ícone de seta para cima.
  - "visualizar": ícone de olho.
  - "editar": ícone de lápis.
  - "assinar": ícone de caneta.

## 4. Fluxo de Navegação

### 4.1. Navegação Principal

1. **Login** → Dashboard → Listagem de Contratos → Detalhes do Contrato.
2. **Login** → Dashboard → Upload de Contrato → Listagem de Contratos.

### 4.2. Navegação Secundária

- Menu lateral acessível em todas as telas, exceto na tela de Login.
- Breadcrumbs no topo das telas para facilitar a navegação de volta para a tela anterior.

## 5. Responsividade e Design Mobile

O design é responsivo e adapta-se a dispositivos móveis e desktops:

- **Telas Pequenas (até 576px)**:
  - Menu lateral colapsa em um ícone de "menu hambúrguer".
  - Tabelas se transformam em listas verticais.
- **Telas Médias e Grandes**:
  - Layout com duas colunas: menu lateral fixo à esquerda e conteúdo à direita.

## 6. Considerações Finais

O design das interfaces foi pensado para proporcionar uma experiência de usuário intuitiva e funcional, seguindo as melhores práticas de usabilidade. As cores, tipografia e layout foram escolhidos para manter a consistência visual e tornar o sistema fácil de navegar e utilizar.

Se desejar adicionar mais componentes ou modificar as interfaces descritas, basta ajustar os detalhes conforme as necessidades do projeto.
