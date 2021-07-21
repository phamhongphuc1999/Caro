// --------------------CARO  GAME-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//
// Product by: Pham Hong Phuc
//
//
// ------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static CaroGame.Program;

namespace CaroGame
{
    internal static class Utils
    {
        public static void ApplicationExit()
        {
            //DialogResult result = MessageBox.Show(languageManager.GetString("exitMessage"), "Thông Báo", MessageBoxButtons.OKCancel); ;
            //if(result == DialogResult.OK)
            //{
                storageManager.Exit();
                Application.Exit();
            //}
        }

        public static string GetCurrentDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            return workingDirectory;
        }

        public static PropertyInfo GetProperty(Type type, string attributeName)
        {
            PropertyInfo property = type.GetProperty(attributeName);
            if (property != null) return property;
            return type.GetProperties()
                 .Where(p => p.IsDefined(typeof(DisplayAttribute), false) && p.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().Single().Name == attributeName)
                 .FirstOrDefault();
        }

        public static object ChangeType(object value, Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null) return null;
                return Convert.ChangeType(value, Nullable.GetUnderlyingType(type));
            }
            return Convert.ChangeType(value, type);
        }

        public static T ToObject<T>(this DataRow dataRow) where T : new()
        {
            T item = new T();
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                PropertyInfo property = GetProperty(typeof(T), column.ColumnName);
                if (property != null && dataRow[column] != DBNull.Value && dataRow[column].ToString() != "NULL")
                    property.SetValue(item, ChangeType(dataRow[column], property.PropertyType), null);
            }
            return item;
        }
    }
}
