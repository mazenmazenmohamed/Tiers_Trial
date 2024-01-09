using BusineesLogicLayer.Entities;
using BusineesLogicLayer.EntityLists;
using BusineesLogicLayer.EntityManagers;
using System.Diagnostics;
using System.Windows.Forms;

namespace NorthWind_WinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //AllocConsole();
            InitializeComponent();
        }
        // [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        // private static extern bool AllocConsole();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        ProductList prds;
        BindingSource prdBindingSource;
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                prds = ProductManager.SelectAllProducts();
                prdBindingSource = new BindingSource(prds, "");
                this.dataGridView1.DataSource = prdBindingSource;
                prdBindingSource.AddingNew += (sender, e) =>
                e.NewObject = new Product() { State = EntityState.Added };
            }


            catch { }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                // Add a new row to the BindingSource
                Product newProduct = new Product()
                {
                    ProductID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["ProductID"].Value),
                    ProductName = Convert.ToString(this.dataGridView1.CurrentRow.Cells["ProductName"].Value),
                    SupplierID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["SupplierID"].Value),
                    CategoryID = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["CategoryID"].Value),
                    QuantityPerUnit = Convert.ToString(this.dataGridView1.CurrentRow.Cells["QuantityPerUnit"].Value),
                    UnitPrice = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells["UnitPrice"].Value),
                    UnitsInStocks = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells["UnitsInStocks"].Value),
                    UnitsInOrder = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells["UnitsInOrder"].Value),
                    ReorderLevel = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells["ReorderLevel"].Value),
                    Discontinued = Convert.ToBoolean(this.dataGridView1.CurrentRow.Cells["Discontinued"].Value)

                };


                prdBindingSource.Add(newProduct);
                prdBindingSource.MoveLast();


                // Insert the new data into the database
                ProductManager.InsertProduct
                    (
                    Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["ProductID"].Value),
                    Convert.ToString(this.dataGridView1.CurrentRow.Cells["ProductName"].Value),
                    Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["SupplierID"].Value),
                    Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["CategoryID"].Value),
                    Convert.ToString(this.dataGridView1.CurrentRow.Cells["QuantityPerUnit"].Value),
                    Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells["UnitPrice"].Value),
                    Convert.ToInt16(this.dataGridView1.CurrentRow.Cells["UnitsInStocks"].Value),
                    Convert.ToInt16(this.dataGridView1.CurrentRow.Cells["UnitsInOrder"].Value),
                    Convert.ToInt16(this.dataGridView1.CurrentRow.Cells["ReorderLevel"].Value),
                    Convert.ToBoolean(this.dataGridView1.CurrentRow.Cells["Discontinued"].Value)
                    );


                // Reload the data from the database
                prds = ProductManager.SelectAllProducts();
                prdBindingSource = new BindingSource(prds, "");
                this.dataGridView1.DataSource = prdBindingSource;
            }


            catch { }
        }

        private void My1stApp_Load(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["ProductID"].Value);

                ProductManager.DeleteProductByID(id);

                // Refresh data by resetting the DataSource
                prds = ProductManager.SelectAllProducts();
                foreach (Product p in prds) { Console.WriteLine(p.ProductID); }
                prdBindingSource = new BindingSource(prds, "");
                this.dataGridView1.DataSource = prdBindingSource;
            }
            catch { }
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prds = ProductManager.SelectAllProducts();
            //foreach (Product p in prds) { Console.WriteLine(p.ProductID); }
            var pl=prds.OrderBy(x=>x.ProductID).ToList();
            prdBindingSource = new BindingSource(pl, "");
            this.dataGridView1.DataSource = prdBindingSource;
        }
    }
}