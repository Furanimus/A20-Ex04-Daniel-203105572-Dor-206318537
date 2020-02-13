using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class Pyramid : Object3D
     {
          protected readonly List<VertexPositionColor> r_TListVertices = new List<VertexPositionColor>();
          protected readonly List<VertexPositionColor> r_TStripVertices = new List<VertexPositionColor>();
          private VertexBuffer m_VertexBuffer;
          private List<short> m_Indices;
          private IndexBuffer m_IndexBuffer;

          public Pyramid (Game i_Game, int i_CallOrder)
               : base(i_Game, i_CallOrder)
          {
               r_TStripVertices.Capacity = 10;
               r_TListVertices.Capacity = 18;

               Width = Height = 5;
               Vertical = 2.5f;
          }

          public Pyramid(Game i_Game) 
               : this(i_Game, int.MaxValue)
          {
          }

          public float Width { get; set; }

          public float Height { get; set; }

          public float Vertical { get; set; }

          public bool UseVertexAndIndexBuffer { get; set; }

          public override void Initialize()
          {
               if (TriangleDrawType == PrimitiveType.TriangleStrip || UseVertexAndIndexBuffer)
               {
                    initTStripVertices();
               }
               else if (TriangleDrawType == PrimitiveType.TriangleList)
               {
                    initTListVertices();
               }

               if (IsYFlip)
               {
                    flipPyramid(1, -1, 1);

                    if (TriangleDrawType == PrimitiveType.TriangleList)
                    {
                         flipPyramid(1, 1, -1);
                    }
               }

               if (UseVertexAndIndexBuffer)
               {
                    initVertexAndIndexBuffer();
               }

               base.Initialize();
          }

          private void initVertexAndIndexBuffer()
          {
               if (!IsYFlip)
               {
                    m_Indices = new List<short>()
                    {
                         0, 1, 2, 
                         2, 1, 3,
                         3, 1, 4, 
                         4, 1, 0,
                         4, 0, 2, 2, 4, 3
                    };
               }
               else
               {
                    m_Indices = new List<short>()
                    {
                         0, 4, 2, 2, 4, 3,
                         1, 0, 2, 
                         1, 2, 3,
                         1, 3, 4,
                         1, 4, 0
                    };
               }

               m_VertexBuffer = new VertexBuffer(
                   this.GraphicsDevice,
                   typeof(VertexPositionColor),
                   r_TStripVertices.Count,
                   BufferUsage.WriteOnly);

               m_VertexBuffer.SetData<VertexPositionColor>(r_TStripVertices.ToArray(), 0, r_TStripVertices.Count);

               m_IndexBuffer = new IndexBuffer(
                   this.GraphicsDevice,
                   typeof(short),
                   m_Indices.Count,
                   BufferUsage.WriteOnly);

               m_IndexBuffer.SetData(m_Indices.ToArray());
          }

          private void initTStripVertices()
          {
               float distanceFromX = Width / 2;
               float distanceFromY = Vertical;
               float distanceFromZ = Height / 2;

               r_TStripVertices.Add(new VertexPositionColor(new Vector3(-distanceFromX + ModelCenter.X, 0 + ModelCenter.Y, distanceFromZ + ModelCenter.Z), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(0 + ModelCenter.X, distanceFromY + ModelCenter.Y, 0 + ModelCenter.Z), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(distanceFromX + ModelCenter.X, 0 + ModelCenter.Y, distanceFromZ + ModelCenter.Z), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(distanceFromX + ModelCenter.X, 0 + ModelCenter.Y, -distanceFromZ + ModelCenter.Z), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(-distanceFromX + ModelCenter.X, 0 + ModelCenter.Y, -distanceFromZ + ModelCenter.Z), Color));
              
               r_TStripVertices.Add(r_TStripVertices[3]);
               r_TStripVertices.Add(r_TStripVertices[1]);
               r_TStripVertices.Add(r_TStripVertices[4]);
               r_TStripVertices.Add(r_TStripVertices[0]);
               r_TStripVertices.Add(r_TStripVertices[2]);
          }

          private void initTListVertices()
          {
               float distanceFromX = Width / 2;
               float distanceFromY = Vertical;
               float distanceFromZ = Height / 2;

               r_TListVertices.Add(new VertexPositionColor(new Vector3(-distanceFromX + ModelCenter.X, 0 + ModelCenter.Y, distanceFromZ + ModelCenter.Z), Color));
               r_TListVertices.Add(new VertexPositionColor(new Vector3(0 + ModelCenter.X, distanceFromY + ModelCenter.Y, 0 + ModelCenter.Z), Color));
               r_TListVertices.Add(new VertexPositionColor(new Vector3(distanceFromX + ModelCenter.X, 0 + ModelCenter.Y, distanceFromZ + ModelCenter.Z), Color));
               r_TListVertices.Add(r_TListVertices[2]);
               r_TListVertices.Add(r_TListVertices[1]);
               r_TListVertices.Add(new VertexPositionColor(new Vector3(distanceFromX + ModelCenter.X, 0 + ModelCenter.Y, -distanceFromZ + ModelCenter.Z), Color));
               r_TListVertices.Add(r_TListVertices[5]);
               r_TListVertices.Add(r_TListVertices[1]);
               r_TListVertices.Add(new VertexPositionColor(new Vector3(-distanceFromX + ModelCenter.X, 0 + ModelCenter.Y, -distanceFromZ + ModelCenter.Z), Color));
               r_TListVertices.Add(r_TListVertices[8]);
               r_TListVertices.Add(r_TListVertices[1]);
               r_TListVertices.Add(r_TListVertices[0]);
               r_TListVertices.Add(r_TListVertices[0]);
               r_TListVertices.Add(r_TListVertices[8]);
               r_TListVertices.Add(r_TListVertices[2]);
               r_TListVertices.Add(r_TListVertices[2]);
               r_TListVertices.Add(r_TListVertices[8]);
               r_TListVertices.Add(r_TListVertices[5]);
          }

          public bool IsYFlip { get; set; }

          private void flipPyramid(float i_X, float i_Y, float i_Z)
          {
               if(r_TListVertices.Count > 0)
               {
                    flipHelper(r_TListVertices, i_X, i_Y, i_Z);
               }
               else if(r_TStripVertices.Count > 0)
               {
                    flipHelper(r_TStripVertices, i_X, i_Y, i_Z);
               }
          }

          private void flipHelper(List<VertexPositionColor> i_ListToFlip, float i_X, float i_Y, float i_Z)
          {
               for(int i = 0; i < i_ListToFlip.Count; i++)
               {
                    Vector3 position = i_ListToFlip[i].Position;

                    i_ListToFlip[i] = new VertexPositionColor(new Vector3(position.X * i_X, position.Y * i_Y, position.Z * i_Z), Color);
               }
          }

          protected override void OnEffectPassDraw(EffectPass i_Pass, GameTime i_GameTime)
          {
               if(UseVertexAndIndexBuffer)
               {
                    this.GraphicsDevice.Indices = m_IndexBuffer;
                    this.GraphicsDevice.SetVertexBuffer(m_VertexBuffer);

                    this.GraphicsDevice.DrawIndexedPrimitives(
                        PrimitiveType.TriangleList,
                        0, // baseVertex
                        0, // minVertexIdx
                        m_VertexBuffer.VertexCount, // num of vertices
                        0,  // startIdx in the vertexBuffer
                        6); // num of primitives 
               }
               else if (TriangleDrawType == PrimitiveType.TriangleStrip)
               {
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                              TriangleDrawType, r_TStripVertices.ToArray(), 0, 3);
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                              TriangleDrawType, r_TStripVertices.ToArray(), 5, 3);
               }
               else if (TriangleDrawType == PrimitiveType.TriangleList)
               {
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                              TriangleDrawType, r_TListVertices.ToArray(), 0, 6);
               }
          }
     }
}
