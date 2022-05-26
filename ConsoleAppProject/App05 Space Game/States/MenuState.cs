using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Sprites;
using MonoGame.Controls;

namespace MonoGame.States
{
  public class MenuState : State
  {
    private List<Component> _components;
    private SpriteFont _font;

    public MenuState(Game1 game, ContentManager content)
      : base(game, content)
    {
    }

    public override void LoadContent()
    {
      _font = _content.Load<SpriteFont>("FontMain");
      var buttonTexture = _content.Load<Texture2D>("Button");
      var buttonFont = _content.Load<SpriteFont>("Font");
      
      _components = new List<Component>()
      {
        new Sprite(_content.Load<Texture2D>("Background/background"))
        {
          Layer = 0f,
          Position = new Vector2(Game1.HD_Width / 2, Game1.HD_Height / 2),
        },
        new Button(buttonTexture, buttonFont)
        {
          Text = "Play",
          Position = new Vector2(Game1.HD_Width / 2, 440),
          Click = new EventHandler(Button_1Player_Clicked),
          Layer = 0.1f
        },
        new Button(buttonTexture, buttonFont)
        {
          Text = "Highscores",
          Position = new Vector2(Game1.HD_Width / 2, 480),
          Click = new EventHandler(Button_Highscores_Clicked),
          Layer = 0.1f
        },
        new Button(buttonTexture, buttonFont)
        {
          Text = "Exit Game",
          Position = new Vector2(Game1.HD_Width / 2, 520),
          Click = new EventHandler(Button_Quit_Clicked),
          Layer = 0.1f
        },
      };
    }

    private void Button_1Player_Clicked(object sender, EventArgs args)
    {
      _game.ChangeState(new GameState(_game, _content)
      {
        PlayerCount = 1,
      });
    }

    private void Button_Highscores_Clicked(object sender, EventArgs args)
    {
      _game.ChangeState(new HighscoresState(_game, _content));
    }

    private void Button_Quit_Clicked(object sender, EventArgs args)
    {
      _game.Exit();
    }

    public override void Update(GameTime gameTime)
    {
      foreach (var component in _components)
        component.Update(gameTime);
    }

    public override void PostUpdate(GameTime gameTime)
    {
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Begin(SpriteSortMode.FrontToBack);
      foreach (var component in _components)
      component.Draw(gameTime, spriteBatch);
      spriteBatch.End();
      spriteBatch.Begin(SpriteSortMode.FrontToBack);
      spriteBatch.DrawString(_font, "APP05: SPACE GAME", new Vector2(300, 250), Color.White);
      spriteBatch.End();
        }
  }
}
