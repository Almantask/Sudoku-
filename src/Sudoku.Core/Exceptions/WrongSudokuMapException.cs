using System;
using System.Runtime.Serialization;

namespace Sudoku.Core.SudokuElements
{
    [Serializable]
    internal class WrongSudokuMapException : Exception
    {
        public WrongSudokuMapException()
        {
        }

        public WrongSudokuMapException(string message) : base(message)
        {
        }

        public WrongSudokuMapException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongSudokuMapException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}