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
               this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);
               this.Services.AddService(typeof(SpriteBatch), this.SpriteBatch);

               base.Initialize();
          }

          protected virtual void InitServices()
          {
               InputManager = new InputManager(this);
               RandomBehavior = new RandomBehavior(this);
               Camera = new Camera(this);
          }

          public GameTime GameTime { get; set; }

          protected IInputManager InputManager { get; set; }

          protected IRandomBehavior RandomBehavior { get; set; }

          protected SpriteBatch SpriteBatch { get; set; }

          protected Composite3D World { get; set; }

          public ICamera Camera { get; set; } 
     }
}