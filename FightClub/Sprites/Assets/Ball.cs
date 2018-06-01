using FightClub.Models;
using FightClub.Sprites.Platforms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub.Sprites
{
    class Ball : PhysicsSprite
    {

        public Ball(Game game, Vector2 position)
           : base(null, position, null)
        {
            _animations = new Dictionary<string, Animation>() {
                { "Idle", new Animation(game.Content.Load<Texture2D>("Assets/Ball"), 4) },
            };
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);
        }

        protected override void OnCollision(Sprite sprite)
        {
            if (sprite is Dog || sprite is Cat)
            {
                sprite.Die();
            }
            if (sprite is Platform)
            {
                this.Die();
            }
        }

        public override void Die()
        {
            Random rnd = new Random();
            _position.X = rnd.Next(0, 800);
             _position.Y = 0;
        }

    }
}