﻿using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADSProject.Controllers
{
    [Route("api/carreras/")]
    public class CarrerasController : ControllerBase
    {
        private readonly ICarrera carrera;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public CarrerasController(ICarrera carrera)
        {
            this.carrera = carrera;
        }

        [HttpPost("agregarCarrera")]
        public ActionResult<string> AgregarCarrera([FromBody] Carrera carrera)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                int contador = this.carrera.AgregarCarrera(carrera);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con éxito";
                    pMensajeTecnico = pCodRespuesta + " ||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + " ||" + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        [HttpPut("actualizarCarrera/{idCarrera}")]
        public ActionResult<string> ActualizarCarrera(int idCarrera, [FromBody] Carrera carrera)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.carrera.ActualizarCarrera(idCarrera, carrera);

                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con éxito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        [HttpDelete("eliminarCarrera/{idCarrera}")]
        public ActionResult<string> EliminarCarrera(int idCarrera)
        {
            try
            {
                bool eliminado = this.carrera.EliminarCarrera(idCarrera);

                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con éxito";
                    pMensajeTecnico = pCodRespuesta + " ||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrió un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        [HttpGet("obtenerCarreraPorID/{idCarrera}")]
        public ActionResult<Carrera> ObtenerCarreraPorID(int idCarrera)
        {
            try
            {
                Carrera carrera = this.carrera.ObtenerCarreraPorID(idCarrera);

                if (carrera != null)
                {
                    return Ok(carrera);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontraron datos de la carrera";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;

                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        [HttpGet("obtenerCarreras")]
        public ActionResult<List<Carrera>> ObtenerCarreras()
        {
            try
            {
                List<Carrera> lstCarreras = this.carrera.ObtenerTodasLasCarreras();
                return Ok(lstCarreras);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
