
namespace dataTableToCSharp
{
    /// <summary>
    /// 表格内容
    /// </summary>
    public class tableContent
    {
        private string columnName = string.Empty;
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get => columnName; set => columnName = value; }

        private string dataType = string.Empty;

        public string DataType { get => dataType; set => dataType = value; }

        private bool isNullable = false;

        public bool IsNullable { get => isNullable; set => isNullable = value; }

        private string comment = string.Empty;

        public string Comment { get => comment; set => comment = value; }
    }
}
