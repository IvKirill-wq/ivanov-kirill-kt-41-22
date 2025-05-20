namespace IvanovKirillKt_41_22.Models
{
    public class Direction //Направление
    {
        public int DirectionId { get; set; }
        public int DisciplineId { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int hours { get; set; }

        public Discipline Discipline { get; set; }
        public Teacher Teacher { get; set; }
    }
}
