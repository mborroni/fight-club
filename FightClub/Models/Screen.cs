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
    public abstract class Screen : Game1
    {
        protected Game1 _game;
        protected GraphicsDevice _graphicsDevice;
        protected ContentManager _content;

        public Screen(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            this._game = game;
            this._graphicsDevice = graphicsDevice;
            this._content = content;
        }

        protected override abstract void LoadContent();

        protected override abstract void Update(GameTime gameTime);

        protected override abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}