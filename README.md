# Windchime 
Windchime is a reactive state library for unity projects,
inspired by solidjs and Fusion for the roblox ecosystem.

## Example
```csharp
public class DebugElapsedTime : ReactiveBehaviour
{
    private readonly State<int> _amount = new(0);
    private float _elapsed = 0;
    
    private void Update()
    {
        _elapsed += Time.deltaTime;
        if (!(_elapsed > 1)) return;
        _amount.Update(x => x + 1);
        _elapsed--;
    }

    protected override void Reactive()
    {
        Debug.Log("Elapsed: " + _amount.Get() + "s");
    }
}
```