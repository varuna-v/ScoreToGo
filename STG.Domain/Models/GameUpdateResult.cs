namespace STG.Domain.Models
{
    public enum GameUpdateResult
    {
        Success,
        SuccessLastAvailable,
        LimitExceeced,
        Failed
    }
}
