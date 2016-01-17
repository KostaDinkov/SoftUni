public class CSharpExam : Exam
{
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get { return this.score; }
        private set
        {
            if (value < MinScore)
            {
                this.score = MinScore;
            }
            if (value > MaxScore)
            {
                this.score = MaxScore;
            }
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
    }
}