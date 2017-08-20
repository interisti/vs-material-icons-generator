namespace MaterialIconsGenerator.Core
{
    public interface IProject
    {
        string GetRootDirectory();

        void AddFile(string filename, string type);

        void Save();
    }
}
