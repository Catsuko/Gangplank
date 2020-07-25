# Gangplank
Provides simple and declarative representations of value ranges in Unity.

## Getting Started

Add the Gangplank Package by editing your `manifest.json` file to include the following line:

```
{
  "dependencies": {
    "com.catsuko.gangplank": "https://github.com/Catsuko/Gangplank.git"
}
```

After Unity installs the Package, you are good to go!

```c#
using Gangplank.Ranges;

FloatRange range = new FloatRange(0f, 5f)

range.Start               // 0
range.End                 // 5
range.Contains(5)         // True
range.Contains(50)        // False

range.Random()            // Random value between 0 - 5
range.Interpolate(0.5f)   // 2.5

range.Walk(1f)            // Enumerable => 0f, 1f, 2f, 3f, 4f, 5f
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

Gangplank unites these start and end values under one concept: a Range. A Range represents not only the start and end but also the values between, providing useful methods for selection and iteration.

Let's take a look at the previous examples implemented with Ranges:

```c#
using Gangplank.Ranges;

[SerializeField]
Vector3Range _scaleOffset;

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
    _renderer.color = _colorOffset.Random();
}
```

### Interpolation

Ranges also provide a way to simplify moving from one value to another, common in transitions that you wish to take place over time.

Recognize this code?
```c#
IEnumerator Walk (Vector3 start, Vector3 end) {
    float timer = 0;
    while(timer < 1f) {
        transform.position = Vector3.Lerp(start, end, timer);
        timer += Time.deltaTime;
        yield return null;
    }
}

StartCoroutine(Walk(transform.position, target.position));
```

With a Range, you could refactor to:
```c#
IEnumerator Walk (Vector3 start, Vector3 end) {
  Vector3Range path = new Vector3Range(start, end);
  foreach(var position in path.Walk(() => Time.deltaTime)) {
    transform.position = position;
    yield return null;
  }
}

StartCoroutine(Walk(transform.position, target.position));
```
Or go with a more declarative syntax:
```c#
var path = new Vector3Range(transform.position, target.position);
StartCoroutine(path.Walk((pos) => transform.position = pos, () => Time.deltaTime));
```
