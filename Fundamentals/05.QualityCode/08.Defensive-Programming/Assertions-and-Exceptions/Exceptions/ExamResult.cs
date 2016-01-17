using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comment;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get { return this.grade; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Grade cannot be less than zero.");
            }
            this.grade = value;
        }
    }

    public int MinGrade
    {
        get { return this.minGrade; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Minimum grade cannot be less than zero.");
            }
            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get { return this.maxGrade; }
        private set
        {
            if (value <= this.MinGrade)
            {
                throw new ArgumentException("Maximum grade cannot be less than minimum grade");
            }
            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get { return this.comment; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Comment argument cannot be empty or null");
            }
            this.comment = value;
        }
    }
}