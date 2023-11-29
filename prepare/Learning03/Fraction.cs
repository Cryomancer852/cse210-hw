using System;

public class Fraction
{
    private int _topNum;
    private int _bottomNum;

    public Fraction(){
        _topNum = 1;
        _bottomNum = 1;
    }

    public void WholeToFraction(int whole){
        _topNum = whole;
    }

    public void SetFraction(int top, int bottom){
        _topNum = top;
        _bottomNum = bottom;
    }

    public int GetNumerator(){
        return _topNum;
    }

    public int GetDenominator(){
        return _bottomNum;
    }

    public void SetNumerator(int newTop){
        _topNum = newTop;
    }

    public void SetDenominator(int newBottom){
        _bottomNum = newBottom;
    }

    public override string ToString(){
        return $"{_topNum}/{_bottomNum}";
    }

    public double ToFloat(){
        double dec = (double)_topNum / (double)_bottomNum;
        return dec;
    }


}