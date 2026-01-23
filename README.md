# SimpleHexes

A small, dependency-free hex-grid coordinate library for .NET.

**SimpleHexes** provides a clear, minimal implementation of hex-based coordinates and common hex-grid operations, suitable for games, simulations, and tooling where you want correctness and readability without framework bloat.

- **NuGet:** `SimpleHexes`
- **Targets:** .NET Standard 2.0 and 2.1
- **Licence:** MIT
- **Repository:** https://github.com/davebrunger/SimpleHexes

## Features

- Hex coordinate type with explicit axial coordinates
- Neighbour lookup
- Hex distance calculation
- Line drawing between hexes
- No runtime dependencies
- Allocation-free fast paths on modern runtimes

## Installation

### .NET CLI
```bash
dotnet add package SimpleHexes
```
### Package Reference
```xml
<PackageReference Include="SimpleHexes" Version="1.0.0" />
```

## Coordinate system
SimpleHexes uses axial hex coordinates:
- Axes: (q, r)
- Distance: standard hex-grid distance
- Neighbours: six adjacent hexes at distance 1

All calculations are deterministic and orientation-agnostic (no pixel or layout assumptions).

## Basic Usage
```csharp
using SimpleHexes;

var origin = new Hex(0, 0);
var target = new Hex(2, -1);

// Distance
var distance = origin.GetDistanceTo(target);

// Basic arithmetic
var sum = origin + target;
var difference = origin - target;

// Neighbours
foreach (var neighbour in origin.GetNeighbours())
{
    Console.WriteLine(neighbour);
}

// Line between two hexes
foreach (var step in origin.GetLineTo(target))
{
    Console.WriteLine(step);
}
```

## API notes
- Method names use UK spelling (GetNeighbours, not GetNeighbors)
- Hex is a value type intended to be cheap to copy
- Returned collections are read-only views; callers cannot mutate internal state
- On .NET Standard 2.1, allocation-free APIs are used internally where possible

## Performance
- No LINQ on hot paths
- No hidden allocations in core operations
- Designed to be safe to call frequently (e.g. per-frame path or range checks)

## When to use SimpleHexes
Use this library if you want:
- A reliable hex maths foundation
- Minimal API surface
- No opinionated game or rendering framework
- Something you can read and understand in one sitting

If you need:
- Pathfinding algorithms
- Pixel/layout conversion
- Large mutable grids

…those are intentionally out of scope.