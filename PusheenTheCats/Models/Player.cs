using PusheenTheCats.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PusheenTheCats.Screens;
using PusheenTheCats.Sprites.Assets;

namespace PusheenTheCats.Models
{
    public class Player : PhysicsSprite
    {
        public int Coins = 0;
        public int Health = 500;
        public Input _input;
        public GameMain _game;
        

        public Boolean _isDead
        {
            get
            {
                return Health <= 0;
            }
        }

        public Boolean _collectionComplete
        {
            get
            {
                return Coins == 7;
            }
        }

        public Player(GameMain game)
            : base(new Vector2(0, 0), null)
        {
            this._game = game;
        }
        
        public override void Update(GameTime gameTime, List<Sprite> sprites) {
            base.Update(gameTime, sprites);

            if (_isDead)
                _game.ChangeScreen(new EndScreen(_game, _game.GraphicsDevice, _game.Content, this));
            else if (_collectionComplete)
                _game.ChangeScreen(new EndScreen(_game, _game.GraphicsDevice, _game.Content, this));


            ConstraintScreen();
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

        protected override void OnCollision(Sprite sprite)
        {
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
                if (sprite.Position.X >= this.Position.X)
                {
                    (sprite as Player).ContactVelocity = Velocity.X + CONTACT_FORCE;
                }
                else
                {
                    (sprite as Player).ContactVelocity = Velocity.X - CONTACT_FORCE;
                }
            }

            if (sprite is Coin)
            {
                sprite.Die();
                Coins++;
            }
        }

        private void ConstraintScreen()
        {
            if (IsLeavingLeftConstraintScreen())
            {
                Position = new Vector2(1240, Position.Y);
            }
            else if (IsLeavingRightConstraintScreen())
            {
                Position = new Vector2(0, Position.Y);
            }
        }
    }
}
