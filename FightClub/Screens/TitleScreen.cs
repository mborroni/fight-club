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

        Texture2D background;
        Rectangle mainFrame;

        public TitleScreen(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
            : base(game, graphicsDevice, content)
        {
            var texture = _content.Load<Texture2D>("Button");
            //SpriteFont font = _content.Load<SpriteFont>("Font/TooMuchInk");
            var newGameButton = new Button(texture, graphicsDevice)
            {
                Text = "Play",
                //Click = new EventHandler(PlayButtonClicked)
            };
             var exitGameButton = new Button(texture, graphicsDevice)
             {
                 Text = "Exit",
                 //Click = new EventHandler(ExitButtonClicked)
             };

            _components = new List<Component>()
            {
                newGameButton,
                exitGameButton,
            };
        }

        protected override void LoadContent()
        {
            background = Content.Load<Texture2D>("background");
            mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        }

        private void PlayButtonClicked(object sender, EventArgs args)
        {
            _game.ChangeScreen(new GameScreen(_game, _graphicsDevice, _content));
        }



        private void ExitButtonClicked(object sender, EventArgs args)
        {
            _game.Exit();
        }

        protected override void Update(GameTime gameTime)
        {

            foreach (var component in _components)
                component.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, mainFrame, Color.White);
            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }
    }
}