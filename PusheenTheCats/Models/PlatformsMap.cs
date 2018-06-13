using FightClub.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub.Models
{
    public class PlatformsMap
    {
        protected ContentManager _content;
        protected GameMain _game;
        protected GraphicsDevice _graphicsDevice;

        public PlatformsMap(GameMain game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            this._game = game;
            this._content = content;
            this._graphicsDevice = graphicsDevice;
        }

        public List<Platform> CreatePlatforms()
        {
            List<Platform> platforms = new List<Platform>();
            Random rnd = new Random();

            var mainPlatform = _content.Load<Texture2D>("Platforms/mainPlatform");
            var onAirPlatform = _content.Load<Texture2D>("Platforms/onAirPlatform");
            var onAirPlatform2 = _content.Load<Texture2D>("Platforms/onAirPlatform2");

            MainPlatform(platforms, mainPlatform);

            OnAirPlatforms(platforms, rnd, onAirPlatform);

            OnAirPlatforms2(platforms, rnd, onAirPlatform);

            return platforms;
        }

        private void MainPlatform(List<Platform> platforms, Texture2D mainPlatform)
        {
            Platform platform = new Platform(_game, mainPlatform, new Vector2(0, 590));
            platforms.Add(platform);
        }

        private void OnAirPlatforms(List<Platform> platforms, Random rnd, Texture2D onAirPlatform)
        {
            var airPlatform0 = new Platform(_game, onAirPlatform, new Vector2(50, 400));
            var airPlatform1 = new Platform(_game, onAirPlatform, new Vector2(500, 400));
            var airPlatform2 = new Platform(_game, onAirPlatform, new Vector2(950, 400));

            platforms.Add(airPlatform0);
            platforms.Add(airPlatform1);
            platforms.Add(airPlatform2);
        }

        private void OnAirPlatforms2(List<Platform> platforms, Random rnd, Texture2D onAirPlatform2)
        {
            var airPlatform0 = new Platform(_game, onAirPlatform2, new Vector2(150, 200));
            var airPlatform1 = new Platform(_game, onAirPlatform2, new Vector2(850, 200));

            platforms.Add(airPlatform0);
            platforms.Add(airPlatform1);
        }
    }
}
