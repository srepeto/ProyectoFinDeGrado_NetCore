using BancoSangre.Domain.Models;
using BancoSangre.Domain.Services;
using BancoSangre.EntityFramework;
using BancoSangre.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Syncfusion.UI.Xaml.ProgressBar;
using System.Collections.ObjectModel;

namespace BancoSangre.WPF
{

    public partial class MainWindow : Window
    {
        IDataServiceDonantes<Donante> donanteService = new DonanteDataService<Donante>(new BancoSangreDbContextFactory());
        IDataServiceDonaciones<Donacion> donacionService = new DonacionDataService<Donacion>(new BancoSangreDbContextFactory());

        Donante donanteSeleccionado = new Donante();
        Donante donanteToDelete = new Donante();
        Donacion donacionToDelete = new Donacion();
        Donacion donacionSeleccionada = new Donacion();

        bool insertarDonante = false;
        bool modificarDonante = false;
        bool insertarDonacion = false;
        bool modificarDonacion = false;

        public MainWindow()
        {
            InitializeComponent();
            RellenarTablaDonantes(donanteService.GetAllDonantes());
            RellenarTablaDonaciones(donacionService.GetAllDonaciones());
        }

        // DASHBOARD
        private async void cambio_tab(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            if (tabcontrol.SelectedIndex == 2)
            {
                resetCirculars();

                for (int i = 0; i < donacionService.getCantidadSangre("A", "+")*100/getTotalCantidades(); i++)
                {
                    await Task.Delay(1);
                    circApos.ProgressContent = circApos.Progress + "%";
                    circApos.Progress++;
                }
                comprobarEstadoCantidad(donacionService.getCantidadSangre("A", "+") * 100 / getTotalCantidades(), circApos);

                for (int i = 0; i < donacionService.getCantidadSangre("A", "-") * 100 / getTotalCantidades(); i++)
                {
                    await Task.Delay(1);
                    circAneg.ProgressContent = circAneg.Progress + "%";
                    circAneg.Progress++;
                }
                comprobarEstadoCantidad(donacionService.getCantidadSangre("A", "-") * 100 / getTotalCantidades(), circAneg);

                for (int i = 0; i < donacionService.getCantidadSangre("B", "+") * 100 / getTotalCantidades(); i++)
                {
                    await Task.Delay(1);
                    circBpos.ProgressContent = circBpos.Progress + "%";
                    circBpos.Progress++;
                }
                comprobarEstadoCantidad(donacionService.getCantidadSangre("B", "+") * 100 / getTotalCantidades(), circBpos);

                for (int i = 0; i < donacionService.getCantidadSangre("B", "-") * 100 / getTotalCantidades(); i++)
                {
                    await Task.Delay(1);
                    circBneg.ProgressContent = circBneg.Progress + "%";
                    circBneg.Progress++;
                }
                comprobarEstadoCantidad(donacionService.getCantidadSangre("B", "-") * 100 / getTotalCantidades(), circBneg);

                for (int i = 0; i < donacionService.getCantidadSangre("AB", "+") * 100 / getTotalCantidades(); i++)
                {
                    await Task.Delay(1);
                    circABpos.ProgressContent = circABpos.Progress + "%";
                    circABpos.Progress++;
                }
                comprobarEstadoCantidad(donacionService.getCantidadSangre("AB", "+") * 100 / getTotalCantidades(), circABpos);

                for (int i = 0; i < donacionService.getCantidadSangre("AB", "-") * 100 / getTotalCantidades(); i++)
                {
                    await Task.Delay(1);
                    circABneg.ProgressContent = circABneg.Progress + "%";
                    circABneg.Progress++;
                }
                comprobarEstadoCantidad(donacionService.getCantidadSangre("AB", "-") * 100 / getTotalCantidades(), circABneg);

                for (int i = 0; i < donacionService.getCantidadSangre("0", "+") * 100 / getTotalCantidades(); i++)
                {
                    await Task.Delay(1);
                    circCeroPos.ProgressContent = circCeroPos.Progress + "%";
                    circCeroPos.Progress++;
                }
                comprobarEstadoCantidad(donacionService.getCantidadSangre("0", "+") * 100 / getTotalCantidades(), circCeroPos);

                for (int i = 0; i < donacionService.getCantidadSangre("0", "-") * 100 / getTotalCantidades(); i++)
                {
                    await Task.Delay(1);
                    circCeroNeg.ProgressContent = circCeroNeg.Progress + "%";
                    circCeroNeg.Progress++;
                }
                comprobarEstadoCantidad(donacionService.getCantidadSangre("0", "-") * 100 / getTotalCantidades(), circCeroNeg);
            }
        }

