using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub.Sprites
{
    public class Items : Sprite, ICloneable
    {

        protected KeyboardState _currentKey;

        protected KeyboardState _previousKey;

        public Vector2 Origin;

        public Vector2 Direction;

        public float RotationVelocity = 3f;

        public float LinearVelocity = 4f;

        public Sprite Parent;

        public float LifeSpan = 0f;

        public bool IsRemoved = false;


        public new Rectangle Rectangle
        {
            get
            {

                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);

            }
        }

        public Items(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            this._texture = texture;
            this._position = position;
        }


        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
