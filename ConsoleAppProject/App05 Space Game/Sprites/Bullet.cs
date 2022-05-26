using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame.Sprites
{
  public class Bullet : Sprite, ICollidable
  {
    private float _timer;
    public Explosion Explosion;
    public float LifeSpan { get; set; }
    public Vector2 Velocity { get; set; }
    public Bullet(Texture2D texture)
      : base(texture)
    {
    }

    public override void Update(GameTime gameTime)
    {
      _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
      if (_timer >= LifeSpan)
        IsRemoved = true;
      Position += Velocity;
    }

    public void OnCollide(Sprite sprite)
    {
      if (sprite is Bullet)
        return;
      if (sprite is Enemy && this.Parent is Enemy)
        return;
      if (sprite is Player && this.Parent is Player)
        return;
      if (sprite is Player && ((Player)sprite).IsDead)
        return;
      if (sprite is Enemy && this.Parent is Player)
      {
        IsRemoved = true;
        AddExplosion();
      }
      if(sprite is Player && this.Parent is Enemy)
      {
        IsRemoved = true;
        AddExplosion();
      }
    }

    private void AddExplosion()
    {
      if (Explosion == null)
      return;
      var explosion = Explosion.Clone() as Explosion;
      explosion.Position = this.Position;
      Children.Add(explosion);
    }
  }
}
