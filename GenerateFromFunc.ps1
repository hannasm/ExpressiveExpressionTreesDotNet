$newline = [Environment]::NewLine;
$output = 'using System;' + $newline; 
$output += 'using System.Linq.Expressions;' + $newline;
$output += $newline;
$newline = [Environment]::NewLine + '    ';
$output += 'namespace ExpressiveExpressionTrees {' + $newline;
$newline = [Environment]::NewLine + '        ';
$output += 'public partial class ExpressionGenerator {';
$fPrefix = $newline;
foreach ($x in (1..16)) {
	$output += $fPrefix;
	$output += 'public Expression<Func<T' + ($x+1) + '>> FromFunc<'; 
	$prefix = ''; 
	for ($y = 1; $y -le ($x+1); $y++) { 
		$output += $prefix; 
		$output += 'T'; 
		$output += $y;
 		$prefix=', ';
	} 
	$output += '>(';
	for($y=1;$y -le $x;$y++) { 
		$output += 'Expression<Func<T' + $y + '>> p' + $y + ', '; 
	} 
	$output += 'Expression<Func<'; 
	$prefix='';
	for ($y = 1; $y -le ($x+1); $y++) { 
		$output += $prefix; 
		$output += 'T' + $y; 
		$prefix = ','; 
	} 
	$output += '>> expr'; 
	$output += ')' + $newline; 
	$output += '{' + $newline;
	$output += '    return Expression.Lambda<Func<T' + ($x+1) + '>>(' + $newline;
	$output += '        ExpressionReplacer.' + $newline;
	$output += '            Search(expr.Body).' + $newline;
	for ($y = 0; $y -lt $x; $y++) {
		$output += '            When(expr.Parameters[' + $y + '], p' + ($y+1) + '.Body).' + $newline;
	}
	$output += '            GetResult()' + $newline;
	$output += '    );' + $newline;
	$output += '}';
	$fPrefix = $newline + $newline;
}
$newline = [Environment]::NewLine;
$output += $newline;
$output += '    }' + $newline;
$output += '}' + $newline;

$output | out-file ExpressiveExpressionTrees\ExpressionGenerator.FromFunc.cs;
