using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using FightClub.Sprites;
using System;
using MonoGame.Extended.Tiled.Graphics;
using MonoGame.Extended.Tiled;
using FightClub.Sprites.Platforms;

namespace FightClub
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<Sprite> _sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _sprites = new List<Sprite>()
            {
                new Dog(this),
                new Cat(this),
            };

            Random rnd = new Random();

            for (int i = 0; i < 30; i++)
            {
                int positionX = rnd.Next(0, 800);
                int positionY = rnd.Next(0, 500);
                Ball ball = new Ball(this, new Vector2(positionX, -30));
                _sprites.Add(ball);
            }

            for (int i = 0; i < 5; i++)
            {
                int positionX = rnd.Next(0, 800);
                int positionY = rnd.Next(0, 800);
                Platform platform = new Platform(this, new Vector2(positionX, positionY));
                _sprites.Add(platform);
            }

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //_mapRenderer.Draw(_map);

            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
