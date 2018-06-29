using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PusheenTheCats.Screens;
using PusheenTheCats.Sprites.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PusheenTheCats.Managers
{
    public class CoinManager
    {
        protected const float COIN_INTERVAL = 2f;

        protected GameMain _game;

        protected GraphicsDevice _graphics;

        protected GameScreen _gameScreen;

        private float _timer;

        protected List<Coin> _coins = new List<Coin>();


        public CoinManager(GameMain game, GraphicsDevice graphics, GameScreen gameScreen)
        {
            this._game = game;
            this._graphics = graphics;
            this._gameScreen = gameScreen;
        }

        public void AddCoin()
        {
            Random rnd = new Random();
            int positionX = rnd.Next(0, _graphics.DisplayMode.Width);
            int positionY = rnd.Next(200, _graphics.DisplayMode.Height/2);
            Coin _coin = new Coin(_game, new Vector2(positionX, positionY));

            _coins.Add(_coin);
            _gameScreen.AddSprite(_coin);
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(_timer >= COIN_INTERVAL && _coins.Count < 3)
            {
                _timer = 0f;
                AddCoin();
            }
        }
    }
}
