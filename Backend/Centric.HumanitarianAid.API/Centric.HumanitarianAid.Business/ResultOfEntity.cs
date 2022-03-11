namespace Centric.HumanitarianAid.Business
{
    public class Result<TEntity>
    {
        public TEntity Entity { get; private set; }

        public string Error { get; private set; }

        public bool IsSuccess { get; private set; }

        public bool IsFailure { get; private set; }

        public static Result<TEntity> Success(TEntity entity)
        {
            return new Result<TEntity>
            {
                Entity = entity,
                IsSuccess = true
            };
        }
        public static Result<TEntity> Failure(string error)
        {
            return new Result<TEntity>
            {
                IsFailure = true,
                Error = error
            };
        }
    }
}