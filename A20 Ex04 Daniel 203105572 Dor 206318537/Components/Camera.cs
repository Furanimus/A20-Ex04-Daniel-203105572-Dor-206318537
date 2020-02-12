using A20_Ex04_Daniel_203105572_Dor_206318537.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Components
{
     public class Camera : GameService, ICamera
     {
          public event EventHandler OnPositionChanged;

          private bool m_ShouldUpdateViewMatrix = true;

          private Matrix m_ProjectionFieldOfView;

          public Camera(Game i_Game) : base(i_Game)
          {
          }

          public override void Initialize()
          {
               float k_NearPlaneDistance = 0.5f;
               float k_FarPlaneDistance = 1000.0f;
               float k_ViewAngle = MathHelper.PiOver4;

               // we are storing the field-of-view data in a matrix:
               m_ProjectionFieldOfView = Matrix.CreatePerspectiveFieldOfView(
                   k_ViewAngle,
                   Game.GraphicsDevice.Viewport.AspectRatio,
                   k_NearPlaneDistance,
                   k_FarPlaneDistance);

               base.Initialize();
          }

          public Matrix FieldOfView
          {
               get { return m_ProjectionFieldOfView; }
               set { m_ProjectionFieldOfView = value; }
          }

          public bool ShouldUpdateViewMatrix
          {
               get 
               { 
                    return m_ShouldUpdateViewMatrix; 
               }

               set
               {
                    if (m_ShouldUpdateViewMatrix != value && OnPositionChanged != null)
                    {
                         OnPositionChanged.Invoke(this, null);
                    }

                    m_ShouldUpdateViewMatrix = value;
               }
          }

          protected Matrix m_ViewMatrix;

          public Matrix ViewMatrix
          {
               get
               {
                    if (ShouldUpdateViewMatrix)
                    {
                         m_ViewMatrix = Matrix.CreateLookAt(Position, TargetPosition, Up);
                         ShouldUpdateViewMatrix = false;
                    }

                    return m_ViewMatrix;
               }
          }

          protected Vector3 m_TargetPosition = Vector3.Zero;

          public Vector3 TargetPosition
          {
               get
               {
                    if (m_ShouldUpdateViewMatrix)
                    {
                         m_TargetPosition = Vector3.Transform(Vector3.Forward, RotationQuaternion);
                         m_TargetPosition = m_Position + m_TargetPosition;
                    }

                    return m_TargetPosition;

               }
               set
               {
                    if (m_TargetPosition != value)
                    {
                         m_TargetPosition = value;
                         ShouldUpdateViewMatrix = true;
                    }
               }
          }

          protected Vector3 m_Rotations = Vector3.Zero;

          public Vector3 Rotations
          {
               get
               {
                    return m_Rotations;
               }
               set
               {
                    if (m_Rotations != value)
                    {
                         m_Rotations = value;
                         ShouldUpdateViewMatrix = true;
                    }
               }
          }

          protected Quaternion m_RotationQuaternion = Quaternion.Identity;

          public Quaternion RotationQuaternion
          {
               get
               {
                    if (m_ShouldUpdateViewMatrix)
                    {
                         m_RotationQuaternion *= Quaternion.CreateFromAxisAngle(Vector3.UnitX, m_Rotations.X);
                         m_RotationQuaternion *= Quaternion.CreateFromAxisAngle(Vector3.UnitY, m_Rotations.Y);
                         m_RotationQuaternion *= Quaternion.CreateFromAxisAngle(Vector3.UnitZ, m_Rotations.Z);
                    }

                    return m_RotationQuaternion;
               }
               set
               {
                    if (m_RotationQuaternion != value)
                    {
                         m_RotationQuaternion = value;
                         ShouldUpdateViewMatrix = true;
                    }
               }
          }

          // we are standing 20 units in front of our target:
          protected Vector3 m_Position = new Vector3(256, 30, 20);

          public Vector3 Position
          {
               get { return m_Position; }
               set
               {
                    if (m_Position != value)
                    {
                         m_Position = value;
                         ShouldUpdateViewMatrix = true;
                    }
               }
          }

          public float Yaw
          {
               get { return m_Rotations.Y; }
               set
               {
                    if (m_Rotations.Y != value)
                    {
                         m_Rotations.Y = value;
                         ShouldUpdateViewMatrix = true;
                    }
               }
          }

          public float Pitch
          {
               get { return m_Rotations.X; }
               set
               {
                    if (m_Rotations.X != value)
                    {
                         m_Rotations.X = value;
                         ShouldUpdateViewMatrix = true;
                    }
               }
          }

          public float Roll
          {
               get { return m_Rotations.Z; }
               set
               {
                    if (m_Rotations.Z != value)
                    {
                         m_Rotations.Z = value;
                         ShouldUpdateViewMatrix = true;
                    }
               }
          }

          public Vector3 Up
          {
               get
               {
                    return Vector3.Transform(Vector3.UnitY, RotationQuaternion);
               }
          }

          public Vector3 Forward
          {
               get
               {
                    return Vector3.Transform(Vector3.Forward, m_RotationQuaternion);
               }
          }

          public Vector3 Right
          {
               get
               {
                    return Vector3.Transform(Vector3.Right, m_RotationQuaternion);
               }
          }

          static readonly float sr_RotationSpeed = MathHelper.ToRadians(0.2f);

          public override void Update(GameTime gameTime)
          {
               UpdateByInput();

               m_Rotations.Y += m_RotationQuaternion.Z / 40;
               ShouldUpdateViewMatrix = true;

               base.Update(gameTime);
          }

          protected void UpdateByInput()
          {
               KeyboardState keyboardState = Keyboard.GetState();

               float movementScale = 1;

               if (keyboardState.IsKeyDown(Keys.LeftShift))
               {
                    movementScale *= 10;
               }
               if (keyboardState.IsKeyDown(Keys.LeftControl))
               {
                    movementScale *= 100;
               }
               // forward:
               if (keyboardState.IsKeyDown(Keys.Up))
               {
                    m_Position -= movementScale * Vector3.Transform(Vector3.UnitZ / 10, RotationQuaternion);
                    ShouldUpdateViewMatrix = true;
               }
               // backwords:
               else if (keyboardState.IsKeyDown(Keys.Down))
               {
                    m_Position += movementScale * Vector3.Transform(Vector3.UnitZ / 10, RotationQuaternion);
                    ShouldUpdateViewMatrix = true;
               }

               // strafe left:
               if (keyboardState.IsKeyDown(Keys.Left))
               {
                    m_Position -= movementScale * Vector3.Transform(Vector3.UnitX / 2, RotationQuaternion);
                    ShouldUpdateViewMatrix = true;
               }
               // strafe right:
               else if (keyboardState.IsKeyDown(Keys.Right))
               {
                    m_Position += movementScale * Vector3.Transform(Vector3.UnitX / 2, RotationQuaternion);
                    ShouldUpdateViewMatrix = true;
               }
          }
     }
}
