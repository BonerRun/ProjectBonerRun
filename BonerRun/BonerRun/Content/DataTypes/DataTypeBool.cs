using System;
namespace BonerRun.Content.DataTypes
{
    public class DataTypeBool:DataType<bool>
    {
        public DataTypeBool()
        {
            type = typeof(bool);
        }

        protected override bool loadDataP(string input)
        {
            if (input == "True")
            {
                return true;
            }
            else if (input == "False")
            {
                return false;
            }
            throw new FormatException();
        }

        protected override string saveDataP(bool input)
        {
            return input.ToString();
        }
    }
}
