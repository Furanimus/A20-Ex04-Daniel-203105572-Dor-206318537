using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class Box : Object3D
     {
          private const int k_TListSize                                       = 24;
          private const int k_TStripVerticesOneColorCount                     = 18;
          private const int k_TStripVerticesMulColorCount                     = 24;
          private const int k_SideFacesStartIndex                             = 0;
          private const int k_SideFacesEndIndex                               = 7;
          private const int k_TopFaceStartIndex                               = 10;
          private const int k_TopFaceEndIndex                                 = 11;
          private const int k_BottomFaceStartIndex                            = 14;
          private const int k_BottomFaceEndIndex                              = 15;
          private const int k_TopAndBottomTrainglesCount                      = 2;
          private const int k_SideFacesTrainglesCount                         = 8;
          private const int k_VerticesInOneFace                               = 4;
          private const int k_TrianglesInOneFace                              = 2;
          private const int k_FacesInCube                                     = 6;
          private readonly List<VertexPositionColor> r_TStripVerticesMulColor = new List<VertexPositionColor>(k_TStripVerticesMulColorCount);
          private PrimitiveType m_TriangleDrawType                            = PrimitiveType.TriangleStrip;
          private bool m_IsMultipleColorBox;
          private bool m_IsMulColorBoxInitialzied;

          public Box(float i_Width, float i_Height, float i_Depth, Game i_Game, int i_CallOrder)
               : base(i_Game, i_CallOrder)
          {
               Width = i_Width;
               Height = i_Height;
               Depth = i_Depth;
               r_TListVertices.Capacity = k_TListSize;
               r_TStripVertices.Capacity = k_TStripVerticesOneColorCount;
          }

          public Box(float i_Width, float i_Height, float i_Depth, Game i_Game)
               : this(i_Width, i_Height, i_Depth, i_Game, int.MaxValue)
          {
          }


          private void genTListVerticesFromTStripVertices(int i_StartIndex, int i_EndIndex)
          {
               for (int i = i_StartIndex; i <= i_EndIndex; i++)
               {
                    Color currentColor = chooseColor(i);

                    if (i % 2 == 0)
                    {
                         r_TListVertices.Add(new VertexPositionColor(r_TStripVertices[i].Position, currentColor));
                         r_TListVertices.Add(new VertexPositionColor(r_TStripVertices[i + 1].Position, currentColor));
                    }
                    else
                    {
                         r_TListVertices.Add(new VertexPositionColor(r_TStripVertices[i + 1].Position, currentColor));
                         r_TListVertices.Add(new VertexPositionColor(r_TStripVertices[i].Position, currentColor));
                    }

                    r_TListVertices.Add(new VertexPositionColor(r_TStripVertices[i + 2].Position, currentColor));
               }
          }

          private Color chooseColor(int i_Index)
          {
               Color currentColor;

               if(i_Index == 0 || i_Index == 1)
               {
                    currentColor = FrontFaceColor;
               }
               else if (i_Index == 2 || i_Index == 3)
               {
                    currentColor = RightFaceColor;
               }
               else if (i_Index == 4 || i_Index == 5)
               {
                    currentColor = BackFaceColor;
               }
               else if(i_Index == 6 || i_Index == 7)
               {
                    currentColor = LeftFaceColor;
               }
               else if(i_Index == 8 || i_Index == 9)
               {
                    currentColor = LeftFaceColor;
               }
               else if(i_Index == 10 || i_Index == 11)
               {
                    currentColor = TopFaceColor;
               }
               else
               {
                    currentColor = BottomFaceColor;
               }

               return currentColor;
          }

          private void initOneColorBoxBottomFace()
          {
               r_TStripVertices.Add(r_TStripVertices[6]);
               r_TStripVertices.Add(r_TStripVertices[0]);
               r_TStripVertices.Add(r_TStripVertices[4]);
               r_TStripVertices.Add(r_TStripVertices[2]);
          }

          private void initOneColorBoxTopFace()
          {
               r_TStripVertices.Add(r_TStripVertices[1]);
               r_TStripVertices.Add(r_TStripVertices[7]);
               r_TStripVertices.Add(r_TStripVertices[3]);
               r_TStripVertices.Add(r_TStripVertices[5]);
          }

          private void initOneColorTStripVertices()
          {
               float distanceFromX = Width / 2;
               float distanceFromY = Height / 2;
               float distanceFromZ = Depth / 2;

               initOneColorBoxSideFacesVertices(distanceFromX, distanceFromY, distanceFromZ);
               initOneColorBoxTopFace();
               initOneColorBoxBottomFace();
          }

          private void initOneColorBoxSideFacesVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), Color));
               r_TStripVertices.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), Color));
               r_TStripVertices.Add(r_TStripVertices[0]);
               r_TStripVertices.Add(r_TStripVertices[1]);
          }

          private void initMulColorBoxTStripVertices()
          {
               float distanceX = Width / 2;
               float distanceY = Height / 2;
               float distanceZ = Depth / 2;

               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), FrontFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), FrontFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), FrontFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), FrontFaceColor));

               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), RightFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), RightFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), RightFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), RightFaceColor));

               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), BackFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), BackFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), BackFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), BackFaceColor));

               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), LeftFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), LeftFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), LeftFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), LeftFaceColor));

               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), TopFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), TopFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), TopFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), TopFaceColor));

               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), BottomFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), BottomFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), BottomFaceColor));
               r_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), BottomFaceColor));
          }

          public Color FrontFaceColor { get; set; } = Color.Yellow;

          public Color RightFaceColor { get; set; } = Color.Green;

          public Color BackFaceColor { get; set; } = Color.Red;

          public Color LeftFaceColor { get; set; } = Color.Blue;

          public Color TopFaceColor { get; set; } = Color.Gray;

          public Color BottomFaceColor { get; set; } = Color.Gray;

          public float Width { get; set; }
          
          public float Height { get; set; }
          
          public float Depth { get; set; }

          public bool IsMultipleColorBox
          {
               get
               {
                    return m_IsMultipleColorBox;
               }

               set
               {
                    m_IsMultipleColorBox = value;

                    if(!m_IsMulColorBoxInitialzied && m_IsMultipleColorBox)
                    {
                         m_IsMulColorBoxInitialzied = true;
                         initMulColorBoxTStripVertices();
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

                    if(m_TriangleDrawType == PrimitiveType.TriangleList)
                    {
                         if(r_TListVertices.Count == 0)
                         {
                              if(r_TStripVertices.Count == 0)
                              {
                                   initOneColorTStripVertices();
                              }

                              genTListVerticesFromTStripVertices(k_SideFacesStartIndex, k_SideFacesEndIndex);
                              genTListVerticesFromTStripVertices(k_TopFaceStartIndex, k_TopFaceEndIndex);
                              genTListVerticesFromTStripVertices(k_BottomFaceStartIndex, k_BottomFaceEndIndex);
                         }
                    }
               }
          }

          public override void Initialize()
          {
               if(r_TListVertices.Count == 0 && r_TStripVerticesMulColor.Count == 0 && r_TStripVertices.Count == 0)
               {
                    initOneColorTStripVertices();
               }

               base.Initialize();
          }

          protected override void OnEffectPassDraw(EffectPass i_Pass, GameTime i_GameTime)
          {
               if(!IsMultipleColorBox)
               {
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                         TriangleDrawType, r_TStripVertices.ToArray(), k_SideFacesStartIndex, k_SideFacesTrainglesCount);
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                         TriangleDrawType, r_TStripVertices.ToArray(), k_TopFaceStartIndex, k_TopAndBottomTrainglesCount);
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                         TriangleDrawType, r_TStripVertices.ToArray(), k_BottomFaceStartIndex, k_TopAndBottomTrainglesCount);
               }
               else if (TriangleDrawType == PrimitiveType.TriangleList)
               {
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                             TriangleDrawType, r_TListVertices.ToArray(), 0, k_SideFacesTrainglesCount + (2 * k_TopAndBottomTrainglesCount));
               }
               else if (TriangleDrawType == PrimitiveType.TriangleStrip)
               {
                    for(int i = 0; i < k_FacesInCube; i++)
                    {
                         this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                              TriangleDrawType, r_TStripVerticesMulColor.ToArray(), i * k_VerticesInOneFace, k_TrianglesInOneFace);
                    }
               }
          }
     }
}