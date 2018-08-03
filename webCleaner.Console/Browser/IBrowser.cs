using webCleaner.Commands;

namespace webCleaner.Browser
{
    public interface IBrowser
    {
        bool CloseProcess();
        void Delete(DeleteOption opt, bool force = false);
    }
}