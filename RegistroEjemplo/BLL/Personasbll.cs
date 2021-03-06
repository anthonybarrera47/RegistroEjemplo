﻿using RegistroEjemplo.BLL;
using RegistroEjemplo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroEjemplo.Entidades
{
    public class PersonasBll
    {
        public static bool Guardar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Personas.Add(persona) != null)
                {
                    db.SaveChanges();
                    paso = true;
                }

                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        //Este es el metodo para modificar en la base de datos
        public static bool Modificar(Personas persona)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                paso = (db.SaveChanges() > 0);
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        //Este es el metodo para eliminar en la base de datos
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Personas.Find(id);
                db.Entry(eliminar).State = System.Data.Entity.EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
                db.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

         //Este es el metodo para buscar en la base de datos
        public static Personas Buscar(int id)
        {
            Contexto db = new Contexto();
            Personas persona = new Personas();
            try
            {
                persona = db.Personas.Find(id);
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return persona;
        }
        
        //Este es el metodo para listar o consultar lo que tenemos en la base de datos
        public static List<Personas> GetList(Expression<Func<Personas, bool>> persona)
        {
            List<Personas> people = new List<Personas>();
            Contexto db = new Contexto();
            try
            {
                people = db.Personas.Where(persona).ToList();
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return people;
        }




    }
}
