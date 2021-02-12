using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    internal class Text
    {
        string fileName;
        SpriteFont spriteFont;
        string displayText;
        Rectangle rectangle;
        HorizontalAlignment horizontalAlignment;
        VerticalAlignment verticalAlignment;

        public Text(Rectangle rectangle, string fileName, string displayText, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment)
        {
            this.rectangle = rectangle;
            this.spriteFont = Game1.contentManager.Load<SpriteFont>(fileName);
            this.displayText = displayText;
            this.horizontalAlignment = horizontalAlignment;
            this.verticalAlignment = verticalAlignment;
        }

        public void Update(string displayText)
        {
            this.displayText = displayText;
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            if (horizontalAlignment == HorizontalAlignment.Center)
            {
                int spaceLeft = (rectangle.Width - (int)spriteFont.MeasureString(displayText).Length()) / 2;

                if (verticalAlignment == VerticalAlignment.Center)
                {
                    int spaceTop = (rectangle.Height - spriteFont.LineSpacing) / 2;

                    Vector2 textPosition = new Vector2(rectangle.X + spaceLeft, rectangle.Y + spaceTop);
                    spriteBatch.DrawString(spriteFont, displayText, textPosition, color);
                }
            }

        }
    }

    internal enum HorizontalAlignment
    {
        Right,
        Center,
        Left
    }

    internal enum VerticalAlignment
    {
        Top,
        Center,
        Bottom
    }
}
