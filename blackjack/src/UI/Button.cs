using System.Numerics;
using Raylib_cs;

namespace Blackjack.UI;

public class Button
{
    public Rectangle Bounds { get; }
    public string Text { get; }
    public Color Color { get; }
    public bool IsEnabled { get; set; } = true;

    public Button(float x, float y, float width, float height, string text, Color color)
    {
        Bounds = new Rectangle(x, y, width, height);
        Text = text;
        Color = color;
    }

    public bool IsClicked()
    {
        if (!IsEnabled) return false;

        Vector2 mouse = Raylib.GetMousePosition();
        bool isHovered = Raylib.CheckCollisionPointRec(mouse, Bounds);
        return isHovered && Raylib.IsMouseButtonPressed(MouseButton.Left);
    }

    public void Draw(Font font)
    {
        Vector2 mouse = Raylib.GetMousePosition();
        bool isHovered = IsEnabled && Raylib.CheckCollisionPointRec(mouse, Bounds);

        // Sombra
        var shadowRect = new Rectangle(Bounds.X + 2, Bounds.Y + 4, Bounds.Width, Bounds.Height);
        Raylib.DrawRectangleRounded(shadowRect, 0.28f, 8, new Color(0, 0, 0, 90));

        // Fundo e borda
        Color bgColor = !IsEnabled
            ? new Color(55, 62, 58, 170)
            : (isHovered ? Raylib.ColorBrightness(Color, 0.18f) : Color);

        Color borderColor = !IsEnabled
            ? new Color(110, 120, 115, 120)
            : (isHovered ? Color.Gold : new Color(255, 255, 255, 200));

        Raylib.DrawRectangleRounded(Bounds, 0.28f, 8, bgColor);
        Raylib.DrawRectangleRoundedLinesEx(Bounds, 0.28f, 8, 2f, borderColor);

        // Texto centralizado
        const float fontSize = 22f;
        const float spacing = 1.0f;
        Vector2 textSize = Raylib.MeasureTextEx(font, Text, fontSize, spacing);
        var textPos = new Vector2(
            Bounds.X + (Bounds.Width - textSize.X) / 2f,
            Bounds.Y + (Bounds.Height - textSize.Y) / 2f
        );

        Color textColor = IsEnabled ? Color.White : new Color(165, 170, 165, 160);
        Raylib.DrawTextEx(font, Text, textPos, fontSize, spacing, textColor);
    }
}
