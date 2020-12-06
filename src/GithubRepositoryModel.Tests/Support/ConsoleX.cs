using System;
using System.Threading.Tasks;

namespace GithubRepositoryModel.Tests.Support
{
    public static class ConsoleX
    {
        private static int _folderDepth;

        public static async Task DumpGithubFolder(GhFolder folder)
        {
            _folderDepth++;
            var ghFolders = await folder.GetFolders();

            foreach (var subFolder in ghFolders)
            {
                Console.WriteLine($"{new string('>', _folderDepth)}{subFolder.Path}");
                foreach (var file in await subFolder.GetFiles())
                {

                    Console.WriteLine($"{new string(' ', _folderDepth)}{file.Path} : {file.Size} content length");
                }
                await DumpGithubFolder(subFolder);
            }

            _folderDepth--;
        }

    }
}