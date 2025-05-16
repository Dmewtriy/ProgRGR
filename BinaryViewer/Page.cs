using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryViewer
{
    public class Page
    {
        private byte[] data;
        private long index;

        public Page(byte[] bytes, long index) 
        {
            data = bytes;
            this.index = index;
        }

        public long Index
        {
            get { return index; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else
                {
                    index = value;
                }
            }
        }

        public byte[] Data
        {
            get { return data; }
        }
    }
}