        private void resetCirculars ()
        {
            circApos.Progress = 0;
            circApos.ProgressContent = "0%";
            circAneg.Progress = 0;
            circAneg.ProgressContent = "0%";
            circBpos.Progress = 0;
            circBpos.ProgressContent = "0%";
            circBneg.Progress = 0;
            circBneg.ProgressContent = "0%";
            circABpos.Progress = 0;
            circABpos.ProgressContent = "0%";
            circABneg.Progress = 0;
            circABneg.ProgressContent = "0%";
            circCeroPos.Progress = 0;
            circCeroPos.ProgressContent = "0%";
            circCeroNeg.Progress = 0;
            circCeroNeg.ProgressContent = "0%";
        }

        private int getTotalCantidades()
        {
            return donacionService.getCantidadSangre("A", "+") + donacionService.getCantidadSangre("A", "-") +
                donacionService.getCantidadSangre("B", "+") + donacionService.getCantidadSangre("B", "-") +
                donacionService.getCantidadSangre("AB", "+") + donacionService.getCantidadSangre("AB", "-") +
                donacionService.getCantidadSangre("0", "+") + donacionService.getCantidadSangre("0", "-");
        }

        private void comprobarEstadoCantidad(int cantidad, SfCircularProgressBar circular)
        {
            if (cantidad > 10)
                circular.ProgressColor = new SolidColorBrush(Color.FromRgb(0, 124, 238));
            if (cantidad < 11 && cantidad > 5)
                circular.ProgressColor = new SolidColorBrush(Color.FromRgb(255, 147, 0));
            if (cantidad < 6 && cantidad >= 0)
                circular.ProgressColor = new SolidColorBrush(Color.FromRgb(238, 68, 0));
        }

        private void botDonReg_Click(object sender, RoutedEventArgs e)
        {
            gridCantidades.Visibility = Visibility.Collapsed;
            gridDonRegulares.Visibility = Visibility.Visible;
            rectCantidades.Visibility = Visibility.Collapsed;
            rectDonReg.Visibility = Visibility.Visible;
            botDonReg.FontWeight = FontWeights.Bold;
            botCantidades.FontWeight = FontWeights.Normal;
            botDonReg.Foreground = new SolidColorBrush(Color.FromRgb(187, 72, 72));
            botCantidades.Foreground = new SolidColorBrush(Color.FromRgb(121, 121, 121));
        }

        private void botCantidades_Click(object sender, RoutedEventArgs e)
        {
            gridDonRegulares.Visibility = Visibility.Collapsed;
            gridCantidades.Visibility = Visibility.Visible;
            rectCantidades.Visibility = Visibility.Visible;
            rectDonReg.Visibility = Visibility.Collapsed;
            botCantidades.FontWeight = FontWeights.Bold;
            botDonReg.FontWeight = FontWeights.Normal;
            botCantidades.Foreground = new SolidColorBrush(Color.FromRgb(187, 72, 72));
            botDonReg.Foreground = new SolidColorBrush(Color.FromRgb(121, 121, 121));
        }

        // CONTROLES VENTANA
        private void window_click(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Minimizar_click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DialogHost_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }

