# Versioning
This is version 1.0.0 of the Expressive Expression Tree library.

This package is available on nuget at: https://www.nuget.org/packages/ExpressiveExpressionTrees/1.0.0

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

