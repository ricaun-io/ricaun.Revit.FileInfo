﻿# ricaun.Revit.FileInfo

[![Revit 2024](https://img.shields.io/badge/Revit-2024-blue.svg)](../..)
[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](../..)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](../../actions/workflows/Build.yml/badge.svg)](../../actions)
[![.NET Framework 4.0](https://img.shields.io/badge/.NET%20Framework%204.0-blue.svg)](../..)

## Example

```csharp
using ricaun.Revit.FileInfo;

RevitFileInfo revitFileInfo = new RevitFileInfo(filePath);
bool isValid = revitFileInfo.IsValid;
RevitVersion revitVersion = revitFileInfo.Version;

```

## RevitFileInfo

* IsValid: Check if the file is a valid Revit file extension. `(.rvt, .rfa, .rte, .rft)`
* Version: Get the Revit version of the file. `RevitVersion` is an `int` with the default value `RevitVersion.Unknown = 0`.

### BasicFileInfo

To find the version of the Revit file the `BasicFileInfoUtils` is used, and a regex is used to find the version in te `Revit Build:` or `Format:` info.

* In Revit 2018 and below: `Revit Build: Autodesk Revit 2018 (Build: 20170106_1515(x64))`.
* In Revit 2019 and above: `Format: 2019`.

A Unit test is used to check if the regex is working correctly between the different Revit file versions `(2014-2024)`.

## Reference Projects

This project was inspired by the following projects:

* [Basic File Info and RVT File Version](https://thebuildingcoder.typepad.com/blog/2013/01/basic-file-info-and-rvt-file-version.html)
* [REvit VErsion CHEcker](https://github.com/teocomi/Reveche)
* [RevitFileUtility](https://github.com/KennanChan/RevitFileUtility)


## License

This project is [licensed](LICENSE) under the [MIT Licence](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](../../stargazers)!