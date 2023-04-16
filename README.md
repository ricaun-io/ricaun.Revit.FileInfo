# ricaun.Revit.FileInfo

[![Revit 2024](https://img.shields.io/badge/Revit-2024-blue.svg)](../..)
[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](../..)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](../../actions/workflows/Build.yml/badge.svg)](../../actions)
[![.NET Framework 4.0](https://img.shields.io/badge/.NET%20Framework%204.0-blue.svg)](../..)

## Example

```csharp
using ricaun.Revit.FileInfo;

RevitVersionInfo revitVersionInfo = new RevitVersionInfo(filePath);
if (revitVersionInfo.IsValid)
{
	RevitVersion revitVersion = revitVersionInfo.Version;
}
```

## Reference Projects  

This project was inspired by the following projects:

* [Basic File Info and RVT File Version](https://thebuildingcoder.typepad.com/blog/2013/01/basic-file-info-and-rvt-file-version.html)
* [REvit VErsion CHEcker](https://github.com/teocomi/Reveche)
* [RevitFileUtility](https://github.com/KennanChan/RevitFileUtility)


## License

This project is [licensed](LICENSE) under the [MIT Licence](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](../../stargazers)!