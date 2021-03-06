﻿using Microsoft.Xna.Framework;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class Box : Object3D
     {
          private const int k_InitialDimension = 5;

          public Box(Game i_Game, int i_CallOrder)
               : base(i_Game, i_CallOrder)
          {
               Width = Height = Depth = k_InitialDimension;
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
