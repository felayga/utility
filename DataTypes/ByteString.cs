using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace utility.DataTypes
{
    public class ByteString
    {
        public static ByteString FromArray(byte[] array, int offset, int length, bool shallow)
        {
            ByteString retval;

            if (shallow)
            {
                retval = new ByteString();
                retval.buffer = array;
                retval.buffercount = offset + length;
                retval.bufferspace = array.Length;
                retval.bufferoffset = offset;
            }
            else
            {
                retval = new ByteString(length);
                Buffer.BlockCopy(array, 0, retval.buffer, offset, length);
                retval.buffercount = length;
            }

            return retval;
        }

        #region variables

        private byte[] buffer;
        private int buffercount, bufferspace, bufferoffset;

        #endregion

        #region constructors

        private ByteString() { }

        public ByteString(int space)
        {
            buffer = new byte[space];
            buffercount = 0;
            bufferspace = space;
            bufferoffset = 0;
        }

        #endregion
        #region destructor

        ~ByteString()
        {
            buffer = null;
        }

        #endregion

        private void checkresize(int newbytes)
        {
            if (buffercount + newbytes > bufferspace)
            {
                byte[] temp = buffer;
                bufferspace = (buffercount - bufferoffset) * 3 / 2 + 1 + newbytes;
                buffer = new byte[bufferspace];

                buffercount -= bufferoffset;
                Buffer.BlockCopy(temp, bufferoffset, buffer, 0, buffercount);
                bufferoffset = 0;
            }
        }

    }
}
