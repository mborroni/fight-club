using FightClub.Managers;
using FightClub.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub.Sprites
{
    public class Sprite
    {
        protected AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animations;

        protected Texture2D _texture;

        protected Vector2 _position;

        protected Rectangle _rectangle;

        public Vector2 Position
        {
            get { return this._position; }
            set
            {
                this._position = value;

                if (this._animationManager != null)
                    this._animationManager.Position = this._position;
            }
        }

        public Vector2 Velocity;

        public float Speed = 250f;

        public float Gravity = 6f;

        public Input _input;

        public Boolean _isJumping;

        public float jumpSpeed = 0f;


        public Rectangle Rectangle
        {
            get
            {

                if (_texture != null)
                {
                    return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
                }

                if (_animationManager.Animation != null)
                {
                    return new Rectangle((int)Position.X, (int)Position.Y, _animationManager.Animation.FrameWidth, _animationManager.Animation.FrameHeight);
                }

                return new Rectangle();
            }
        }

        public Sprite(Dictionary<string, Animation> animations, Vector2 position, Input input)
        {
            this._animations = animations;
            this._animationManager = new AnimationManager(null);
            this._position = position;
            this._input = input;
        }

        public Sprite(Texture2D texture, Vector2 position)
        {
            this._texture = texture;
            this._position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this._texture != null)
                spriteBatch.Draw(_texture, Position, Color.White);
            if (this._animationManager != null)
                this._animationManager.Draw(spriteBatch);
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if(this._animations != null)
            {
                SetAnimations();
            }
        }

        protected void SetAnimations()
        {
            if (Velocity.X > 0)
                this._animationManager.Play(this._animations["WalkRight"]);
            else if (Velocity.X < 0)
                this._animationManager.Play(this._animations["WalkLeft"]);
            else if (Velocity.Y > 0)
                this._animationManager.Play(this._animations["Idle"]);
            else if (Velocity.X < 0 && _isJumping)
                this._animationManager.Play(this._animations["JumpLeft"]);
            else if (Velocity.X > 0 && _isJumping)
                this._animationManager.Play(this._animations["JumpRight"]);
            else this._animationManager.Stop();
        }

        protected void CheckCollisions(List<Sprite> sprites, float deltaTime)
        {
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if ((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) ||
                    (this.Velocity.X < 0 && this.IsTouchingRight(sprite)))
                {
                    this.Velocity.X = 0;
                    OnCollision(sprite);
                }

                if (((Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                     (Velocity.Y < 0 && this.IsTouchingBottom(sprite))))
                {
                    this.Velocity.Y = 0;
                    OnCollision(sprite);
                }
            }
        }

        public virtual void Die()
        {

        }

        protected virtual void OnCollision(Sprite spriteA)
        {
            
        }

        protected bool IsTouchingLeft(Sprite sprite)
        {
            return this.Rectangle.Right + this.Velocity.X > sprite.Rectangle.Left &&
                this.Rectangle.Left < sprite.Rectangle.Left &&
                this.Rectangle.Bottom > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.Rectangle.Left + this.Velocity.X < sprite.Rectangle.Right &&
               this.Rectangle.Right > sprite.Rectangle.Right &&
               this.Rectangle.Bottom > sprite.Rectangle.Top &&
               this.Rectangle.Top < sprite.Rectangle.Bottom;
        }

        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > sprite.Rectangle.Top &&
               this.Rectangle.Top < sprite.Rectangle.Top &&
               this.Rectangle.Right > sprite.Rectangle.Left &&
               this.Rectangle.Left < sprite.Rectangle.Right;
        }

        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.Rectangle.Top + this.Velocity.Y < sprite.Rectangle.Bottom &&
               this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
               this.Rectangle.Right > sprite.Rectangle.Left &&
               this.Rectangle.Left < sprite.Rectangle.Right;
        }
    }
}