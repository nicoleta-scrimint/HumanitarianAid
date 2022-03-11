namespace Centric.HumanitarianAid.Business
{
    public class Result
    {
        public string Error { get; private set; }

        public bool IsSuccess { get; private set; }

        public bool IsFailure { get; private set; }

        public static Result Success()
        {
            return new Result
            {
                IsSuccess = true
            };
        }
        public static Result Failure(string error)
        {
            return new Result
            {
                IsFailure = true,
                Error = error
            };
        }
    }
}