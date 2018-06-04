using FightClub.Models;
using FightClub.Sprites;
using FightClub.Sprites.Platforms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub.Screens
{
    public class GameScreen : Screen
    {
        private List<Sprite> _sprites;

        public GameScreen(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
        }

        protected override void LoadContent()
        {
            _sprites = new List<Sprite>()
            {
                new Dog(this),
                new Cat(this),
            };

            Random rnd = new Random();

            for (int i = 0; i < 30; i++)
            {
                int positionX = rnd.Next(0, GraphicsDevice.DisplayMode.Width);
                int positionY = rnd.Next(-30, 0);
                Ball ball = new Ball(this, new Vector2(positionX, positionY));
                _sprites.Add(ball);
            }

            for (int i = 0; i < 10; i++)
            {
                int positionX = rnd.Next(0, GraphicsDevice.DisplayMode.Width);
                int positionY = rnd.Next(0, GraphicsDevice.DisplayMode.Height);
                Platform platform = new Platform(this, new Vector2(positionX, positionY));
                _sprites.Add(platform);
            }

            for (int i = 0; i < GraphicsDevice.DisplayMode.Width; i += 100)
            {
                int positionX = i;
                int positionY = GraphicsDevice.DisplayMode.Height - 100;
                Platform platform = new Platform(this, new Vector2(positionX, positionY));
                _sprites.Add(platform);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }
        }

        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }


    }
}
