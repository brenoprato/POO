# Requirements Document - Blackjack com Raylib-cs (POO)

## Introduction
Este projeto consiste no desenvolvimento de uma aplicação interativa do clássico jogo **Blackjack (21)** em C# utilizando a biblioteca gráfica **Raylib-cs**. O trabalho foi modelado de acordo com a especificação formal da disciplina de **Programação Orientada a Objetos (POO)** da Unifesp, estruturado para ser desenvolvido e entregue por um grupo de **3 membros**.

O projeto atende aos requisitos de código, conceitos de POO, interface gráfica com botões interativos e fornece a base completa para a elaboração do relatório técnico em PDF e do vídeo demonstrativo de uso.

---

## Requirements

### Requirement 1: Botões da Interface Gráfica
**User Story:** Como jogador, quero botões claros e intuitivos na interface gráfica, para que eu possa executar todas as ações fundamentais da partida.

#### Acceptance Criteria
1. WHEN a aplicação estiver aberta THEN a interface SHALL conter no mínimo os 3 botões interativos exigidos:
   - **Pedir Carta**: solicita uma nova carta do baralho para o jogador.
   - **Parar**: encerra a jogada do jogador e passa a vez para a banca.
   - **Reiniciar Jogo**: reinicia completamente a partida e limpa a mesa.
2. WHILE for o turno do jogador THEN os botões "Pedir Carta" e "Parar" SHALL estar habilitados e visualmente destacados.
3. IF o jogador estourar (> 21) ou a rodada encerrar THEN os botões de ação SHALL ser desabilitados e o botão "Reiniciar Jogo" SHALL estar habilitado.
4. WHEN o usuário passar o mouse ou clicar em um botão THEN o botão SHALL responder com feedback visual (hover) e acionar a ação correspondente.

---

### Requirement 2: Regras Oficiais do Jogo e Condições de Vitória
**User Story:** Como usuário e avaliador, quero que todas as regras de pontuação e desempate da especificação sejam cumpridas com precisão.

#### Acceptance Criteria
1. WHEN uma mão calcular sua pontuação THEN as cartas de 2 a 10 SHALL somar seus respectivos valores nominais, e figuras (J, Q, K) SHALL somar exatamente 10 pontos.
2. WHEN houver um Ás (A) na mão THEN o sistema SHALL avaliar dinamicamente:
   - 11 pontos, caso isso não faça a pontuação total ultrapassar 21;
   - 1 ponto, caso contrário (evitando o estouro sempre que possível).
3. IF o jogador ultrapassar 21 pontos THEN o jogador SHALL perder automaticamente ("Bust / Estourou"), encerrando a rodada de imediato sem necessidade da banca jogar.
4. WHEN o jogador acionar "Parar" THEN a banca SHALL jogar automaticamente com base em uma lógica de decisão para vencer a pontuação do jogador.
5. IF a banca ultrapassar 21 pontos durante sua jogada THEN o jogador SHALL ser declarado vencedor ("A banca estourou!").
6. IF o jogador e a banca terminarem com a mesma pontuação (empate) THEN a vitória SHALL ser atribuída à banca ("Em caso de empate, a vitória é da banca").
7. IF a banca não estourar e tiver pontuação maior ou igual à do jogador THEN a vitória SHALL ser da banca.
8. IF a banca não estourar e sua pontuação final for menor que a do jogador THEN a vitória SHALL ser do jogador.

---

### Requirement 3: Lógica Inteligente de Decisão da Banca (Dealer AI)
**User Story:** Como jogador, quero que a banca jogue com inteligência competitiva e não aleatoriamente, para que a partida seja desafiadora e coerente com as regras.

#### Acceptance Criteria
1. WHEN o jogador parar com uma pontuação válida (ex: 18) THEN a banca SHALL avaliar sua própria pontuação em relação à pontuação do jogador.
2. WHILE a pontuação da banca for estritamente menor que a pontuação do jogador E a banca não tiver estourado THEN a banca SHALL obrigatoriamente comprar cartas para tentar alcançar ou superar o jogador.
3. IF a pontuação da banca for maior ou igual à pontuação do jogador (já que o empate é vitória da banca) THEN a banca SHALL parar imediatamente de comprar para não arriscar estourar.

---

### Requirement 4: Conceitos e Estrutura de POO
**User Story:** Como professor e avaliador de POO, quero que o projeto aplique de forma exemplar os pilares de orientação a objetos, para avaliar o domínio dos conceitos pelos 3 membros.

#### Acceptance Criteria
1. WHEN a arquitetura for examinada THEN o sistema SHALL apresentar as seguintes classes sugeridas (ou correspondentes em inglês):
   - **Carta** (`Card`)
   - **Baralho** (`Deck`)
   - **Jogador** (`Player`)
   - **Banca** (`Dealer`)
   - **Jogo** (`GameManager` / `BlackjackGame`)
2. WHEN o código for analisado THEN ele SHALL demonstrar explicitamente:
   - **Classes e Objetos**: instâncias bem delimitadas com responsabilidade única.
   - **Encapsulamento**: atributos privados com propriedades controladas (`get`/`set`) e coleções imutáveis/somente leitura (`IReadOnlyList`).
   - **Construtores**: inicialização adequada de estado e injeção de dependências.
   - **Associação entre classes**: `GameManager` associado a `Deck`, `Player`, `Dealer`, `TableRenderer`.
   - **Herança e Polimorfismo**: classe abstrata `Participant` especializada por `Player` e `Dealer`.

---

### Requirement 5: Organização do Trabalho para 3 Membros
**User Story:** Como equipe de 3 estudantes, queremos uma divisão de tarefas equilibrada, para que todos contribuam com código relevante e possam demonstrar suas partes no relatório e no vídeo.

#### Acceptance Criteria
1. WHEN a lista de tarefas for consultada THEN cada um dos 3 membros SHALL ter um módulo bem definido:
   - **Membro 1**: Cartas, Baralho, Mão e Cálculo Dinâmico de Pontuação (`Card`, `Deck`, `Hand`, `Suit`, `Rank`, interfaces).
   - **Membro 2**: Participantes e Regras (`Participant`, `Player`, `Dealer` com IA de decisão, `BlackjackRules`).
   - **Membro 3**: Gráficos, UI e Game Loop (`CardSpriteSheet`, `TableRenderer`, `Button`, `GameManager`, `Program`).
