namespace Presenters
{
    public class Result<T> where T : class
    {
        public Result()
        {
                
        }

        public Result(T data)
        {
            this.Data = data;
        }

        public List<string> Errors { get; set; } = new List<string>();
        public T Data { get; set; }
        public bool Success { get { return !Errors.Any(); } }
    }
}
