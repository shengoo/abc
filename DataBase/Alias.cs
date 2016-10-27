using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        private bool isIdentity;

        public bool IsIdentity { get { return this.isIdentity; } }

        public string ColumnName { get; set; }

        public ColumnAttribute(string columnName)
            : this(columnName, false)
        {

        }
        protected ColumnAttribute(string columnName, bool isIdentity)
        {
            this.isIdentity = isIdentity;
            this.ColumnName = columnName;
        }
    }


    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        public string TableName { get; set; }

        protected TableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }
}
