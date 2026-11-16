using System.Numerics;
using Raylib_cs;
using Blackjack.Models;
using Blackjack.UI;

namespace Blackjack.Game;

public class BlackjackGame
{
    private const int CardWidth = 71;
    private const int CardHeight = 95;

    private readonly Deck _deck = new();
    private readonly Player _player = new();
    private readonly Dealer _dealer = new();

    private readonly Button _btnPedirCarta;
    private readonly Button _btnParar;
    private readonly Button _btnReiniciar;

    private readonly Texture2D _cardsTexture;
    private readonly Font _font;
    private bool _isGameOver = true;
    private string _statusMessage = "Clique em 'Reiniciar Jogo' para começar!";

    public BlackjackGame(Texture2D cardsTexture, Font font)
    {
        _cardsTexture = cardsTexture;
        _font = font;

        _btnPedirCarta = new Button(312, 628, 200, 52, "Pedir Carta",    new Color(34, 139, 74, 255));
        _btnParar      = new Button(540, 628, 200, 52, "Parar",          new Color(180, 52, 52, 255));
        _btnReiniciar  = new Button(768, 628, 200, 52, "Reiniciar Jogo", new Color(196, 138, 28, 255));

        ReiniciarJogo();
    }

    public void ReiniciarJogo()
    {
        _deck.Reset();
        _deck.Shuffle();
        _player.ClearCards();
        _dealer.ClearCards();

        // Distribui 2 cartas para cada um (a segunda da banca fica oculta)
        for (int i = 0; i < 2; i++)
        {
            _player.AddCard(_deck.Draw());
            _dealer.AddCard(_deck.Draw());
        }

        _dealer.Cards[1].IsFaceUp = false;
        _isGameOver = false;
        _statusMessage = "Compre ou Pare";
    }

    public void PedirCarta()
    {
        if (_isGameOver) return;

        _player.AddCard(_deck.Draw());

        // Encerra a partida se o jogador estourar
        if (_player.IsBust())
        {
            _dealer.RevealCards();
            _isGameOver = true;
            _statusMessage = "Estourou, Banca venceu";
        }
    }

    public void Parar()
    {
        if (_isGameOver) return;

        _dealer.RevealCards();
        _isGameOver = true;

        // Banca joga automaticamente para tentar vencer o jogador
        while (_dealer.ShouldHit(_player.CalculateScore()))
        {
            _dealer.AddCard(_deck.Draw());
        }

        if (_dealer.IsBust())
        {
            _statusMessage = "Vitoria!";
        }
        else
        {
            _statusMessage = "Derrota";
        }
    }

    public void Update()
    {
        _btnPedirCarta.IsEnabled = !_isGameOver;
        _btnParar.IsEnabled = !_isGameOver;

        if (_btnPedirCarta.IsClicked()) PedirCarta();
        if (_btnParar.IsClicked()) Parar();
        if (_btnReiniciar.IsClicked()) ReiniciarJogo();
    }

    public void Draw(int screenWidth, int screenHeight)
    {
        // Mesa e molduras
        Raylib.ClearBackground(new Color(18, 62, 38, 255));
        Raylib.DrawRectangleLinesEx(new Rectangle(12, 12, screenWidth - 24, screenHeight - 24), 12, new Color(45, 26, 16, 255));
        Raylib.DrawRectangleRoundedLinesEx(new Rectangle(28, 28, screenWidth - 56, screenHeight - 56), 0.03f, 8, 2f, new Color(212, 175, 55, 130));

        Raylib.DrawLineEx(new Vector2(80, 305), new Vector2(screenWidth - 80, 305), 1.5f, new Color(212, 175, 55, 45));
        Raylib.DrawLineEx(new Vector2(80, 395), new Vector2(screenWidth - 80, 395), 1.5f, new Color(212, 175, 55, 45));

        // Placar
        DrawScoreBadge("BANCA", _dealer.CalculateScore(), new Vector2(70, 115), new Color(150, 45, 45, 230));
        DrawScoreBadge("JOGADOR", _player.CalculateScore(), new Vector2(70, 465), new Color(34, 115, 165, 230));

        // Cartas centralizadas
        DrawHand(_dealer.Cards, screenWidth, 72);
        DrawHand(_player.Cards, screenWidth, 422);

        // Faixa de status
        const float statusFontSize = 26f;
        const float spacing = 1.2f;
        Vector2 msgSize = Raylib.MeasureTextEx(_font, _statusMessage, statusFontSize, spacing);
        float bannerW = Math.Max(msgSize.X + 64f, 360f);
        float bannerH = 50f;
        var bannerRect = new Rectangle((screenWidth - bannerW) / 2f, 325f, bannerW, bannerH);

        Raylib.DrawRectangleRounded(bannerRect, 0.45f, 8, new Color(10, 25, 16, 210));
        Raylib.DrawRectangleRoundedLinesEx(bannerRect, 0.45f, 8, 2f, new Color(212, 175, 55, 200));

        var msgPos = new Vector2(
            bannerRect.X + (bannerRect.Width - msgSize.X) / 2f,
            bannerRect.Y + (bannerRect.Height - msgSize.Y) / 2f
        );
        Raylib.DrawTextEx(_font, _statusMessage, msgPos, statusFontSize, spacing, new Color(255, 215, 70, 255));

        // Botões
        _btnPedirCarta.Draw(_font);
        _btnParar.Draw(_font);
        _btnReiniciar.Draw(_font);
    }

