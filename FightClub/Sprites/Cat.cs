using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using FightClub.Models;
using FightClub.Sprites;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub.Sprites
{
    public class Cat : Sprite
    {

        public Cat(Game game)
            : base(null, new Vector2(0, 0), null)
        {
            _animations = new Dictionary<string, Animation>() {
                { "WalkUp", new Animation(game.Content.Load<Texture2D>("Cat/JumpingRight"), 4) },
                { "WalkDown", new Animation(game.Content.Load<Texture2D>("Cat/WalkingDown"), 4) },
                { "WalkLeft", new Animation(game.Content.Load<Texture2D>("Cat/WalkingLeft"), 4) },
                { "WalkRight", new Animation(game.Content.Load<Texture2D>("Cat/WalkingRight"), 4) },
            };
            Position = new Vector2(300, 100);
            base._input = new Input()
            {
                Up = Keys.Up,
                Down = Keys.Down,
                Left = Keys.Left,
                Right = Keys.Right,
            };
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Move(deltaTime);

            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if ((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) ||
                    (this.Velocity.X < 0 && this.IsTouchingRight(sprite)))
                    this.Velocity.X = 0;

                if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                    (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite)))
                    this.Velocity.Y = 0;
            }

            base.Update(gameTime, sprites);
        }

        //public void Move(float deltaTime)
        //{
        //    base.Move(deltaTime);
        //}
    }
}
