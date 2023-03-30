namespace api.Common
{
    public interface IToDoItem
    {
        public string Name { get; set; }
       
        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}