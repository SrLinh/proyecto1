// Permite usar el modelo Product. 
using SistemaProductosGUI.Models;

// Permite usar el servicio ProductService.
using SistemaProductosGUI.Services;

// Indica que esta clase pertenece a la carpeta logica Forms.
namespace SistemaProductosGUI.Forms;

// MainForm hereda de Form, por eso representa una ventana de Windows Forms.
public class MainForm : Form
{
    // Servicio que maneja la logica de productos.
    private readonly ProductService service = new();

    // Etiquetas que describen los campos.
    private readonly Label lblCode = new() { Text = "Codigo:", Left = 20, Top = 25, Width = 100 };
    private readonly Label lblName = new() { Text = "Nombre:", Left = 20, Top = 65, Width = 100 };
    private readonly Label lblPrice = new() { Text = "Precio:", Left = 20, Top = 105, Width = 100 };
    private readonly Label lblStock = new() { Text = "Existencia:", Left = 20, Top = 145, Width = 100 };
    private readonly Label lblSearch = new() { Text = "Buscar:", Left = 20, Top = 185, Width = 100 };

    // Cajas de texto para capturar datos.
    private readonly TextBox txtCode = new() { Left = 130, Top = 20, Width = 220 };
    private readonly TextBox txtName = new() { Left = 130, Top = 60, Width = 220 };
    private readonly TextBox txtPrice = new() { Left = 130, Top = 100, Width = 220 };
    private readonly TextBox txtStock = new() { Left = 130, Top = 140, Width = 220 };
    private readonly TextBox txtSearch = new() { Left = 130, Top = 180, Width = 220 };

    // Botones de acciones CRUD.
    private readonly Button btnAdd = new() { Text = "Agregar", Left = 380, Top = 20, Width = 125 };
    private readonly Button btnUpdate = new() { Text = "Actualizar", Left = 380, Top = 60, Width = 125 };
    private readonly Button btnDelete = new() { Text = "Eliminar", Left = 380, Top = 100, Width = 125 };
    private readonly Button btnClear = new() { Text = "Limpiar", Left = 380, Top = 140, Width = 125 };

    // Tabla visual donde se muestran los productos.
    private readonly DataGridView dgvProducts = new()
    {
        Left = 20,
        Top = 230,
        Width = 760,
        Height = 300,
        ReadOnly = true,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        MultiSelect = false
    };

    // Constructor del formulario. Se ejecuta al crear la ventana.
    public MainForm() 
    {
        // Configura propiedades generales de la ventana.
        Text = "Sistema de productos";
        Width = 830;
        Height = 600;
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        // Agrega todos los controles visuales al formulario.
        Controls.AddRange(new Control[]
        {
            lblCode, lblName, lblPrice, lblStock, lblSearch,
            txtCode, txtName, txtPrice, txtStock, txtSearch,
            btnAdd, btnUpdate, btnDelete, btnClear,
            dgvProducts
        });

        // Conecta cada boton con su evento correspondiente.
        btnAdd.Click += BtnAdd_Click;
        btnUpdate.Click += BtnUpdate_Click;
        btnDelete.Click += BtnDelete_Click;
        btnClear.Click += BtnClear_Click;

        // Conecta la tabla con el evento que llena los campos al seleccionar una fila.
        dgvProducts.CellClick += DgvProducts_CellClick;

        // Cada vez que se escribe en buscar, se filtra la tabla.
        txtSearch.TextChanged += TxtSearch_TextChanged;

        // Carga los productos iniciales en la tabla.
        RefreshGrid();
    }

    // Evento del boton Agregar.
    private void BtnAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            // Lee y valida los datos escritos por el usuario.
            Product product = ReadProductFromForm();

            // Agrega el producto usando el servicio.
            service.Add(product);

            // Actualiza la tabla.
            RefreshGrid();

            // Limpia los campos.
            ClearForm();

            // Muestra mensaje de exito.
            MessageBox.Show("Producto agregado correctamente.");
        }
        catch (Exception ex)
        {
            // Muestra cualquier error de validacion o regla de negocio.
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Evento del boton Actualizar.
    private void BtnUpdate_Click(object? sender, EventArgs e)
    {
        try
        {
            Product product = ReadProductFromForm();
            service.Update(product);
            RefreshGrid();
            ClearForm();
            MessageBox.Show("Producto actualizado correctamente.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Evento del boton Eliminar.
    private void BtnDelete_Click(object? sender, EventArgs e)
    {
        try
        {
            // Valida que el codigo no este vacio.
            if (string.IsNullOrWhiteSpace(txtCode.Text))
                throw new Exception("Seleccione o escriba el codigo del producto a eliminar.");

            // Pide confirmacion antes de eliminar.
            DialogResult result = MessageBox.Show(
                "¿Esta seguro de eliminar este producto?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Si el usuario responde No, se cancela la accion.
            if (result == DialogResult.No)
                return;

            // Elimina el producto usando el servicio.
            service.Delete(txtCode.Text.Trim());

            // Refresca la tabla y limpia los campos.
            RefreshGrid();
            ClearForm();

            MessageBox.Show("Producto eliminado correctamente.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Evento del boton Limpiar.
    private void BtnClear_Click(object? sender, EventArgs e)
    {
        ClearForm();
    }

    // Evento que se ejecuta cuando se hace clic en una fila de la tabla.
    private void DgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        // Evita errores si se hace clic en el encabezado.
        if (e.RowIndex < 0)
            return;

        // Obtiene el producto seleccionado.
        Product? selected = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;

        // Si no se pudo convertir, se cancela.
        if (selected == null)
            return;

        // Copia los datos de la tabla a los campos.
        txtCode.Text = selected.Code;
        txtName.Text = selected.Name;
        txtPrice.Text = selected.Price.ToString();
        txtStock.Text = selected.Stock.ToString();
    }

    // Evento que filtra la tabla mientras el usuario escribe en el buscador.
    private void TxtSearch_TextChanged(object? sender, EventArgs e)
    {
        dgvProducts.DataSource = null;
        dgvProducts.DataSource = service.Search(txtSearch.Text);
    }

    // Lee los controles, valida datos y devuelve un objeto Product.
    private Product ReadProductFromForm()
    {
        // Valida codigo obligatorio.
        if (string.IsNullOrWhiteSpace(txtCode.Text))
            throw new Exception("El codigo es obligatorio.");

        // Valida nombre obligatorio.
        if (string.IsNullOrWhiteSpace(txtName.Text))
            throw new Exception("El nombre es obligatorio.");

        // Convierte el precio a decimal.
        if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            throw new Exception("El precio debe ser un numero mayor que cero.");

        // Convierte la existencia a entero.
        if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            throw new Exception("La existencia debe ser un numero entero mayor o igual que cero.");

        // Devuelve el producto construido con los datos capturados.
        return new Product
        {
            Code = txtCode.Text.Trim(),
            Name = txtName.Text.Trim(),
            Price = price,
            Stock = stock
        };
    }

    // Recarga la tabla con todos los productos.
    private void RefreshGrid()
    {
        dgvProducts.DataSource = null;
        dgvProducts.DataSource = service.GetAll();
    }

    // Limpia los campos del formulario.
    private void ClearForm()
    {
        txtCode.Clear();
        txtName.Clear();
        txtPrice.Clear();
        txtStock.Clear();
        txtSearch.Clear();
        txtCode.Focus();
    }
}
