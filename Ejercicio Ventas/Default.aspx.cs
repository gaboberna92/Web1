using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : Page
{
    private List<Venta> Ventas;
    private int Pagina;
    protected void Page_Load(object sender, EventArgs e)
    {
        try {
            string cookie = Request.Cookies.Get("pagina").Value;
            Pagina = Convert.ToInt32(cookie);
        } catch {
            Pagina = 0;
        }
        
        if (!IsPostBack)
        {

            Ventas = new List<Venta>();
            CargarVentas();

        }
    }

    private void CargarVentas()
    {
        DAL acceso = new DAL();
        Ventas = acceso.obtenerVentas(Pagina);

        Response.Cookies.Add(new HttpCookie("pagina", Pagina.ToString()));
        GridView1.DataSource = Ventas;
        GridView1.DataBind();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Pagina > 0)
        {
            Pagina --;
        }

        CargarVentas();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
      
        Pagina ++;

        CargarVentas();
    }
}

public class Venta
{
    public string Transaccion { get; set; }
    public string Producto { get; set; }
    public string Tipo { get; set; }
    public string Monto { get; set; }
    public string Categoria { get; set; }
    public string Fecha { get; set; }
    public string Tienda { get; set; }
}

public class DAL
{

    SqlCommand oCommand;
    SqlConnection oConexionDB;

    public DAL()
    {
        string connectionString = @"Data Source=.;Initial Catalog=Ejercicio;Integrated Security=True;Encrypt=False";
        oConexionDB = new SqlConnection(connectionString);
    }

    public List<Venta> obtenerVentas(int pagina)
    {
        List<Venta> Ventas = new List<Venta>();

        oCommand = new SqlCommand("Obtener_Ventas_SP", oConexionDB);
        oCommand.CommandType = CommandType.StoredProcedure;
        oCommand.Parameters.AddWithValue("@pagina", pagina);

        oConexionDB.Open();

        using (SqlDataReader reader = oCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                Venta venta = new Venta();

                venta.Transaccion = reader["transaccion"].ToString();
                venta.Producto = reader["Producto"].ToString();
                venta.Tipo = reader["Tipo"].ToString();
                venta.Monto = reader["Monto"].ToString();
                venta.Monto = reader["Monto"].ToString();
                venta.Categoria = reader["Categoría"].ToString();
                venta.Fecha = reader["Fecha"].ToString();
                venta.Tienda = reader["Tienda"].ToString();

                Ventas.Add(venta);
            }
        }

        oConexionDB.Close();
        return Ventas;
    }


}