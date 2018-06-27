using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PusheenTheCats.Models;
using PusheenTheCats.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PusheenTheCats.Screens
{
    public class EndScreen : Screen
    {

        Texture2D catVictory1;
        Texture2D catVictory2;
        Rectangle mainFrame;
        Sprite sprite;

        public EndScreen(GameMain game, GraphicsDevice graphicsDevice, ContentManager content, Sprite sprite) : base(game, graphicsDevice, content)
        {
            this.sprite = sprite;
        }

        public override void LoadContent()
        {
            mainFrame = new Rectangle(0, 0, _game.ScreenWidth, _game.ScreenHeight);

            catVictory1 = _content.Load<Texture2D>("Backgrounds/VictoryPlayerOne");
            catVictory2 = _content.Load<Texture2D>("Backgrounds/VictoryPlayerTwo");

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (((Player)sprite)._isDead)
            {
                if (sprite is Cat)
                    spriteBatch.Draw(catVictory1, mainFrame, Color.White);
                else
                    spriteBatch.Draw(catVictory2, mainFrame, Color.White);
            }
            else if (((Player)sprite)._collectionComplete)
            {
                if (sprite is Cat)
                    spriteBatch.Draw(catVictory2, mainFrame, Color.White);
                else
                    spriteBatch.Draw(catVictory1, mainFrame, Color.White);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _game.ChangeScreen(new TitleScreen(_game, _graphicsDevice, _content));
        }


        public override void Update(GameTime gameTime)
        {
        }
    }
}
