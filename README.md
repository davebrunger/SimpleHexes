# SimpleHexes

A small, dependency-light hex coordinate library for .NET.

- **NuGet:** `SimpleHexes`
- **Targets:** .NET Standard 2.0 and .Net Standard 2.1 
- **License:** MIT
- **Repo:** https://github.com/davebrunger/SimpleHexes

## Why this exists

SimpleHexes aims to be a “just enough” hex coordinate package:
- Easy-to-read coordinate type(s)
- Common hex operations (neighbors, distance, etc.)
- Minimal allocations and predictable performance

> If you’re building a tactics game, board-game sim, map tools, or TTRPG utilities, this is the kind of library you don’t want to rewrite every time.

## Install

### .NET CLI
```bash
dotnet add package SimpleHexes
```
### Package Reference
```xml
<PackageReference Include="SimpleHexes" Version="1.0.0" />
```

## Quick start
```csharp
using SimpleHexes;

// Create a hex coordinate
var a = new Hex(0, 0);
var b = new Hex(2, -1);

// Basic arithmetic
var c = a + b;

// Distance (hex distance)
var d = Hex.GetDistanceTo(a, b);

// Neighbours
foreach (var n in a.GetNeighbours())
{
    Console.WriteLine(n);
}
```

## Coordinate system
- **Type:** Axial
- **Axis names:** (q,r)
- **Orientation:** pointy-top

+ Coordinates are stored as axial (q, r)
+ Neighbour directions are ordered NW, NE, E, SE, SW, W
+ Distance is the standard hex-grid distance

## Common operations
### Line drawing
```csharp
foreach (var h in hexA.GetLineTo(hexB))
{
    ...
}
```