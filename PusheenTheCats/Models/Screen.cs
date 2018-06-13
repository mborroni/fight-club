using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub.Models
{
    public abstract class Screen
    {
        protected GameMain _game;
        protected GraphicsDevice _graphicsDevice;
        protected ContentManager _content;

        public Screen(GameMain game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            this._game = game;
            this._graphicsDevice = graphicsDevice;
            this._content = content;
        }

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}