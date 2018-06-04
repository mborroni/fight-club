using FightClub.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub.Sprites.Platforms
{
    public class Platform : Sprite
    {

        public Platform(Game1 game, Texture2D texture, Vector2 position)
            : base(texture, position)
        {
        }

    }
}
