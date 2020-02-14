using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class TextureBox : Box
     {
          private const int k_FacesInCube = 6;
          private const int k_VerticesInOneFace = 4;
          private const int k_TrianglesInOneFace = 2;
          private const int k_TrianglesCountInListPrimitiveType = 12;
          private readonly List<VertexPositionTexture> r_TListVertices = new List<VertexPositionTexture>();
          private readonly List<VertexPositionTexture> r_TStripVertices = new List<VertexPositionTexture>();
          private string m_SidesTextureAssetName;
          private VertexBuffer m_VertexBuffer;
          private List<short> m_Indices;
          private IndexBuffer m_IndexBuffer;

          public TextureBox(Game i_Game, int i_CallOrder, string i_SidesTexture)
               : base(i_Game, i_CallOrder)
          {
               m_SidesTextureAssetName = i_SidesTexture;
               Width = Height = Depth = 5;
          }

          public TextureBox(Game i_Game, string i_SidesTexture)
               : this(i_Game, int.MaxValue, i_SidesTexture)
          {
          }

          public Texture2D SidesTexture { get; set; }

          public Texture2D TopTexture { get; set; }

          public Texture2D BottomTexture { get; set; }

          public override void Initialize()
          {
               base.Initialize();

               if (UseVertexAndIndexBuffer)
               {
                    initTStripVertices();
                    initVertexAndIndexBuffer();
               }

               if (r_TListVertices.Count == 0 && r_TStripVertices.Count == 0)
               {
                    initTStripVertices();
               }
          }

          public bool UseVertexAndIndexBuffer { get; set; }

          private void initVertexAndIndexBuffer()
          {
               m_Indices = new List<short>()
               {
                     0,  1,  2,  2,  1,  3, // front
                     4,  5,  6,  6,  5,  7, // left
                     8,  9, 10, 10,  9, 11, // back
                    12, 13, 14, 14, 13, 15, // right
                    16, 17, 18, 18, 17, 19, // top
                    20, 21, 22, 22, 21, 23  // bottom
               };

               m_VertexBuffer = new VertexBuffer(
                   this.GraphicsDevice,
                   typeof(VertexPositionTexture),
                   r_TStripVertices.Count,
                   BufferUsage.WriteOnly);

               m_VertexBuffer.SetData<VertexPositionTexture>(r_TStripVertices.ToArray(), 0, r_TStripVertices.Count);

               m_IndexBuffer = new IndexBuffer(
                   this.GraphicsDevice,
                   typeof(short),
                   m_Indices.Count,
                   BufferUsage.WriteOnly);

               m_IndexBuffer.SetData(m_Indices.ToArray());
          }

          protected override void LoadContent()
          {
               base.LoadContent();

               SidesTexture = this.Game.Content.Load<Texture2D>(m_SidesTextureAssetName);
               this.BasicEffect = new BasicEffect(this.Game.GraphicsDevice);
               this.BasicEffect.VertexColorEnabled = false;
               this.BasicEffect.Texture = this.SidesTexture;
               this.BasicEffect.TextureEnabled = true;
          }

          private void initTStripVertices()
          {
               float distanceX = Width / 2;
               float distanceY = Height / 2;
               float distanceZ = Depth / 2;

               addFrontVertices(distanceX, distanceY, distanceZ);
               addRightVertices(distanceX, distanceY, distanceZ);
               addBackVertices(distanceX, distanceY, distanceZ);
               addLeftVertices(distanceX, distanceY, distanceZ);
               addTopVertices(distanceX, distanceY, distanceZ);
               addBottomVertices(distanceX, distanceY, distanceZ);
          }

          private void addFrontVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), new Vector2(0, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), new Vector2(0, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), new Vector2(0.20f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), new Vector2(0.20f, 0)));
          }

          private void addRightVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[2].Position, new Vector2(0.20f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[3].Position, new Vector2(0.20f, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), new Vector2(0.4f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), new Vector2(0.4f, 0)));
          }

          private void addBackVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[6].Position, new Vector2(0.4f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[7].Position, new Vector2(0.4f, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), new Vector2(0.60f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, -i_DistanceZ + ModelCenter.Z), new Vector2(0.60f, 0)));
          }

          private void addLeftVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[10].Position, new Vector2(0.60f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[11].Position, new Vector2(0.60f, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-i_DistanceX + ModelCenter.X, -i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), new Vector2(0.8f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-i_DistanceX + ModelCenter.X, i_DistanceY + ModelCenter.Y, i_DistanceZ + ModelCenter.Z), new Vector2(0.8f, 0)));
          }

          private void addTopVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[0].Position, new Vector2(0.8f, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[10].Position, new Vector2(0.8f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[2].Position, new Vector2(1, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[6].Position, new Vector2(1, 1)));
          }

          private void addBottomVertices(float i_DistanceX, float i_DistanceY, float i_DistanceZ)
          {
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[1].Position, new Vector2(0.8f, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[11].Position, new Vector2(0.8f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[3].Position, new Vector2(1, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[7].Position, new Vector2(1, 1)));
          }

          protected override void OnEffectPassDraw(EffectPass i_Pass, GameTime i_GameTime)
          {
               if (UseVertexAndIndexBuffer)
               {
                    drawWithVertexAndIndexBuffer();
               }
               else 
               { 
                    for (int i = 0; i < k_FacesInCube; i++)
                    {
                         this.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(
                              PrimitiveType.TriangleStrip, r_TStripVertices.ToArray(), i * k_VerticesInOneFace, k_TrianglesInOneFace);
                    }
               }
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

          protected override void UnloadContent()
          {
               m_VertexBuffer.Dispose();
               m_IndexBuffer.Dispose();
          }
     }
}
