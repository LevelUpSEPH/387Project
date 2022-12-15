using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ResMart
{
    public partial class Stocks : Form
    {
        public Stocks()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Ege Sefertaş\Documents\ResMartDb.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Stocks_Load(object sender, EventArgs e)
        {
            Populate();
        }
        private void Populate()
        {
            con.Open();
            String query = "select * from StockTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var dataSet = new DataSet();
            da.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || product.Text == "" || price.Text == "" || stock.Text == "")
                MessageBox.Show("Missing Information");
            else
            {
                try
                {
                    con.Open();
                    String sql = "insert into StockTbl (product_id, product, price, stock) values (" + id.Text + ",'" + product.Text + "'," + price.Text + "," + stock.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Added");
                    con.Close();
                    Populate();
                }catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                };
            }
        }

        private void button1_Click(object sender, EventArgs e) // Remove button
        {
            if (id.Text == "")
                MessageBox.Show("Nothing to remove");
            else {
                try
                {
                    con.Open();
                    String query = "delete from StockTbl where product_id=" + id.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Removed.");
                    con.Close();
                    Populate();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                }
        }

        private void button3_Click(object sender, EventArgs e) // Update button
        {
            if (id.Text == "" || product.Text == "" || price.Text == "" || stock.Text == "")
                MessageBox.Show("Missing Information");
            else
            {
                try
                {
                    con.Open();
                    String sql = "update StockTbl set product_id = " + id.Text + ", product = " + product.Text + ", price = " + price.Text + ", stock = " + stock.Text + "where product_id = " + id.Text;
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succesfully Updated");
                    con.Close();
                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                };
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellEventArgs e) // Not working for some reason
        {
            id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            product.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            price.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            stock.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}