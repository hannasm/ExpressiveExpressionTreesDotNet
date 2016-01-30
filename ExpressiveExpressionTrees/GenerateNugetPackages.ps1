remove-item ExpressiveExpressionTrees*.nupkg

msbuild ./ExpressiveExpressionTrees.csproj /p:Configuration=Release

nuget pack 'Package.nuspec' -Symbol -Prop Configuration=Release

$data = [xml](Get-Content Package.nuspec);
$version = $data.package.metadata.version;

$data.package.metadata.description = 'This is a source only distribution of the ' + $data.package.metadata.id + ' library that can be embedded inside of other projects / libraries.';
$data.package.metadata.id = $data.package.metadata.id + '.Sources';

$project = [xml](Get-Content ExpressiveExpressionTrees.csproj)
$rootFilePath = (Join-Path (join-path 'content' 'App_Packages') ($data.package.metadata.id + '.' + $version))
$fileRef = $data.package.files.file | select -first 1;

$toRemove = @();
foreach ($grp in $project.Project.ItemGroup) {
	foreach ($compile in $grp.Compile) {
		if ( (Split-Path $compile.Include -Leaf) -eq 'AssemblyInfo.cs') { continue; }
		
		# annotate source files with a comment indicating package version, as well as wrapping all code inside the namespace and rename extension to .pp
		$text = [System.IO.File]::ReadAllText($compile.Include);
		$text = '// Nuget source distribution of ' + $data.package.metadata.id + '.' + $versionString + [Environment]::NewLine +
			    'namespace $rootnamespace$.App_Packages {' + [Environment]::NewLine + '  ' +
				$text.Replace(([Environment]::NewLine), ([Environment]::Newline + '  ')) +
				'}';
		[System.IO.File]::WriteAllText( ($compile.Include + '.pp'), $text);
		
		$file = $fileRef.Clone();
		$file.src = $compile.Include + '.pp';
		$file.target = [string](Join-Path $rootFilePath ($compile.Include + '.pp'));

		$data.package.files.AppendChild($file);

		$toRemove += $file.src;
	}
}

$sourcesNuspec = 'ExpressiveExpressionTrees.Sources.nuspec';

$data.OuterXml | Out-File -FilePath $sourcesNuspec -Force;

nuget pack $sourcesNuspec;

# remove all the generated .pp files
foreach ($file in $toRemove) {
	Remove-Item $file -force;
}

# vim: set expandtab ts=2 sw=2: 
