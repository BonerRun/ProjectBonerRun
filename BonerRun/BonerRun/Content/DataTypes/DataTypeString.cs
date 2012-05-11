using System;
namespace BonerRun.Content.DataTypes
{
    public class DataTypeString:DataType<string>
    {
        public DataTypeString()
        {
            type = typeof(string);
        }

        protected override string loadDataP(string input)
        {
            return input;
        }

        protected override string saveDataP(string input)
        {
            return input;
        }
    }
}
