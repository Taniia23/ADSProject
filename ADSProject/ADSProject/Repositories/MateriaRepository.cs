using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ADSProject.Repositories
{
    public class MateriaRepository : IMateria
    {
        private List<Materia> lstMateria = new List<Materia>
        {
            new Materia{idMateria = 1, NombreMateria = "Redes"}
        };

        public int ActualizarMateria(int idMateria, Materia materia)
        {
            try
            {
                int indice = lstMateria.FindIndex(tmp => tmp.idMateria == idMateria);

                lstMateria[indice] = materia;

                return idMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int AgregarMateria(Materia materia)
        {
            try
            {
                if (lstMateria.Count > 0)
                {
                    materia.idMateria = lstMateria.Last().idMateria + 1;
                }
                lstMateria.Add(materia);

                return materia.idMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarMateria(int idMateria)
        {
            try
            {
                int indice = lstMateria.FindIndex(tmp => tmp.idMateria == idMateria);

                lstMateria.RemoveAt(indice);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Materia ObtenerMateriaPorID(int idMateria)
        {
            throw new NotImplementedException();
        }

        public Materia ObtenerMateriaPorId(int idMateria)
        {
            try
            {
                Materia materia = lstMateria.FirstOrDefault(tmp => tmp.idMateria == idMateria);

                return materia;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            try
            {
                return lstMateria;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
