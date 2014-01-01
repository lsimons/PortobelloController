"C:\Program Files (x86)\WiX Toolset v3.8\bin\candle.exe" PortobelloController.wxs -ext WixUtilExtension -ext WixUIExtension
"C:\Program Files (x86)\WiX Toolset v3.8\bin\light.exe" PortobelloController.wixobj -ext WixUtilExtension -ext WixUIExtension

"C:\Program Files (x86)\WiX Toolset v3.8\bin\candle.exe" PortobelloBundle.wxs -ext WixBalExtension -ext WixUtilExtension -ext WixNetFxExtension
"C:\Program Files (x86)\WiX Toolset v3.8\bin\light.exe" PortobelloBundle.wixobj -ext WixBalExtension -ext WixUtilExtension -ext WixNetFxExtension