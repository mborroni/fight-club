using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PusheenTheCats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PusheenTheCats.Sprites.Assets
{
    public class Coin : AnimatedSprite
    {
        protected Game game;
        protected bool isDead = false;

        public Coin(Game game, Vector2 position)
           : base(position, null)
        {
            this.game = game;
            _animations = new Dictionary<string, Animation>() {
                { "Idle", new Animation(game.Content.Load<Texture2D>("Assets/coin"), 6) },
            };
        }

		protected override void SetAnimations()
        {
            _animationManager.Play(_animations["Idle"]);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            SetAnimations();
            base.Update(gameTime, sprites);
        }

        protected override void OnCollision(Sprite sprite)
        {
            if (sprite is Player)
            {
                ((Player)sprite).Coins += 1;
                isDead = true;
                this.Die();
            }

			if (sprite is Ball)
            {
                isDead = true;
                this.Die();
            }

        }

        public override void Die()
        {
            Random rnd = new Random();
            _position.X = rnd.Next(5, game.GraphicsDevice.DisplayMode.Width);
            _position.Y = 400;
        }

    }
}

