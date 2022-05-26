using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Sprites;
using Microsoft.Xna.Framework.Input;
using MonoGame.Managers;

namespace MonoGame.States
{
  public class GameState : State
  {
    private EnemyManager _enemyManager;
    private SpriteFont _font;
    private List<Player> _players;
    private ScoreManager _scoreManager;
    private List<Sprite> _sprites;
    public int PlayerCount;

    public GameState(Game1 game, ContentManager content)
      : base(game, content)
    {
    }

    public override void LoadContent()
    {
      var playerTexture = _content.Load<Texture2D>("Ships/Player");
      var bulletTexture = _content.Load<Texture2D>("Bullet");
      _font = _content.Load<SpriteFont>("Font");
      _scoreManager = ScoreManager.Load();
      _sprites = new List<Sprite>()
      {
        new Sprite(_content.Load<Texture2D>("Background/background"))
        {
          Layer = 0.0f,
          Position = new Vector2(Game1.HD_Width / 2, Game1.HD_Height / 2),
        }
      };
      var bulletPrefab = new Bullet(bulletTexture)
      {
        Explosion = new Explosion(new Dictionary<string, Models.Animation>()
            {
              { "Explode", new Models.Animation(_content.Load<Texture2D>("Explosion"), 3) { FrameSpeed = 0.1f, } }
            })
        {
          Layer = 0.5f,
        }
      };

      if (PlayerCount >= 1)
      {
        _sprites.Add(new Player(playerTexture)
        {
          Position = new Vector2(100, 500),
          Layer = 0.3f,
          Bullet = bulletPrefab,
          Input = new Models.Input()
          {
            Up = Keys.W,
            Down = Keys.S,
            Left = Keys.A,
            Right = Keys.D,
            Shoot = Keys.Space,
          },
          Health = 10,
          Score = new Models.Score()
          {
            PlayerName = "Player",
            Value = 0,
          },
        });
      }
      _players = _sprites.Where(c => c is Player).Select(c => (Player)c).ToList();
      _enemyManager = new EnemyManager(_content)
      {
        Bullet = bulletPrefab,
      };
    }

    public override void Update(GameTime gameTime)
    {
      if (Keyboard.GetState().IsKeyDown(Keys.Escape))
        _game.ChangeState(new MenuState(_game, _content));
      foreach (var sprite in _sprites)
        sprite.Update(gameTime);
      _enemyManager.Update(gameTime);
      if (_enemyManager.CanAdd && _sprites.Where(c => c is Enemy).Count() < _enemyManager.MaxEnemies)
      {
        _sprites.Add(_enemyManager.GetEnemy());
      }
    }

    public override void PostUpdate(GameTime gameTime)
    {
      var collidableSprites = _sprites.Where(c => c is ICollidable);
      foreach (var spriteA in collidableSprites)
      {
        foreach (var spriteB in collidableSprites)
        {
          if (spriteA == spriteB)
            continue;
          if (!spriteA.CollisionArea.Intersects(spriteB.CollisionArea))
            continue;
          if (spriteA.Intersects(spriteB))
            ((ICollidable)spriteA).OnCollide(spriteB);
        }
      }

      int spriteCount = _sprites.Count;
      for (int i = 0; i < spriteCount; i++)
      {
        var sprite = _sprites[i];
        foreach (var child in sprite.Children)
          _sprites.Add(child);
        sprite.Children = new List<Sprite>();
      }
      for (int i = 0; i < _sprites.Count; i++)
      {
        if (_sprites[i].IsRemoved)
        {
          _sprites.RemoveAt(i);
          i--;
        }
      }
      if (_players.All(c => c.IsDead))
      {
        foreach (var player in _players)
         _scoreManager.Add(player.Score);
         ScoreManager.Save(_scoreManager);
        _game.ChangeState(new HighscoresState(_game, _content));
      }
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Begin(SpriteSortMode.FrontToBack);
      foreach (var sprite in _sprites)
      sprite.Draw(gameTime, spriteBatch);
      spriteBatch.End();
      spriteBatch.Begin();
      float x = 10f;
      foreach (var player in _players)
      {
        spriteBatch.DrawString(_font, "Health: " + player.Health, new Vector2(x, 10f), Color.White);
        spriteBatch.DrawString(_font, "Score: " + player.Score.Value, new Vector2(x, 30f), Color.White);
        x += 150;
      }
      spriteBatch.End();
    }
  }
}
