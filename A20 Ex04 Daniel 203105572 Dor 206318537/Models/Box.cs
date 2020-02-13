using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class Box : Object3D
     {
          public Box(Game i_Game, int i_CallOrder)
               : base(i_Game, i_CallOrder)
          {
               Width = Height = Depth = 5;
          }

          public Box(Game i_Game)
               : this(i_Game, int.MaxValue)
          {
          }

          public float Width { get; set; }

          public float Height { get; set; }

          public float Depth { get; set; }
     }
}
