﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class Rectangle3D : Object3D
     {
          protected readonly List<VertexPositionColor> r_TListVertices = new List<VertexPositionColor>();
          protected readonly List<VertexPositionColor> r_TStripVertices = new List<VertexPositionColor>();
          private const int k_TListCapacity = 6;
          private const int k_TStripCapacity = 4;
          private PrimitiveType m_TriangleDrawType;
          private bool m_IsDrawTypeSet;

          public Rectangle3D(float i_Width, float i_Height, Vector3 i_ModelCenter, Game i_Game, int i_CallOrder) 
               : base(i_Game, i_CallOrder)
          {
               ModelCenter = i_ModelCenter;
               Width = i_Width;
               Height = i_Height;
               r_TListVertices.Capacity = k_TListCapacity;
               r_TStripVertices.Capacity = k_TStripCapacity;
          }

          public Rectangle3D(float i_Width, float i_Height, Vector3 i_ModelCenter, Game i_Game) 
               : this(i_Width, i_Height, i_ModelCenter, i_Game, int.MaxValue)
          {
          }

          public float Width { get; set; }

          public float Height { get; set; }

          private void initTStripVertices()
          {
               float distanceX = Width / 2;
               float distanceY = Height / 2;
               float distanceZ = ModelCenter.Z;

               r_TStripVertices.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ), Color));
          }

          public override void Initialize()
          {
               if(!m_IsDrawTypeSet || (m_IsDrawTypeSet && m_TriangleDrawType == PrimitiveType.TriangleStrip))
               {
                    TriangleDrawType = PrimitiveType.TriangleStrip;
                    initTStripVertices();
               }
               else if(m_TriangleDrawType == PrimitiveType.TriangleList)
               {
                    initTListVertices();
               }

               base.Initialize();
          }

          private void initTListVertices()
          {
               float distanceX = Width / 2;
               float distanceY = Height / 2;
               float distanceZ = ModelCenter.Z;

               r_TListVertices.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ), Color));
               r_TListVertices.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ), Color));
               r_TListVertices.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ), Color));

               r_TListVertices.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ), Color));
               r_TListVertices.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ), Color));
               r_TListVertices.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ), Color));
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
                    m_IsDrawTypeSet = true;
               }
          }

          protected override void OnEffectPassDraw(EffectPass i_Pass, GameTime i_GameTime)
          {
               if (TriangleDrawType == PrimitiveType.TriangleStrip)
               {
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                              TriangleDrawType, r_TStripVertices.ToArray(), 0, 2);
               }
               else if(TriangleDrawType == PrimitiveType.TriangleList)
               {
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                              TriangleDrawType, r_TListVertices.ToArray(), 0, 2);
               }
          }
     }
}
