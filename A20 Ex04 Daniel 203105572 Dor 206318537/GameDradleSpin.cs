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
          private readonly List<Dreidel> r_Dreidels;
          private readonly GameManager r_GameManager;

          private GraphicsDeviceManager r_Graphics;
          private SpriteBatch r_SpriteBatch;
          private BasicEffect m_BasicEffect;
          private RasterizerState m_RasterizerState;
          private Camera m_Camera;


          public GameDradleSpin()
          {
               r_Graphics = new GraphicsDeviceManager(this);
               Content.RootDirectory = "Content";
               r_RandomBehavior = this.Services.GetService(typeof(IRandomBehavior)) as IRandomBehavior;
               r_Dreidels = new List<Dreidel>(k_NumOfDreidels);
               r_GameManager = new GameManager(this);
          }

          protected override void Initialize()
          {
               m_Camera = new Camera(this);
               m_Camera.Position = new Vector3(0, 0, 20);
               m_Camera.TargetPosition = new Vector3(0, 0, 0);
               
               r_Dreidels.Add(new Dreidel(this, 1));
               r_Dreidels[0].Position = r_RandomBehavior.generateRandomVector3();
               r_Dreidels[0].AngularVelocity = new Vector3(0, 1f, 0);
               r_Dreidels[0].TriangleDrawType = PrimitiveType.TriangleList;

               r_Dreidels.Add(new Dreidel(this, 1));
               r_Dreidels[1].Position = r_RandomBehavior.generateRandomVector3();
               r_Dreidels[1].AngularVelocity = new Vector3(0, 1f, 0);
               r_Dreidels[1].TriangleDrawType = PrimitiveType.TriangleList;


               r_Dreidels.Add(new Dreidel(this, 1));
               r_Dreidels[2].Position = r_RandomBehavior.generateRandomVector3();
               r_Dreidels[2].AngularVelocity = new Vector3(0, 1f, 0);
               r_Dreidels[2].TriangleDrawType = PrimitiveType.TriangleStrip;

               r_Dreidels.Add(new Dreidel(this, 1));
               r_Dreidels[3].Position = r_RandomBehavior.generateRandomVector3();
               r_Dreidels[3].AngularVelocity = new Vector3(0, 1f, 0);
               r_Dreidels[3].TriangleDrawType = PrimitiveType.TriangleStrip;

               r_Dreidels.Add(new Dreidel(this, 1));
               r_Dreidels[4].Position = r_RandomBehavior.generateRandomVector3();
               r_Dreidels[4].AngularVelocity = new Vector3(0, 1f, 0);
               r_Dreidels[4].TriangleDrawType = PrimitiveType.TriangleStrip;

               r_Dreidels.Add(new Dreidel(this, 1));
               r_Dreidels[5].Position = r_RandomBehavior.generateRandomVector3();
               r_Dreidels[5].AngularVelocity = new Vector3(0, 1f, 0);
               r_Dreidels[5].TriangleDrawType = PrimitiveType.TriangleStrip;

               base.Initialize();
          }

          protected override void LoadContent()
          {
               r_SpriteBatch = new SpriteBatch(GraphicsDevice);
               m_BasicEffect = new BasicEffect(this.GraphicsDevice);
               m_BasicEffect.VertexColorEnabled = true;
               m_RasterizerState = new RasterizerState();
               m_RasterizerState.CullMode = CullMode.CullCounterClockwiseFace;

               foreach(Object3D dreidel in r_Dreidels)
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
