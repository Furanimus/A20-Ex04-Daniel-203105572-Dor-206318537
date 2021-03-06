﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using A20_Ex04_Daniel_203105572_Dor_206318537.Utils;
using A20_Ex04_Daniel_203105572_Dor_206318537.Components;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public abstract class Object3D : DrawableGameComponent
     {
          protected readonly Camera r_Camera;
          protected Matrix m_ModelWorldTransform;

          public Object3D(Game i_Game, int i_UpdateOrder, int i_DrawOrder)
               : base(i_Game)
          {
               this.UpdateOrder = i_UpdateOrder;
               this.DrawOrder = i_DrawOrder;
               r_Camera = i_Game.Services.GetService(typeof(Camera)) as Camera;
          }

          public Object3D(Game i_Game, int i_CallOrder)
               : this(i_Game, i_CallOrder, i_CallOrder)
          {
          }

          public Object3D(Game i_Game) 
               : this(i_Game, int.MaxValue)
          {
          }

          public Vector3 ModelCenter { get; set; }

          public virtual PrimitiveType TriangleDrawType { get; set; } = PrimitiveType.TriangleStrip;

          public virtual Texture2D Texture { get; set; }

          public virtual Vector3 Position { get; set; }

          public Color Color { get; set; } = Color.Black;

          public virtual Vector3 Velocity { get; set; }

          public virtual Vector3 Rotations { get; set; }

          public virtual Vector3 AngularVelocity { get; set; }

          public virtual Vector3 Scales { get; set; } = Vector3.One;

          public virtual Matrix CameraView { get; set; }

          public virtual Matrix CameraProjection { get; set; }

          public virtual BasicEffect BasicEffect { get; set; }

          public override void Initialize()
          {
               if (this.BasicEffect == null)
               {
                    this.BasicEffect = (this.Game as BaseGame).BasicEffect;
               }

               CameraView = r_Camera.ViewMatrix;
               CameraProjection = r_Camera.FieldOfView;
               
               base.Initialize();
          }

          public override void Update(GameTime i_GameTime)
          {
               OnUpdate(i_GameTime);

               if(r_Camera.ShouldUpdateViewMatrix)
               {
                    CameraView = r_Camera.ViewMatrix;
                    CameraProjection = r_Camera.FieldOfView;
               }

               BuildModelWorldMatrix();

               base.Update(i_GameTime);
          }

          protected virtual void OnUpdate(GameTime i_GameTime)
          {
               Position += Velocity * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
               Rotations += AngularVelocity * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
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
               OnDraw(i_GameTime);

               base.Draw(i_GameTime);
          }

          protected virtual void OnDraw(GameTime i_GameTime)
          {
               BasicEffect.World = m_ModelWorldTransform;
               BasicEffect.View = CameraView;
               BasicEffect.Projection = CameraProjection;

               foreach (EffectPass pass in BasicEffect.CurrentTechnique.Passes)
               {
                    pass.Apply();
                    OnEffectPassDraw(pass, i_GameTime);
               }
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
