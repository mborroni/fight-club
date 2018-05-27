//using FightClub.Managers;
//using FightClub.Models;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FightClub.Sprites.Players
//{
//    public class Player : Sprite
//    {


//        public new Rectangle Rectangle
//        {
//            get
//            {
//                    return new Rectangle((int)Position.X, (int)Position.Y, _animationManager.Animation.FrameWidth, _animationManager.Animation.FrameHeight);
//            }
//        }

//        public Player(Dictionary<string, Animation> animations, Vector2 position, Input input)
//        {
//            this._animations = animations;
//            this._animationManager = new AnimationManager(null);
//            this._position = position;
//            this._input = input;
//        }

//        public override void Draw(SpriteBatch spriteBatch)
//        {
//            if (this._animationManager != null)
//                this._animationManager.Draw(spriteBatch);
//            else throw new Exception("This ain't right..!");
//        }

//        public virtual void Move(float deltaTime)
//        {
//            Velocity.Y += Gravity;

//            if (_isJumping)
//            {
//                Velocity.Y += jumpSpeed;
//                jumpSpeed += 1;
//            }

//            if (_isJumping && Velocity.Y >= 10f)
//            {
//                _isJumping = false;
//            }

//            if (_input == null)
//                return;

//            if (Keyboard.GetState().IsKeyDown(_input.Left))
//            {
//                Velocity.X -= Speed * deltaTime;
//            }

//            if (Keyboard.GetState().IsKeyDown(_input.Right))
//            {
//                Velocity.X += Speed * deltaTime;
//            }

//            if (Keyboard.GetState().IsKeyDown(_input.Up) && !_isJumping)
//            {
//                _isJumping = true;
//                jumpSpeed = -20f;
//            }

//            if (Keyboard.GetState().IsKeyDown(_input.Down))
//            {
//                Velocity.Y += Speed * deltaTime;
//            }

//        }

//        protected void SetAnimations()
//        {
//            if (Velocity.X > 0)
//            {
//                this._animationManager.Play(this._animations["WalkRight"]);
//            }
//            else if (Velocity.X < 0)
//            {
//                this._animationManager.Play(this._animations["WalkLeft"]);
//            }
//            else if (Velocity.Y > 0)
//            {
//                this._animationManager.Play(this._animations["WalkDown"]);
//            }
//            else if (Velocity.X < 0 && _isJumping)
//            {
//                this._animationManager.Play(this._animations["JumpLeft"]);
//            }
//            else if (Velocity.X > 0 && _isJumping)
//            {
//                this._animationManager.Play(this._animations["JumpRight"]);
//            }
//            else this._animationManager.Stop();
//        }

//        public override void Update(GameTime gameTime, List<Sprite> sprites)
//        {
//            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

//            if (_animations != null)
//            {
//                Move(deltaTime);
//                CheckCollisions(sprites, deltaTime);
//                SetAnimations();

//                this._animationManager.Update(gameTime);

//                Position += Velocity;
//                Velocity = Vector2.Zero;
//            }
//        }
//    }
//}
