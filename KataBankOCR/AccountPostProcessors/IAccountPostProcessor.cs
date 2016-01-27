namespace KataBankOCR.AccountPostProcessors
{
    public interface IAccountPostProcessor
    {
        string[] Process(string[] accounts);
    }
}