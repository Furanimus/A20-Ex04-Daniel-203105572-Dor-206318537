using Microsoft.Xna.Framework;
using A20_Ex04_Daniel_203105572_Dor_206318537.Interfaces;
using A20_Ex04_Daniel_203105572_Dor_206318537.Components;
using System;
using Microsoft.Xna.Framework.Input;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Managers
{
     public class CameraManager : RegisteredComponent
     {

          private Camera m_Camera;
          private readonly InputManager r_InputManager;

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
                    Vector3 v = m_Camera.Position;
                    v.X -= 5 * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
                    m_Camera.Position = v;
               }

               base.Update(i_GameTime);
          }

          //private Matrix m_ViewMatrix; // Dropped readonly because of initializiation
          //private Matrix m_ProjectionMatrix; 
          //private readonly IInputManager r_InputManager;


          //public override void Initialize()
          //{
          //     base.Initialize();

          //     setCameraSettings();
          //}

          //private void setCameraSettings()
          //{
          //     float k_NearPlaneDistance = 0.5f;
          //     float k_FarPlaneDistance = 1000.0f;
          //     float k_ViewAngle = MathHelper.PiOver4;

          //     // we are storing the camera settings data in a matrix:
          //     m_ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
          //          k_ViewAngle,
          //          this.Game.GraphicsDevice.Viewport.AspectRatio,
          //          k_NearPlaneDistance,
          //          k_FarPlaneDistance);
          //}

          //public override void Update(GameTime i_GameTime)
          //{
          //     base.Update(i_GameTime);

          //     getCameraMovement();
          //     updateCameraSettings();
          //}

          //private void updateCameraSettings()
          //{
          //     throw new NotImplementedException();
          //}

          //private void getCameraMovement()
          //{
          //     throw new NotImplementedException();
          //}
     }
}
