using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Models
{
     public class Composite3D : Object3D, ICollection
     {
          private readonly List<Object3D> r_Components;

          public Composite3D(Game i_Game)
               : this(i_Game, int.MaxValue, null)
          {
          }

          public Composite3D(Game i_Game, int i_CallOrder)
               : this(i_Game, i_CallOrder, null)
          {
          }

          public Composite3D(Game i_Game, int i_CallOrder, params Object3D[] i_Components)
               : base(i_Game, i_CallOrder)
          {
               r_Components = new List<Object3D>();

               if (i_Components != null)
               {
                    foreach(Rectangle3D Component in i_Components)
                    {
                         AddComponent(Component);
                    }
               }
          }

          public Object3D this[int i_Index]
          {
               get
               {
                    return r_Components[i_Index];
               }
          }

          public override PrimitiveType TriangleDrawType
          {
               get
               {
                    return base.TriangleDrawType;
               }

               set
               {
                    base.TriangleDrawType = value;

                    foreach (Object3D component in r_Components)
                    {
                         component.TriangleDrawType = value;
                    }
               }
          }

          public override Texture2D Texture 
          {
               get
               {
                    return base.Texture;
               }

               set
               {
                    base.Texture = value;

                    foreach (Object3D component in r_Components)
                    {
                         component.Texture = value;
                    }
               }
          }

          public override Vector3 Position
          {
               get
               {
                    return base.Position;
               }

               set
               {
                    base.Position = value;

                    foreach (Object3D component in r_Components)
                    {
                         component.Position = value;
                    }
               }
          }

          public override Vector3 Velocity
          {
               get
               {
                    return base.Velocity;
               }

               set
               {
                    base.Velocity = value;

                    foreach (Object3D component in r_Components)
                    {
                         component.Velocity = value;
                    }
               }
          }

          public override Vector3 Scales
          {
               get
               {
                    return base.Scales;
               }

               set
               {
                    base.Scales = value;

                    foreach (Object3D component in r_Components)
                    {
                         component.Scales = value;
                    }
               }
          }

          public override Matrix CameraView
          {
               get
               {
                    return base.CameraView;
               }

               set
               {
                    base.CameraView = value;

                    foreach (Object3D component in r_Components)
                    {
                         component.CameraView = value;
                    }
               }
          }

          public override Matrix CameraProjection 
          {
               get
               {
                    return base.CameraProjection;
               }

               set
               {
                    base.CameraProjection = value;

                    foreach (Object3D component in r_Components)
                    {
                         component.CameraProjection = value;
                    }
               }
          }

          public override BasicEffect BasicEffect
          {
               get
               {
                    return base.BasicEffect;
               }

               set
               {
                    base.BasicEffect = value;

                    foreach (Object3D component in r_Components)
                    {
                         component.BasicEffect = value;
                    }
               }
          }
         
          public override Vector3 AngularVelocity
          {
               get
               {
                    return base.AngularVelocity;
               }

               set
               {
                    base.AngularVelocity = value;

                    foreach(Object3D component in r_Components)
                    {
                         component.AngularVelocity = value;
                    }
               }
          }

          public override Vector3 Rotations
          {
               get
               {
                    return base.Rotations;
               }
               set
               {
                    base.Rotations = value;

                    foreach (Object3D component in r_Components)
                    {
                         component.Rotations += value;
                    }
               }
          }


          public void AddComponent(Object3D i_Component)
          {
               r_Components.Add(i_Component);
          }

          public override void Initialize()
          {
               foreach(Object3D component in r_Components)
               {
                    component.Initialize();
               }
               
               base.Initialize();
          }

          protected override void OnUpdate(GameTime i_GameTime)
          {
               if(r_Camera.ShouldUpdateViewMatrix)
               {
                    foreach (Object3D component in r_Components)
                    {
                         component.CameraView = r_Camera.ViewMatrix;
                         component.CameraProjection = r_Camera.FieldOfView;
                    }
               }

               foreach (Object3D component in r_Components)
               {
                    component.Update(i_GameTime);
               }
          }

          protected override void OnDraw(GameTime i_GameTime)
          {
               foreach (Object3D component in r_Components)
               {
                    component.Draw(i_GameTime);
               }
          }

          public int Count => r_Components.Count;

          public object SyncRoot => null;

          public bool IsSynchronized => false;


          public void CopyTo(Array i_Array, int i_Index)
          {
               r_Components.CopyTo(i_Array as Object3D[], i_Index);
          }

          public IEnumerator GetEnumerator()
          {
               return r_Components.GetEnumerator();
          }
     }
}
