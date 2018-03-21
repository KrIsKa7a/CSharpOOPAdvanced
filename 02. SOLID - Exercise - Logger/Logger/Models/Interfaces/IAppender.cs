using Logger.Models.Enums;

namespace Logger.Models.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}
