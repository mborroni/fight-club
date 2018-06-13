using PusheenTheCats.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PusheenTheCats.Sprites
{
    public class Platform : Sprite
    {

        public Platform(GameMain game, Texture2D texture, Vector2 position)
            : base(texture, position)
        {
        }

    }
}
