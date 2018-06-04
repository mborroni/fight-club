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

        Texture2D backgroundGameScreen;
        Rectangle mainFrame;

        public GameScreen(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
        }

        public override void LoadContent()
        {
            var width = _graphicsDevice.Viewport.Width;
            var height = _graphicsDevice.Viewport.Height;

            backgroundGameScreen = _content.Load<Texture2D>("Backgrounds/GameScreen");
            mainFrame = new Rectangle(0, 0, width, height);

            _sprites = new List<Sprite>()
            {
                new Dog(_game),
                new Cat(_game),
            };

            Random rnd = new Random();

            for (int i = 0; i < 30; i++)
            {
                int positionX = rnd.Next(0, _graphicsDevice.DisplayMode.Width);
                int positionY = rnd.Next(-30, 0);
                Ball ball = new Ball(_game, new Vector2(positionX, positionY));
                _sprites.Add(ball);
            }

            var mainPlatform = _content.Load<Texture2D>("Platforms/mainPlatform");
            Platform platform = new Platform(_game, mainPlatform, new Vector2(0, 860));
            _sprites.Add(platform);

            var onAirPlatform = _content.Load<Texture2D>("Platforms/onAirPlatform");
            for (int i = 0; i < 10; i++)
            {
                int positionX = rnd.Next(0, _graphicsDevice.DisplayMode.Width);
                int positionY = rnd.Next(0, 750);
                Platform airPlatform = new Platform(_game, onAirPlatform, new Vector2(positionX, positionY));
                _sprites.Add(airPlatform);
            }

        }

        public override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundGameScreen, mainFrame, Color.White);
            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }


    }
}
