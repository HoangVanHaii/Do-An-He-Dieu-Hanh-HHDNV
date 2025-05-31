namespace Data
{
    public class Process
    {
        public int ID { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public bool IsCompleted { get; set; } = false;

        // Các thuộc tính bổ sung cho quá trình tính toán
        public int StartTime { get; set; } = -1;
        public int FinishTime { get; set; }
        public int WaitTime { get; set; }
        public int TurnaroundTime { get; set; }
        public int RemainingTime { get; set; }
    }
}
