using System.IO;
using System.Threading.Tasks;

namespace CSharp
{
    public static class FileInputHelper
    {
        public static async Task<string[]> GetInput(string path)
            => await File.ReadAllLinesAsync(path);
    }
}