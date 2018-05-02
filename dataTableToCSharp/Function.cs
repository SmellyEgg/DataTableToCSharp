namespace dataTableToCSharp
{
    public class Function
    {
        public static string GetDataTypeFromOracleType(string type)
        {
            if (type.ToLower().Contains("number") || type.ToLower().Contains("int"))
            {
                return DataTypeEnum.intType;
            }
            else if (type.ToLower().Contains("varchar"))
            {
                return DataTypeEnum.stringType;
            }
            else if (type.ToLower().Contains("date"))
            {
                return DataTypeEnum.DateType;
            }
            else
            {
                return DataTypeEnum.stringType;
            }
        }

        /// <summary>
        /// 获取首字母大写的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetFirstUpperCharacter(string str)
        {
            string returnstr = str.Substring(0, 1).ToUpper();
            returnstr += str.Substring(1, str.Length - 1);
            return returnstr;
        }
    }
}
