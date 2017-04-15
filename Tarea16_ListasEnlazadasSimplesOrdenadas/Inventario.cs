using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea16_ListasEnlazadasSimplesOrdenadas
{
    class Inventario
    {
        private Producto _primero;
        private Producto _ultimo;

        public Inventario()
        {
            _primero = null;
            _ultimo = null;
        }

        public string agregarProductoOrdenado(Producto productoNuevo)
        {
            Producto actual = _primero;
            string mensaje = "Error: El código ya existe.";

            while (actual != null && actual.codigo <= productoNuevo.codigo)
            {
                if (actual.codigo == productoNuevo.codigo)
                    return mensaje;
                else if (actual.siguiente != null && actual.siguiente.codigo > productoNuevo.codigo)
                    break;
                actual = actual.siguiente;
            }

            if (_primero == null)
            {
                _primero = productoNuevo;
                _ultimo = productoNuevo;
            }
            else if (actual == null)
            {
                _ultimo.siguiente = productoNuevo;
                _ultimo = productoNuevo;
            }
            else if (_primero.codigo > productoNuevo.codigo)
            {
                productoNuevo.siguiente = _primero;
                _primero = productoNuevo;
            }
            else
            {
                productoNuevo.siguiente = actual.siguiente;
                actual.siguiente = productoNuevo;
            }
            mensaje = "Producto agregado exitosamente.";
            return mensaje;
        }

        public Producto buscarProducto(int codigoProducto)
        {
            Producto actual = _primero;
            while (actual != null)
            {
                if (actual.codigo == codigoProducto)
                    return actual;
                actual = actual.siguiente;
            }
            return null;
        }

        private Producto _buscarProductoAnterior(int codigoProducto)
        {
            Producto actual = _primero;
            while (actual != null)
            {
                if (actual.siguiente.codigo == codigoProducto)
                    return actual;
                actual = actual.siguiente;
            }
            return null;
        }

        public string borrarProducto(int codigoProducto)
        {
            string mensaje = "Producto no encontrado";
            Producto busquedaProducto = buscarProducto(codigoProducto);
            if (busquedaProducto != null)
            {
                if (busquedaProducto == _primero)
                {
                    _primero = busquedaProducto.siguiente;
                    mensaje = "Producto eliminado";
                }
                else if (busquedaProducto == _ultimo)
                {
                    Producto anteriorUltimo = _buscarProductoAnterior(codigoProducto);
                    anteriorUltimo.siguiente = null;
                    _ultimo = anteriorUltimo;
                    mensaje = "Producto eliminado";
                }
                else
                {
                    _buscarProductoAnterior(codigoProducto).siguiente = busquedaProducto.siguiente;
                    mensaje = "Producto eliminado";
                }

            }
            return mensaje;
        }

        public string reporte()
        {
            string reporte = "";
            Producto actual = _primero;
            while (actual != null)
            {
                reporte += actual.ToString() + Environment.NewLine + "----------------------------" + Environment.NewLine;
                actual = actual.siguiente;
            }
            return reporte;
        }
    }
}
