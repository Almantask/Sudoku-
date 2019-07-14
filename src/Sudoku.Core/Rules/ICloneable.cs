namespace Sudoku.Core.Rules
{
    public interface ICloneable<T> where T: ICloneable<T>
    {
        T Clone();
    }
}