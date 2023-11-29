using System;

public class MathAssignment : Assignment{

    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string section, string problems) : base(studentName, topic){
        _textbookSection = section;
        _problems = problems;

    }

    public string GetHomeworkList(){
        return $"Chapter {_textbookSection}: Problems {_problems}";
    }

    public string GetFullSummary(){
        return $"{GetSummary()} [{GetHomeworkList()}]";
    }

}