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

        protected Game game;
        protected bool isDead = false;

        public Ball(Game game, Vector2 position)
           : base(position, null)
        {
            this.game = game;
            _animations = new Dictionary<string, Animation>() {
                { "Idle", new Animation(game.Content.Load<Texture2D>("Assets/ball"), 4) },
                // TODO: Set animation when onCollision
                //{ "Die", new Animation(game.Content.Load<Texture2D>("Assets/Die"), 1) },
            };
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            SetAnimations();
            base.Update(gameTime, sprites);
        }

        protected override void OnCollision(Sprite sprite)
        {
            if (sprite is Platform || sprite is Player)
            {
                isDead = true;
                this.Die();
            }
        }

        public override void Die()
        {
            Random rnd = new Random();
            _position.X = rnd.Next(0, game.GraphicsDevice.DisplayMode.Width);
             _position.Y = rnd.Next(-30, 0);
        }

    }
}