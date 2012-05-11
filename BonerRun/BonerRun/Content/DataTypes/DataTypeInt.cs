using System;
namespace BonerRun.Content.DataTypes
{
    public class DataTypeInt : DataType<int>
    {
        public DataTypeInt()
        {
            type = typeof(int);
        }

        protected override int loadDataP(string input)
        {
            return int.Parse(input);
        }

        protected override string saveDataP(int input)
        {
            return input.ToString();
        }
    }
}
