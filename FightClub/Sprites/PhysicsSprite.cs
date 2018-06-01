using FightClub.Models;
using FightClub.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub
{
    public class PhysicsSprite : Sprite
    {
        public PhysicsSprite(Dictionary<string, Animation> animations, Vector2 position, Input input)
            : base(animations, position, input)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

                Move(deltaTime);
                CheckCollisions(sprites, deltaTime);
                SetAnimations();

                this._animationManager.Update(gameTime);

                Position += Velocity;
                Velocity = Vector2.Zero;
        }

        public virtual void Move(float deltaTime)
        {
            Velocity.Y += Gravity;

            if (_isJumping)
            {
                Velocity.Y += jumpSpeed;
                jumpSpeed += 1;
            }

            if (_isJumping && Velocity.Y >= 10f)
            {
                _isJumping = false;
            }

            if (_input == null)
                return;

            if (Keyboard.GetState().IsKeyDown(_input.Left))
            {
                Velocity.X -= Speed * deltaTime;
            }

            if (Keyboard.GetState().IsKeyDown(_input.Right))
            {
                Velocity.X += Speed * deltaTime;
            }

            if (Keyboard.GetState().IsKeyDown(_input.Up) && !_isJumping)
            {
                _isJumping = true;
                jumpSpeed = -20f;
            }

            if (Keyboard.GetState().IsKeyDown(_input.Down))
            {
                Velocity.Y += Speed * deltaTime;
            }

        }

    }
}