# Implementation Plan - Blackjack (Enxuto para 3 Membros)

Estrutura enxuta com **6 arquivos em `src/`** (exatamente **2 arquivos por membro**), seguindo as 5 classes sugeridas pelo professor (`Card`, `Deck`, `Player`, `Dealer`, `BlackjackGame`) + `Button`. Os métodos de regra de negócio estão limpos com `// TODO` para vocês programarem na mão.

---

### 🎴 Membro 1: Carta e Baralho (`src/Models/Card.cs` e `src/Models/Deck.cs`)

- [x] 1.1 Implementar `Card.GetValue()` em `src/Models/Card.cs`
  - Retornar 2 a 10 para cartas numéricas, 10 para J/Q/K e 11 para o Ás (`Rank.Ace`).
- [x] 1.2 Implementar `Deck.Reset()`, `Shuffle()` e `Draw()` em `src/Models/Deck.cs`
  - `Reset()`: criar as 52 cartas combinando `Suit` e `Rank`.
  - `Shuffle()`: embaralhar a lista `_cards`.
  - `Draw()`: remover e retornar a carta do topo (e recriar o baralho se ficar vazio).

---

### ⚖️ Membro 2: Jogador e Banca (`src/Models/Player.cs` e `src/Models/Dealer.cs`)

- [x] 2.1 Implementar a mão e pontuação em `src/Models/Player.cs`
  - `AddCard(Card)` e `ClearCards()`.
  - `CalculateScore()`: somar pontos das cartas visíveis (`IsFaceUp == true`) e ajustar o Ás de 11 para 1 (subtraindo 10) caso a soma passe de 21.
  - `IsBust()`: retornar `true` se `CalculateScore() > 21`.
- [x] 2.2 Implementar a herança e decisão da Banca em `src/Models/Dealer.cs`
  - `RevealCards()`: virar todas as cartas da banca para cima (`IsFaceUp = true`).
  - `ShouldHit(int playerScore)`: retornar `true` enquanto a pontuação da banca for menor que `playerScore` e menor que 21 (já que o empate dá vitória à banca, ela para assim que empatar ou superar o jogador).

---

### 🎮 Membro 3: Fluxo do Jogo e Botões (`src/Game/BlackjackGame.cs` e `src/UI/Button.cs`)

- [x] 3.1 Implementar `ReiniciarJogo()` em `src/Game/BlackjackGame.cs`
  - Limpar mãos do jogador e da banca, embaralhar o baralho e distribuir 2 cartas para cada (a 2ª da banca com `IsFaceUp = false`).
- [x] 3.2 Implementar `PedirCarta()` em `src/Game/BlackjackGame.cs`
  - Dar uma carta ao jogador; se `IsBust()` for verdadeiro, encerrar a partida com vitória da banca.
- [x] 3.3 Implementar `Parar()` em `src/Game/BlackjackGame.cs`
  - Revelar as cartas da banca, comprar cartas enquanto `_dealer.ShouldHit(...)` for `true`, e definir o vencedor (lembrando que empate é vitória da banca).
