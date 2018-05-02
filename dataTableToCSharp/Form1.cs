using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataTableToCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTableName.Text.Trim()))
            {
                MessageBox.Show("请先输入表名好吗！");
                return;
            }
            else
            {
                this.btnGenerate.Enabled = false;
                this.lblTips.Text = "正在转换……";
                this.prgData.Visible = true;
                string result = await Task.Run(() => GenerateClassObject(this.txtTableName.Text.Trim()));
                this.txtContent.Text = result;
                this.btnGenerate.Enabled = true;
                this.lblTips.Text = "转换完成!";
                this.prgData.Visible = false;
            }
        }

        private string GenerateClassObject(string tableName)
        {
            //List<tableContent> listtableContent = this.GetTableContentObjects(tableName);
            System.Threading.Thread.Sleep(2000);
            List<tableContent> listtableContent = new List<tableContent>();
            listtableContent.Add(new tableContent() { ColumnName = "name", DataType = "varchar2", Comment = "我是注释" });
            listtableContent.Add(new tableContent() { ColumnName = "id", DataType = "int", Comment = "我是注释" });
            listtableContent.Add(new tableContent() { ColumnName = "birthday", DataType = "date", Comment = "我是注释" });

            StringBuilder sbClass = new StringBuilder(5000);
            //添加类名
            sbClass.Append("public class " + tableName + "cls" + "\n{\n");
            //循环添加列
            int count = 1;
            foreach (tableContent obj in listtableContent)
            {
                
                string datatype = Function.GetDataTypeFromOracleType(obj.DataType);
                sbClass.Append(string.Format("\tprivate {1} {0};\n\n", obj.ColumnName, datatype));
                //添加注释
                sbClass.Append("\t/// <summary>\n");
                sbClass.Append(string.Format("\t/// {0}\n", obj.Comment));
                sbClass.Append("\t/// </summary>\n");


                //sbClass.Append(string.Format("public {2} {1} { get => {0}; set => {0} = value; }\n\n", obj.ColumnName, Function.GetFirstUpperCharacter(obj.ColumnName), datatype));
                sbClass.Append(string.Format("\tpublic {0} {1}\n", datatype, Function.GetFirstUpperCharacter(obj.ColumnName)));
                sbClass.Append("\t{\n");
                sbClass.Append(string.Format("\t\tget => {0}; set => {0} = value;\n", obj.ColumnName));
                sbClass.Append("\t}\n");

                this.prgData.Invoke((Action)(() => prgData.Value = count * 100 / listtableContent.Count));
                count++;

            }
            //添加结束表机
            sbClass.Append("}");
            //重置进度条
            this.prgData.Invoke((Action)(() => prgData.Value = 0));
            return sbClass.ToString();

        }


        /// <summary>
        /// 获取表内容实体
        /// </summary>
        /// <returns></returns>
        private List<tableContent> GetTableContentObjects(string tableName)
        {
            string connstr = "data source=192.168.1.1/orcl;User Id=abc;Password=abc;";
            string sql = @"select t1.column_name,data_type,data_default,nullable,comments from (
                            select table_name, column_name, data_type, data_default, nullable from user_tab_cols where Table_Name = 'T_POL_CUSTOMER_NEW'
                                )t1
                            RIGHT JOIN
                            (   
                                select column_name, comments from user_col_comments where Table_Name = '{0}'
                            )t2
                            on t1.column_name = t2.column_name; ";
            sql = string.Format(sql, tableName);
            using (OracleConnection conn = new OracleConnection(connstr))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.CommandText = sql;
                    //cmd.Parameters.AddRange(parameters);
                    OracleDataReader reader = cmd.ExecuteReader();
                    List<tableContent> list = new List<tableContent>();
                    while (reader.Read())
                    {
                        tableContent obj = new tableContent();

                        obj.ColumnName = reader.GetString(0);
                        obj.DataType = reader.GetString(1);
                        obj.IsNullable = reader.GetBoolean(2);
                        obj.Comment = reader.GetString(3);

                        list.Add(obj);
                    }
                    return list;
                }
            }
        }

        private void txtTableName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnGenerate.PerformClick();
            }
        }
    }
}
