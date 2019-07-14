namespace Sudoku.Core.Rules
{
    internal interface ICloneable<T> where T: ICloneable<T>
    {
        T Clone();
    }
}