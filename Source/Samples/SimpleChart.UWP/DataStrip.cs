using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChart.UWP
{
    internal class DataStrip:IEnumerable<float>
    {
        float[] buffer;
        int index = 0;
        public int Length { get; private set; } = 0;
        public DataStrip(int size)
        {
            buffer = new float[size];
            Length = size;
        }

        public void Add(float value)
        {
            index = (index + 1) % buffer.Length;
            buffer[index] = value;
        }
        public void Clear()
        {
            buffer = new float[Length];
            index = 0;
        }

        public IEnumerator<float> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return buffer[(index + i+1) % buffer.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
