using Raylib_cs;
using Blackjack.Game;

namespace Blackjack;

public static class Program
{
    public const int ScreenWidth = 1280;
    public const int ScreenHeight = 720;

    public static void Main()
    {
        Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint | ConfigFlags.VSyncHint);
        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Blackjack 21 - POO");
        Raylib.SetTargetFPS(60);

        string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        string cardsPath = Path.Combine(baseDir, "assets", "balatro_playing_cards_assets.png");
        if (!File.Exists(cardsPath))
            cardsPath = Path.Combine("assets", "balatro_playing_cards_assets.png");

        string fontPath = Path.Combine(baseDir, "assets", "font.otf");
        if (!File.Exists(fontPath))
            fontPath = Path.Combine("assets", "font.otf");

        Texture2D cardsTexture = Raylib.LoadTexture(cardsPath);

        // Fonte em alta resolução com suporte a acentuação
        int[] codepoints = Enumerable.Range(32, 224).ToArray();
        Font customFont = File.Exists(fontPath)
            ? Raylib.LoadFontEx(fontPath, 64, codepoints, codepoints.Length)
            : Raylib.GetFontDefault();
        Raylib.SetTextureFilter(customFont.Texture, TextureFilter.Bilinear);

        var game = new BlackjackGame(cardsTexture, customFont);

        while (!Raylib.WindowShouldClose())
        {
            game.Update();

            Raylib.BeginDrawing();
            game.Draw(ScreenWidth, ScreenHeight);
            Raylib.EndDrawing();
        }

        if (File.Exists(fontPath))
            Raylib.UnloadFont(customFont);
        Raylib.UnloadTexture(cardsTexture);
        Raylib.CloseWindow();
    }
}
