﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartSystem
{
  class dom_Design
    {
        public static void NumberOnly(KeyPressEventArgs e)
        {
            int num = e.KeyChar;
            //MessageBox.Show(num + "");
            if (!(num>=48&&num<=57)&&num!=8)
            {
                e.KeyChar='\0';
            }
        }
        public static void CharaterOnly(KeyPressEventArgs e)
        {
            int ch = e.KeyChar;
            
            if (!((ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122) || (ch == 8 || ch == 32)))
            {
                e.KeyChar=('\0');
            }
        }
        public static void GenerateColumHeader(String[] ColumnHeader, int numberColum, DataGridView Data)
        {
            for (int i = 0; i < numberColum; i++)
            {
                Data.Columns[i].HeaderText = ColumnHeader[i];
                Data.Columns[i].Name= ColumnHeader[i];
            }
        }

        public static void GenerateColumHeader(String[] ColumnHeader, int numberColum,DataGridView Data ,DataTable DgvDataSource)
        {
            for (int i = 0; i < numberColum; i++)
            {
                DgvDataSource.Columns.Add(ColumnHeader[i]);
                Data.Columns[i].HeaderText = ColumnHeader[i];
                Data.Columns[i].Name = ColumnHeader[i];
            }
            Data.DataSource = DgvDataSource;
        }

        public static String GenerateID(string ID,String Suffix) 
        {
            int num = 0;
            if (ID == "")
                num = 1;
            else
            {
                try
                {
                    num = int.Parse(ID) + 1;
                }
                catch
                {
                    num = int.Parse(ID.Substring(5));
                }
            }
            if (Suffix != null)
            {
                ID = Suffix + (num);
            }
            return ID;
        }
        public static String GenerateID(string ID, String Suffix,int indexSubstring)
        {
            int num = 0;
            if (ID == "")
                num = 1;
            else
            {
                try
                {
                    num = int.Parse(ID) + 1;
                }
                catch
                {
                    num = int.Parse(ID.Substring(indexSubstring))+1;
                }
            }
            if (Suffix != null)
            {
                ID = Suffix + (num);
            }
            return ID;
        }
        public static void ColumnName(DataGridView data,int column,String[]columnName)
        {
            for (int i = 0; i < column; i++)
            {
                data.Columns[i].Name = columnName[i];
                
            }
        }
        public static String SetID(int indexsubstring,String ID,String suffix)
        {
            ID = dom_Design.GenerateID(ID.Substring(indexsubstring), suffix);
            return ID;
        }
    }
}