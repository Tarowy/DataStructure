using System;
using System.Runtime.InteropServices;

namespace DataStructure.Test;

public class TestRef
{
    public static void Main(string[] args)
    {
        var str1 = "hello";
        var str2 = "hello";
        ref var c = ref MemoryMarshal.GetReference<char>(str1);
        c++;
        c = 'H';
        Console.WriteLine(str1);//输出：Hello
        Console.WriteLine(str2);//输出：Hello
    }
}