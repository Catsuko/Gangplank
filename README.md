# Gangplank
Provides simple and declarative representations of value ranges in Unity.

## Installation

Add the Gangplank Package by editing your `manifest.json` file to include the following line:

```
{
  "dependencies": {
    "com.catsuko.gangplank": "https://github.com/Catsuko/Gangplank.git"
}
```

## Why

I find myself frequently creating pairs of values in order to add some variance, whether it is random or maybe a value that increases as the game is played. The code that picks a value between the pair or moves between them will then get scattered across the codebase, cluttering otherwise simple methods.

Here are some examples:

```c#
// Adding a random scale offset to an object on Start
[SerializeField]
private float _scaleMin, _scaleMax;

public void Start () {
    transform.localScale = Vector3.one * Random.Range(_scaleMin, _scaleMax);
}
```

```c#
// Add some variance in color when clicked
[SerializeField]
private Color _colorOffsetA, _colorOffsetB;
[SerializeField]
private SpriteRenderer _renderer;

public void OnClick () {
    _renderer.color = Color.lerp(_colorOffsetA, _colorOffsetB, Random.value);
}
```

In both cases we need to define multiple fields and then go about writing the same boilerplate to find the value we want.

## Usage

Gangplank's Ranges represent this pair and the values in between so you can simplify this process. The above examples could be rewritten as:

```c#
using Gangplank.Ranges;

[SerializeField]
FloatRange _scaleOffset;

public void Start () {
    transform.localScale = _scaleOffset.Random();
}
```

```c#
using Gangplank.Ranges;

[SerializeField]
ColorRange _colorOffset;
[SerializeField]
private SpriteRenderer _renderer;

public void OnClick () {
    _renderer.color = _colorOffset.Random();_
}
```

### Interpolation

Ranges also provide a way to simplify moving from one value to another, common in transitions that you wish to take place over time.

Recognize this code?
```c#
IEnumerator Walk (Vector3 start, end) {
    float timer = 0;
    while(timer < 1f){
        transform.position = Vector3.Lerp(start, end, timer);
        timer += Time.deltaTime;
        yield return null;
    }
}

StartCoroutine(Walk(transform.position, target.position));
```

You could do this instead:

```c#
var path = new Vector3Range(transform.position, target.position);
StartCoroutine(path.Walk((pos) => transform.position = pos, () => Time.deltaTime));
```