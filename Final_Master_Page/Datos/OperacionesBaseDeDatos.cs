using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Final_Master_Page.Datos {
    public class OperacionesBaseDeDatos {
        unlamEntities alumnosEntities = new unlamEntities();

        public int crearEstudiante(Estudiante student) {
            unlamEntities alumnosEntities = new unlamEntities();

            alumnosEntities.Estudiante.Add(student);
            try {
                return alumnosEntities.SaveChanges();
            } catch (DbEntityValidationException exp) {
                foreach (var eve in exp.EntityValidationErrors) {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors) {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public int actualizarEstudiante(Estudiante estudiante) {
            Estudiante estudianteEncontrado = obtenerEstudiantePorId(estudiante.Id);

            Usuario usuarioEncontrado = obtenerUsuarioPorId(estudianteEncontrado.userid);

            if (estudiante != null) {
                estudianteEncontrado.name = estudiante.name;
                estudianteEncontrado.lastname = estudiante.lastname;

                if (estudianteEncontrado.Usuario.username != estudiante.Usuario.username) {
                    if (obtenerUsuarioPorMail(estudiante.Usuario.username).Count > 0) {
                        return 2;
                    }
                    usuarioEncontrado.username = estudiante.Usuario.username;

                } else if (estudianteEncontrado.Usuario.password != estudiante.Usuario.password) {
                    usuarioEncontrado.password = estudiante.Usuario.password;
                }

                estudianteEncontrado.Usuario = usuarioEncontrado;
                estudianteEncontrado.address = estudiante.address;
                estudianteEncontrado.phone = estudiante.phone;
                estudianteEncontrado.birthdate = estudiante.birthdate;
                estudianteEncontrado.docnumber = estudiante.docnumber;
                estudianteEncontrado.doctype = estudiante.doctype;
                estudianteEncontrado.subjectQuantity = estudiante.subjectQuantity;
                estudianteEncontrado.numberFile = estudiante.numberFile;

                try {
                    return alumnosEntities.SaveChanges();
                } catch (DbEntityValidationException exp) {
                    foreach (var eve in exp.EntityValidationErrors) {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors) {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                }
            }
            return 0;
        }

        public Estudiante obtenerEstudiantePorId(int id) {
            return (from estudiante in alumnosEntities.Estudiante.Include("Usuario").Include("Documento_Tipo")
                    where estudiante.Id == id
                    select estudiante).First();
        }

        public Usuario obtenerUsuarioPorId(int id) {
            return (from usuario in alumnosEntities.Usuario
                    where usuario.id == id
                    select usuario).First();
        }

        public List<Usuario> obtenerUsuarioPorMail(String userName) {
            return (from usuario in alumnosEntities.Usuario
                    where usuario.username == userName
                    select usuario).ToList();
        }

        public int eliminarEstudiante(int id) {
            unlamEntities alumnosEntities = new unlamEntities();
            Estudiante estudiante = alumnosEntities.Estudiante.Find(id);
            int userId = estudiante.userid;

            Usuario usuario = alumnosEntities.Usuario.Find(userId);

            alumnosEntities.Usuario.Remove(usuario);
            alumnosEntities.Estudiante.Remove(estudiante);

            return alumnosEntities.SaveChanges();
        }

        public List<Estudiante> obtenerTodosLosestudiantes() {
            try {
                return alumnosEntities.Estudiante.ToList();
            } catch (Exception e) {
                Console.WriteLine($"error obtenerTodosLosestudiantes: {e}");
                throw;
            }
        }

        public List<Documento_Tipo> obtenerTodosLosTipoDoc() {
            try {
                return alumnosEntities.Documento_Tipo.ToList();
            } catch (Exception e) {
                Console.WriteLine($"error obtenerTodosLosTipoDoc: {e}");
                throw;
            }
        }

        public List<Usuario> obtenerTodosLosUsuarios() {
            try {
                return alumnosEntities.Usuario.ToList();
            } catch (Exception e) {
                Console.WriteLine($"error obtenerTodosLosUsuarios: {e}");
                throw;
            }
        }

        public UsuarioLogin obtenerUsuarioLogin(String usuario, String contrasenia) {
            try {
                return (from usuarioLogin in alumnosEntities.UsuarioLogin
                        where usuarioLogin.Usuario == usuario && usuarioLogin.Contrasenia == contrasenia
                        select usuarioLogin).First();
            } catch (Exception e) {
                Console.WriteLine($"error obtenerUsuarioLogin: {e}");
                return null;
            }
        }
    }
}