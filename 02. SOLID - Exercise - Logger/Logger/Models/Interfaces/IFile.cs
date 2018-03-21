namespace Logger.Models.Interfaces
{
    public interface IFile
    {
        string Path { get; }

        int Size { get; }

        string Write(ILayout layout, IError error);
    }
}
