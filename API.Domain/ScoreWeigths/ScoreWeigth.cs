using Domain.SportMen;

namespace Domain.ScoreWeigths
{
    public class ScoreWeigth
    {
        public Guid Id { get; set; }
        //Arranque
        public int Snatch { get; set; }
        //Envion
        public int Jerk { get; set; }
        public int TotalWeigth => Snatch + Jerk;
        public Guid SportManId { get; set; }
        public SportMan SportMan { get; set; }

        public ScoreWeigth()
        {
        }

        public ScoreWeigth(Guid id, int snatch, int jerk, Guid sportManId)
        {
            Id = id;
            Snatch = snatch;
            Jerk = jerk;
			SportManId = sportManId;
        }
    }
}
