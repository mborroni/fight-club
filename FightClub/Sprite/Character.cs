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

namespace FightClub.Sprite
{
    public class Character
    {
        protected AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animations;

        protected Vector2 _position;

        private Texture2D _texture;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;

                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }

        public float Speed = 2f;

        public Vector2 Velocity;

        public Input Input;

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("This ain't right..!");
        }

        public void Move()
        {
            if (Input == null)
                return;

            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X -= Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X += Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y -= Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y += Speed;
            }
        }

        protected void SetAnimations()
        {
            if (Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["WalkDown"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["WalkUp"]);
            else _animationManager.Stop();
        }

        public Character(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        public Character(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update(GameTime gameTime, List<Character> sprites)
        {
            Move();

            SetAnimations();

            _animationManager.Update(gameTime);

            Position += Velocity;
            Velocity = Vector2.Zero;
        }
    }
}
