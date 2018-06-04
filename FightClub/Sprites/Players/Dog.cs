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
    public class Dog : Player
    {

        public Dog(Game game)
            : base(game)
        {
            _animations = new Dictionary<string, Animation>() { 
                { "Idle", new Animation(game.Content.Load<Texture2D>("Dog/Idle"), 4) },
                { "WalkLeft", new Animation(game.Content.Load<Texture2D>("Dog/RunLeft"), 8) },
                { "WalkRight", new Animation(game.Content.Load<Texture2D>("Dog/RunRight"), 8) },
                { "JumpLeft", new Animation(game.Content.Load<Texture2D>("Dog/JumpingLeft"), 8) },
                { "JumpRight", new Animation(game.Content.Load<Texture2D>("Dog/JumpingRight"), 8) },
                { "Die", new Animation(game.Content.Load<Texture2D>("Dog/Death"), 8) },
            };
            Position = new Vector2(150, 550);
            base._input = new Input()
            {
                Up = Keys.W,
                Down = Keys.S,
                Left = Keys.A,
                Right = Keys.D,
            };
        }
    }
}