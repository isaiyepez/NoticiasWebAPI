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

        public bool Editar(Noticia updateNoticia) 
        {
            try
            {
                var noticia = noticiasDB.Noticia.FirstOrDefault(x => x.NoticiaID == updateNoticia.NoticiaID);
                noticia.Titulo = updateNoticia.Titulo;
                noticia.Descripcion = updateNoticia.Descripcion;
                noticia.Contenido = updateNoticia.Contenido;
                noticia.Fecha = updateNoticia.Fecha;
                noticia.AutorID = updateNoticia.AutorID;
                noticiasDB.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                
                return false;
            }
        }

        public bool Eliminar(int noticiaID)
        {
            try
            {
                var noticia = noticiasDB.Noticia.FirstOrDefault(x => x.NoticiaID == noticiaID);
                noticiasDB.Noticia.Remove(noticia);
                noticiasDB.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                
                return false;
            }
        }
    }
}
