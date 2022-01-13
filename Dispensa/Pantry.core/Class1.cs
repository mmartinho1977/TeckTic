using Pantry.entities;
using Pantry.dataaccess;
using System;

namespace Pantry.core
{
    public class Categorias
    {

        public static int InsertCategoria(Categoria c)
        {
            int res;
            try
            {
                res = Categorias.InsertCategoria(c);

                return res;

            }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
}
