namespace ToDoList.Models
{
    public class Entry
    {
        public Entry(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }

}
