using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IPersonaservice
    {
        IEnumerable<Personas> GetAll();
        Personas Get(int id);
        bool Add(Personas model);
        bool Update(Personas model);
        bool Delete(int id);
    }
    public class Personaservice : IPersonaservice

    {
        private readonly PersonasDbcontext _personasDbcontext;
        public Personaservice(
            PersonasDbcontext personasDbcontext
             )
        {
            _personasDbcontext = personasDbcontext;

        }
        public IEnumerable<Personas> GetAll()
        {
            var result = new List<Personas>();
            try
            {
                result = _personasDbcontext.Personas.ToList();
            }
            catch (Exception)
            {


            }

            return result;
        }
        public Personas Get(int id)
        {
            var result = new Personas();
            try
            {
                result = _personasDbcontext.Personas.Single(x => x.Id == id);
            }
            catch (Exception)
            {


            }

            return result;
        }
        public bool Add(Personas model)
        {
            try
            {
                _personasDbcontext.Add(model);
                _personasDbcontext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
        public bool Update(Personas model)
        {
            try
            {
                var originalModel = _personasDbcontext.Personas.Single(x =>
                 x.Id == model.Id
                );

                originalModel.Nombre = model.Nombre;
                originalModel.Apellido = model.Apellido;


                _personasDbcontext.Update(model);
                _personasDbcontext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                _personasDbcontext.Entry(new Personas { Id = id }).State = EntityState.Deleted; ;
                _personasDbcontext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

    }
}
