# Universidade - Sistema de Matrículas

Este repositório contém a modelagem de um sistema de matrículas, desenvolvida como parte de uma atividade acadêmica. O objetivo foi projetar um modelo que representasse a estrutura de um sistema de matrículas, abrangendo entidades e seus relacionamentos.

## Modelagem

Abaixo está o diagrama representando o modelo criado para o sistema de matrículas:

```mermaid
---
title: Sistema de Matrículas em Cursos
---
erDiagram

    %% Entidades
    Aluno {
        string matricula PK
        string nomeCompleto
        string cpf
        date dataNasc
        string telefone
        string email
        id idCurso FK
        int anoIngresso
        string situacao
    }

    Professor {
        string matricula PK
        string nomeCompleto
        string cpf
        string areaAtuacao
        date dataNasc
        string telefone
        string email
        int idCurso FK
    }

    Curso {
        int id PK
        string nomeCurso
        int cargaHoraria
        string unidadeAcademica
        string campus
    }

    Disciplina {
        string cod PK
        string nomeDisciplina
        int cargaHoraria
        string ementa
    }

    Turma {
        int id PK
        int codDisciplina FK
        int idCurso FK
        string semestre "ex: 2024.1"
        int maxAlunos
        int qtdeAlunos
    }

    HorarioTurma {
        int idTurma FK
        string diaSemana
        time inicioHorario
        time fimHorario
    }

    Turma_Professor {
        int idTurma FK
        int idProfessor FK
    }

    Matricula {
        int id PK
        string matriculaAluno FK
        int idTurma FK
        date dataMatricula
        string status
    }

    Nota {
        int id PK
        int idMatricula FK
        string tipo "ex: prova, trabalho, arguição, etc"
        float nota
    }

    PreRequisito {
        int idDisciplina FK
        int idPreRequisito FK
    }



    %% Relacionamentos

    Curso ||--o{ Aluno: "cursa"

    Turma }|--|| Disciplina : "está associada a"
    Turma }|--|| Curso : "oferece"

    Turma_Professor }|--|{ Turma : "é lecionada por"
    Turma_Professor }|--|{ Professor : "leciona"
    HorarioTurma }|--|| Turma: "ocorre em"

    Matricula }o--|| Aluno : "tem"
    Matricula }o--|| Turma : "pertence a"

    PreRequisito }o--|| Disciplina : "é pré-requisito"
    PreRequisito }o--|| Disciplina : "tem como pré-requisito"

    Nota }|--|| Matricula : "é atribuida a"

```

## Próximos Passos

Como sugestão do professor, após a modelagem conceitual, foi indicado que implementássemos o modelo em um banco de dados relacional e uma API para consumir e manipular os dados com o objetivo de reforçar os estudos.

## Tecnologias Utilizadas

Para a implementação do banco de dados:

- PostgreSQL

Para o desenvolvimento da API:

- .NET 6
- ASP.NET Core

---

Além das entidades relacionadas ao sistema de matrículas, foi adicionada uma classe extra chamada Administrador. Para essa classe, foram implementados mecanismos de autenticação e autorização utilizando JWT (JSON Web Token), garantindo que apenas usuários autorizados possam acessar determinadas funcionalidades do sistema.
