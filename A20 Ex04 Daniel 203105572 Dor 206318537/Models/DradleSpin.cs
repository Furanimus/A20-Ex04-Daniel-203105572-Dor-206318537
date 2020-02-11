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
               box.AngularVelocity = new Vector3(0, 1, 0);

               Rectangle3D nunLetter = new Rectangle3D(2, 1, new Vector3(0, 0, 2.6f), this.Game, 3);
               nunLetter.AngularVelocity = new Vector3(0, 1, 0);

               r_Bones.Add(box);
               r_Bones.Add(nunLetter);
               nunLetter.Position = box.Position;
               nunLetter.Position -= new Vector3(0, 0.5f, 0);
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
