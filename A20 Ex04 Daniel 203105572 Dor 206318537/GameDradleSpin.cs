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
     public class GameDradleSpin : BaseGame
     {
          private readonly IRandomBehavior r_RandomBehavior;
          private GraphicsDeviceManager r_Graphics;
          private SpriteBatch r_SpriteBatch;
          private BasicEffect m_BasicEffect;
          private VertexPositionColor[] m_Vertices;
          private RasterizerState m_RasterizerState;
          private Camera m_Camera;
          private Dreidel m_DradleSpin;

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

               m_DradleSpin = new Dreidel(this, 1);
               m_DradleSpin.Position = new Vector3(0, -2, -10);
               m_DradleSpin.Rotations = new Vector3(0.1f, 0, 0);
               m_DradleSpin.AngularVelocity = new Vector3(0, 0.5f, 0);
               m_DradleSpin.TriangleDrawType = PrimitiveType.TriangleList;

               base.Initialize();
          }

          protected override void LoadContent()
          {
               r_SpriteBatch = new SpriteBatch(GraphicsDevice);
               m_BasicEffect = new BasicEffect(this.GraphicsDevice);
               m_BasicEffect.VertexColorEnabled = true;
               m_RasterizerState = new RasterizerState();
               m_RasterizerState.CullMode = CullMode.CullCounterClockwiseFace;
               m_DradleSpin.BasicEffect = m_BasicEffect;

               base.LoadContent();
          }

          protected override void Update(GameTime i_GameTime)
          {
               if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

               base.Update(i_GameTime);
          }

          protected override void Draw(GameTime gameTime)
          {
               GraphicsDevice.Clear(Color.CornflowerBlue);

               base.Draw(gameTime);
          }
     }
}
