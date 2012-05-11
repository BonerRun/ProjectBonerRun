using System;
namespace BonerRun.Content
{
    public abstract class DataType<T>:IDataType
    {
        public Type type
        {
            get;
            set;
        }

        public object loadData(string input)
        {
            return (T)loadDataP(input);
        }

        public string saveData(object input)
        {
            return saveDataP((T)(input));
        }

        protected abstract T loadDataP(string input);

        protected abstract string saveDataP(T input);

    }
}
