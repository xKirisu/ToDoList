using System.Text.Json.Serialization;

namespace ToDoList
{
    public class TDTask
    {
        public string Name { get; }
        public string Description { get; }

        public DateOnly Date { get; }

        [JsonConstructor]
        public TDTask(string name, string description, DateOnly date)
        {
            this.Name = name;
            this.Description = description;
            this.Date = date;
        }
    }
}