        // COMPATIBILIDAD
        private void botCompat_Click(object sender, RoutedEventArgs e)
        {
            string gsrh = ((ComboBoxItem)comboGs.SelectedItem).Content.ToString() + ((ComboBoxItem)comboRh.SelectedItem).Content.ToString();
            var list = new ObservableCollection<DonantesCompatibles>();
            switch (gsrh) {
                case "A+":
                    list.Add(new DonantesCompatibles() { dona = "A+", recibe = "A+" });
                    list.Add(new DonantesCompatibles() { dona = "AB+", recibe = "A-" });
                    list.Add(new DonantesCompatibles() { dona = "", recibe = "0+" });
                    list.Add(new DonantesCompatibles() { dona = "", recibe = "0-" });
                    this.CompatDG.ItemsSource = list;
                    break;
                case "A-":
                    list.Add(new DonantesCompatibles() { dona = "A+", recibe = "0-" });
                    list.Add(new DonantesCompatibles() { dona = "A-", recibe = "A-" });
                    list.Add(new DonantesCompatibles() { dona = "AB+", recibe = "" });
                    list.Add(new DonantesCompatibles() { dona = "AB-", recibe = "" });
                    this.CompatDG.ItemsSource = list;
                    break;
                case "B+":
                    list.Add(new DonantesCompatibles() { dona = "B+", recibe = "B+" });
                    list.Add(new DonantesCompatibles() { dona = "AB+", recibe = "B-" });
                    list.Add(new DonantesCompatibles() { dona = "", recibe = "0+" });
                    list.Add(new DonantesCompatibles() { dona = "", recibe = "0-" });
                    this.CompatDG.ItemsSource = list;
                    break;
                case "B-":
                    list.Add(new DonantesCompatibles() { dona = "B+", recibe = "B-" });
                    list.Add(new DonantesCompatibles() { dona = "B-", recibe = "0-" });
                    list.Add(new DonantesCompatibles() { dona = "AB+", recibe = "" });
                    list.Add(new DonantesCompatibles() { dona = "AB-", recibe = "" });
                    this.CompatDG.ItemsSource = list;
                    break;
                case "AB+":
                    list.Add(new DonantesCompatibles() { dona = "AB+", recibe = "Todos" });
                    this.CompatDG.ItemsSource = list;
                    break;
                case "AB-":
                    list.Add(new DonantesCompatibles() { dona = "AB+", recibe = "A-" });
                    list.Add(new DonantesCompatibles() { dona = "AB-", recibe = "B-" });
                    list.Add(new DonantesCompatibles() { dona = "", recibe = "AB-" });
                    list.Add(new DonantesCompatibles() { dona = "", recibe = "0-" });
                    this.CompatDG.ItemsSource = list;
                    break;
                case "0+":
                    list.Add(new DonantesCompatibles() { dona = "A+", recibe = "0+" });
                    list.Add(new DonantesCompatibles() { dona = "B+", recibe = "0-" });
                    list.Add(new DonantesCompatibles() { dona = "AB+", recibe = "" });
                    list.Add(new DonantesCompatibles() { dona = "0+", recibe = "" });
                    this.CompatDG.ItemsSource = list;
                    break;
                case "0-":
                    list.Add(new DonantesCompatibles() { dona = "Todos", recibe = "0-" });
                    this.CompatDG.ItemsSource = list;
                    break;
            }
        }

        // CONTROLES GESTIÓN DATOS
        private void botDonantes_Click(object sender, RoutedEventArgs e)
        {
            activarGridDonantes();
        }

        private void botDonaciones_Click(object sender, RoutedEventArgs e)
        {
            activarGridDonaciones();
        }

        private void activarGridGestionDatos()
        {
            grid_GestionDatos.Visibility = Visibility.Visible;
            grid_Donaciones.Visibility = Visibility.Collapsed;
            grid_Donantes.Visibility = Visibility.Collapsed;
        }

        private void activarGridDonantes()
        {
            grid_GestionDatos.Visibility = Visibility.Collapsed;
            grid_Donaciones.Visibility = Visibility.Collapsed;
            grid_Donantes.Visibility = Visibility.Visible;
        }

        private void activarGridDonaciones()
        {
            grid_GestionDatos.Visibility = Visibility.Collapsed;
            grid_Donaciones.Visibility = Visibility.Visible;
            grid_Donantes.Visibility = Visibility.Collapsed;
        }

        private void botAtras_Click(object sender, RoutedEventArgs e)
        {
            activarGridGestionDatos();
        }

        private void obtenerDatosDonante()
        {
            donanteSeleccionado.Dni = fieldDni.Text;
            donanteSeleccionado.Nombre = fieldNombre.Text;
            donanteSeleccionado.Direccion = fieldDireccion.Text;
            donanteSeleccionado.Telefono = fieldTelf.Text;
            donanteSeleccionado.FechaNacimiento = datePicker.SelectedDate.GetValueOrDefault();
            donanteSeleccionado.Gruposanguineo = ((ComboBoxItem)comboDatosGs.SelectedItem).Content.ToString();
            donanteSeleccionado.Factorrh = ((ComboBoxItem)comboDatosRh.SelectedItem).Content.ToString();
        }

