using System;
namespace BonerRun.Content
{
    public interface IDataType
    {
        Type type
        {
            get;
            set;
        }

        object loadData(string input);

        string saveData(object input);
    }
}
