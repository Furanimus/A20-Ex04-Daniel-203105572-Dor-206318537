using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using A20_Ex04_Daniel_203105572_Dor_206318537.Components;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Managers
{
     public class CameraManager : RegisteredComponent
     {
          private readonly InputManager r_InputManager;
          private Camera m_Camera;

          public CameraManager(Game i_Game)
               : base(i_Game)
          {
               m_Camera = new Camera(i_Game);
               r_InputManager = i_Game.Services.GetService(typeof(InputManager)) as InputManager;
          }

          public override void Initialize()
          {
               base.Initialize();
          }

          public override void Update(GameTime i_GameTime)
          {
               if (r_InputManager.KeyPressed(Keys.Left))
               {
                    Vector3 tempVector = m_Camera.Position;
                    tempVector.X -= 5 * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
                    m_Camera.Position = tempVector;
               }

               base.Update(i_GameTime);
          }
     }
}
