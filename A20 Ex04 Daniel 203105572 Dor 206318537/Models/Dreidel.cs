using Microsoft.Xna.Framework;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public abstract class Dreidel : Composite3D
     {
          public Dreidel(Game i_Game)
               : this(i_Game, int.MaxValue)
          {
          }

          public Dreidel(Game i_Game, int i_CallOrder)
               : base(i_Game, i_CallOrder)
          {
               this.Base = new Pyramid(this.Game);
               this.Holder = new ColorBox(this.Game);
               this.Body = new ColorBox(this.Game);
          }

          protected Pyramid Base { get; set; }

          protected ColorBox Holder { get; set; }

          protected Box Body { get; set; }
     }
}
