using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using FightClub.Models;
using Fightclub.Models;
using FightClub;

namespace FightClub.Screens
{
    public class TitleScreen : Screen
    {

        protected List<Component> _components;

        Texture2D backgroundTitleScreen;
        Rectangle mainFrame;

        public TitleScreen(GameMain game, GraphicsDevice graphicsDevice, ContentManager content)
            : base(game, graphicsDevice, content)
        {
        }

        public override void LoadContent()
        {
            var width = _graphicsDevice.Viewport.Width;
            var height = _graphicsDevice.Viewport.Height;

            backgroundTitleScreen = _content.Load<Texture2D>("Backgrounds/TitleScreen");
            mainFrame = new Rectangle(0, 0, width, height);

            var texture = _content.Load<Texture2D>("Button");
            SpriteFont font = _content.Load<SpriteFont>("Font/Ink");
            var newGameButton = new Button(texture, font, _graphicsDevice)
            {
                Text = "Play",
                Position = new Vector2((width / 2) - 120, (height / 2) - 20),
            };
            var exitGameButton = new Button(texture, font, _graphicsDevice)
            {
                Text = "Exit",
                Position = new Vector2((width / 2) - 120, (height / 2) + 60),
            };

            exitGameButton.Click += new EventHandler(ExitButtonClicked);
            newGameButton.Click += new EventHandler(PlayButtonClicked);

            _components = new List<Component>()
            {
                newGameButton,
                exitGameButton,
            };
        }

        private void PlayButtonClicked(object sender, EventArgs args)
        {
            _game.ChangeScreen(new GameScreen(_game, _graphicsDevice, _content));
        }

        private void ExitButtonClicked(object sender, EventArgs args)
        {
            _game.Exit();
        }

        public override void Update(GameTime gameTime)
        {

            foreach (var component in _components)
                component.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTitleScreen, mainFrame, Color.White);
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
        }
    }
}