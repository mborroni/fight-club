using PusheenTheCats.Models;
using PusheenTheCats.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PusheenTheCats.Sprites.Assets;

namespace PusheenTheCats.Screens
{
    public class GameScreen : Screen
    {
        private List<Sprite> _sprites;

        Texture2D backgroundGameScreen;
        Rectangle mainFrame;
        SpriteFont font;

        public GameScreen(GameMain game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
        }

        public override void LoadContent()
        {
            var width = _graphicsDevice.Viewport.Width;
            var height = _graphicsDevice.Viewport.Height;

            backgroundGameScreen = _content.Load<Texture2D>("Backgrounds/GameScreen");
            mainFrame = new Rectangle(0, 0, width, height);
            font = _content.Load<SpriteFont>("Font/Ink");

            _sprites = new List<Sprite>()
            {
                new Dog(_game),
                new Cat(_game),
            };

            Random rnd = new Random();
;
            for (int i = 0; i < 18; i++)
            {
                int positionX = rnd.Next(0, _graphicsDevice.DisplayMode.Width);
                int positionY = rnd.Next(-80, 0);
                Ball ball = new Ball(_game, new Vector2(positionX, positionY));
                _sprites.Add(ball);
            }

            for (int i = 0; i < 10; i++)
            {
                int positionX = rnd.Next(0, _graphicsDevice.DisplayMode.Width);
                int positionY = rnd.Next(0, _graphicsDevice.DisplayMode.Height);
                Coin coin= new Coin(_game, new Vector2(positionX, positionY));
                _sprites.Add(coin);
            }

            var platformsMap = new PlatformsMap(_game, _graphicsDevice, _content);

            var _platforms = platformsMap.CreatePlatforms();

            foreach (var _platform in _platforms)
            {
                _sprites.Add(_platform);
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
            var spacingY = 10;
            var i = 0;
            foreach (var sprite in _sprites)
            {
                if(sprite is Player)
                {
                    spriteBatch.DrawString(font, string.Format("Player {0}: {1} \nCoins: {2}", ++i, ((Player)sprite).Health, ((Player)sprite).Coins), new Vector2(10, spacingY += 40), Color.Black);
                }
            }
        }


    }
}
