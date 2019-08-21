# MayaLiveLinkPluginLinux for UE 4.22.3

## It is compiled but maya crashes :)

Build command like that:
```
UnrealEngine/Engine/Build/BatchFiles/RunUAT.sh BuildGraph -Script=UnrealEngine/Engine/Source/Programs/MayaLiveLinkPlugin/BuildMayaPluginLinux.xml -Target="Stage Maya Plugin Module"
```

Additional:
```
cp Engine/Source/ThirdParty/SDL2/SDL-gui-backend/lib/Linux/x86_64-unknown-linux-gnu/libSDL2_fPIC.a libSDL2.a
cp Engine/Source/ThirdParty/jemalloc/lib/Linux/x86_64-unknown-linux-gnu/libjemalloc_fPIC.a libjemalloc.a
cp Engine/Source/ThirdParty/zlib/zlib-1.2.5/Lib/Linux/x86_64-unknown-linux-gnu/libz_fPIC.a libz.a
```