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
          private const int k_TriangleListSize = 24;
          private const int k_NumOfVerticesSideFaces = 10;
          private const int k_NumOfVerticesInFace = 4;
          private readonly List<VertexPositionColor> r_TriangleListVertices;
          private readonly List<VertexPositionColor> r_TriangleStripVertices;
          private readonly List<VertexPositionColor> r_TriangleStripTopFace;
          private readonly List<VertexPositionColor> r_TriangleStripBottomFace;
          private const int k_TrianglesCount = 12;

          //We model the Box around the (0,0,0)
          public Box(float i_Width, float i_Height, float i_Depth, Game i_Game)
               : base(i_Game)
          {
               r_TriangleListVertices = new List<VertexPositionColor>(k_TriangleListSize);
               r_TriangleStripVertices = new List<VertexPositionColor>(k_NumOfVerticesSideFaces);
               r_TriangleStripTopFace = new List<VertexPositionColor>(k_NumOfVerticesInFace);
               r_TriangleStripBottomFace = new List<VertexPositionColor>(k_NumOfVerticesInFace);

               initSideFaces(i_Width, i_Height, i_Depth);
               initTopFace();
               initBottomFace();
               initTriangleListVertices();
          }

          private void initTriangleListVertices()
          {
               generateTrianglesFromVertices(r_TriangleStripVertices);
               generateTrianglesFromVertices(r_TriangleStripTopFace);
               generateTrianglesFromVertices(r_TriangleStripBottomFace);
          }

          private void generateTrianglesFromVertices(List<VertexPositionColor> i_Vertices)
          {
               for (int i = 0; i < i_Vertices.Count - 2; i++)
               {
                    Color currentColor = chooseColor(i);

                    if (i % 2 == 0)
                    {
                         r_TriangleListVertices.Add(new VertexPositionColor(r_TriangleStripVertices[i].Position, currentColor));
                         r_TriangleListVertices.Add(new VertexPositionColor(r_TriangleStripVertices[i + 1].Position, currentColor));
                    }
                    else
                    {
                         r_TriangleListVertices.Add(new VertexPositionColor(r_TriangleStripVertices[i + 1].Position, currentColor));
                         r_TriangleListVertices.Add(new VertexPositionColor(r_TriangleStripVertices[i].Position, currentColor));
                    }

                    r_TriangleListVertices.Add(new VertexPositionColor(r_TriangleStripVertices[i + 2].Position, currentColor));
               }
          }

          private Color chooseColor(int i_Index)
          {
               Color currentColor;

               if (i_Index == 2 || i_Index == 3)
               {
                    currentColor = LeftFaceColor;
               }
               else if (i_Index == 4 || i_Index == 5)
               {
                    currentColor = FrontFaceColor;
               }
               else if (i_Index == 6 || i_Index == 7)
               {
                    currentColor = RightFaceColor;
               }
               else
               {
                    currentColor = BackFaceColor;
               }

               return currentColor;
          }

          private void initBottomFace()
          {
               r_TriangleStripVertices.Add(r_TriangleStripVertices[6]);
               r_TriangleStripVertices.Add(r_TriangleStripVertices[0]);
               r_TriangleStripVertices.Add(r_TriangleStripVertices[4]);
               r_TriangleStripVertices.Add(r_TriangleStripVertices[2]);
          }

          private void initTopFace()
          {
               r_TriangleStripVertices.Add(r_TriangleStripVertices[1]);
               r_TriangleStripVertices.Add(r_TriangleStripVertices[7]);
               r_TriangleStripVertices.Add(r_TriangleStripVertices[3]);
               r_TriangleStripVertices.Add(r_TriangleStripVertices[5]);
          }

          private void initSideFaces(float i_Width, float i_Height, float i_Depth)
          {
               float distanceX = i_Width / 2;
               float distanceY = i_Height / 2;
               float distanceZ = i_Depth / 2;

               r_TriangleStripVertices.Add(new VertexPositionColor(new Vector3(-distanceX, -distanceY, distanceZ), LeftFaceColor));
               r_TriangleStripVertices.Add(new VertexPositionColor(new Vector3(-distanceX, distanceY, distanceZ), LeftFaceColor));
               r_TriangleStripVertices.Add(new VertexPositionColor(new Vector3(distanceX, -distanceY, distanceZ), FrontFaceColor));
               r_TriangleStripVertices.Add(new VertexPositionColor(new Vector3(distanceX, distanceY, distanceZ), FrontFaceColor));
               r_TriangleStripVertices.Add(new VertexPositionColor(new Vector3(distanceX, -distanceY, -distanceZ), RightFaceColor));
               r_TriangleStripVertices.Add(new VertexPositionColor(new Vector3(distanceX, distanceY, -distanceZ), RightFaceColor));
               r_TriangleStripVertices.Add(new VertexPositionColor(new Vector3(-distanceX, -distanceY, -distanceZ), BackFaceColor));
               r_TriangleStripVertices.Add(new VertexPositionColor(new Vector3(-distanceX, distanceY, -distanceZ), BackFaceColor));
               r_TriangleStripVertices.Add(r_TriangleStripVertices[0]);
               r_TriangleStripVertices.Add(r_TriangleStripVertices[1]);
          }

          public Color FrontFaceColor { get; set; } = Color.Red;

          public Color RightFaceColor { get; set; } = Color.Blue;

          public Color BackFaceColor { get; set; } = Color.Yellow;

          public Color LeftFaceColor { get; set; } = Color.Green;

          public Color TopFaceColor { get; set; } = Color.Green;

          public Color BottomFaceColor { get; set; } = Color.Green;

          public PrimitiveType TriangleDrawType { get; set;}

          protected override void OnEffectPassDraw(EffectPass i_Pass, GameTime i_GameTime)
          {
               if (TriangleDrawType == PrimitiveType.TriangleList)
               {
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                             TriangleDrawType, r_TriangleListVertices.ToArray(), 0, k_TrianglesCount);
               }
          }

          protected override void InitBounds()
          {
          }
     }
}