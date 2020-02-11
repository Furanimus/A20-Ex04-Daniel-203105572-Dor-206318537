﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace A20_Ex04_Daniel_203105572_Dor_206318537.Components
{
     public abstract class LoadableDrawableComponent : DrawableGameComponent
     {
          public event EventHandler<EventArgs> SizeChanged;

          public event EventHandler<EventArgs> PositionChanged;

          public event EventHandler<EventArgs> Disposed;

          protected string m_AssetName;

          public LoadableDrawableComponent(string i_AssetName, Game i_Game, int i_UpdateOrder, int i_DrawOrder)
               : base(i_Game)
          {
               this.AssetName = i_AssetName;
               this.UpdateOrder = i_UpdateOrder;
               this.DrawOrder = i_DrawOrder;
               this.Game.Components.Add(this);
          }

          public LoadableDrawableComponent(string i_AssetName, Game i_Game, int i_CallsOrder)
              : this(i_AssetName, i_Game, i_CallsOrder, i_CallsOrder)
          {
          }

          public LoadableDrawableComponent(Game i_Game, int i_CallsOrder)
              : this(string.Empty, i_Game, i_CallsOrder, i_CallsOrder)
          {
          }

          public LoadableDrawableComponent(Game i_Game)
               : this(i_Game, int.MaxValue)
          {
          }

          protected virtual void OnDisposed(object sender, EventArgs args)
          {
               if (Disposed != null)
               {
                    Disposed.Invoke(sender, args);
               }
          }

          protected override void Dispose(bool disposing)
          {
               base.Dispose(disposing);
               OnDisposed(this, EventArgs.Empty);
          }

          protected ContentManager ContentManager
          {
               get { return this.Game.Content; }
          }

          protected virtual void OnPositionChanged()
          {
               if (PositionChanged != null)
               {
                    PositionChanged(this, EventArgs.Empty);
               }
          }

          protected virtual void OnSizeChanged()
          {
               if (SizeChanged != null)
               {
                    SizeChanged(this, EventArgs.Empty);
               }
          }

          public string AssetName
          {
               get { return m_AssetName; }
               set { m_AssetName = value; }
          }

          public override void Draw(GameTime gameTime)
          {
               base.Draw(gameTime);
          }
     }
}
