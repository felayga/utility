using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace utility.DataTypes
{
    public unsafe class PointerWrapper
    {
        protected byte* buffer;
        public readonly int Count;

        public PointerWrapper(IntPtr buffer, int count) : this((byte *)(buffer.ToPointer()), count) { }

        public PointerWrapper(byte* buffer, int count)
        {
            this.buffer = buffer;
            Count = count;
        }

        public byte this[int index]
        {
            set
            {
                buffer[index] = value;
            }
            get
            {
                return buffer[index];
            }
        }
    }

    public unsafe class BitmapWrapper : PointerWrapper
    {
        public readonly int Width;
        public readonly int Height;
        public readonly int BitsPerPixel;

        public BitmapWrapper(IntPtr buffer, int width, int height, int bpp)
            : base(buffer, width * height * bpp)
        {
            if (bpp != 1 && bpp != 2 && bpp != 4) throw new ArgumentException();

            Width = width;
            Height = height;
            BitsPerPixel = bpp;
        }

        public void SetPixel(int index, uint value)
        {
            switch (BitsPerPixel)
            {
                case 1:
                    buffer[index] = (byte)value;
                    break;
                case 2:
                    ((ushort*)buffer)[index] = (ushort)value;
                    break;
                case 4:
                    ((uint*)buffer)[index] = value;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void SetPixel(int x, int y, uint value)
        {
            switch (BitsPerPixel)
            {
                case 1:
                    buffer[x + y * Width] = (byte)value;
                    break;
                case 2:
                    ((ushort*)buffer)[x + y * Width] = (ushort)value;
                    break;
                case 4:
                    ((uint*)buffer)[x + y * Width] = value;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public uint GetPixel(int index)
        {
            switch (BitsPerPixel)
            {
                case 1:
                    return buffer[index];
                case 2:
                    return ((ushort*)buffer)[index];
                case 4:
                    return ((uint*)buffer)[index];
                default:
                    throw new ArgumentException();
            }
        }

        public uint GetPixel(int x, int y)
        {
            switch (BitsPerPixel)
            {
                case 1:
                    return buffer[x + y * Width];
                case 2:
                    return ((ushort*)buffer)[x + y * Width];
                case 4:
                    return ((uint*)buffer)[x + y * Width];
                default:
                    throw new ArgumentException();
            }
        }

        public new uint this[int index]
        {
            set
            {
                SetPixel(index, value);
            }
            get
            {
                return GetPixel(index);
            }
        }

    }
}
