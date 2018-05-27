using FightClub.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub.Sprites.Assets
{
    class Star : Sprite
    {
        public Star(Game game, Vector2 position)
        : base(null, position)
        {
            //this._texture = new Animation(game.Content.Load<Texture2D>("Assets/star"), 8);
        }
    }
}
