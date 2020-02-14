using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class BufferAndIndexDreidel : Dreidel
     {
          private const string k_AssetName = @"Sprites\NGHP";
          private readonly Vector3 r_ModelCenter = new Vector3(0, 2.5f, 0);

          public BufferAndIndexDreidel(Game i_Game)
               : this(i_Game, int.MaxValue)
          {
          }

          public BufferAndIndexDreidel(Game i_Game, int i_CallOrder)
               : base(i_Game, i_CallOrder)
          {
               this.Body = new TextureBox(this.Game, k_AssetName);
               AddComponent(Base);
               AddComponent(Holder);
               AddComponent(Body);
          }

          public override void Initialize()
          {
               this.Base.ModelCenter = r_ModelCenter;
               this.Base.IsYFlip = true;
               this.Base.Color = Color.Gray;
               this.Base.UseVertexAndIndexBuffer = true;

               this.TriangleDrawType = PrimitiveType.TriangleList;

               (this.Body as TextureBox).UseVertexAndIndexBuffer = true;

               this.Holder.UseVertexAndIndexBuffer = true;
               this.Holder.ModelCenter = r_ModelCenter;
               this.Holder.Color = Color.Red;
               this.Holder.Depth = this.Holder.Width = 1;
               this.Holder.Height = 4;

               base.Initialize();
          }
     }
}
