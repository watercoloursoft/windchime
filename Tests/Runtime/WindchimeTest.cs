using UnityEngine;
using Windchime.Runtime;

namespace Windchime.Tests.Runtime
{
    public static class SpriteRendererExtension
    {
        public static Tween<Color> TweenColor(this SpriteRenderer spriteRenderer, Color to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => spriteRenderer.color, value => spriteRenderer.color = value, to, info);
            return tween;
        }
    }
    
    public class WindchimeTest : MonoBehaviour
    {
        private float _elapsed;

        private bool _isShaded;

        private Vector3 OFF_POS = new(0f, 2f, 0f);
        private Vector3 ON_POS = new(1f, -2f, 0f);
        
        private void Update()
        {
            _elapsed += Time.deltaTime;
            if (!(_elapsed > 1)) return;
            _elapsed--;
            _isShaded = !_isShaded;
            transform.TweenPosition(_isShaded ? ON_POS : OFF_POS, new TweenInfo {Time = 0.5f}, false);
        }
    }
}