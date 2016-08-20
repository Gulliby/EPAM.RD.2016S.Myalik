// <copyright file="FibIdGenerator.cs" company="Sprocket Enterprises">
//     Copyright (c) Ilya Myalik. All rights reserved.
// </copyright>
// <author>Ilya Myalik</author>

namespace Generator.Generators
{
    using System;
    using System.Collections;
    using Interface;

    [Serializable]
    public class FibIdGenerator : IGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FibIdGenerator"/> class.
        /// </summary>
        /// <param name="current">Current number.</param>
        /// <param name="prev">Previous number.</param>
        public FibIdGenerator(int current, int prev)
        {
            this.Current = current;
            this.Prev = prev;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FibIdGenerator"/> class.
        /// </summary>
        public FibIdGenerator() : this(1, 0)
        {        
        }

        /// <summary>
        /// Gets information about previous number of the sequence.
        /// </summary>
        public int Prev
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets information about current number of the sequence.
        /// </summary>
        public int Current
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets information about current number of the sequence.
        /// </summary>
        object IEnumerator.Current => this.Current;

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
        public bool MoveNext()
        {
            if (int.MaxValue - this.Current < this.Prev)
            {
                return false;
            }

            var temp = this.Prev + this.Current;
            this.Prev = this.Current;
            this.Current = temp;
            return true;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        public void Reset()
        {
            this.Prev = 0;
            this.Current = 1;
        }

        /// <summary>
        /// Method is using for closing and releasing unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Prev = this.Current = 0;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current generator instance.
        /// </summary>
        /// <returns>New object that is a copy of the current instance.</returns>
        public object Clone()
        {
            return new FibIdGenerator(this.Current, this.Prev);
        }
    }
}