        private void resetCamposDonantes ()
        {
            fieldDni.Text = "";
            fieldNombre.Text = "";
            fieldDireccion.Text = "";
            fieldTelf.Text = "";
            datePicker.SelectedDate = null;
            comboDatosGs.SelectedValue = "";
            comboDatosRh.SelectedValue = "";
        }

        private void obtenerDatosDonacion()
        {
            donacionSeleccionada.Id = fieldId.Text;
            donacionSeleccionada.Donantefk = fieldDonantefk.Text;
            donacionSeleccionada.Fecha = datePickerDonacion.SelectedDate.GetValueOrDefault();
            donacionSeleccionada.Cantidad = int.Parse(fieldCantidad.Text);
        }

        private void resetCamposDonaciones()
        {
            fieldId.Text = "";
            fieldDonantefk.Text = "";
            datePickerDonacion.SelectedDate = null;
            fieldCantidad.Text = "";
        }

        private void borderClearSelection_Click(object sender, MouseButtonEventArgs e)
        {
            if (grid_Donantes.Visibility == Visibility.Visible)
                DonanteDG.SelectedItem = null;
            if (grid_Donaciones.Visibility == Visibility.Visible)
                DonacionesDG.SelectedItem = null;
        }

        // GESTIÓN DATOS DONANTES
        private void RellenarTablaDonantes(List<Donante> listaDonantes)
        {
            DonanteDG.ItemsSource = listaDonantes;
        }

        private void botInsDonante_Click(object sender, RoutedEventArgs e)
        {
            resetCamposDonantes();
            botAceptarDonantes.Content = "Insertar";
            insertarDonante = true;
            fieldDni.IsEnabled = true;
            dialogDonantes.IsOpen = true;
        }

        private void botModificarDonante_Click(object s, MouseButtonEventArgs e)
        {
            donanteSeleccionado = (s as FrameworkElement).DataContext as Donante;
            fieldDni.Text = donanteSeleccionado.Dni;
            fieldNombre.Text = donanteSeleccionado.Nombre;
            fieldDireccion.Text = donanteSeleccionado.Direccion;
            fieldTelf.Text = donanteSeleccionado.Telefono;
            datePicker.SelectedDate = donanteSeleccionado.FechaNacimiento;
            comboDatosGs.SelectedValue = donanteSeleccionado.Gruposanguineo;
            comboDatosRh.SelectedValue = donanteSeleccionado.Factorrh;

            botAceptarDonantes.Content = "Modificar";
            fieldDni.IsEnabled = false;
            modificarDonante = true;
            dialogDonantes.IsOpen = true;

        }

        private void botElimDonante_Click(object s, RoutedEventArgs e)
        {
            donanteToDelete = (s as FrameworkElement).DataContext as Donante;
            dialogConfirmacion.IsOpen = true;
        }

        private void botConfirmacion_Click(object sender, RoutedEventArgs e)
        {
            List<Donacion> listaDonaciones= donacionService.GetDonacionesByDni(donanteToDelete.Dni);
            foreach (Donacion donacion in listaDonaciones)
            {
                donacionService.DeleteDonacion(donacion.Id);
            }
            donanteService.DeleteDonante(donanteToDelete.Dni);
            RellenarTablaDonaciones(donacionService.GetAllDonaciones());
            mantenerBusquedaDonantes();
            MessageBox.Show("Se ha eliminado correctamente");
            dialogConfirmacion.IsOpen = false;
        }

        private void botCancelar_Click(object sender, RoutedEventArgs e)
        {
            dialogConfirmacion.IsOpen = false;
        }

