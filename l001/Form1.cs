using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l001
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        void tableAll()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
            {
                try
                {
                    tableUsers.Rows.Clear();
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    //заполнение данных
                    cmd.CommandText = "select * from [Users]";

                    SqlDataReader reader = cmd.ExecuteReader();
                    int j = 0;
                    while (reader.Read())
                    {
                        tableUsers.Rows.Add();
                        tableUsers.Rows[j].Cells[0].Value = Convert.ToString(String.Format("{0}", reader[0]));
                        tableUsers.Rows[j].Cells[1].Value = Convert.ToString(String.Format("{0}", reader[1]));
                        tableUsers.Rows[j].Cells[2].Value = Convert.ToString(String.Format("{0}", reader[2]));
                        tableUsers.Rows[j].Cells[3].Value = Convert.ToString(String.Format("{0}", reader[3]));
                        tableUsers.Rows[j].Cells[4].Value = Convert.ToString(String.Format("{0}", reader[4]));
                        if(tableUsers.Rows[j].Cells[4].Value.ToString() == "True")
                        {
                            tableUsers.Rows[j].Cells[4].Value = "1";
                        }
                        else
                        {
                            tableUsers.Rows[j].Cells[4].Value = "0";
                        }
                        j++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
                finally
                {
                    con.Close();
                }



            }
        }

        private void tableUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add au = new Add();
            au.Visible = true;
            au.ShowInTaskbar = true;
            
         
        }

        private void tableUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //информация о пользователе
            try
            {
                if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
                {
                    String id = Convert.ToString(tableUsers.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[0].Value);
                    String Login = Convert.ToString(tableUsers.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[1].Value);
                    String Password = Convert.ToString(tableUsers.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[2].Value);
                    String Name = Convert.ToString(tableUsers.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[3].Value);
                    String Roled = Convert.ToString(tableUsers.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[4].Value);
                    this.Hide();
                    Read uu = new Read(id, Login, Password, Name, Roled);
                    uu.Visible = true;
                    uu.ShowInTaskbar = true;
                }
            }
            catch { }
        }

        private void tableUsers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //изменить
                if (e.ColumnIndex == 5)
                {
                    String id = Convert.ToString(tableUsers.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[0].Value);
                    String Login = Convert.ToString(tableUsers.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[1].Value);
                    String Password = Convert.ToString(tableUsers.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[2].Value);
                    String Name = Convert.ToString(tableUsers.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[3].Value);
                    String Roled = Convert.ToString(tableUsers.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[4].Value);
                    this.Hide();
                    Update uc = new Update(id, Login, Password, Name, Roled);
                    uc.Visible = true;
                   
                }
                //удалить
                if (e.ColumnIndex == 6)
                {
                    String id = Convert.ToString(tableUsers.Rows[Convert.ToInt32(e.RowIndex.ToString())].Cells[0].Value);

                    using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=I001;User ID=student;Password=Passw0rd"))
                    {
                        try
                        {

                            con.Open();
                            SqlCommand cmd = con.CreateCommand();
                            cmd.CommandText = "DELETE FROM Users where IDUser=@Id";
                            cmd.Parameters.AddWithValue(@"Id", id);
                            cmd.ExecuteScalar();
                            con.Close();
                            tableAll();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Convert.ToString(ex));
                        }
                    }

                }
            }
            catch { }
        }
    }
}
