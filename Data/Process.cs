namespace Data
{
    public class Process
    {
        public int ID { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
