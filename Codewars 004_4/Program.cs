
internal static class Program
{
    [STAThread]
    static void Main()
    {
        KataTests kataTests = new KataTests();
        kataTests.BasicTests();
    }
}

public class SnailSolution
{
    public static int[] Snail(int[][] array)
    {
        int size = 0;
        System.Collections.Generic.List<int> resultList = new List<int>();
        for (int i = 0; i < array.Length; i++)
        {
            size += array[i].Length;
        }
        int[] result = new int[size];
        if (array.Length < 2)
        {
            result = array[0];
        }
        else 
        {
            int _xMin = 0, _xMax = 1;
            int _yMin = 0, _yMax = 1;
            int _target = 0;
            do 
            {
                switch (_target)
                {
                    case 0:
                        {
                            for (int i = _xMin; i <= array[_yMin].Length - _xMax; i++)
                            {
                                resultList.Add(array[_yMin][i]);
                                size--;
                            }
                            _yMin++;
                            _target++;
                        }
                        break;
                    case 1:
                        {
                            for (int i = _yMin; i <= array.Length - _yMax; i++)
                            {
                                resultList.Add(array[i][array[i].Length - _xMax]);
                                size--;
                            }
                            _xMax++;
                            _target++;
                        }
                        break;
                    case 2:
                        {
                            for (int i = array[array.Length - _yMax].Length - _xMax; i >= _xMin; i--)
                            {
                                resultList.Add(array[array.Length - _yMax][i]);
                                size--;
                            }
                            _yMax++;
                            _target++;
                        }
                        break;
                    case 3:
                        {
                            for (int i = array.Length - _yMax; i >= _yMin; i--)
                            {
                                resultList.Add(array[i][_xMin]);
                                size--;
                            }
                            _xMin++;
                            _target = 0;
                        }
                        break;
                };
            }
            while (size > 0);
            result = resultList.ToArray();
        }
        return result;
    }
}

public class KataTests
{
    private int[][] _inData1 =
    {
        new int[] {1,2,3},
        new int[] {4,5,6},
        new int[] {7,8,9}
    };
    private int[][] _inData2 =
    {
        new int[] {1,2,3,4,5},
        new int[] {6,7,8,9,10},
        new int[] {11,12,13,14,15},
        new int[] {16,17,18,19,20},
        new int[] {21,22,23,24,25}
    };
    private int[][] _inData3 =
    {
        new int[] {1,2},
        new int[] {3,4,5},
        new int[] {6,7,8,9}
    };
    private int[][] _inData4 =
    {
        new int[] {1,2,3,4}
    };
    private int[] _result1 = { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
    private int[] _result2 = { 1, 2, 3, 4, 5, 10, 15, 20, 25, 24, 23, 22, 21, 16, 11, 6, 7, 8, 9, 14, 19, 18, 17, 12, 13 };
    private int[] _result3 = { 1, 2, 5, 9, 8, 7, 6, 3, 4};
    private int[] _result4 = { 1, 2, 3, 4 };
    internal void BasicTests()
    {
        Console.WriteLine( Int2dToString(_inData1));
        Console.WriteLine("***");
        Console.WriteLine(Int2dToString(_inData2));
        Console.WriteLine("***");
        Console.WriteLine(Int2dToString(_inData3));
        Console.WriteLine("***");
        Console.WriteLine(Int2dToString(_inData4));
        Console.WriteLine("***");
        Console.WriteLine($" _result1 {_result1.SequenceEqual(SnailSolution.Snail(_inData1))} ");
        Console.WriteLine($" _result2 {_result2.SequenceEqual(SnailSolution.Snail(_inData2))} ");
        Console.WriteLine($" _result3 {_result3.SequenceEqual(SnailSolution.Snail(_inData3))} ");
        Console.WriteLine($" _result4 {_result4.SequenceEqual(SnailSolution.Snail(_inData4))} ");
        Console.WriteLine("***");
    }
    public string Int2dToString(int[][] a)
    {
        return $"[{string.Join("\n", a.Select(row => $"[{string.Join(",", row)}]"))}]";
    }
}