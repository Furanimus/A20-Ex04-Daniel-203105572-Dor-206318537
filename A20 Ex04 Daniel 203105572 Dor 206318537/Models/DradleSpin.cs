using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class DradleSpin : Object3D
     {
          private const int k_BonesCount          = 3;
          private readonly List<Object3D> r_Bones = new List<Object3D>(k_BonesCount);
          private PrimitiveType m_TriangleDrawType;

          public DradleSpin(Game i_Game) 
               : this(i_Game, int.MaxValue)
          {
          }

          public DradleSpin(Game i_Game, int i_CallOrder) 
               : base(i_Game, i_CallOrder)
          {
               Box box = new Box(5, 5, 5, this.Game, 2);
               box.IsMultipleColorBox = true;
               box.AngularVelocity = new Vector3(0, 0.5f, 0);

               //Box holder = new Box(1, 2, 1, this.Game, 3); //??? why out of range
               //holder.AngularVelocity = new Vector3(0, 0.5f, 0);
               //holder.Position = new Vector3(box.Width / 2, box.Height / 2, 0);

               // Letter3D nunLetter = new Letter3D(this.Game);
               Rectangle3D nunLetter1 = new Rectangle3D(2, 0.8f, new Vector3(0.5f, 1.3f, 2.52f), this.Game, 3);
               Rectangle3D nunLetter2 = new Rectangle3D(1, 3, new Vector3(1, 0.2f, 2.52f), this.Game, 3);
               Rectangle3D nunLetter3 = new Rectangle3D(3f, 0.8f, new Vector3(0, -1.3f, 2.52f), this.Game, 3);
              // nunLetter.AddBone(nunLetter1);
              // nunLetter.AddBone(nunLetter2);
              // nunLetter.AddBone(nunLetter3);
              // nunLetter.AngularVelocity = new Vector3(0, 0.5f, 0);
              // nunLetter.Rotations = new Vector3(0, MathHelper.PiOver2, 0);
               nunLetter1.AngularVelocity = new Vector3(0, 0.5f, 0);
               nunLetter2.AngularVelocity = new Vector3(0, 0.5f, 0);
               nunLetter3.AngularVelocity = new Vector3(0, 0.5f, 0);

               nunLetter1.Rotations = new Vector3(0, 0, 0);
               nunLetter2.Rotations = new Vector3(0, 0, 0);
               nunLetter3.Rotations = new Vector3(0, 0, 0);

               Rectangle3D gimelLetter1 = new Rectangle3D(2.5f, 0.8f, new Vector3(0.5f, 1.3f, 2.52f), this.Game, 3);
               Rectangle3D gimelLetter2 = new Rectangle3D(1, 3, new Vector3(1.5f, 0, 2.52f), this.Game, 3);
               Rectangle3D gimelLetter3 = new Rectangle3D(2f, 0.8f, new Vector3(0, 0, 2.52f), this.Game, 3);
               Rectangle3D gimelLetter4 = new Rectangle3D(1f, 1.5f, new Vector3(-0.8f, -0.6f, 2.52f), this.Game, 3);
               gimelLetter1.Rotations = new Vector3(0, -MathHelper.PiOver2, 0);
               gimelLetter2.Rotations = new Vector3(0, -MathHelper.PiOver2, 0);
               gimelLetter3.Rotations = new Vector3(0, -MathHelper.PiOver2, 0);
               gimelLetter4.Rotations = new Vector3(0, -MathHelper.PiOver2, 0);
               gimelLetter1.AngularVelocity = new Vector3(0, 0.5f, 0);
               gimelLetter2.AngularVelocity = new Vector3(0, 0.5f, 0);
               gimelLetter3.AngularVelocity = new Vector3(0, 0.5f, 0);
               gimelLetter4.AngularVelocity = new Vector3(0, 0.5f, 0);

               Rectangle3D heLetter1 = new Rectangle3D(2.5f, 0.8f, new Vector3(0f, 1.3f, 2.52f), this.Game, 3);
               Rectangle3D heLetter2 = new Rectangle3D(1, 3, new Vector3(1f, 0, 2.52f), this.Game, 3);
               Rectangle3D heLetter3 = new Rectangle3D(1f, 1.5f, new Vector3(-0.8f, -0.6f, 2.52f), this.Game, 3);
               heLetter1.Rotations = new Vector3(0, -MathHelper.Pi, 0);
               heLetter2.Rotations = new Vector3(0, -MathHelper.Pi, 0);
               heLetter3.Rotations = new Vector3(0, -MathHelper.Pi, 0);
               heLetter1.AngularVelocity = new Vector3(0, 0.5f, 0);
               heLetter2.AngularVelocity = new Vector3(0, 0.5f, 0);
               heLetter3.AngularVelocity = new Vector3(0, 0.5f, 0);

               Rectangle3D peLetter1 = new Rectangle3D(2.5f, 0.8f, new Vector3(0f, 1.3f, 2.52f), this.Game, 3);
               Rectangle3D peLetter2 = new Rectangle3D(1, 3, new Vector3(1, 0.2f, 2.52f), this.Game, 3);
               Rectangle3D peLetter3 = new Rectangle3D(3f, 0.8f, new Vector3(0, -1.3f, 2.52f), this.Game, 3);
               Rectangle3D peLetter4 = new Rectangle3D(1f, 1.5f, new Vector3(-1f, -0.6f, 2.52f), this.Game, 3);
               Rectangle3D peLetter5 = new Rectangle3D(1.5f, 0.7f, new Vector3(-0.7f, 0f, 2.52f), this.Game, 3);
               peLetter1.Rotations = new Vector3(0, -MathHelper.ToRadians(270), 0);
               peLetter2.Rotations = new Vector3(0, -MathHelper.ToRadians(270), 0);
               peLetter3.Rotations = new Vector3(0, -MathHelper.ToRadians(270), 0);
               peLetter4.Rotations = new Vector3(0, -MathHelper.ToRadians(270), 0);
               peLetter5.Rotations = new Vector3(0, -MathHelper.ToRadians(270), 0);
               peLetter1.AngularVelocity = new Vector3(0, 0.5f, 0);
               peLetter2.AngularVelocity = new Vector3(0, 0.5f, 0);
               peLetter3.AngularVelocity = new Vector3(0, 0.5f, 0);
               peLetter4.AngularVelocity = new Vector3(0, 0.5f, 0);
               peLetter5.AngularVelocity = new Vector3(0, 0.5f, 0);

               r_Bones.Add(box);
               //r_Bones.Add(holder);
               // r_Bones.Add(nunLetter);
               // r_Bones.Add(gimelLetter);
               // r_Bones.Add(heLetter);
               // r_Bones.Add(peLetter);
               r_Bones.Add(nunLetter1);
               r_Bones.Add(nunLetter2);
               r_Bones.Add(nunLetter3);
               r_Bones.Add(gimelLetter1);
               r_Bones.Add(gimelLetter2);
               r_Bones.Add(gimelLetter3);
               r_Bones.Add(gimelLetter4);
               r_Bones.Add(heLetter1);
               r_Bones.Add(heLetter2);
               r_Bones.Add(heLetter3);
               r_Bones.Add(peLetter1);
               r_Bones.Add(peLetter2);
               r_Bones.Add(peLetter3);
               r_Bones.Add(peLetter4);
               r_Bones.Add(peLetter5);
          }

          public new Vector3 AngularVelocity
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

          public new Vector3 Position
          {
               get
               {
                    return base.Position;
               }

               set
               {
                    base.Position = value;

                    foreach(Object3D bone in r_Bones)
                    {
                         bone.Position = value;
                    }
               }
          }

          public new BasicEffect BasicEffect
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
                         bone.BasicEffect = this.BasicEffect;
                    }
               }
          }

          public new PrimitiveType TriangleDrawType 
          {
               get
               {
                    return m_TriangleDrawType;
               }

               set
               {
                    m_TriangleDrawType = value;

                    foreach(Object3D bone in r_Bones)
                    {
                         bone.TriangleDrawType = value;
                    }
               }
          }
     }
}