        private void botAceptarDonantes_Click(object sender, RoutedEventArgs e)
        {
            ErrorsControl errosControl = new ErrorsControl(fieldDni.Text, fieldNombre.Text, fieldTelf.Text, datePicker.SelectedDate.GetValueOrDefault());

            if (errosControl.validarCamposDonante())
            {
                if (insertarDonante)
                {
                    if (!errosControl.donanteExiste(fieldDni.Text))
                    {
                        fieldDni.IsEnabled = true;
                        obtenerDatosDonante();
                        donanteService.CreateDonante(donanteSeleccionado);
                        mantenerBusquedaDonantes();
                        MessageBox.Show("Se ha insertado correctamente");
                        insertarDonante = false;
                        modificarDonante = false;
                        dialogDonantes.IsOpen = false;
                    } else
                    {
                        MessageBox.Show("Ya existe un donante con DNI '" + fieldDni.Text + "'");
                    }
                }
                if (modificarDonante)
                {
                    obtenerDatosDonante();
                    donanteService.UpdateDonante(fieldDni.Text, donanteSeleccionado);
                    mantenerBusquedaDonantes();
                    MessageBox.Show("Se ha modificado correctamente");
                    insertarDonante = false;
                    modificarDonante = false;
                    dialogDonantes.IsOpen = false;
                }
            }
        }

        private void botCancDonantes_Click(object sender, RoutedEventArgs e)
        {
            insertarDonante = false;
            modificarDonante = false;
            dialogDonantes.IsOpen = false;
        }

        private void botClearFieldSearchDonantes_Click(object sender, RoutedEventArgs e)
        {
            fieldBuscar.Text = "";
        }

        private void botClearFiltersDonantes_Click(object sender, RoutedEventArgs e)
        {
            DonanteDG.ClearFilters();
            DonanteDG.SortColumnDescriptions.Clear();
            DonanteDG.SelectedItem = null;
        }

        private void mantenerBusquedaDonantes ()
        {
            if (fieldBuscar.Text.Length == 0)
            {
                RellenarTablaDonantes(donanteService.GetAllDonantes());
            }
            else
            {
                buscarDonante();
            }
        }

        // BUSCADOR DONANTES
        private void fieldBuscar_textChanged(object sender, TextChangedEventArgs e)
        {
            buscarDonante();
        }

        private void buscarDonante()
        {
            string busqueda = fieldBuscar.Text.Trim();
            string signo = "";
            Boolean encontrado = false;

            List<string> listaGS = new List<string>();
            List<string> listaRH = new List<string>();

            listaGS.Add("A");
            listaGS.Add("B");
            listaGS.Add("AB");
            listaGS.Add("0");
            listaRH.Add("+");
            listaRH.Add("-");

            if (string.IsNullOrEmpty(busqueda))
            {
                encontrado = true;
                RellenarTablaDonantes(donanteService.GetAllDonantes());
            }
            else
            {
                foreach (string rh in listaRH)
                {
                    if (busqueda.Equals(rh))
                    {
                        encontrado = true;
                        RellenarTablaDonantes(donanteService.GetSearchDonantes(busqueda));
                    }
                }
                if (!encontrado)
                {
                    foreach (string gs in listaGS)
                    {
                        if (busqueda.Equals(gs))
                        {
                            encontrado = true;
                            RellenarTablaDonantes(donanteService.GetSearchDonantesGSRH(busqueda, signo));
                        }
                        else
                        {
                            foreach (string rh in listaRH)
                            {
                                if (busqueda.Contains(rh))
                                {
                                    signo = rh;
                                    busqueda = busqueda.Replace(rh, "");
                                    encontrado = true;
                                    RellenarTablaDonantes(donanteService.GetSearchDonantesGSRH(busqueda, signo));
                                }
                            }
                        }
                    }
                }
            }

            if (encontrado == false)
                RellenarTablaDonantes(donanteService.GetSearchDonantes(busqueda));
        }

        // GESTIÓN DATOS DONACIONES
        private void RellenarTablaDonaciones(List<Donacion> listaDonantes)
        {
            DonacionesDG.ItemsSource = listaDonantes;
        }

        private void botInsDonacion_Click(object sender, RoutedEventArgs e)
        {
            resetCamposDonaciones();
            botAceptarDonaciones.Content = "Insertar";
            fieldId.Text = (donacionService.getUltimoId() + 1).ToString();
            fieldId.IsEnabled = false;
            insertarDonacion = true;
            dialogDonaciones.IsOpen = true;
        }

