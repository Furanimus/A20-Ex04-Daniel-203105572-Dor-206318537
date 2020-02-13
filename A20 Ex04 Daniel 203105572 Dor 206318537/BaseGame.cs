using A20_Ex04_Daniel_203105572_Dor_206318537.Components;
using A20_Ex04_Daniel_203105572_Dor_206318537.Interfaces;
using A20_Ex04_Daniel_203105572_Dor_206318537.Managers;
using A20_Ex04_Daniel_203105572_Dor_206318537.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Utils
{
     public abstract class BaseGame : Game
     {
          private RasterizerState m_RasterizerState;

          public BaseGame()
          {
               InitServices();
               World = new Composite3D(this);
               this.Components.Add(World);
          }

          protected override void Update(GameTime i_GameTime)
          {
               this.GameTime = i_GameTime;

               base.Update(i_GameTime);
          }

          protected override void Initialize()
          {
               BasicEffect = new BasicEffect(this.GraphicsDevice);
               this.BasicEffect.VertexColorEnabled = true;
               m_RasterizerState = new RasterizerState();
               m_RasterizerState.CullMode = CullMode.CullCounterClockwiseFace;
               this.GraphicsDevice.RasterizerState = m_RasterizerState;

               base.Initialize();
          }

          protected virtual void InitServices()
          {
               GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
               InputManager = new InputManager(this);
               RandomBehavior = new RandomBehavior(this);
               Camera = new Camera(this);
          }

          public GameTime GameTime { get; set; }

          protected IInputManager InputManager { get; set; }

          protected IRandomBehavior RandomBehavior { get; set; }

          public Composite3D World { get; set; }

          public ICamera Camera { get; set; } 

          public BasicEffect BasicEffect { get; set; }
     }
}