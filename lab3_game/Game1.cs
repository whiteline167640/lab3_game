
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace lab3_game
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics; SpriteBatch spriteBatch; Texture2D myTexture; Vector2 spritePosition = Vector2.Zero; int frame = 3;

        Texture2D cloudTexture; Vector2[] scaleCloud; Vector2[] cloudPos; int[] speed;

        Random r = new Random();

        public Game1() { graphics = new GraphicsDeviceManager(this); Content.RootDirectory = "Content"; IsMouseVisible = true; }

        protected override void Initialize()
        {                 base.Initialize();        }


 protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice); myTexture = Content.Load<Texture2D>("NatureSprite"); cloudTexture = Content.Load<Texture2D>("Cloud_sprite");

            cloudPos = new Vector2[4]; scaleCloud = new Vector2[4]; speed = new int[4];

            for (int i = 0; i < 4; i++) { cloudPos[i].Y = r.Next(0, graphics.GraphicsDevice.Viewport.Height - cloudTexture.Height); scaleCloud[i].X = r.Next(1, 3); scaleCloud[i].Y = scaleCloud[i].X; speed[i] = r.Next(3, 7); }                 }


 protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

                    for (int i = 0; i < 4; i++)            {                cloudPos[i].X = cloudPos[i].X + speed[i];                if (cloudPos[i].X > graphics.GraphicsDevice.Viewport.Width)                {                    cloudPos[i].X = 0;                    cloudPos[i].Y = r.Next(0, graphics.GraphicsDevice.Viewport.Height - cloudTexture.Height);                    scaleCloud[i].X = r.Next(1, 3);                    scaleCloud[i].Y = scaleCloud[i].X;                }            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(85, 133, 50)); spriteBatch.Begin();                     spriteBatch.Draw(myTexture, new Vector2(0, 0), new Rectangle(64 * 4,64 * 2, 64 * 4, 64 * 4), Color.White);                       spriteBatch.Draw(myTexture, new Vector2(64 * 5, 64), new Rectangle(64, 0, 64, 64), Color.White);            spriteBatch.Draw(myTexture, new Vector2(64 * 5, 64 * 2), new Rectangle(64, 0, 64, 64), Color.White);            spriteBatch.Draw(myTexture, new Vector2(64 * 5, 64 * 3), new Rectangle(64, 0, 64, 64), Color.White);            spriteBatch.Draw(myTexture, new Vector2(64 * 5, 64 * 4), new Rectangle(64, 0, 64, 64), Color.White);            spriteBatch.Draw(myTexture, new Vector2(64 * 4, 64 * 4), new Rectangle(64, 0, 64, 64), Color.White);                       spriteBatch.Draw(myTexture, new Vector2(64 * 2, 64 * 5), new Rectangle(0, 64 * 3, 64 * 2, 64 * 2), Color.White);                        spriteBatch.Draw(myTexture, new Vector2(64 * 6, 64), new Rectangle(0, 0, 64, 64), Color.White);            spriteBatch.Draw(myTexture, new Vector2(64 * 9.5f, 64 * 4.3f), new Rectangle(0, 0, 64, 64), Color.White);                        spriteBatch.Draw(myTexture, new Vector2(64 * 6.5f, 64 * 4.5f), new Rectangle(64 * 2, 0, 64, 64), Color.White);            spriteBatch.Draw(myTexture, new Vector2(64 * 8, 64 * 2.5f), new Rectangle(64 * 2, 0, 64, 64), Color.White);                        spriteBatch.Draw(myTexture, new Vector2(64 * 9.7f, 64 * 1.5f), new Rectangle(64 * 2, 64 * 4, 64 * 2, 64 * 2), Color.White);                        spriteBatch.Draw(myTexture, new Vector2(64 * 8, 64 * 5.5f), new Rectangle(0, 64, 64, 64), Color.White);                       for (int i = 0; i < 4; i++)            {                spriteBatch.Draw(cloudTexture, cloudPos[i], null, Color.White, 0, Vector2.Zero, scaleCloud[i], 0, 0);            }            spriteBatch.End();

           

            base.Draw(gameTime);
        }
    }
}

