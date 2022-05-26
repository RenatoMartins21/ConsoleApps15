using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using MonoGame.Sprites;
using MonoGame.States;

namespace MonoGame
{
  public class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    public static Random Random;
    public static int HD_Width = 1280;
    public static int HD_Height = 720;
    private State _currentState;
    private State _nextState;
    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
      Random = new Random();
      graphics.PreferredBackBufferWidth = HD_Width;
      graphics.PreferredBackBufferHeight = HD_Height;
      graphics.ApplyChanges();
      IsMouseVisible = true;
      base.Initialize();
    }

    protected override void LoadContent()
    {
      spriteBatch = new SpriteBatch(GraphicsDevice);
      _currentState = new MenuState(this, Content);
      _currentState.LoadContent();
      _nextState = null;
    }
    protected override void UnloadContent()
    {
    }

    protected override void Update(GameTime gameTime)
    {
      if(_nextState != null)
      {
        _currentState = _nextState;
        _currentState.LoadContent();
        _nextState = null;
      }
      _currentState.Update(gameTime);
      _currentState.PostUpdate(gameTime);
      base.Update(gameTime);
    }

    public void ChangeState(State state)
    {
      _nextState = state;
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(new Color(00, 00, 00));
      _currentState.Draw(gameTime, spriteBatch);
      base.Draw(gameTime);
    }
  }
}