        private void botModificarDonacion_Click(object sender, MouseButtonEventArgs e)
        {
            donacionSeleccionada = (sender as FrameworkElement).DataContext as Donacion;
            fieldId.Text = donacionSeleccionada.Id;
            fieldDonantefk.Text = donacionSeleccionada.Donantefk;
            datePickerDonacion.SelectedDate = donacionSeleccionada.Fecha;
            fieldCantidad.Text = donacionSeleccionada.Cantidad.ToString();

            botAceptarDonaciones.Content = "Modificar";
            fieldId.IsEnabled = false;
            modificarDonacion = true;
            dialogDonaciones.IsOpen = true;
        }

        private void botElimDonacion_Click(object sender, MouseButtonEventArgs e)
        {
            donacionToDelete = (sender as FrameworkElement).DataContext as Donacion;
            dialogConfirmacionDonacion.IsOpen = true;
        }

        private void botConfirmacionDonacion_Click(object sender, RoutedEventArgs e)
        {
            donacionService.DeleteDonacion(donacionToDelete.Id);
            RellenarTablaDonaciones(donacionService.GetAllDonaciones());
            MessageBox.Show("Se ha eliminado correctamente");
            mantenerBusquedaDonaciones();
            dialogConfirmacionDonacion.IsOpen = false;
        }

        private void botCancelarDonacion_Click(object sender, RoutedEventArgs e)
        {
            dialogConfirmacionDonacion.IsOpen = false;
        }

        private void botAceptarDonaciones_Click(object sender, RoutedEventArgs e)
        {
            ErrorsControl errorsControl = new ErrorsControl(fieldDonantefk.Text, datePickerDonacion.SelectedDate.GetValueOrDefault(), fieldCantidad.Text);

            if (errorsControl.validarCamposDonacion())
            {
                if (insertarDonacion)
                {
                    if (errorsControl.donanteExiste(fieldDonantefk.Text))
                    {
                        obtenerDatosDonacion();
                        donacionService.CreateDonacion(donacionSeleccionada);
                        RellenarTablaDonaciones(donacionService.GetAllDonaciones());
                        mantenerBusquedaDonaciones();
                        MessageBox.Show("Se ha insertado correctamente");
                        insertarDonacion = false;
                        modificarDonacion = false;
                        dialogDonaciones.IsOpen = false;
                    } else
                    {
                        MessageBox.Show("No existe ningún donante con DNI '" + fieldDonantefk.Text + "'");
                    }
                }
                if (modificarDonacion)
                {
                    if (errorsControl.donanteExiste(fieldDonantefk.Text))
                    {
                        obtenerDatosDonacion();
                        donacionService.UpdateDonacion(fieldId.Text, donacionSeleccionada);
                        mantenerBusquedaDonaciones();
                        MessageBox.Show("Se ha modificado correctamente");
                        insertarDonacion = false;
                        modificarDonacion = false;
                        dialogDonaciones.IsOpen = false;
                    } else
                    {
                        MessageBox.Show("No existe ningún donante con DNI '" + fieldDonantefk.Text + "'");
                    }
                }
            }
        }

        private void botCancDonaciones_Click(object sender, RoutedEventArgs e)
        {
            insertarDonacion = false;
            modificarDonacion = false;
            dialogDonaciones.IsOpen = false;
        }

        private void botClearFieldSearchDonaciones_Click(object sender, RoutedEventArgs e)
        {
            fieldBuscarDonacion.Text = "";
        }

        private void botClearFiltersDonaciones_Click(object sender, RoutedEventArgs e)
        {
            DonacionesDG.ClearFilters();
            DonacionesDG.SortColumnDescriptions.Clear();
        }

        private void mantenerBusquedaDonaciones ()
        {
            if (fieldBuscarDonacion.Text.Length == 0)
            {
                RellenarTablaDonaciones(donacionService.GetAllDonaciones());
            }
            else
            {
                string busqueda = fieldBuscarDonacion.Text;
                RellenarTablaDonaciones(donacionService.GetSearchDonaciones(busqueda));
            }
        }

        // BUSCADOR DONACIONES
        private void fieldBuscarDonacion_TextChanged(object sender, TextChangedEventArgs e)
        {
            string busqueda = fieldBuscarDonacion.Text;
            RellenarTablaDonaciones(donacionService.GetSearchDonaciones(busqueda));
        }


