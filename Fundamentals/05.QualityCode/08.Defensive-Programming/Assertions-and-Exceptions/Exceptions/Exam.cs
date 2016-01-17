using System;

public abstract class Exam
{
    internal const int MinScore = 0;
    internal const int MaxScore = 100;
    public abstract ExamResult Check();
}
