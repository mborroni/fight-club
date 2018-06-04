using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightClub.Models;
using Microsoft.Xna.Framework;
using FightClub.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace FightClub.Sprites
{
    public class AnimatedSprite : Sprite
    {

        protected Dictionary<string, Animation> _animations;

        public AnimatedSprite(Vector2 position, Input input)
            :base(position)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _animationManager.Draw(spriteBatch);
        }

    }
}
