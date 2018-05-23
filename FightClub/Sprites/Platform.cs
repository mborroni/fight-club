using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub.Sprites
{
    class Platform : Sprite
    {
      

        public Platform(Game game, Vector2 position)
            : base(null, position)
        {
            this._texture = game.Content.Load<Texture2D>("Platforms/platform_2");
        }

    }
}