        // REPORTES
        private void botPDF_Click(object sender, RoutedEventArgs e)
        {

            string contenido = ((ComboBoxItem)comboRepContenido.SelectedItem).Content.ToString();

            if (contenido.Equals("Donantes"))
            {
                string filtro = (panelRadiosDonantes.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value)).Content.ToString();
                string gs = ((ComboBoxItem)comboRepDonantesGs.SelectedItem).Content.ToString();
                string rh = ((ComboBoxItem)comboRepDonantesRh.SelectedItem).Content.ToString();

                switch (filtro)
                {
                    case "Completo":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                    case "Grupo sanguíneo":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            BoldReports.Windows.ReportParameter parameterGS = new BoldReports.Windows.ReportParameter();
                            parameterGS.Name = "GS";
                            parameterGS.Values = new List<string>() { gs };
                            parameters.Add(parameterGS);
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                    case "Factor RH":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            BoldReports.Windows.ReportParameter parameterRH = new BoldReports.Windows.ReportParameter();
                            parameterRH.Name = "RH";
                            parameterRH.Values = new List<string>() { rh };
                            parameters.Add(parameterRH);
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                    case "GS, RH":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            BoldReports.Windows.ReportParameter parameterGS = new BoldReports.Windows.ReportParameter();
                            parameterGS.Name = "GS";
                            parameterGS.Values = new List<string>() { gs };
                            parameters.Add(parameterGS);
                            BoldReports.Windows.ReportParameter parameterRH = new BoldReports.Windows.ReportParameter();
                            parameterRH.Name = "RH";
                            parameterRH.Values = new List<string>() { rh };
                            parameters.Add(parameterRH);
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                }
                comprobarPathReporte(contenido, filtro);
            }

            if (contenido.Equals("Donaciones"))
            {
                string filtro = (panelRadiosDonaciones.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value)).Content.ToString();
                string gs = ((ComboBoxItem)comboRepDonacionesGs.SelectedItem).Content.ToString();
                string rh = ((ComboBoxItem)comboRepDonacionesRh.SelectedItem).Content.ToString();
                string fechaInicio = datePickerFechaInicio.SelectedDate.GetValueOrDefault().ToString();
                string fechaFin = datePickerFechaFin.SelectedDate.GetValueOrDefault().ToString();
                string dni = fieldRepDni.Text;


                switch (filtro)
                {
                    case "Completo":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                    case "Grupo sanguíneo":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            BoldReports.Windows.ReportParameter parameterGS = new BoldReports.Windows.ReportParameter();
                            parameterGS.Name = "GS";
                            parameterGS.Values = new List<string>() { gs };
                            parameters.Add(parameterGS);
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                    case "Factor RH":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            BoldReports.Windows.ReportParameter parameterRH = new BoldReports.Windows.ReportParameter();
                            parameterRH.Name = "RH";
                            parameterRH.Values = new List<string>() { rh };
                            parameters.Add(parameterRH);
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                    case "GS, RH":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            BoldReports.Windows.ReportParameter parameterGS = new BoldReports.Windows.ReportParameter();
                            parameterGS.Name = "GS";
                            parameterGS.Values = new List<string>() { gs };
                            parameters.Add(parameterGS);
                            BoldReports.Windows.ReportParameter parameterRH = new BoldReports.Windows.ReportParameter();
                            parameterRH.Name = "RH";
                            parameterRH.Values = new List<string>() { rh };
                            parameters.Add(parameterRH);
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                    case "Inventario":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                    case "Dni":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            BoldReports.Windows.ReportParameter parameterDni = new BoldReports.Windows.ReportParameter();
                            parameterDni.Name = "DNI";
                            parameterDni.Values = new List<string>() { dni };
                            parameters.Add(parameterDni);
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                    case "Fecha":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            BoldReports.Windows.ReportParameter parameterFechaInicio = new BoldReports.Windows.ReportParameter();
                            parameterFechaInicio.Name = "FechaInicio";
                            parameterFechaInicio.Values = new List<string>() { fechaInicio };
                            parameters.Add(parameterFechaInicio);
                            BoldReports.Windows.ReportParameter parameterFechaFin = new BoldReports.Windows.ReportParameter();
                            parameterFechaFin.Name = "FechaFin";
                            parameterFechaFin.Values = new List<string>() { fechaFin };
                            parameters.Add(parameterFechaFin);
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                    case "Dni, Fecha":
                        this.reportViewer.Reset();
                        this.reportViewer.ReportLoaded += (sen, arg) =>
                        {
                            List<BoldReports.Windows.ReportParameter> parameters = new List<BoldReports.Windows.ReportParameter>();
                            parameters.Add(addLogoParameter());
                            BoldReports.Windows.ReportParameter parameterDni = new BoldReports.Windows.ReportParameter();
                            parameterDni.Name = "DNI";
                            parameterDni.Values = new List<string>() { dni };
                            parameters.Add(parameterDni);
                            BoldReports.Windows.ReportParameter parameterFechaInicio = new BoldReports.Windows.ReportParameter();
                            parameterFechaInicio.Name = "FechaInicio";
                            parameterFechaInicio.Values = new List<string>() { fechaInicio };
                            parameters.Add(parameterFechaInicio);
                            BoldReports.Windows.ReportParameter parameterFechaFin = new BoldReports.Windows.ReportParameter();
                            parameterFechaFin.Name = "FechaFin";
                            parameterFechaFin.Values = new List<string>() { fechaFin };
                            parameters.Add(parameterFechaFin);
                            this.reportViewer.SetParameters(parameters);
                        };
                        break;
                }
                comprobarPathReporte(contenido, filtro);
            }

