# Versioning
This is version 1.1.1 of the Expressive Expression Tree library.

This package is available on nuget at: https://www.nuget.org/packages/ExpressiveExpressionTrees/1.1.1

This package is also available from nuget as an embeddable sources package at: https://www.nuget.org/packages/ExpressiveExpressionTrees.Sources/1.1.1

The source for this package is available on github at: https://github.com/hannasm/ExpressiveExpressionTreesDotNet/releases/tag/1.1.1

# ExpressiveExpressionTreesDotNet
This is a library that simplifies creating / manipulating expression trees. This includes various expression tree related utilities
that are useful but without a better place to live.

## What's Included

* ExpressionGenerator - leverages the Expression<Func<...>> / Expression<Action<...>> language feature to support expressive creation of expression trees
* ExpressionVisitor - custom implementation of the visitor pattern on expression trees
* ExpressionComparer - custom implementation of the visitor pattern on expression trees to compare two instances
* ExpressionReplacer - derivation of the ExpressionVisitor to replace subexpressions
* ExpressionHasher - derivation of the ExpressionVisitor to create a valid hashcodes for an expression tree
* ExpressionFinder - derivation of the ExpressionVistior to determine whether one expression exists within another expression tree
* ExpressionReader - collection of utitlity methods useful when manipulating expression trees

# Expression Generator

The expression generator is the Expressive part of the ExpressiveExpressionTrees library. With it, you can leverage the C# compiler to 
produce expression trees for you from static C# source code. These compiler generated expression trees are easily manipulated and
recompiled later into executable code.

```csharp
var xgr = new ExpressiveExpressionTrees.ExpressionGenerator();

// create an expression tree for instantiating a new anonymous type
var e1 = xgr.FromFunc(()=>new {
  FieldOne = 1,
  FieldTwo = "ABC"
});

// create an expression tree for writing hello world to the console
var e2 = xgr.FromAction(()=>Console.WriteLine("Hello World"));

// create an expression tree for returning the length of a string parameter
// demonstrating the use of the lambda parameters and strongly typed expression substitutions
var p1 = Expression.Lambda<Func<string>>(Expression.Parameter(typeof(string)));
var e3 = xgr.FromFunc(p1, (s)=>s.Length);
```

# Expression Hasher / Expression Comparer
The ExpresisonHasher and ExpressionComparer are useful in a number of different contexts because they allow for Expression trees to
be stored inside of a dictionary / hashtable data structure as a key. The hasher / comparer are based on field level
equality, and not reference equality, meaning that two distinct instances of an expression tree composed of the exact same expression
will be treated as equal.

# Changelog

## 1.1.1
  * Apparently the binary nuget packages didn't have a dll in them
  
## 1.1.0 
  * Added ConvertExpressions() / Split() / Join() / MultiProject() helpers
  * Add helpers for MakeBinary() / etc...
  * This is the first release that is also available as a Sources package on nuget
  * This version imports the Sources nuget package of ExpressiveReflection

 ## 1.0.0
   * Initial release