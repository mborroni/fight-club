using PusheenTheCats.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PusheenTheCats.Models
{
    public class Player : PhysicsSprite
    {

        public Input _input;

        public Player(Game game)
            : base(new Vector2(0, 0), null)
        {
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites) {
            base.Update(gameTime, sprites);
        }

        public override void Move(float deltaTime) {
            base.Move(deltaTime);

            if (Keyboard.GetState().IsKeyDown(_input.Left))
            {
                Velocity.X -= MOVE_SPEED * deltaTime;
            }

            if (Keyboard.GetState().IsKeyDown(_input.Right))
            {
                Velocity.X += MOVE_SPEED * deltaTime;
            }

            if (Keyboard.GetState().IsKeyDown(_input.Up) && !_isJumping && Jumps < 1)
            {
                Jumps += 1;
                _isJumping = true;
                jumpSpeed = JUMP_FORCE;
            }

            if (Keyboard.GetState().IsKeyDown(_input.Down))
            {
                Velocity.Y += MOVE_SPEED * deltaTime;
            }

        }

        protected override void OnCollision(Sprite sprite) {
            if (sprite is Ball)
            {
                Health -= 10;
            }

            if (sprite is Platform && IsTouchingBottom(sprite))
            {
                Jumps = 0;
            }

            if (sprite is Player)
            {
                if(sprite.Position.X >= this.Position.X)
                {
                    (sprite as Player).ContactVelocity = Velocity.X + CONTACT_FORCE;
                } else
                {
                    (sprite as Player).ContactVelocity = Velocity.X - CONTACT_FORCE;
                }
            }
        }

        public override void Die()
        {
            // TODO: Set animation "Die" when Player dies. 
        }

    }
}
