using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class TextureBox : Object3D
     {
          private const int k_FacesInCube = 6;
          private const int k_VerticesInOneFace = 4;
          private const int k_TrianglesInOneFace = 2;
          private readonly List<VertexPositionTexture> r_TListVertices = new List<VertexPositionTexture>();
          private readonly List<VertexPositionTexture> r_TStripVertices = new List<VertexPositionTexture>();
          private PrimitiveType m_TriangleDrawType;
          private string m_SidesTextureAssetName;
          private SamplerState m_SamplerState = new SamplerState();
          private RasterizerState m_RasterizerState = new RasterizerState();
          private BlendState m_BlendState = new BlendState();

          public TextureBox(Game i_Game, int i_CallOrder, string i_SidesTexture)
               : base(i_Game, i_CallOrder)
          {
               m_SidesTextureAssetName = i_SidesTexture;
          }

          public TextureBox(Game i_Game, string i_SidesTexture)
               : this(i_Game, int.MaxValue, i_SidesTexture)
          {
          }

          public float Width { get; set; } = 5;

          public float Height { get; set; } = 5;

          public float Depth { get; set; } = 5;

          public Texture2D SidesTexture { get; set; }

          public Texture2D TopTexture { get; set; }

          public Texture2D BottomTexture { get; set; }

          protected override void LoadContent()
          {
               SidesTexture = this.Game.Content.Load<Texture2D>(m_SidesTextureAssetName);
               m_SamplerState.AddressU = TextureAddressMode.Wrap;
               m_SamplerState.AddressV = TextureAddressMode.Clamp;
               m_RasterizerState.CullMode = CullMode.CullClockwiseFace;
               m_BlendState.ColorSourceBlend = Blend.SourceAlpha;
               m_BlendState.ColorDestinationBlend = Blend.InverseSourceAlpha;
               this.BasicEffect = new BasicEffect(this.Game.GraphicsDevice);
               this.BasicEffect.VertexColorEnabled = false;
               this.BasicEffect.Texture = this.SidesTexture;
               this.BasicEffect.TextureEnabled = true;
               base.LoadContent();
          }

          public override PrimitiveType TriangleDrawType
          {
               get
               {
                    return m_TriangleDrawType;
               }

               set
               {
                    m_TriangleDrawType = value;

                    if (m_TriangleDrawType == PrimitiveType.TriangleList)
                    {
                         initTListVertices();
                    }
                    else if (m_TriangleDrawType == PrimitiveType.TriangleStrip)
                    {
                         initTStripVertices();
                    }
               }
          }

          public override void Initialize()
          {
               if (r_TListVertices.Count == 0 && r_TStripVertices.Count == 0)
               {
                    initTStripVertices();
               }

               base.Initialize();
          }

          private void initTStripVertices()
          {
               float distanceX = Width / 2;
               float distanceY = Height / 2;
               float distanceZ = Depth / 2;

               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), new Vector2(0, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z),  new Vector2(0, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z),  new Vector2(0.25f, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z),   new Vector2(0.25f, 1)));

               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[2].Position, new Vector2(0.25f, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[3].Position, new Vector2(0.25f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), new Vector2(0.5f, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(distanceX + ModelCenter.X, distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), new Vector2(0.5f, 1)));

               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[6].Position, new Vector2(0.5f, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[7].Position, new Vector2(0.5f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), new Vector2(0.75f, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, -distanceZ + ModelCenter.Z), new Vector2(0.75f, 1)));

               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[10].Position, new Vector2(0.75f, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[11].Position, new Vector2(0.75f, 1)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-distanceX + ModelCenter.X, -distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), new Vector2(1, 0)));
               r_TStripVertices.Add(new VertexPositionTexture(new Vector3(-distanceX + ModelCenter.X, distanceY + ModelCenter.Y, distanceZ + ModelCenter.Z), new Vector2(1, 1)));

               //r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[0].Position,  new Vector2(0, 0)));
               //r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[10].Position, new Vector2(0, 1)));
               //r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[2].Position,  new Vector2(1, 0)));
               //r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[6].Position,  new Vector2(1, 1)));

               //r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[1].Position,  new Vector2(0, 0)));
               //r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[11].Position, new Vector2(0, 1)));
               //r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[3].Position,  new Vector2(1, 0)));
               //r_TStripVertices.Add(new VertexPositionTexture(r_TStripVertices[7].Position,  new Vector2(1, 1)));
          }

          private void initTListVertices()
          {
          }

          protected override void OnEffectPassDraw(EffectPass i_Pass, GameTime i_GameTime)
          {
               this.GraphicsDevice.SamplerStates[0] = m_SamplerState;
               this.GraphicsDevice.RasterizerState = m_RasterizerState;
               this.GraphicsDevice.BlendState = m_BlendState;

               if (TriangleDrawType == PrimitiveType.TriangleStrip)
               {
                    for (int i = 0; i < 4; i++)
                    {
                         this.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(
                              TriangleDrawType, r_TStripVertices.ToArray(), i * k_VerticesInOneFace, 1);
                    }
               }
               else if (TriangleDrawType == PrimitiveType.TriangleList)
               {
                    this.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(
                              TriangleDrawType, r_TListVertices.ToArray(), 0, 6);
               }
          }
     }
}
