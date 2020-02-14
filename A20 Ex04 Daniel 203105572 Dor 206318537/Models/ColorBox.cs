using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class ColorBox : Box
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
          private const int k_TrianglesCountInListPrimitiveType               = 12;
          private List<VertexPositionColor> m_TListVertices;
          private List<VertexPositionColor> m_TStripVertices;
          private List<VertexPositionColor> m_TStripVerticesMulColor;
          private bool m_IsMultipleColorBox;
          private bool m_IsMulColorBoxInitialzied;
          private VertexBuffer m_VertexBuffer;
          private List<short> m_Indices;
          private IndexBuffer m_IndexBuffer;

          public ColorBox(Game i_Game, int i_CallOrder)
               : base(i_Game, i_CallOrder)
          {
          }

          public ColorBox(Game i_Game)
               : this(i_Game, int.MaxValue)
          {
          }

          private void genTListVerticesFromTStripVertices(int i_StartIndex, int i_EndIndex)
          {
               if(m_TListVertices == null)
               {
                    m_TListVertices = new List<VertexPositionColor>(k_TListSize);
               }

               for (int i = i_StartIndex; i <= i_EndIndex; i++)
               {
                    Color currentColor = IsMultipleColorBox ? chooseColor(i) : Color;

                    if (i % 2 == 0)
                    {
                         m_TListVertices.Add(new VertexPositionColor(m_TStripVertices[i].Position, currentColor));
                         m_TListVertices.Add(new VertexPositionColor(m_TStripVertices[i + 1].Position, currentColor));
                    }
                    else
                    {
                         m_TListVertices.Add(new VertexPositionColor(m_TStripVertices[i + 1].Position, currentColor));
                         m_TListVertices.Add(new VertexPositionColor(m_TStripVertices[i].Position, currentColor));
                    }

                    m_TListVertices.Add(new VertexPositionColor(m_TStripVertices[i + 2].Position, currentColor));
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
               m_TStripVertices.Add(m_TStripVertices[6]);
               m_TStripVertices.Add(m_TStripVertices[0]);
               m_TStripVertices.Add(m_TStripVertices[4]);
               m_TStripVertices.Add(m_TStripVertices[2]);
          }

          private void initOneColorBoxTopFace()
          {
               m_TStripVertices.Add(m_TStripVertices[1]);
               m_TStripVertices.Add(m_TStripVertices[7]);
               m_TStripVertices.Add(m_TStripVertices[3]);
               m_TStripVertices.Add(m_TStripVertices[5]);
          }

          private void initOneColorTStripVertices()
          {
               float distanceFromX = Width / 2;
               float distanceFromY = Height / 2;
               float distanceFromZ = Depth / 2;

               if (m_TStripVertices == null)
               {
                    m_TStripVertices = new List<VertexPositionColor>(k_TListSize);
               }

               initOneColorBoxSideFacesVertices(distanceFromX, distanceFromY, distanceFromZ);
               initOneColorBoxTopFace();
               initOneColorBoxBottomFace();
          }

          private void initOneColorBoxSideFacesVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               m_TStripVertices.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), Color));
               m_TStripVertices.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), Color));
               m_TStripVertices.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), Color));
               m_TStripVertices.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), Color));
               m_TStripVertices.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), Color));
               m_TStripVertices.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), Color));
               m_TStripVertices.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), Color));
               m_TStripVertices.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), Color));
               m_TStripVertices.Add(m_TStripVertices[0]);
               m_TStripVertices.Add(m_TStripVertices[1]);
          }

          private void initMulColorBoxTStripVertices()
          {
               float distanceX = Width / 2;
               float distanceY = Height / 2;
               float distanceZ = Depth / 2;

               if (m_TStripVerticesMulColor == null)
               {
                    m_TStripVerticesMulColor = new List<VertexPositionColor>(k_TStripVerticesMulColorCount);
               }

               addFrontVertices(distanceX, distanceY, distanceZ);
               addRightVertices(distanceX, distanceY, distanceZ);
               addBackVertices(distanceX, distanceY, distanceZ);
               addLeftVertices(distanceX, distanceY, distanceZ);
               addTopVertices();
               addBottomVertices();
          }

          private void addFrontVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               m_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), FrontFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), FrontFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), FrontFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), FrontFaceColor));
          }

          private void addRightVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[2].Position, RightFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[3].Position, RightFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), RightFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), RightFaceColor));
          }

          private void addBackVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[6].Position, BackFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[7].Position, BackFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), BackFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), BackFaceColor));
          }

          private void addLeftVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[10].Position, LeftFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[11].Position, LeftFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), LeftFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(new Vector3(-i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), LeftFaceColor));
          }

          private void addTopVertices()
          {
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[0].Position, TopFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[10].Position, TopFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[2].Position, TopFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[6].Position, TopFaceColor));
          }

          private void addBottomVertices()
          {
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[1].Position, BottomFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[11].Position, BottomFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[3].Position, BottomFaceColor));
               m_TStripVerticesMulColor.Add(new VertexPositionColor(m_TStripVerticesMulColor[7].Position, BottomFaceColor));
          }

          public Color FrontFaceColor { get; set; } = Color.Yellow;

          public Color RightFaceColor { get; set; } = Color.Green;

          public Color BackFaceColor { get; set; } = Color.Red;

          public Color LeftFaceColor { get; set; } = Color.Blue;

          public Color TopFaceColor { get; set; } = Color.Gray;

          public Color BottomFaceColor { get; set; } = Color.Gray;

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

          public override void Initialize()
          {
               if(UseVertexAndIndexBuffer)
               {
                    initOneColorTStripVertices();
                    initVertexAndIndexBuffer();
               }
               else if (TriangleDrawType == PrimitiveType.TriangleList)
               {
                    if (m_TStripVertices == null || m_TStripVertices.Count == 0)
                    {
                         initOneColorTStripVertices();
                    }

                    genTListVerticesFromTStripVertices(k_SideFacesStartIndex, k_SideFacesEndIndex);
                    genTListVerticesFromTStripVertices(k_TopFaceStartIndex, k_TopFaceEndIndex);
                    genTListVerticesFromTStripVertices(k_BottomFaceStartIndex, k_BottomFaceEndIndex);
               }

               if((m_TListVertices == null ||m_TListVertices.Count == 0)
                    && (m_TStripVerticesMulColor == null || m_TStripVerticesMulColor.Count == 0 )
                    && (m_TStripVertices == null || m_TStripVertices.Count == 0))
               {
                    initOneColorTStripVertices();
               }

               base.Initialize();
          }

          protected override void OnEffectPassDraw(EffectPass i_Pass, GameTime i_GameTime)
          {
               if (IsMultipleColorBox)
               {
                    drawMulColorBox();
               }
               else
               {
                    drawOneColorBox();
               }
          }

          private void drawMulColorBox()
          {
               if (TriangleDrawType == PrimitiveType.TriangleList)
               {
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                         TriangleDrawType, m_TListVertices.ToArray(), 0, k_SideFacesTrainglesCount + (2 * k_TopAndBottomTrainglesCount));
               }
               else if (TriangleDrawType == PrimitiveType.TriangleStrip)
               {
                    for (int i = 0; i < k_FacesInCube; i++)
                    {
                         this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                              TriangleDrawType, m_TStripVerticesMulColor.ToArray(), i * k_VerticesInOneFace, k_TrianglesInOneFace);
                    }
               }
          }

          public bool UseVertexAndIndexBuffer { get; set; }

          private void initVertexAndIndexBuffer()
          {
               m_Indices = new List<short>()
               {
                    0, 1, 2, 2, 1, 3, // front
                    2, 3, 4, 4, 3, 5, // left
                    4, 5, 6, 6, 5, 7, // back
                    6, 7, 0, 0, 7, 1, // right
                    1, 7, 2, 2, 7, 5, // top
                    6, 0, 4, 4, 0, 2  // bottom
               };

               m_VertexBuffer = new VertexBuffer(
                   this.GraphicsDevice,
                   typeof(VertexPositionColor),
                   m_TStripVertices.Count,
                   BufferUsage.WriteOnly);

               m_VertexBuffer.SetData<VertexPositionColor>(m_TStripVertices.ToArray(), 0, m_TStripVertices.Count);

               m_IndexBuffer = new IndexBuffer(
                   this.GraphicsDevice,
                   typeof(short),
                   m_Indices.Count,
                   BufferUsage.WriteOnly);

               m_IndexBuffer.SetData(m_Indices.ToArray());
          }

          private void drawWithVertexAndIndexBuffer()
          {
               this.GraphicsDevice.Indices = m_IndexBuffer;
               this.GraphicsDevice.SetVertexBuffer(m_VertexBuffer);

               this.GraphicsDevice.DrawIndexedPrimitives(
                   PrimitiveType.TriangleList,
                   0, // baseVertex
                   0, // minVertexIdx
                   m_VertexBuffer.VertexCount, // num of vertices
                   0,  // startIdx in the vertexBuffer
                   k_TrianglesCountInListPrimitiveType); // num of primitives 
          }

          private void drawOneColorBox()
          {
               if (UseVertexAndIndexBuffer)
               {
                    drawWithVertexAndIndexBuffer();
               }
               else if (TriangleDrawType == PrimitiveType.TriangleList)
               {
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                         TriangleDrawType, m_TListVertices.ToArray(), 0, k_SideFacesTrainglesCount + (2 * k_TopAndBottomTrainglesCount));
               }
               else if (TriangleDrawType == PrimitiveType.TriangleStrip)
               {
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                         TriangleDrawType, m_TStripVertices.ToArray(), k_SideFacesStartIndex, k_SideFacesTrainglesCount);
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                         TriangleDrawType, m_TStripVertices.ToArray(), k_TopFaceStartIndex, k_TopAndBottomTrainglesCount);
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                         TriangleDrawType, m_TStripVertices.ToArray(), k_BottomFaceStartIndex, k_TopAndBottomTrainglesCount);
               }
          }
     }
}