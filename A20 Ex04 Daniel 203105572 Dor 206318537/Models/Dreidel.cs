using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class Dreidel : Composite3D
     {
          private const float k_BoxDimension           = 5;
          private const float k_HolderDimension        = 1;
          private const float k_HolderHeight           = 4;
          private readonly Vector3 r_HolderModelCenter = new Vector3(0, 2.5f, 0);

          public Dreidel(Game i_Game) 
               : this(i_Game, int.MaxValue)
          {
          }

          public Dreidel(Game i_Game, int i_CallOrder)
               : base(i_Game, i_CallOrder)
          {
               this.Game.Components.Add(this);
               Box box = new Box(k_BoxDimension, k_BoxDimension, k_BoxDimension, this.Game);
               box.IsMultipleColorBox = true;

               Box holder = new Box(k_HolderDimension, k_HolderHeight, k_HolderDimension, this.Game);
               holder.ModelCenter = r_HolderModelCenter;
               holder.Color = Color.Yellow;

               Composite3D nunLetter = new Composite3D(
                    this.Game,
                    1,
                    new Rectangle3D(2, 0.8f, new Vector3(0.5f, 1.3f, 2.52f), this.Game),
                    new Rectangle3D(1, 3, new Vector3(1, 0.2f, 2.52f), this.Game),
                    new Rectangle3D(3f, 0.8f, new Vector3(0, -1.3f, 2.52f), this.Game)
               );

               Composite3D gimelLetter = new Composite3D(
                    this.Game,
                    1,
                    new Rectangle3D(2.5f, 0.8f, new Vector3(0.5f, 1.3f, 2.52f), this.Game),
                    new Rectangle3D(1, 3, new Vector3(1.5f, 0, 2.52f), this.Game),
                    new Rectangle3D(2f, 0.8f, new Vector3(0, 0, 2.52f), this.Game),
                    new Rectangle3D(1f, 1.5f, new Vector3(-0.8f, -0.6f, 2.52f), this.Game)
               );

               Composite3D heLetter = new Composite3D(
                    this.Game,
                    1,
                    new Rectangle3D(2.5f, 0.8f, new Vector3(0f, 1.3f, 2.52f), this.Game),
                    new Rectangle3D(1, 3, new Vector3(1f, 0, 2.52f), this.Game),
                    new Rectangle3D(1f, 1.5f, new Vector3(-0.8f, -0.6f, 2.52f), this.Game)
               );

               Composite3D peLetter = new Composite3D(
                    this.Game,
                    1,
                    new Rectangle3D(2.5f, 0.8f, new Vector3(0f, 1.3f, 2.52f), this.Game),
                    new Rectangle3D(1, 3, new Vector3(1, 0.2f, 2.52f), this.Game),
                    new Rectangle3D(3f, 0.8f, new Vector3(0, -1.3f, 2.52f), this.Game),
                    new Rectangle3D(1f, 1.5f, new Vector3(-1f, -0.6f, 2.52f), this.Game),
                    new Rectangle3D(1.5f, 0.7f, new Vector3(-0.7f, 0f, 2.52f), this.Game)
               );

               Pyramid pyramid = new Pyramid(5, 5, 2.5f, this.Game);
               pyramid.ModelCenter = new Vector3(0, 2.5f, 0);
               pyramid.IsYFlip = true;
               pyramid.Color = Color.Gray;

               gimelLetter.Rotations = new Vector3(0, MathHelper.PiOver2, 0);
               heLetter.Rotations = new Vector3(0, MathHelper.Pi, 0);
               peLetter.Rotations = new Vector3(0, MathHelper.ToRadians(270), 0);

               AddBone(box);
               AddBone(holder);
               AddBone(nunLetter);
               AddBone(gimelLetter);
               AddBone(heLetter);
               AddBone(peLetter);
               AddBone(pyramid);
          }
     }
}
