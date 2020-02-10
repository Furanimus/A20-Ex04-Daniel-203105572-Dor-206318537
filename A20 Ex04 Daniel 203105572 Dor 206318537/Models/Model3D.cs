using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class Model3D : DrawableGameComponent
     {
          public string AssetName { get; set; }
          private Matrix m_ModelWorldTransform;
          private Matrix[] m_ModelAbsoluteTransforms;

          public Vector3 Position { get; set; }

          protected Model Model { get; set; }

          public Vector3 Velocity { get; set; }

          public Vector3 Rotations { get; set; }

          public Vector3 AngularVelocity { get; set; }

          public Vector3 Scales { get; set; }

          public Matrix CameraView { get; set; }
          
          public Matrix CameraProjection { get; set; }

          public Model3D(Game i_Game) : base(i_Game)
          {
               Scales = Vector3.One;
          }

          protected override void LoadContent()
          {
               // load our model:
               // NOTE: we don't need to manualy load the model's texture(s),
               //  neither we need to include the texure(s) in our project.
               //  we only need to ensure that the textures are in the right place
               //  where the model needs them to be
               Model = Game.Content.Load<Model>(AssetName);

               // hold all the pre-defined world transformations of each of the model's bones:
               m_ModelAbsoluteTransforms = new Matrix[Model.Bones.Count];

               Model.CopyAbsoluteBoneTransformsTo(m_ModelAbsoluteTransforms);
               // NOTE: This copy can happen once if we don't change our model during the game
               //  Changing a model can include:
               //   1. Bone-Animation (i.e. moving the arms of a soldier..)
               //   2. some kind of mutation or distruction (i.e. breaking the tank canon..)
               //  If this is the case, we need to update this matrix array
               //   to hold the current bone transformations
          }

          public override void Update(GameTime gameTime)
          {
               Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
               Rotations += AngularVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

               buildModelWorldMatrix();

               Model.CopyAbsoluteBoneTransformsTo(m_ModelAbsoluteTransforms);
               // NOTE: This copy can happen once if we don't change our model during the game
               //  Changing a model can include:
               //   1. Bone-Animation (i.e. moving the arms of a soldier..)
               //   2. some kind of mutation or distruction (i.e. breaking the tank canon..)
               //  If this is the case, we need to update this matrix array
               //   to hold the current bone transformations

               base.Update(gameTime);
          }

          private void buildModelWorldMatrix()
          {
               m_ModelWorldTransform =
                    Matrix.CreateScale(Scales) *                    // this will shrink the model to half..
                    Matrix.CreateRotationY(Rotations.Y) *           // rotate on Y axis.. (Yow)
                    Matrix.CreateRotationX(Rotations.X) *           // rotate on Z axis.. (Pitch)
                    Matrix.CreateRotationZ(Rotations.Z) *           // rotate on Z axis.. (Roll)
                    Matrix.CreateTranslation(Position);             // move in space..
          }

          public override void Draw(GameTime gameTime)
          {
               foreach (ModelMesh mesh in Model.Meshes)
               {
                    // each mesh can have several effects
                    // that are loaded to the graphics device when the model is loaded:
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                         // each effect needs the 3 transformation matrices in order to draw the mesh 
                         // to the screen properly:
                         // 1. the world matrix defines the position, rotation and scale of the mesh in a 3d space:
                         effect.World =
                              m_ModelAbsoluteTransforms[mesh.ParentBone.Index] *
                              m_ModelWorldTransform;

                         effect.View = CameraView;
                         effect.Projection = CameraProjection;
                         // we don't have a lighting algorithm implemented in a special shader,
                         // so we'll tell the basic effect shader to use it's default lighting implementation:
                         effect.EnableDefaultLighting();
                    }

                    // after setting up the effect parameteres for each of the meshe's effects,
                    // lets tell the mesh to draw itself (it will tell the gc to draw it..)
                    mesh.Draw();
               }

               base.Draw(gameTime);
          }

          public override void Initialize()
          {
               base.Initialize();
          }
     }
}