            this.reportViewer.RefreshReport();
            this.reportViewer.ShowParametersBlock = false;
        }

        private void comboRepContenido_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (tabcontrol.SelectedIndex == 1)
            {
                if (comboRepContenido.SelectedIndex == 0)
                {
                    gridRepDonaciones.Visibility = Visibility.Collapsed;
                    gridRepDonantes.Visibility = Visibility.Visible;
                    Thickness margin = botPDF.Margin;
                    margin.Top = 335;
                    botPDF.Margin = margin;
                }
                if (comboRepContenido.SelectedIndex == 1)
                {
                    gridRepDonaciones.Visibility = Visibility.Visible;
                    gridRepDonantes.Visibility = Visibility.Collapsed;
                    Thickness margin = botPDF.Margin;
                    margin.Top = 457;
                    botPDF.Margin = margin;
                }
            }
        }

        public void comprobarPathReporte(string contenido, string filtro)
        {
            if (contenido.Equals("Donantes"))
            {
                switch (filtro)
                {
                    case "Completo":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donantes\Donantes_Completo.rdl");
                        break;
                    case "Grupo sanguíneo":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donantes\Donantes_GS.rdl");
                        break;
                    case "Factor RH":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donantes\Donantes_RH.rdl");
                        break;
                    case "GS, RH":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donantes\Donantes_GSRH.rdl");
                        break;
                }
            }
            if (contenido.Equals("Donaciones"))
            {
                switch (filtro)
                {
                    case "Completo":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donaciones\Donaciones_Completo.rdl");
                        break;
                    case "Grupo sanguíneo":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donaciones\Donaciones_GS.rdl");
                        break;
                    case "Factor RH":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donaciones\Donaciones_RH.rdl");
                        break;
                    case "GS, RH":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donaciones\Donaciones_GSRH.rdl");
                        break;
                    case "Inventario":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donaciones\Donaciones_Inventario.rdl");
                        break;
                    case "Dni":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donaciones\Donaciones_DNI.rdl");
                        break;
                    case "Fecha":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donaciones\Donaciones_Fecha.rdl");
                        break;
                    case "Dni, Fecha":
                        this.reportViewer.ReportPath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Donaciones\Donaciones_FechaDNI.rdl");
                        break;
                }
            }
        }

        public BoldReports.Windows.ReportParameter addLogoParameter()
        {
            BoldReports.Windows.ReportParameter parameterLogo = new BoldReports.Windows.ReportParameter();
            parameterLogo.Name = "Logo";
            parameterLogo.Values = new List<string>() { System.IO.Path.Combine(Environment.CurrentDirectory, @"Resources\Logo.png") };
            return parameterLogo;
        }

    }
}
