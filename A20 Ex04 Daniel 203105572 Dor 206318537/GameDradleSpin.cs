using A20_Ex04_Daniel_203105572_Dor_206318537.Components;
using A20_Ex04_Daniel_203105572_Dor_206318537.Interfaces;
using A20_Ex04_Daniel_203105572_Dor_206318537.Models;
using A20_Ex04_Daniel_203105572_Dor_206318537.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace A20_Ex04_Daniel_203105572_Dor_206318537
{
     /// <summary>
     /// This is the main type for your game.
     /// </summary>
     public class GameDradleSpin : BaseGame
     {
          private readonly IRandomBehavior r_RandomBehavior;
          private GraphicsDeviceManager r_Graphics;
          private SpriteBatch r_SpriteBatch;
          private BasicEffect m_BasicEffect;
          private VertexPositionColor[] m_Vertices;
          private RasterizerState m_RasterizerState;
          private Camera m_Camera;
          private Box m_Box;

          public GameDradleSpin()
          {
               r_Graphics = new GraphicsDeviceManager(this);
               Content.RootDirectory = "Content";
               r_RandomBehavior = this.Services.GetService(typeof(IRandomBehavior)) as IRandomBehavior;

          }

          protected override void Initialize()
          {
               m_Camera = new Camera(this);

               m_Camera.Position = new Vector3(0, 0, 20);
               m_Camera.TargetPosition = new Vector3(0, 0, 0);

               base.Initialize();
          }

          protected override void LoadContent()
          {
               r_SpriteBatch = new SpriteBatch(GraphicsDevice);
               m_BasicEffect = new BasicEffect(this.GraphicsDevice);
               m_BasicEffect.VertexColorEnabled = true;
               m_Box = new Box(10, 10, 10, this);
               m_RasterizerState = new RasterizerState();
               m_RasterizerState.CullMode = CullMode.CullCounterClockwiseFace;
               m_Box.BasicEffect = m_BasicEffect;
          }

          protected override void UnloadContent()
          {
          }

          protected override void Update(GameTime i_GameTime)
          {
               if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

               // TODO: Add your update logic here

               foreach (GameComponent component in this.Components)
               {
                    component.Update(i_GameTime);
               }

               base.Update(i_GameTime);
          }

          protected override void Draw(GameTime gameTime)
          {
               GraphicsDevice.Clear(Color.CornflowerBlue);

               //foreach (EffectPass pass in m_BasicEffect.CurrentTechnique.Passes)
               //{
               //     pass.Apply();

               //     this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
               //         PrimitiveType.TriangleStrip, m_Vertices, 0, 2);
               //}

               base.Draw(gameTime);
          }
     }
}