    private void DrawScoreBadge(string label, int score, Vector2 pos, Color accentColor)
    {
        var cardRect = new Rectangle(pos.X, pos.Y, 175, 92);
        var shadowRect = new Rectangle(pos.X + 3, pos.Y + 4, 175, 92);

        Raylib.DrawRectangleRounded(shadowRect, 0.2f, 8, new Color(0, 0, 0, 80));
        Raylib.DrawRectangleRounded(cardRect, 0.2f, 8, new Color(12, 38, 24, 220));
        Raylib.DrawRectangleRoundedLinesEx(cardRect, 0.2f, 8, 2f, accentColor);

        Vector2 labelSize = Raylib.MeasureTextEx(_font, label, 18f, 1.5f);
        Raylib.DrawTextEx(
            _font,
            label,
            new Vector2(cardRect.X + (cardRect.Width - labelSize.X) / 2f, cardRect.Y + 14f),
            18f,
            1.5f,
            new Color(200, 215, 205, 255)
        );

        string scoreText = $"{score} pts";
        Vector2 scoreSize = Raylib.MeasureTextEx(_font, scoreText, 30f, 1.0f);
        Raylib.DrawTextEx(
            _font,
            scoreText,
            new Vector2(cardRect.X + (cardRect.Width - scoreSize.X) / 2f, cardRect.Y + 42f),
            30f,
            1.0f,
            Color.White
        );
    }

    private void DrawHand(IReadOnlyList<Card> cards, int screenWidth, float yPos)
    {
        if (cards.Count == 0) return;

        const float scale = 1.75f;
        const float cardW = CardWidth * scale;
        const float cardH = CardHeight * scale;
        const float spacing = 92f;

        float totalWidth = cardW + (cards.Count - 1) * spacing;
        float startX = (screenWidth - totalWidth) / 2f;

        for (int i = 0; i < cards.Count; i++)
        {
            Card card = cards[i];
            var dest = new Rectangle(startX + i * spacing, yPos, cardW, cardH);

            // Sombra da carta
            var shadow = new Rectangle(dest.X + 5, dest.Y + 6, dest.Width, dest.Height);
            Raylib.DrawRectangleRounded(shadow, 0.08f, 6, new Color(0, 0, 0, 85));

            if (!card.IsFaceUp)
            {
                // Verso estilizado da carta oculta
                Raylib.DrawRectangleRounded(dest, 0.08f, 6, new Color(32, 54, 108, 255));
                Raylib.DrawRectangleRoundedLinesEx(dest, 0.08f, 6, 3f, Color.White);

                var inner = new Rectangle(dest.X + 10, dest.Y + 10, dest.Width - 20, dest.Height - 20);
                Raylib.DrawRectangleRounded(inner, 0.06f, 6, new Color(22, 38, 80, 255));
                Raylib.DrawRectangleRoundedLinesEx(inner, 0.06f, 6, 1.5f, new Color(212, 175, 55, 190));
                continue;
            }

            // Recorte do spritesheet (Coluna = Rank, Linha = Suit)
            var src = new Rectangle((int)card.Rank * CardWidth, (int)card.Suit * CardHeight, CardWidth, CardHeight);
            Raylib.DrawTexturePro(_cardsTexture, src, dest, Vector2.Zero, 0f, Color.White);
        }
    }
}
