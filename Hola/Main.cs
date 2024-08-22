#region
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Hola.Source.Engine;
using Hola.Source.Gameplay;
using SharpDX.MediaFoundation;

#endregion

namespace Hola
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Gameplay gamePlay;
        Basic2D cursor;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            Globals.screenWidth = 1600;
            Globals.screenHeight = 900;
            _graphics.PreferredBackBufferWidth = Globals.screenWidth;
            _graphics.PreferredBackBufferHeight = Globals.screenHeight;

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.keyboard = new McKeyboard();
            Globals.mouse = new McMouseControl();
            cursor = new Basic2D("2d\\Misc\\cursor", Vector2.Zero, new Vector2(20, 20));
            gamePlay = new Gameplay();

            Globals.normalEffect = Globals.content.Load<Effect>("Effects\\Normal");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.gameTime = gameTime;   
            Globals.keyboard.Update();
            Globals.mouse.Update();
            gamePlay.Update();
            








            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();
            
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);


            gamePlay.Draw();
            cursor.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), Vector2.Zero, Color.White);



            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
