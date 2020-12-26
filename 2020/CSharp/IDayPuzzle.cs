using System.Threading.Tasks;

namespace CSharp
{
    public interface IDayPuzzle
    {
         Task<long> SolvePartOne();
         Task<long> SolvePartTwo();
    }
}