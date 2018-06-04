﻿using Microsoft.Xna.Framework;
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
    public class Cat : Player
    {

        public Cat(Game game)
            : base(game)
        {
            _animations = new Dictionary<string, Animation>() {
                { "Idle", new Animation(game.Content.Load<Texture2D>("Cat/WalkingDown"), 4) },
                { "WalkLeft", new Animation(game.Content.Load<Texture2D>("Cat/WalkingLeft"), 4) },
                { "WalkRight", new Animation(game.Content.Load<Texture2D>("Cat/WalkingRight"), 4) },
                { "JumpLeft", new Animation(game.Content.Load<Texture2D>("Cat/JumpingLeft"), 4) },
                { "JumpRight", new Animation(game.Content.Load<Texture2D>("Cat/JumpingRight"), 4) },
                { "Die", new Animation(game.Content.Load<Texture2D>("Cat/Death"), 4) },
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
    }
}