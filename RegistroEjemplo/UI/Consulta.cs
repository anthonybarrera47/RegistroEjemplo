﻿using RegistroEjemplo.BLL;
using RegistroEjemplo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroEjemplo.UI
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void ConsultaButton_Click(object sender, EventArgs e)
        {
            var listado = new List<Persona>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    
                    case 0://Todo
                        listado = Personasbll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = Personasbll.GetList(p => p.PersonaID == id);
                        break;
                        
                    case 2://Nombre
                        listado = Personasbll.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Cedula
                        listado = Personasbll.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;
                    case 4://Telefono
                        listado = Personasbll.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));
                        break;
                    case 5://Direccion
                        listado = Personasbll.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));
                        break;
                }

                listado = listado.Where(c => c.FechaNacimiento.Date >= DesdeDateTimePicker.Value.Date && c.FechaNacimiento.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = Personasbll.GetList(p => true);
            }


            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
