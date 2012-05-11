using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using BonerRun.Content.DataTypes;
namespace BonerRun.Content
{
    public static class FileLoader
    {
        public static List<IDataType> dataTypes;


        public static void addDataType(IDataType dataType)
        {
            dataTypes.Add(dataType);
        }

        public static void LoadDataTypes()
        {
            dataTypes = new List<IDataType>();
            addDataType(new DataTypeInt());
            addDataType(new DataTypeBool());
            addDataType(new DataTypeString());
            addDataType(new DataTypeVector2());
            addDataType(new DataTypeColor());
            addDataType(new DataTypeObstacle());
            addDataType(new DataTypeTexture2D());
        }

        #region Load
        private static object Load(string input,Type type)
        {
            foreach (IDataType dataType in dataTypes)
            {
                if (dataType.type == type)
                {
                    return dataType.loadData(input);
                }
            }
            return null;
        }

        private static object Load(object var, string line)
        {
             Type type = var.GetType();
             return Load(line, type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="var"></param>
        /// <returns>When loading was succesfull true is returned</returns>
        public static object Load(object var)
        {
            string line = activeReader.ReadLine();

            Type type = var.GetType(); 

            if (activeFormat == FileFormat.Minified)
            {                
            }
            else if (activeFormat == FileFormat.NameFirst)
            {
                line = line.Split(':')[1];
            }
            else if (activeFormat == FileFormat.TypeFirst)
            {
                line = line.Split(':')[1];
            }
            else if (activeFormat == FileFormat.Extensive)
            {
                line = line.Split(':')[2];
            }

            var = Load(var, line);
            return var;
        }



        public static object loadList<T>()
        {
            List<T> list = new List<T>();

            string temp = activeReader.ReadLine();

            while (temp != "}")
            {
                if (temp != "{")
                {
                    T t = Activator.CreateInstance<T>();
                    if (activeFormat == FileFormat.Minified)
                    {
                    }
                    else if (activeFormat == FileFormat.NameFirst)
                    {
                        temp = temp.Split(':')[1];
                    }
                    else if (activeFormat == FileFormat.TypeFirst)
                    {
                        temp = temp.Split(':')[1];
                    }
                    else if (activeFormat == FileFormat.Extensive)
                    {
                        temp = temp.Split(':')[2];
                    }
                    t = (T)Load(t, temp);
                    list.Add(t);
                }
                temp = activeReader.ReadLine();
            }
            return list;
        }
        #endregion

        #region Save
        public static void Save(object var,string name)
        {
            string line = "";
            Type type = var.GetType(); 

            if (activeFormat == FileFormat.Minified)
            {
            }
            else if (activeFormat == FileFormat.NameFirst)
            {
                line = name + ":";
            }
            else if (activeFormat == FileFormat.TypeFirst)
            {
                line = type.Name + ":";
            }
            else if (activeFormat == FileFormat.Extensive)
            {
                line = type.Name + ":" + name + ":";
            }

            line += SaveP(var);

            activeWriter.WriteLine(line);
        }

        public static void Save(object var)
        {
            string line = "";
            Type type = var.GetType();

            if (activeFormat == FileFormat.Minified)
            {
            }
            else if (activeFormat == FileFormat.TypeFirst)
            {
                line = type.Name + ":";
            }

            line += SaveP(var);

            activeWriter.WriteLine(line);
        }

        private static string Save(object input, Type type)
        {
            foreach (IDataType dataType in dataTypes)
            {
                if (dataType.type == type)
                {
                    return dataType.saveData(input);
                }
            }
            return null;
        }

        private static string SaveP(object var)
        {
            Type type = var.GetType();
            return Save(var, type);
        }
        #endregion

        public static StreamWriter activeWriter;

        public static StreamReader activeReader;

        public static FileFormat activeFormat;

        public static ContentManager contentManager;
    }

}
