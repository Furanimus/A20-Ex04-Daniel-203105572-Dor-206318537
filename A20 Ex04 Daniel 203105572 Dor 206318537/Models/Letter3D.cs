using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class Letter3D : Object3D
     {
          private readonly List<Rectangle3D> r_LetterBones;

          public Letter3D(Game i_Game)
               : base(i_Game)
          {
               r_LetterBones = new List<Rectangle3D>();
          }

          public override void Initialize()
          {
               base.Initialize();
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

                    foreach(Object3D bone in r_LetterBones)
                    {
                         bone.AngularVelocity = value;
                    }
               }
          }

          public new Vector3 Rotations
          {
               get
               {
                    return base.Rotations;
               }
               set
               {
                    base.Rotations = value;

                    foreach (Object3D bone in r_LetterBones)
                    {
                         bone.Rotations = value;
                    }
               }
          }

          public void AddBone(Rectangle3D i_Bone)
          {
               r_LetterBones.Add(i_Bone);
          }

          public override void Draw(GameTime i_GameTime)
          {
               //base.Draw(i_GameTime);

               foreach(Object3D bone in r_LetterBones)
               {
                    bone.Draw(i_GameTime);
               }
          }
     }
}
