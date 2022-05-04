using System;

namespace DataStructure.SortAlgorithm
{
    public class Date : IComparable<Date>
    {
        //日期类
        private int year;
        private int month;
        private int day;
        private string happen;

        public Date(int year, int month, int day, string happen)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.happen = happen;
        }

        //自定义比较方法。
        public int CompareTo(Date other)
        {
            if (this.year > other.year) return 1; //年份大的返回1，放后面
            if (this.year < other.year) return -1; //年份小的返回-1，放前面
            if (this.month > other.month) return 1; //月份大的返回1，放后面
            if (this.month < other.month) return -1; //月份小的返回-1，放前面
            if (this.day > other.day) return 1; //天数大的返回1，放后面
            if (this.day < other.day) return -1; //天数小的返回-1，放前面
            return 0; //年月日都相等返回0，相邻放一起
        }

        public override string ToString()
        {
            return year + "/" + month + "/" + day + ": " + happen;
        }
    }
}