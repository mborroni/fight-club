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
    public class Dog : Sprite
    {

        public Dog(Game game)
            : base(null, new Vector2(0, 0), null)
        {
            _animations = new Dictionary<string, Animation>() {
                { "WalkUp", new Animation(game.Content.Load<Texture2D>("Dog/JumpingRight"), 4) },
                { "WalkDown", new Animation(game.Content.Load<Texture2D>("Dog/WalkingDown"), 1) },
                { "WalkLeft", new Animation(game.Content.Load<Texture2D>("Dog/WalkingLeft"), 4) },
                { "WalkRight", new Animation(game.Content.Load<Texture2D>("Dog/WalkingRight"), 4) },
                { "JumpLeft", new Animation(game.Content.Load<Texture2D>("Dog/JumpingLeft"), 4) },
                { "JumpRight", new Animation(game.Content.Load<Texture2D>("Dog/JumpingRight"), 4) },
            };
            Position = new Vector2(100, 100);
            base._input = new Input()
            {
                Up = Keys.W,
                Down = Keys.S,
                Left = Keys.A,
                Right = Keys.D,
            };
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            base.Update(gameTime, sprites);
        }

    }
}



