using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NoticiasWebAPI.Models;

namespace NoticiasWebAPI.Services
{
    public class NoticiaServices
    {
        public readonly NoticiasDBContext noticiasDB;

        public NoticiaServices(NoticiasDBContext noticiasDBContext)
        {
            noticiasDB = noticiasDBContext;
        }

        public List<Noticia> VerListadoNoticias()
        {
            return noticiasDB.Noticia.Include(x => x.Autor).OrderByDescending(x => x.NoticiaID).ToList();
        }

        public bool Agregar(Noticia newNoticia)
        {
            try
            {
                noticiasDB.Noticia.Add(newNoticia);
                noticiasDB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
