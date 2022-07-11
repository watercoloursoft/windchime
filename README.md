# Windchime 
Windchime is a fast and simple tween library for unity.

## Example
```csharp
public class WindchimeTest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    private float _elapsed;

    private bool _isShaded;

    private Color NORMAL_COLOR = Color.HSVToRGB(0.5f, 0.5f, 1f);
    private Color SHADED_COLOR = Color.HSVToRGB(0.8f, 0.5f, 1f);
    
    private void Update()
    {
        _elapsed += Time.deltaTime;
        if (!(_elapsed > 1)) return;
        _elapsed--;
        _isShaded = !_isShaded;
        var _ = new Tween<Color>(
            () => _spriteRenderer.color, 
            x => _spriteRenderer.color = x, 
            _isShaded ? SHADED_COLOR : NORMAL_COLOR, 
            new TweenInfo {Time = 0.5f});
    }
}
```