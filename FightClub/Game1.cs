using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using FightClub.Models;
using FightClub.Sprites;

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

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Trying to call Dog and Cat Sprites
            //_sprites = new List<Sprite>()
            //{
            //    new Dog()
            //    new Cat();
            //};
            _sprites = new List<Sprite>()
            {

                    new Sprite(new Dictionary<string, Animation>()
                    {
                      { "WalkUp", new Animation(Content.Load<Texture2D>("Dog/JumpingRight"), 4) },
                      { "WalkDown", new Animation(Content.Load<Texture2D>("Dog/WalkingDown"), 1) },
                      { "WalkLeft", new Animation(Content.Load<Texture2D>("Dog/WalkingLeft"), 4) },
                      { "WalkRight", new Animation(Content.Load<Texture2D>("Dog/WalkingRight"), 4) },
                    })
                    {
                      Position = new Vector2(100, 100),
                      Input = new Input()
                      {
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D,
                      },
                    },
                    new Sprite(new Dictionary<string, Animation>()
                    {
                      { "WalkUp", new Animation(Content.Load<Texture2D>("Cat/WalkingUp"), 1) },
                      { "WalkDown", new Animation(Content.Load<Texture2D>("Cat/WalkingDown"), 1) },
                      { "WalkLeft", new Animation(Content.Load<Texture2D>("Cat/WalkingLeft"), 1) },
                      { "WalkRight", new Animation(Content.Load<Texture2D>("Cat/WalkingRight"), 1) },
                    })
                    {
                      Position = new Vector2(150, 100),
                      Input = new Input()
                      {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Left = Keys.Left,
                        Right = Keys.Right,
                      },
                    },
                  };
        }
    
            



    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
    {
        // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
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

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();

        foreach (var sprite in _sprites)
        {
            sprite.Draw(spriteBatch);
        }

        spriteBatch.End();

        base.Draw(gameTime);
    }
}
}
