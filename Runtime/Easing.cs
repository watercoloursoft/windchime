using System;
using UnityEngine;

// From https://github.com/sole/tween.js/blob/master/src/Tween.js

namespace Windchime.Runtime
{
    public enum EasingDirection
    {
        In,
        Out,
        InOut
    }

    public class EasingSet
    {
        public delegate double EasingFunc(double x);
        
        private readonly EasingFunc _in;
        private readonly EasingFunc _out;
        private readonly EasingFunc _inout;

        private static double DefaultFallbackEasing(double x)
        {
            return x;
        }
        
        public EasingSet(EasingFunc none)
        {
            _in = none;
            _out = none;
            _inout = none;
        }

        public EasingSet(EasingFunc inFunc, EasingFunc outFunc, EasingFunc inoutFunc)
        {
            _in = inFunc;
            _out = outFunc;
            _inout = inoutFunc;
        }

        public EasingFunc Get(EasingDirection direction)
        {
            return direction switch
            {
                EasingDirection.In => _in,
                EasingDirection.Out => _out,
                EasingDirection.InOut => _inout,
                _ => DefaultFallbackEasing
            };
        }
    }
    
    // No easy way to check if is a numeric thing
    public class EasingStyle
    {
        public static EasingSet Linear = new((x) => x);
        public static EasingSet Quadratic = new((x) => x * x, x => x * (2 - x), x =>
        {
            if ((x *= 2) < 1) {
                return 0.5 * x * x;
            }
            return - 0.5 * (--x * (x - 2) - 1);
        });

        public static EasingSet Cubic = new(x => x * x * x, x => --x * x * x + 1, x =>
        {
            if ((x *= 2) < 1)
            {
                return 0.5 * x * x * x;
            }

            return 0.5 * ((x -= 2) * x * x * x);
        });

        public static EasingSet Quartic = new(x => x * x * x * x, x => 1 - (--x * x * x * x), x =>
        {
            if ((x *= 2) < 1) {
                return 0.5 * x * x * x * x;
            }

            return - 0.5 * ((x -= 2) * x * x * x - 2);
        });

        public static EasingSet Quintic = new(x => x * x * x * x * x, x => --x * x * x * x * x + 1, x =>
        {
            if ((x *= 2) < 1) {
                return 0.5 * x * x * x * x * x;
            }

            return 0.5 * ((x -= 2) * x * x * x * x + 2);
        });

        public static EasingSet Sinusoidal = new(x => 1 - Math.Cos(x * Mathf.PI / 2), x => Math.Sin(x * Math.PI / 2),
            x => 0.5 * (1 - Math.Cos(Math.PI * x)));
        
        public static EasingSet Exponential = new(x => x == 0 ? 0 : Math.Pow(1024, x - 1), x => Math.Abs(x - 1) < double.Epsilon ? 1 : 1 - Math.Pow(2, - 10 * x),
            x =>
            {
                switch (x)
                {
                    case 0:
                        return 0;
                    case 1:
                        return 1;
                }

                if ((x *= 2) < 1) {
                    return 0.5 * Math.Pow(1024, x - 1);
                }

                return 0.5 * (- Math.Pow(2, - 10 * (x - 1)) + 2);
            });
        
        public static EasingSet Circular = new(x => 1 - Math.Sqrt(1 - x * x), x => Math.Sqrt(1 - --x * x), x =>
        {
            if ((x *= 2) < 1) {
                return - 0.5 * (Math.Sqrt(1 - x * x) - 1);
            }

            return 0.5 * (Math.Sqrt(1 - (x -= 2) * x) + 1);
        });
        
        public static EasingSet Elastic = new(x =>
        {
            if (x == 0) {
                return 0;
            }

            if (Math.Abs(x - 1) < double.Epsilon) {
                return 1;
            }

            return -Math.Pow(2, 10 * (x - 1)) * Math.Sin((x - 1.1) * 5 * Math.PI);     
        }, x =>
        {

            if (x == 0) {
                return 0;
            }

            if (Math.Abs(x - 1) < double.Epsilon) {
                return 1;
            }

            return Math.Pow(2, -10 * x) * Math.Sin((x - 0.1) * 5 * Math.PI) + 1;
        }, x =>
        {
            if (x == 0) {
                return 0;
            }

            if (Math.Abs(x - 1) < double.Epsilon) {
                return 1;
            }

            x *= 2;

            if (x < 1) {
                return -0.5 * Math.Pow(2, 10 * (x - 1)) * Math.Sin((x - 1.1) * 5 * Math.PI);
            }

            return 0.5 * Math.Pow(2, -10 * (x - 1)) * Math.Sin((x - 1.1) * 5 * Math.PI) + 1;
        });

        private const double S = 1.70158;
        public static EasingSet Back = new(x => x * x * ((S + 1) * x - S), x => --x * x * ((S + 1) * x + S) + 1, x =>
        {
            const double s = 1.70158 * 1.525;

            if ((x *= 2) < 1) {
                return 0.5 * (x * x * ((s + 1) * x - s));
            }

            return 0.5 * ((x -= 2) * x * ((s + 1) * x + s) + 2);
        });

        private static double EaseBounceOut(double x)
        {
            return x switch
            {
                < 1 / 2.75 => 7.5625 * x * x,
                < 2 / 2.75 => 7.5625 * (x -= 1.5 / 2.75) * x + 0.75,
                < 2.5 / 2.75 => 7.5625 * (x -= 2.25 / 2.75) * x + 0.9375,
                _ => 7.5625 * (x -= 2.625 / 2.75) * x + 0.984375
            };
        }

        private static double EaseBounceIn(double x)
        {
            return 1 - EaseBounceOut(1 - x);
        }
        
        public static EasingSet Bounce = new(EaseBounceIn, EaseBounceOut, x =>
        {
            if (x < 0.5)
            {
                return EaseBounceIn(x * 2) * 0.2;
            }

            return EaseBounceOut(x * 2 - 1) * 0.5 + 0.5;
        });
    }

    public static class Lerp
    {
        private static T Coerce<T>(object v)
        {
            return (T) v;
        }
        
        // Inspiration from https://github.com/Elttob/Fusion/blob/main/src/Animation/lerpType.lua
        public static T LerpType<T>(T from, T to, float ratio)
        {
            return Coerce<T>((from, to) switch
            {
                (float x, float y) => (y - x) * ratio + x,
                (double x, double y) => (y - x) * ratio + x,
                (Color x, Color y) => Color.Lerp(x, y, ratio),
                (DateTime x, DateTime y) => DateTime.FromFileTimeUtc(
                    LerpType(x.ToFileTimeUtc(), y.ToFileTimeUtc(), ratio)),
                
                (Index x, Index y) => LerpType(x.Value, y.Value, ratio),
                (Range x, Range y) => new Range(LerpType(x.Start, y.Start, ratio), LerpType(x.End, y.End, ratio)),
                
                (Rect x, Rect y) => new Rect(LerpType(x.min, y.min, ratio), LerpType(x.max, y.max, ratio)),
                (RectInt x, RectInt y) => new RectInt(LerpType(x.min, y.min, ratio), LerpType(x.max, y.max, ratio)),
                
                (Vector2 x, Vector2 y) => Vector2.Lerp(x, y, ratio),
                (Vector3 x, Vector3 y) => Vector3.Lerp(x, y, ratio),
                (Vector4 x, Vector4 y) => Vector4.Lerp(x, y, ratio),
                
                (Quaternion x, Quaternion y) => Quaternion.Lerp(x, y, ratio),
                
                _ => ratio < 0.5 ? from : to
            });
        }
    }
}