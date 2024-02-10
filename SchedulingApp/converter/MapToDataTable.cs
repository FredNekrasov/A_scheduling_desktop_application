﻿using System.Data;
using System.Reflection;

namespace SchedulingApp.converter;

public class MapToDataTable
{
    //https://stackoverflow.com/questions/56351038/how-to-export-a-datagrid-to-excel-in-wpf
    public static DataTable ToDataTable<T>(List<T> items)
    {
        var dataTable = new DataTable(typeof(T).Name);

        //Get all the properties
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var prop in properties)
        {
            //Defining type of data column gives proper data table 
            var type = prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType;
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name, type);
        }
        foreach (var item in items)
        {
            var values = new object[properties.Length];
            for (var i = 0; i < properties.Length; i++)
            {
                //inserting property values to data table rows
                values[i] = properties[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
        //put a breakpoint here and check data table
        return dataTable;
    }
}
