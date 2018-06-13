using PusheenTheCats.Managers;
using PusheenTheCats.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PusheenTheCats.Sprites
{
    public class Sprite
    {
        protected AnimationManager _animationManager;

        protected Texture2D _texture;

        protected Vector2 Velocity;

        protected Vector2 _position;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        protected Rectangle _rectangle;

        public Rectangle Rectangle
        {
            get
            {
                if (_animationManager != null && _animationManager.Animation != null)
                {
                    return new Rectangle((int)Position.X, (int)Position.Y, _animationManager.Animation.FrameWidth, _animationManager.Animation.FrameHeight);
                }

                if (_texture != null)
                {
                    return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
                }

                return new Rectangle();
            }
        }

        public Sprite(Vector2 position)
        {
            _animationManager = new AnimationManager(null, this);
            _position = position;
        }

        public Sprite(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public virtual void Die()
        {

        }

        protected virtual void OnCollision(Sprite sprite)
        {

        }

        public bool IsTouchingLeft(Sprite sprite)
        {
            return Rectangle.Right + Velocity.X > sprite.Rectangle.Left &&
                Rectangle.Left < sprite.Rectangle.Left &&
                Rectangle.Bottom > sprite.Rectangle.Top &&
                Rectangle.Top < sprite.Rectangle.Bottom;
        }

        public bool IsTouchingRight(Sprite sprite)
        {
            return Rectangle.Left + Velocity.X < sprite.Rectangle.Right &&
               Rectangle.Right > sprite.Rectangle.Right &&
               Rectangle.Bottom > sprite.Rectangle.Top &&
               Rectangle.Top < sprite.Rectangle.Bottom;
        }

        public bool IsTouchingTop(Sprite sprite)
        {
            return Rectangle.Bottom + Velocity.Y > sprite.Rectangle.Top &&
               Rectangle.Top < sprite.Rectangle.Top &&
               Rectangle.Right > sprite.Rectangle.Left &&
               Rectangle.Left < sprite.Rectangle.Right;
        }

        public bool IsTouchingBottom(Sprite sprite)
        {
            return Rectangle.Top + Velocity.Y < sprite.Rectangle.Bottom &&
               Rectangle.Bottom > sprite.Rectangle.Bottom &&
               Rectangle.Right > sprite.Rectangle.Left &&
               Rectangle.Left < sprite.Rectangle.Right;
        }

    }
}