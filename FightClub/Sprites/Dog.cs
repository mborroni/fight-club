//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System.Collections.Generic;
//using FightClub.Models;
//using FightClub.Sprites;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework.Content;

//namespace FightClub.Sprites
//{
//    public class Dog : Sprite
//    {
//        ContentManager Content;

//        public Dog ()
//            :base(_animations, new Vector2(0,0), null)
//        {
//            _animations = new Dictionary<string, Animation>() {
//                { "WalkUp", new Animation(Content.Load<Texture2D>("Dog/JumpingRight"), 4) },
//                { "WalkDown", new Animation(Content.Load<Texture2D>("Dog/WalkingDown"), 1) },
//                { "WalkLeft", new Animation(Content.Load<Texture2D>("Dog/WalkingLeft"), 4) },
//                { "WalkRight", new Animation(Content.Load<Texture2D>("Dog/WalkingRight"), 4) },
//            };

//            Position = new Vector2(100, 100);
//            Input = new Input()
//            {
//                Up = Keys.W,
//                Down = Keys.S,
//                Left = Keys.A,
//                Right = Keys.D,
//            };
//        }
//    }
//}



