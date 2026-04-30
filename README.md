# 🛒 Sistema de Lista de Compras em C#

## 📌 Descrição do Projeto

Este projeto é uma aplicação de console desenvolvida em **C#** para gerenciamento completo de listas de compras, permitindo ao usuário cadastrar, editar, visualizar e excluir:

- Categorias
- Produtos
- Listas de Compras
- Itens das Listas

O sistema utiliza **persistência de dados em JSON**, garantindo que todas as informações sejam salvas automaticamente e restauradas ao iniciar o programa.

---

## 🎯 Objetivo

Facilitar o controle de compras de forma organizada, permitindo:

- Separação de produtos por categorias
- Controle de preços e quantidades
- Cálculo automático de valor total
- Organização visual com categorias coloridas
- Armazenamento permanente dos dados

---

## ⚙️ Funcionalidades Principais

### 🗂️ Gestão de Categorias

- Cadastrar categorias
- Editar nome e cor
- Excluir categorias vazias
- Visualizar categorias cadastradas

### 📦 Gestão de Produtos

- Cadastrar produtos em categorias
- Editar produtos
- Excluir produtos
- Visualizar produtos por categoria

### 🛒 Gestão de Listas de Compras

- Criar listas de compras
- Editar nome e status
- Excluir listas vazias
- Visualizar listas

### 📋 Gestão de Itens da Lista

- Adicionar produtos às listas
- Definir quantidade
- Visualizar itens detalhados
- Excluir itens
- Cálculo automático de subtotal e total

---

## 🧠 Regras de Negócio

### Categorias

- ❌ Não permite categorias duplicadas
- ❌ Não permite excluir categorias que possuam produtos
- 📏 Nome deve ter no máximo 50 caracteres

### Produtos

- ❌ Não permite produtos duplicados na mesma categoria
- 📏 Nome deve conter entre 2 e 100 caracteres
- 💲 Preço deve ser numérico válido

### Listas de Compras

- 📏 Nome deve conter entre 3 e 100 caracteres
- ❌ Não permite excluir listas com itens cadastrados
- 📅 Data de criação automática
- 📌 Status padrão: **Aberta**
- ✅ Pode ser alterado para **Concluída**

### Itens da Lista

- ❌ Não permite duplicação de produto na mesma categoria da lista
- 💰 Atualiza automaticamente:
  - Total de produtos
  - Valor total
- 🗑️ Remove categorias vazias automaticamente

---

## 🏗️ Estrutura das Classes

### `Program`

Responsável por:

- Exibir menus
- Controlar fluxo principal
- Carregar dados do arquivo JSON
- Salvar alterações

### `Controller`

Classe principal de gerenciamento:

- CRUD de categorias
- CRUD de produtos
- CRUD de listas
- CRUD de itens
- Regras de validação

### `Categoria`

Representa categorias de produtos:

- Nome
- Cor
- Lista de produtos

### `Produto`

Representa um produto:

- Nome
- Unidade de medida
- Preço
- Quantidade

### `ListaDeCompra`

Representa uma lista de compras:

- Nome
- Status
- Total de produtos
- Valor total
- Data de criação
- Categorias e itens

---

## 💾 Persistência de Dados

Os dados são armazenados automaticamente no arquivo:

```json
Serializable.json
```

### Benefícios:

- Salvamento automático
- Recuperação ao iniciar
- Estrutura organizada
- Serialização com `System.Text.Json`

---

## ▶️ Como Executar

### Pré-requisitos:

- .NET SDK instalado
- Visual Studio ou VS Code

### Passos:

```bash
dotnet run
```

---

## 🖥️ Menu Principal

```txt
1 - Gerenciar Categorias
2 - Gerenciar Produtos
3 - Gerenciar Lista de Compras
4 - Gerenciar Itens da Lista de Compras
5 - Sair
```

---

## 🎨 Diferenciais do Projeto

- Interface interativa em console
- Categorias coloridas usando ANSI
- Persistência JSON
- Organização modular
- Validação de entradas
- Controle financeiro automático

---

## 📊 Exemplo de Fluxo

### Cadastro:

1. Criar categoria
2. Adicionar produtos
3. Criar lista de compras
4. Inserir produtos na lista
5. Visualizar total da compra

---

## 🚀 Melhorias Futuras

- Interface gráfica
- Busca por nome
- Relatórios de gastos
- Exportação para PDF/Excel
- Controle de usuários
- Histórico de compras
- Ordenação e filtros

---

## 📚 Tecnologias Utilizadas

- C#
- .NET
- System.Text.Json
- Programação Orientada a Objetos (POO)
- Console Application

---

## 👨‍💻 Conceitos Aplicados

- Encapsulamento
- Serialização
- CRUD
- Estruturas de repetição
- Tratamento de exceções
- Organização em camadas
- Validação de dados

---

## 📄 Conclusão

Este sistema oferece uma solução robusta para gerenciamento de compras via terminal, aplicando conceitos fundamentais de desenvolvimento de software como:

- Organização modular
- Persistência de dados
- Regras de negócio
- Experiência de usuário em console

É um projeto ideal para estudos de:

- Programação Orientada a Objetos
- Estruturação de sistemas
- Manipulação de arquivos JSON
- Desenvolvimento de aplicações administrativas
