using System;
using System.Runtime.InteropServices;

namespace UnhollowerBaseLib.Runtime.VersionSpecific.Image
{
    [ApplicableToUnityVersionsSince("2017.1.0")]
    [ApplicableToUnityVersionsSince("2017.2.0")]
    public unsafe class NativeImageStructHandler_24_A : INativeImageStructHandler
        {
            public INativeImageStruct CreateNewImageStruct()
            {
                var pointer = Marshal.AllocHGlobal(Marshal.SizeOf<Il2CppImage_24>());

                *(Il2CppImage_24*) pointer = default;

                return new NativeImageStruct(pointer);
            }

            public INativeImageStruct Wrap(Il2CppImage* imagePointer)
            {
                return new NativeImageStruct((IntPtr) imagePointer);
            }
            
            [StructLayout(LayoutKind.Sequential)]
            private struct Il2CppImage_24
            {
                public IntPtr name;      // const char*
                public int assemblyIndex;

                public /*TypeDefinitionIndex*/ int typeStart;
                public uint typeCount;

                public /*TypeDefinitionIndex*/ int exportedTypeStart;
                public uint exportedTypeCount;

                public /*CustomAttributeIndex*/ int customAttributeStart;
                public uint customAttributeCount;
        
                public /*MethodIndex*/ int entryPointIndex;

                public /*Il2CppNameToTypeDefinitionIndexHashTable **/ IntPtr nameToClassHashTable;

                public uint token;
            }
            
            private class NativeImageStruct : INativeImageStruct
            {
                private static byte dynamicDummy;
                
                public NativeImageStruct(IntPtr pointer)
                {
                    Pointer = pointer;
                }
                
                public IntPtr Pointer { get; }

                public Il2CppImage* ImagePointer => (Il2CppImage*) Pointer;
                
                private Il2CppImage_24* NativeImage => (Il2CppImage_24*) ImagePointer;
                
                public ref Il2CppAssembly* Assembly => throw new NotSupportedException();

                public ref byte Dynamic => ref dynamicDummy;

                public ref IntPtr Name => ref NativeImage->name;

                public bool HasNameNoExt => false;

                public ref IntPtr NameNoExt => throw new NotSupportedException();
            }
        }
}