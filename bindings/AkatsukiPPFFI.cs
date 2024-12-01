// Automatically generated by Interoptopus.

#pragma warning disable 0105
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using My.Company;
#pragma warning restore 0105

namespace My.Company
{
    public static partial class Interop
    {
        public const string NativeLib = "akatsuki_pp";

        static Interop()
        {
        }


        [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "calculate_performance_from_path")]
        public static extern CalculatePerformanceResult calculate_performance_from_path(ref sbyte beatmap_path, uint mode, uint mods, uint max_combo, Optionf64 accuracy, Optionu32 count_300, Optionu32 count_100, Optionu32 count_50, uint miss_count, Optionu32 passed_objects);

        [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "calculate_performance_from_bytes")]
        public static extern CalculatePerformanceResult calculate_performance_from_bytes(Sliceu8 beatmap_bytes, uint mode, uint mods, uint max_combo, Optionf64 accuracy, Optionu32 count_300, Optionu32 count_100, Optionu32 count_50, uint miss_count, Optionu32 passed_objects);

    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct CalculatePerformanceResult
    {
        public double pp;
        public double stars;
        public double ar;
        public double od;
        public uint max_combo;
    }

    ///A pointer to an array of data someone else owns which may not be modified.
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Sliceu8
    {
        ///Pointer to start of immutable data.
        IntPtr data;
        ///Number of elements.
        ulong len;
    }

    public partial struct Sliceu8 : IEnumerable<byte>
    {
        public Sliceu8(GCHandle handle, ulong count)
        {
            this.data = handle.AddrOfPinnedObject();
            this.len = count;
        }
        public Sliceu8(IntPtr handle, ulong count)
        {
            this.data = handle;
            this.len = count;
        }
        public byte this[int i]
        {
            get
            {
                if (i >= Count) throw new IndexOutOfRangeException();
                var size = Marshal.SizeOf(typeof(byte));
                var ptr = new IntPtr(data.ToInt64() + i * size);
                return Marshal.PtrToStructure<byte>(ptr);
            }
        }
        public byte[] Copied
        {
            get
            {
                var rval = new byte[len];
                for (var i = 0; i < (int) len; i++) {
                    rval[i] = this[i];
                }
                return rval;
            }
        }
        public int Count => (int) len;
        public IEnumerator<byte> GetEnumerator()
        {
            for (var i = 0; i < (int)len; ++i)
            {
                yield return this[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }


    ///Option type containing boolean flag and maybe valid data.
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Optionf64
    {
        ///Element that is maybe valid.
        double t;
        ///Byte where `1` means element `t` is valid.
        byte is_some;
    }

    public partial struct Optionf64
    {
        public static Optionf64 FromNullable(double? nullable)
        {
            var result = new Optionf64();
            if (nullable.HasValue)
            {
                result.is_some = 1;
                result.t = nullable.Value;
            }

            return result;
        }

        public double? ToNullable()
        {
            return this.is_some == 1 ? this.t : (double?)null;
        }
    }


    ///Option type containing boolean flag and maybe valid data.
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Optionu32
    {
        ///Element that is maybe valid.
        uint t;
        ///Byte where `1` means element `t` is valid.
        byte is_some;
    }

    public partial struct Optionu32
    {
        public static Optionu32 FromNullable(uint? nullable)
        {
            var result = new Optionu32();
            if (nullable.HasValue)
            {
                result.is_some = 1;
                result.t = nullable.Value;
            }

            return result;
        }

        public uint? ToNullable()
        {
            return this.is_some == 1 ? this.t : (uint?)null;
        }
    }




    public class InteropException<T> : Exception
    {
        public T Error { get; private set; }

        public InteropException(T error): base($"Something went wrong: {error}")
        {
            Error = error;
        }
    }

}
