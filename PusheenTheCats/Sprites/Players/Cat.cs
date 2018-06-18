using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PusheenTheCats.Models;
using PusheenTheCats.Sprites;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PusheenTheCats.Sprites
{
    public class Cat : Player
    {

        public Cat(GameMain game)
            : base(game)
        {
            _animations = new Dictionary<string, Animation>() {
                { "Idle", new Animation(game.Content.Load<Texture2D>("Cat/Idle"), 4) },
                { "WalkLeft", new Animation(game.Content.Load<Texture2D>("Cat/RunLeft"), 8) },
                { "WalkRight", new Animation(game.Content.Load<Texture2D>("Cat/RunRight"), 8) },
                { "JumpLeft", new Animation(game.Content.Load<Texture2D>("Cat/JumpingLeft"), 8) },
                { "JumpRight", new Animation(game.Content.Load<Texture2D>("Cat/JumpingRight"), 8) },
                { "Die", new Animation(game.Content.Load<Texture2D>("Cat/Death"), 8) },
            };
            Position = new Vector2(950, 425);
            base._input = new Input()
            {
                Up = Keys.Up,
                Down = Keys.Down,
                Left = Keys.Left,
                Right = Keys.Right,
            };
        }
    }
}
