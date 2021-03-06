﻿#region License
//Copyright(c) 2016 Dmytro Mukalov

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
#endregion

namespace ObjectPort.Common
{
    using System.IO;
    using System.Text;

    public class Formatter<T>
    {
        private const int BytesBufferSize = 16;
        private const int StringBufferSize = 512;

        internal static readonly byte SizeOfBool = sizeof(bool);
        internal static readonly byte SizeOfChar = sizeof(char);
        internal static readonly byte SizeOfDecimal = sizeof(decimal);
        internal static readonly byte SizeOfDouble = sizeof(double);
        internal static readonly byte SizeOfFloat = sizeof(float);
        internal static readonly byte SizeOfInt = sizeof(int);
        internal static readonly byte SizeOfLong = sizeof(long);
        internal static readonly byte SizeOfShort = sizeof(short);
        internal static readonly byte SizeOfUInt = sizeof(uint);
        internal static readonly byte SizeOfULong = sizeof(ulong);
        internal static readonly byte SizeOfUShort = sizeof(ushort);
        internal static readonly byte SizeOfGuid = 16;

        internal ValueStruct PrimitiveBuffer;
        internal byte[] StringBuffer;
        internal Stream Stream;
        internal Encoding Encoding;
        internal T Next;
#if !NETCORE
        internal bool FromAffinityCache;
#endif

        internal Formatter()
        {
            PrimitiveBuffer.Bytes = new byte[BytesBufferSize];
            StringBuffer = new byte[StringBufferSize];
        }
    }
}
