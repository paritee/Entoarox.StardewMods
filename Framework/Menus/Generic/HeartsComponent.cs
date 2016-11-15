﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using StardewValley;

namespace Entoarox.Framework.Menus
{
    public class HeartsComponent : BaseMenuComponent
    {
        protected static Rectangle HeartFull = new Rectangle(211, 428, 7, 6);
        protected static Rectangle HeartEmpty = new Rectangle(218, 428, 7, 6);
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = Math.Min(Math.Max(0, value), MaxValue);
            }
        }
        protected int _Value;
        protected int MaxValue;
        public HeartsComponent(Point position, int value, int maxValue)
        {
            if (maxValue % 2 != 0)
                maxValue++;
            SetScaledArea(new Rectangle(position.X, position.Y, 8 * (maxValue / 2), HeartEmpty.Height));
            MaxValue = maxValue;
            Value = value;
        }
        public override void Draw(SpriteBatch b, Point o)
        {
            if (!Visible)
                return;
            for (int c = 0; c < MaxValue / 2; c++)
                b.Draw(Game1.mouseCursors, new Vector2(o.X + Area.X + Game1.pixelZoom + c * 8 * Game1.pixelZoom, o.Y + Area.Y), new Rectangle(HeartEmpty.X, HeartEmpty.Y, 7, 6), Color.White, 0, Vector2.Zero, Game1.pixelZoom, SpriteEffects.None, 1f);
            for (int c = 0; c < Value; c++)
                b.Draw(Game1.mouseCursors, new Vector2(o.X + Area.X + Game1.pixelZoom + c * 4 * Game1.pixelZoom, o.Y + Area.Y), new Rectangle(HeartFull.X + (c % 2 == 0 ? 0 : 4), HeartFull.Y, (c % 2 == 0 ? 4 : 3), 6), Color.White, 0, Vector2.Zero, Game1.pixelZoom, SpriteEffects.None, 1f);
        }
    }
}