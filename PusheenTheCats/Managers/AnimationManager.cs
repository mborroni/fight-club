using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PusheenTheCats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PusheenTheCats.Sprites;

namespace PusheenTheCats.Managers
{
    public class AnimationManager
    {
        private Sprite _sprite;

        private Animation _animation;

        public Animation Animation
        {
            get { return _animation; }
        }

        private float _timer;

        public bool isPlaying;

        public AnimationManager(Animation animation, Sprite sprite)
        {
            _animation = animation;
            _sprite = sprite;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(_animation != null)
            {
                spriteBatch.Draw(_animation.Texture,
                                 _sprite.Position,
                                 new Rectangle(_animation.CurrentFrame * _animation.FrameWidth,
                                               0,
                                               _animation.FrameWidth,
                                               _animation.FrameHeight),
                                 Color.White);
            }
        }

        public void Play(Animation animation)
        {
            if (_animation == animation) //Check if plays the same animation
                return;

            _animation = animation;

            _animation.CurrentFrame = 0;

            _timer = 0;

            isPlaying = true;
        }

        public void Stop()
        {
            _timer = 0f;
            
            if (_animation != null)
                _animation.CurrentFrame = 0; // Sets the frame to the beginning

            isPlaying = false;
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_animation != null && _timer > _animation.FrameSpeed)
            {
                _timer = 0f;

                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.FrameCount)
                    _animation.CurrentFrame = 0;
            }
        }
    }
}
