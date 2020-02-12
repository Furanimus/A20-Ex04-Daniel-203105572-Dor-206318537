using A20_Ex04_Daniel_203105572_Dor_206318537.Components;
using A20_Ex04_Daniel_203105572_Dor_206318537.Interfaces;
using A20_Ex04_Daniel_203105572_Dor_206318537.Managers;
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
          private const int k_NumOfDreidels = 6;
          private readonly IRandomBehavior r_RandomBehavior;
          //private readonly List<Dreidel> World;
          private readonly GameManager r_GameManager;

          private GraphicsDeviceManager r_Graphics;
          private SpriteBatch r_SpriteBatch;
          private BasicEffect m_BasicEffect;
          private RasterizerState m_RasterizerState;


          public GameDradleSpin()
          {
               r_Graphics = new GraphicsDeviceManager(this);
               Content.RootDirectory = "Content";
               r_RandomBehavior = this.Services.GetService(typeof(IRandomBehavior)) as IRandomBehavior;
               r_GameManager = new GameManager(this);
          }

          protected override void Initialize()
          {
               Camera.Position = new Vector3(0, 0, 50);
               Camera.TargetPosition = new Vector3(0, 0, 0);
               
               World.AddComponent(new Dreidel(this, 1));
               World[0].Position = r_RandomBehavior.generateRandomVector3();
               World[0].AngularVelocity = new Vector3(0, 1f, 0);
               World[0].TriangleDrawType = PrimitiveType.TriangleList;

               World.AddComponent(new Dreidel(this, 1));
               World[1].Position = r_RandomBehavior.generateRandomVector3();
               World[1].AngularVelocity = new Vector3(0, 1f, 0);
               World[1].TriangleDrawType = PrimitiveType.TriangleList;


               World.AddComponent(new Dreidel(this, 1));
               World[2].Position = r_RandomBehavior.generateRandomVector3();
               World[2].AngularVelocity = new Vector3(0, 1f, 0);
               World[2].TriangleDrawType = PrimitiveType.TriangleStrip;

               World.AddComponent(new Dreidel(this, 1));
               World[3].Position = r_RandomBehavior.generateRandomVector3();
               World[3].AngularVelocity = new Vector3(0, 1f, 0);
               World[3].TriangleDrawType = PrimitiveType.TriangleStrip;

               World.AddComponent(new Dreidel(this, 1));
               World[4].Position = r_RandomBehavior.generateRandomVector3();
               World[4].AngularVelocity = new Vector3(0, 1f, 0);
               World[4].TriangleDrawType = PrimitiveType.TriangleStrip;

               World.AddComponent(new Dreidel(this, 1));
               World[5].Position = r_RandomBehavior.generateRandomVector3();
               World[5].AngularVelocity = new Vector3(0, 1f, 0);
               World[5].TriangleDrawType = PrimitiveType.TriangleStrip;

               base.Initialize();
          }

          protected override void LoadContent()
          {
               r_SpriteBatch = new SpriteBatch(GraphicsDevice);
               m_BasicEffect = new BasicEffect(this.GraphicsDevice);
               m_BasicEffect.VertexColorEnabled = true;
               m_RasterizerState = new RasterizerState();
               m_RasterizerState.CullMode = CullMode.CullCounterClockwiseFace;

               foreach(Object3D dreidel in World)
               {
                    dreidel.BasicEffect = m_BasicEffect;
               }


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
