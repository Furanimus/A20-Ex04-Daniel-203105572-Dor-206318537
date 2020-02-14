using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class ColorDreidel : Dreidel
     {
          private readonly Vector3 r_HolderModelCenter = new Vector3(0, 2.5f, 0);
          private readonly Composite3D r_NunLetter;
          private readonly Composite3D r_GimelLetter;
          private readonly Composite3D r_HeLetter;
          private readonly Composite3D r_PeLetter;

          public ColorDreidel(Game i_Game) 
               : this(i_Game, int.MaxValue)
          {
          }

          public ColorDreidel(Game i_Game, int i_CallOrder)
               : base(i_Game, i_CallOrder)
          {
               r_NunLetter = new Composite3D(
                    this.Game,
                    1,
                    new Rectangle3D(2, 0.8f, new Vector3(0.5f, 1.3f, 2.52f), this.Game),
                    new Rectangle3D(1, 3, new Vector3(1, 0.2f, 2.52f), this.Game),
                    new Rectangle3D(3f, 0.8f, new Vector3(0, -1.3f, 2.52f), this.Game));

               r_GimelLetter = new Composite3D(
                    this.Game,
                    1,
                    new Rectangle3D(2.5f, 0.8f, new Vector3(0.5f, 1.3f, 2.52f), this.Game),
                    new Rectangle3D(1, 3, new Vector3(1.5f, 0, 2.52f), this.Game),
                    new Rectangle3D(2f, 0.8f, new Vector3(0, 0, 2.52f), this.Game),
                    new Rectangle3D(1f, 1.5f, new Vector3(-0.8f, -0.6f, 2.52f), this.Game));

               r_HeLetter = new Composite3D(
                    this.Game,
                    1,
                    new Rectangle3D(2.5f, 0.8f, new Vector3(0f, 1.3f, 2.52f), this.Game),
                    new Rectangle3D(1, 3, new Vector3(1f, 0, 2.52f), this.Game),
                    new Rectangle3D(1f, 1.5f, new Vector3(-0.8f, -0.6f, 2.52f), this.Game));

               r_PeLetter = new Composite3D(
                    this.Game,
                    1,
                    new Rectangle3D(2.5f, 0.8f, new Vector3(0f, 1.3f, 2.52f), this.Game),
                    new Rectangle3D(1, 3, new Vector3(1, 0.2f, 2.52f), this.Game),
                    new Rectangle3D(3f, 0.8f, new Vector3(0, -1.3f, 2.52f), this.Game),
                    new Rectangle3D(1f, 1.5f, new Vector3(-1f, -0.6f, 2.52f), this.Game),
                    new Rectangle3D(1.5f, 0.7f, new Vector3(-0.7f, 0f, 2.52f), this.Game));

               AddComponent(Base);
               AddComponent(Holder);
               AddComponent(Body);
               AddComponent(r_NunLetter);
               AddComponent(r_GimelLetter);
               AddComponent(r_HeLetter);
               AddComponent(r_PeLetter);
          }

          public override void Initialize()
          {
               this.TriangleDrawType = PrimitiveType.TriangleList;
               (this.Body as ColorBox).IsMultipleColorBox = true;

               this.Holder.ModelCenter = r_HolderModelCenter;
               this.Holder.Color = Color.Yellow;
               this.Holder.Depth = this.Holder.Width = 1;
               this.Holder.Height = 4;

               this.Base.ModelCenter = new Vector3(0, 2.5f, 0);
               this.Base.IsYFlip = true;
               this.Base.Color = Color.Gray;

               r_GimelLetter.Rotations = new Vector3(0, MathHelper.PiOver2, 0);
               r_HeLetter.Rotations = new Vector3(0, MathHelper.Pi, 0);
               r_PeLetter.Rotations = new Vector3(0, MathHelper.ToRadians(270), 0);

               base.Initialize();
          }
     }
}
