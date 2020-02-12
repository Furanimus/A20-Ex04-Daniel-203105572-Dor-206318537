using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class Composite3D : Object3D
     {
          private readonly List<Object3D> r_Bones;

          public Composite3D(Game i_Game)
               : this(i_Game, int.MaxValue, null)
          {
          }

          public Composite3D(Game i_Game, int i_CallOrder)
               : this(i_Game, i_CallOrder, null)
          {
          }

          public Composite3D(Game i_Game, int i_CallOrder, params Object3D[] i_Bones)
               : base(i_Game, i_CallOrder)
          {
               r_Bones = new List<Object3D>();

               if (i_Bones != null)
               {
                    foreach(Rectangle3D bone in i_Bones)
                    {
                         AddBone(bone);
                    }
               }
          }

          public override PrimitiveType TriangleDrawType
          {
               get
               {
                    return base.TriangleDrawType;
               }

               set
               {
                    base.TriangleDrawType = value;

                    foreach (Object3D bone in r_Bones)
                    {
                         bone.TriangleDrawType = value;
                    }
               }
          }

          public override Texture2D Texture 
          {
               get
               {
                    return base.Texture;
               }

               set
               {
                    base.Texture = value;

                    foreach (Object3D bone in r_Bones)
                    {
                         bone.Texture = value;
                    }
               }
          }

          public override Vector3 Position
          {
               get
               {
                    return base.Position;
               }

               set
               {
                    base.Position = value;

                    foreach (Object3D bone in r_Bones)
                    {
                         bone.Position = value;
                    }
               }
          }

          public override Vector3 Velocity
          {
               get
               {
                    return base.Velocity;
               }

               set
               {
                    base.Velocity = value;

                    foreach (Object3D bone in r_Bones)
                    {
                         bone.Velocity = value;
                    }
               }
          }

          public override Vector3 Scales
          {
               get
               {
                    return base.Scales;
               }

               set
               {
                    base.Scales = value;

                    foreach (Object3D bone in r_Bones)
                    {
                         bone.Scales = value;
                    }
               }
          }

          public override Matrix CameraView
          {
               get
               {
                    return base.CameraView;
               }

               set
               {
                    base.CameraView = value;

                    foreach (Object3D bone in r_Bones)
                    {
                         bone.CameraView = value;
                    }
               }
          }

          public override Matrix CameraProjection 
          {
               get
               {
                    return base.CameraProjection;
               }

               set
               {
                    base.CameraProjection = value;

                    foreach (Object3D bone in r_Bones)
                    {
                         bone.CameraProjection = value;
                    }
               }
          }

          public override BasicEffect BasicEffect
          {
               get
               {
                    return base.BasicEffect;
               }

               set
               {
                    base.BasicEffect = value;

                    foreach (Object3D bone in r_Bones)
                    {
                         bone.BasicEffect = value;
                    }
               }
          }
         
          public override Vector3 AngularVelocity
          {
               get
               {
                    return base.AngularVelocity;
               }

               set
               {
                    base.AngularVelocity = value;

                    foreach(Object3D bone in r_Bones)
                    {
                         bone.AngularVelocity = value;
                    }
               }
          }

          public override Vector3 Rotations
          {
               get
               {
                    return base.Rotations;
               }
               set
               {
                    base.Rotations = value;

                    foreach (Object3D bone in r_Bones)
                    {
                         bone.Rotations += value;
                    }
               }
          }

          public void AddBone(Object3D i_Bone)
          {
               r_Bones.Add(i_Bone);
          }

          public override void Initialize()
          {
               foreach(Object3D bone in r_Bones)
               {
                    bone.Initialize();
               }
               
               base.Initialize();
          }

          protected override void OnUpdate(GameTime i_GameTime)
          {
               if(r_Camera.ShouldUpdateViewMatrix)
               {
                    foreach (Object3D bone in r_Bones)
                    {
                         bone.CameraView = r_Camera.ViewMatrix;
                         bone.CameraProjection = r_Camera.FieldOfView;
                    }
               }

               foreach (Object3D bone in r_Bones)
               {
                    bone.Update(i_GameTime);
               }
          }

          protected override void OnDraw(GameTime i_GameTime)
          {
               foreach (Object3D bone in r_Bones)
               {
                    bone.Draw(i_GameTime);
               }
          }
     }
}
