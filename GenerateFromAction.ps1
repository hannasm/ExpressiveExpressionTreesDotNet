$newline = [Environment]::NewLine;
$output = 'using global::System;' + $newline; 
$output += 'using global::System.Linq.Expressions;' + $newline;
$output += $newline;
$newline = [Environment]::NewLine + '    ';
$output += 'namespace ExpressiveExpressionTrees {' + [Environment]::NewLine;
$output += '#if EXPRESSIVE_EXPRESSION_TREES_ASSEMBLY' + $newline;
$output += 'public' + [Environment]::NewLine;
$output += '#endif' + $newline;
$newline = [Environment]::NewLine + '        ';
$output += 'partial class ExpressionGenerator {';
$fPrefix = $newline;
foreach ($x in (1..16)) {
	$output += $fPrefix;
	$output += 'public Expression FromAction<'; 
	$prefix = ''; 
	for ($y = 1; $y -le ($x); $y++) { 
		$output += $prefix; 
		$output += 'T'; 
		$output += $y;
 		$prefix=', ';
	} 
	$output += '>(';
	for($y=1;$y -le $x;$y++) { 
		$output += 'Expression<Func<T' + $y + '>> p' + $y + ', '; 
	} 
	$output += 'Expression<Action<'; 
	$prefix='';
	for ($y = 1; $y -le $x; $y++) { 
		$output += $prefix; 
		$output += 'T' + $y; 
		$prefix = ','; 
	} 
	$output += '>> expr'; 
	$output += ')' + $newline; 
	$output += '{' + $newline;
	$output += '    return ExpressionReplacer.' + $newline;
	$output += '        Search(expr.Body).' + $newline;
	for ($y = 0; $y -lt $x; $y++) {
		$output += '        When(expr.Parameters[' + $y + '], p' + ($y+1) + '.Body).' + $newline;
	}
	$output += '        GetResult();' + $newline;
	$output += '}';
	$fPrefix = $newline + $newline;
}
$newline = [Environment]::NewLine;
$output += $newline;
$output += '    }' + $newline;
$output += '}' + $newline;

$output | out-file ExpressiveExpressionTrees\ExpressionGenerator.FromAction.cs;
