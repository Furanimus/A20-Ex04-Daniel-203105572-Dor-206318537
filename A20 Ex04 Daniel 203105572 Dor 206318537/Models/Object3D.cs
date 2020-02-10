using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using A20_Ex04_Daniel_203105572_Dor_206318537.Components;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public abstract class Object3D : LoadableDrawableComponent
     {
          protected Matrix m_ModelWorldTransform;
          private readonly Camera r_Camera;

          public Object3D(Game i_Game) 
               : base(i_Game)
          {
               r_Camera = i_Game.Services.GetService(typeof(Camera)) as Camera;
          }

          public Texture2D Texture { get; set; }

          public Vector3 Position { get; set; }

          public Vector3 Velocity { get; set; }

          public Vector3 Rotations { get; set; }

          public Vector3 AngularVelocity { get; set; }

          public Vector3 Scales { get; set; } = Vector3.One;

          public Matrix CameraView { get; set; }

          public Matrix CameraProjection { get; set; }

          public BasicEffect BasicEffect { get; set; }

          public override void Initialize()
          {
               CameraView = r_Camera.ViewMatrix;
               CameraProjection = r_Camera.FieldOfView;

               base.Initialize();
          }

          public override void Update(GameTime gameTime)
          {
               Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
               Rotations += AngularVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

               BuildModelWorldMatrix();

               base.Update(gameTime);
          }

          protected void BuildModelWorldMatrix()
          {
               m_ModelWorldTransform =
                    Matrix.CreateScale(Scales) *                    // this will shrink the model.
                    Matrix.CreateRotationY(Rotations.Y) *           // rotate on Y axis.. (Yow)
                    Matrix.CreateRotationX(Rotations.X) *           // rotate on Z axis.. (Pitch)
                    Matrix.CreateRotationZ(Rotations.Z) *           // rotate on Z axis.. (Roll)
                    Matrix.CreateTranslation(Position);             // move in space..
          }

          public override void Draw(GameTime i_GameTime)
          {
               BasicEffect.World = m_ModelWorldTransform;
               BasicEffect.View = CameraView;
               BasicEffect.Projection = CameraProjection;

               foreach (EffectPass pass in BasicEffect.CurrentTechnique.Passes)
               {
                    pass.Apply();
                    OnEffectPassDraw(pass, i_GameTime);
               }

               base.Draw(i_GameTime);
          }

          protected virtual void OnEffectPassDraw(EffectPass i_Pass, GameTime i_GameTime)
          {
          }

          protected override void UnloadContent()
          {
               if (BasicEffect != null)
               {
                    BasicEffect.Dispose();
                    BasicEffect = null;
               }
          }
     }
}
