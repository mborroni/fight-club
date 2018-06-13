using PusheenTheCats.Models;
using PusheenTheCats.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PusheenTheCats
{
    public class PhysicsSprite : AnimatedSprite
    {
        public int Health = 500;

        public const float CONTACT_FORCE = 16f;

        public const float MOVE_SPEED = 250f;

        public const float JUMP_FORCE = -20f;

        public float ContactVelocity = 0f;

        public float Gravity = 7f;

        public float jumpSpeed = 0f;

        public int Jumps = 0;

        public Boolean _isJumping;

        public PhysicsSprite(Vector2 position, Input input)
            : base(position, input)
        {

        }

        protected void SetAnimations()
        {
            if (Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["Idle"]);
            else if (Velocity.X < 0 && _isJumping)
                _animationManager.Play(_animations["JumpLeft"]);
            else if (Velocity.X > 0 && _isJumping)
                _animationManager.Play(_animations["JumpRight"]);
            else if (Health <= 0)
                _animationManager.Play(_animations["Die"]);
            else _animationManager.Stop();
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Move(deltaTime);
            CheckCollisions(sprites, deltaTime);
            SetAnimations();

            _animationManager.Update(gameTime);

            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        public virtual void Move(float deltaTime)
        {
            Velocity.Y += Gravity;

            if (_isJumping)
            {
                Velocity.Y += jumpSpeed;
                jumpSpeed += .8f;
            }

            if (_isJumping && Velocity.Y >= 0f)
            {
                _isJumping = false;
            }

            if (ContactVelocity > 0)
            {
                Velocity.X += ContactVelocity;
                ContactVelocity -= .5f;
            }

            if (ContactVelocity < 0)
            {
                Velocity.X += ContactVelocity;
                ContactVelocity += .5f;
            }
        }

        protected void CheckCollisions(List<Sprite> sprites, float deltaTime)
        {
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if ((Velocity.X > 0 && IsTouchingLeft(sprite)) ||
                    (Velocity.X < 0 && IsTouchingRight(sprite)))
                {
                    Velocity.X = 0;
                    OnCollision(sprite);
                }

                if ((Velocity.Y < 0 && IsTouchingBottom(sprite)) ||
                    (Velocity.Y > 0 && IsTouchingTop(sprite)))
                {
                    Velocity.Y = 0;
                    OnCollision(sprite);

                    if (sprite is Platform)
                    {
                        Jumps = 0;
                    }
                }
            }
        }

        public bool IsTouchingLeft(PhysicsSprite sprite)
        {
            return Rectangle.Right + Velocity.X > sprite.Rectangle.Left &&
                Rectangle.Left < sprite.Rectangle.Left &&
                Rectangle.Bottom > sprite.Rectangle.Top &&
                Rectangle.Top < sprite.Rectangle.Bottom;
        }

        public bool IsTouchingRight(PhysicsSprite sprite)
        {
            return Rectangle.Left + Velocity.X < sprite.Rectangle.Right &&
               Rectangle.Right > sprite.Rectangle.Right &&
               Rectangle.Bottom > sprite.Rectangle.Top &&
               Rectangle.Top < sprite.Rectangle.Bottom;
        }

        public bool IsTouchingTop(PhysicsSprite sprite)
        {
            return Rectangle.Bottom + Velocity.Y > sprite.Rectangle.Top &&
               Rectangle.Top < sprite.Rectangle.Top &&
               Rectangle.Right > sprite.Rectangle.Left &&
               Rectangle.Left < sprite.Rectangle.Right;
        }

        public bool IsTouchingBottom(PhysicsSprite sprite)
        {
            return Rectangle.Top + Velocity.Y < sprite.Rectangle.Bottom &&
               Rectangle.Bottom > sprite.Rectangle.Bottom &&
               Rectangle.Right > sprite.Rectangle.Left &&
               Rectangle.Left < sprite.Rectangle.Right;
        }

    }
}